﻿using HealthyEats.WebMVC.Data;
using HealtyEats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEats.Services
{
    public class MealService
    {
        private readonly Guid _userId;
        public MealService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMeal(MealCreate model)
        {
            var entity =
                new Meal()
                {
                    UserID = _userId,
                    MealName = model.MealName,
                    MealDescription = model.MealDescription,
                    Recipes = model.Recipes
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Meals.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MealListItem> GetMeals()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Meals
                    .Where(e => e.UserID == _userId)
                    .Select(
                        e =>
                        new MealListItem
                        {
                            MealID = e.MealID,
                            MealName = e.MealName,
                            MealDescription = e.MealDescription,
                            Recipes = e.Recipes
                        }
                        );
                return query.ToArray();
            }
        }
    }
}