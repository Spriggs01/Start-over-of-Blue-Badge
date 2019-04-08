﻿using HealthyEats.Data;
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
                    .Where(e => e.UserID == _userId)
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
