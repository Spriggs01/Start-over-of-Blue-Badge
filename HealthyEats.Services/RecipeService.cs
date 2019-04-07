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
        public readonly int _recipeID;

        public RecipeService(int recipeId)
        {
            _recipeID = recipeId;
        }
        public bool CreateRecipe(RecipeCreate model)
        {
            var entity =
                new Recipe()
                {
                    RecipeID = _recipeID,
                    RecipeTitle = model.RecipeTitle,
                    Link = model.Link,
                    Calories = model.Calories,
                    TypeName = model.TypeName,
                    Dietary = model.Dietary,
                    Meals = model.Meals,
                    FavoriteRecipes = model.FavoriteRecipes

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
                    .Where(e => e.RecipeID == _recipeID)
                    .Select(
                        e =>
                        new RecipeListItem
                        {
                            RecipeTitle = e.RecipeTitle,
                            Link = e.Link,
                            Calories = e.Calories,
                            TypeName = e.TypeName,
                            Dietary = e.Dietary,
                            Meals = e.Meals,
                            FavoriteRecipes = e.FavoriteRecipes
                        }
                        );

                return query.ToArray();
            }
        }

    }
}
