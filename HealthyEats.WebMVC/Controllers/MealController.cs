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
        // GET: Meal
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new MealService(userID);
            var model = service.GetMeals();

            return View(model);
        }

        // GET: Meal/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Meal/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Meal/Create
        [HttpPost]
        public ActionResult Create(MealCreate meal)
        {
            if (!ModelState.IsValid)
            {
                return View(meal);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MealService(userId);

            service.CreateMeal(meal);

            return RedirectToAction("Index");
        }

        // GET: Meal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Meal/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Meal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Meal/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
