using HealthyEats.WebMVC.Data;
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
                    RecipeID = model.RecipeID,

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
                            Recipe = e.Recipe,
                        }
                        );
                return query.ToArray();
            }
        }

        public MealDetail GetMealByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Meals
                    .Single(e => e.MealID == id && e.UserID == _userId);
                return
                    new MealDetail
                    {
                        MealID = entity.MealID,
                        RecipeID = entity.RecipeID,
                        MealName = entity.MealName,
                        

                    };
            }
        }

        public bool UpdateMeal(MealEdit mealEdit)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Meals
                    .Single(e => e.MealID == mealEdit.MealID && e.UserID == _userId);

                entity.MealID = mealEdit.MealID;
                entity.MealName = mealEdit.MealName;
                entity.MealDescription = mealEdit.MealDescription;
                

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
