using HealthyEats.Data;
using HealthyEats.WebMVC.Data;
using HealtyEats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEats.Services
{
    public class RecipeService
    {
        private readonly Guid _userId;
        public RecipeService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateRecipe(RecipeCreate model)
        {
            var entity =
                new Recipe()
                {
                    UserID = _userId,
                    RecipeTitle = model.RecipeTitle,
                    Link = model.Link,
                    Calories = model.Calories,
                    TypeName = model.TypeName,
                    Dietary = model.Dietary,



                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RecipeListItem> GetRecipe()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Recipes
                    .Where(e => e.UserID == _userId)
                    .Select(
                        e =>
                        new RecipeListItem
                        {
                            RecipeID = e.RecipeID,
                            RecipeTitle = e.RecipeTitle,
                            Link = e.Link,
                            Calories = e.Calories,
                            TypeName = e.TypeName,
                            Dietary = e.Dietary,

                        }
                        );

                return query.ToArray();
            }
        }

        public RecipeDetail GetRecipeByID(int recipeID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Recipes
                    .Single(e => e.RecipeID == recipeID && e.UserID == _userId);
                return
                    new RecipeDetail
                    {
                        RecipeID = entity.RecipeID,
                        //MealID = entity.MealID,
                        RecipeTitle = entity.RecipeTitle,
                        Link = entity.Link,
                        TypeName = entity.TypeName,
                        Calories = entity.Calories,
                        Dietary = entity.Dietary,


                    };
            }
        }

        public IEnumerable<RecipeListItem> GetRecipeByUserID(Guid userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Recipes
                    .Where(e => e.UserID == userId)
                    .Select(e => new RecipeListItem
                    {
                        RecipeID = e.RecipeID,
                        RecipeTitle = e.RecipeTitle,
                        Link = e.Link,
                        Calories = e.Calories,
                        TypeName = e.TypeName,
                        Dietary = e.Dietary

                    });
                return query.ToArray();



            }
        }

    }
}



