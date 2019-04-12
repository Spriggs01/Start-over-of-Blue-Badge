using HealthyEats.Services;
using HealtyEats.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthyEats.WebMVC.Controllers
{
    public class MealController : Controller
    {
        //you won't need the view bag in this controller.
        //we can use this as a example for recipecontroller 
        // GET: Meal
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new MealService(userID);
            var model = service.GetMeal();

            return View(model);
        }

        // GET: Meal/Details/5
        public ActionResult Details(int id)
        {
            var svc = CreateMealService();
            var model = svc.GetMealByID(id);
            return View(model);
        }

        // GET: Meal/Create
        public ActionResult Create()
        {
           // var recipeID = Guid.Parse(User.Identity.GetUserId());
            //var recipeService = new RecipeService(recipeID);
            //var recipeList = recipeService.GetRecipeByUserID(recipeID);

            //ViewBag.RecipeID = new SelectList(recipeList, "RecipeID", "RecipeTitle");


            return View();
        }

        // POST: Meal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MealCreate meal)
        {
            if (!ModelState.IsValid) return View(meal);
            var service = CreateMealService();

            if (service.CreateMeal(meal))

            {
                TempData["SaveResult"] = "Woot! Meal Tracking is AWESOME!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Super Lame! Not, you,..Well..No Meal was created. Don't Give up!");

            return View(meal);




        }

        public MealService CreateMealService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MealService(userId);
            return service;
        }

        // GET: Meal/Edit/5
        public ActionResult Edit(int id)
        {
            var service = CreateMealService();
            var detail = service.GetMealByID(id);
            var model =
                new MealEdit
                {
                    MealID = detail.MealID,
                    MealName = detail.MealName,
                    MealDescription = detail.MealDescription
                };
            return View(model);
        }

        // POST: Meal/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MealEdit mealedit)
        {
            if (!ModelState.IsValid)

                return View(mealedit);

            if (mealedit.MealID != id)
            {
                ModelState.AddModelError("", "Sorry Mate, the ID does not match the Meal you are trying to Edit. Don't give up!");
                return View(mealedit);
            }

            var service = CreateMealService();

            if (service.UpdateMeal(mealedit))
            {
                TempData["SaveResult"] = "Only Cool People Edit their Meal Tracker! You Rock!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Lame, not you, this app.. Well?.. No Meal was updated. Don't Give up!");
            return View(mealedit);

        }

        // GET: Meal/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateMealService();
            var model = svc.GetMealByID(id);
            return View(model);
        }

        // POST: Meal/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
 public ActionResult Delete(int id, FormCollection collection)
        {

            var service = CreateMealService();

            service.DeleteMeal(id);

            TempData["SaveResult"] = "YAY! You successfully DESTROYED a meal!";

            return RedirectToAction("Index");

        }
    }
}
