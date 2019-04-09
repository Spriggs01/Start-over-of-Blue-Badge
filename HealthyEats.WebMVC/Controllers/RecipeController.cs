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
    public class RecipeController : Controller
    {
        // GET: Reipe
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeService(userId);
            var model = service.GetRecipe();
            return View(model);
        }

        // GET: Reipe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reipe/Create
        public ActionResult Create()
        {
            return View();
        
        }

        // POST: Reipe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeCreate recipe)
        {
            if (!ModelState.IsValid) return View(recipe);

            var service = RecipeService();

            if (service.CreateRecipe(recipe))

            {
                TempData["SaveResult"] = "MMMMM, that's a TASTY Recipe!NOM NOM NOM";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Lame! Not you, this app...Well?.. No Recipe was created. Don't Give up!");


            return View(recipe);

            


        }

        public RecipeService RecipeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeService(userId);
            return service;
        }

        // GET: Reipe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reipe/Edit/5
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

        // GET: Reipe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reipe/Delete/5
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
