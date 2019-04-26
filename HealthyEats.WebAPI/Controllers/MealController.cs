using HealthyEats.Services;
using HealtyEats.Models;
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
    public class MealController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            MealService mealService = CreateMealService();
            var meal = mealService.GetMeal();
            return Ok(meal);
        }
        public IHttpActionResult Get(int id)
        {
            MealService mealService = CreateMealService();
            var meal = mealService.GetMealByID(id);
            return Ok(meal);
        }
        public IHttpActionResult Post(MealCreate meal)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMealService();

            if (!service.CreateMeal(meal))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(MealEdit meal)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMealService();

            if (!service.UpdateMeal(meal))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateMealService();

            if (!service.DeleteMeal(id))
                return InternalServerError();

            return Ok();
        }
       private MealService CreateMealService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var mealService = new MealService(userId);
            return mealService;
        }

    }
   
}
