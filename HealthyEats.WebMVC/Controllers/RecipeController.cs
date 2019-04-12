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
        // GET: Rceipe
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeService(userId);
            var model = service.GetRecipe();
            return View(model);
        }

        // GET: Recipe/Details/5
      
        public ActionResult Details(int id)
        {
            var svc = RecipeService();
            var model = svc.GetRecipeByID(id);
            return View(model);
        }

        // GET: Recipe/Create
        public ActionResult Create()
        {
            var mealID = Guid.Parse(User.Identity.GetUserId());
            var mealService = new MealService(mealID);
            var mealList = mealService.GetMealByUserID(mealID);

            ViewBag.MealID = new SelectList(mealList, "MealID", "MealName");

            return View();
        
        }

        // POST: Recipe/Create
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
            var service = RecipeService();
            var detail = service.GetRecipeByID(id);
            var model =
                new RecipeEdit
                {
                    
                    RecipeTitle = detail.RecipeTitle,
                    Link = detail.Link,
                    TypeName = detail.TypeName,
                    Dietary = detail.Dietary,
                    Calories = detail.Calories

                };
            return View();
        }

        // POST: Reipe/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RecipeEdit recipeEdit)
        {
            if (!ModelState.IsValid)
                return View(recipeEdit);

            if(recipeEdit.RecipeID != id)
            {
                ModelState.AddModelError("", "OH NO! The ID does not match. Lame.. No Recipe Updated. Don't Give up!");
                return View(recipeEdit);
            }

            var service = RecipeService();

            if (service.UpdateRecipe(recipeEdit))
            {
                TempData["SaveResult"] = "Yay! Look at your bad self editing your Recipe. WOOT!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Lame! Not you, this app.. Well?.. No Recipe was Updated! Cool people NEVER give up!");

            return View(recipeEdit);
           
        }

        // GET: Reipe/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = RecipeService();
            var model = svc.GetRecipeByID(id);
            return View(model);
        }

        // POST: Reipe/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var service = RecipeService();

            service.DeleteRecipe(id);

            TempData["SaveResult"] = "Sometimes you just have to say bye-bye to old recipes!";

            return RedirectToAction("Index");
            
        }
    }
}
