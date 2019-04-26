using HealthyEats.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HealthyEats.WebAPI.Controllers
{
    [Authorize]
    public class HealthyEatsController : ApiController
    {
        public IHttpActionResult Get()
        {
            MealService mealService = CreateMealService();
            var meals = mealService.GetMeal();
            return Ok(meals);
        }
        private MealService CreateMealService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var mealService = new MealService(userId);
            return mealService;
        }
    }
}
