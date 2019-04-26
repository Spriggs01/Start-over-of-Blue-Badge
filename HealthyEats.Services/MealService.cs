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

        //need to remove recipe id from both method and model
        public bool CreateMeal(MealCreate model)
        {
            var entity =
                new Meal()
                {
                    UserID = _userId,
                    MealName = model.MealName,
                    MealDescription = model.MealDescription,
                    //Recipes = model.Recipes,



                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Meals.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MealListItem> GetMeal()
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

                           
                            //Recipes = e.Recipes

                        }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<MealListItem> GetMealByUserID(Guid userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Meals
                    .Where(e => e.UserID == userId)
                    .Select(e => new MealListItem
                    {
                        MealID = e.MealID,
                        MealName = e.MealName,
                        MealDescription = e.MealDescription,
                        //Recipes = e.Recipes

                    });
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
                        MealName = entity.MealName,
                        MealDescription = entity.MealDescription,
                        //Recipes = entity.Recipes

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

            //entity.MealID = mealEdit.MealID;
            entity.MealName = mealEdit.MealName;
            entity.MealDescription = mealEdit.MealDescription;
                //entity.Recipes = mealEdit.Recipes;


            return ctx.SaveChanges() == 1;
        }
    }

    public bool DeleteMeal(int mealId)
    {
          
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                .Meals
                .Single(e => e.MealID == mealId && e.UserID == _userId);

            ctx.Meals.Remove(entity);

            return ctx.SaveChanges() == 1;
        }
    }
}

}
