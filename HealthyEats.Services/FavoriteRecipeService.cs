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

        private readonly int _favoriteRecipeId; 

        public FavoriteRecipeService(int favoriteRecipeId)
        {
            _favoriteRecipeId = favoriteRecipeId;
        }

        public bool CreateFavoriteRecipe(FavoriteRecipeCreate model)
        {
            var entity =
                new FavoriteRecipe()
                {
                    FavoriteRecipeID = _favoriteRecipeId,
                    FavoriteList = model.FavoriteList,
                    Recipes = model.Recipes
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.FavoriteRecipes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FavoriteRecipeListItem> GetFavoriteRecipe()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .FavoriteRecipes
                    .Where(e => e.FavoriteRecipeID == _favoriteRecipeId)
                    .Select(
                        e =>
                        new FavoriteRecipeListItem
                        {
                            FavoriteRecipeID = e.FavoriteRecipeID,
                            FavoriteList = e.FavoriteList,
                            Recipes = e.Recipes
                        }
                        );
                return query.ToArray();
            }
        }

    }
}
