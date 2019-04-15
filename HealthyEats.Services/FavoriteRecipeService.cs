using HealthyEats.WebMVC.Data;
using HealtyEats.Models;
using HealtyEats.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEats.Services
{
    public class FavoriteRecipeService
    {

        private readonly Guid _userId;

        public FavoriteRecipeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFavoriteRecipe(FavoriteRecipeCreate model)
        {
            var entity =
                new FavoriteRecipe()
                {
                    UserID = _userId,
                    FavoriteList = model.FavoriteList,
                    RecipeID = model.RecipeID



                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.FavoriteRecipes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FavoriteRecipeListItem> GetFavoriteRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .FavoriteRecipes
                    .Where(e => e.UserID == _userId)
                    .Select(
                        e =>
                        new FavoriteRecipeListItem
                        {
                            FavoriteRecipeID = e.FavoriteRecipeID,
                            FavoriteList = e.FavoriteList,
                            RecipeTitle = e.Recipe.RecipeTitle,

                        }
                        );
                return query.ToArray();
            }
        }

        public FavoriteRecipeDetail GetFavoriteRecipeByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FavoriteRecipes
                    .Single(e => e.FavoriteRecipeID == id && e.UserID == _userId);
                return
                    new FavoriteRecipeDetail
                    {
                        FavoriteRecipeID = entity.FavoriteRecipeID,
                        FavoriteList = entity.FavoriteList,
                        RecipeTitle = entity.RecipeTitle,

                    };
            }
        }

        public bool UpdateFavoriteRecipe(FavoriteRecipeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FavoriteRecipes
                    .Single(e => e.FavoriteRecipeID == model.FavoriteRecipeID && e.UserID == _userId);

                entity.FavoriteRecipeID = model.FavoriteRecipeID;
                entity.FavoriteList = model.FavoriteList;
                entity.RecipeTitle = model.RecipeTitle;


                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteFavoriteRecipe(int favoriteRecipeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FavoriteRecipes
                    .Single(e => e.FavoriteRecipeID == favoriteRecipeId && e.UserID == _userId);

                ctx.FavoriteRecipes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<RecipeListItem> GetRecipeByUserID(Guid recipeID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Recipes
                    .Where(e => e.UserID == _userId)
                    .Select(e => new RecipeListItem
                    {
                        RecipeID = e.RecipeID,
                        RecipeTitle = e.RecipeTitle,
                        Link = e.Link,
                        Calories = e.Calories,
                        Dietary = e.Dietary,
                    });
                return query.ToArray();
            }
        }
    }
}


