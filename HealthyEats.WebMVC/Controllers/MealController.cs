using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HealthyEats.Services;
using HealthyEats.WebMVC.Data;
using HealtyEats.Models;
using Microsoft.AspNet.Identity;

namespace HealthyEats.WebMVC.Controllers
{
    public class MealController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Meal
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MealService(userId);
            var model = service.GetMeals();
            return View(db.Meals.ToList());
        }

        // GET: Meal/Details/5
        public ActionResult Details(int id)
        {
            var svc = CreateMealService();
            var model = svc.GetMealByID(id);

            return View(model);
        }

        // GET: Meal/Create
        public ActionResult Create(MealCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMealService();

            if (service.CreateMeal(model))
            {
                TempData["SaveResult"] = "WOOHOO! Meal Tracking is AWESOME!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "BOOH! Meal was not created. Such a sad moment.");
            {
                return View(model);
            }


        }

        private MealService CreateMealService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new MealService(userID);
            return service;
        }


        // POST: Meal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MealID,UserID,MealName,MealDescription")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                db.Meals.Add(meal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meal);
        }

        // GET: Meal/Edit/5
        public ActionResult RecipeEdit(int id)
        {
            var service = CreateMealService();
            var detail = service.GetMealByID(id);
            var model =
                new MealEdit
                {
                    MealID = detail.MealID,
                    MealName = detail.MealName,
                    MealDescription = detail.MealDescription,
                    Recipes = detail.Recipes
                };
        }

        // POST: Meal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MealID,UserID,MealName,MealDescription")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meal);
        }

        // GET: Meal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // POST: Meal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meal meal = db.Meals.Find(id);
            db.Meals.Remove(meal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
