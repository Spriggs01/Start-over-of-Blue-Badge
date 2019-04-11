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
    public class YummyFoodService
    {
        private readonly Guid _userID;
        public YummyFoodService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateYummyFood(YummyFoodCreate yummyFoodcreate)
        {
            var entity =
                new YummyFood()
                {
                    UserID = _userID,
                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.YummyFoods.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<YummyFoodListItem> GetYummyFoods()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .YummyFoods
                    .Where(e => e.UserID == _userID)
                    .Select(
                        e =>
                        new YummyFoodListItem
                        {
                            MealID = e.MealID,
                            RecipeID = e.RecipeID,
                        }
                        );
                return query.ToArray();
            }
        }

        public YummyFoodDetail GetYummyFoodByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .YummyFoods
                    .Single(e => e.UserID == _userID);

                return
                    new YummyFoodDetail
                    {
                        MealID = entity.MealID,
                        RecipeID = entity.RecipeID,

                    };

            }
        }

        public bool UpdateYummyFood(YummyFoodEdit yummyfoodedit)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .YummyFoods
                    .Single(e => e.UserID == _userID);

                entity.MealID = yummyfoodedit.MealID;
                entity.RecipeID = yummyfoodedit.RecipeID;

                return ctx.SaveChanges() == 1;
            }
        }
            
    }
}
