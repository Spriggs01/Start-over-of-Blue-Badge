using HealthyEats.Services;
using HealtyEats.Models;
using HealtyEats.WebMVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthyEats.WebMVC.Controllers
{
    [Authorize]
    public class FavoriteRecipeController : Controller
    {
        // GET: FavoriteRecipe
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new FavoriteRecipeService(userID);
            var model = service.GetFavoriteRecipes();
            return View(model);
        }

        // GET: FavoriteRecipe/Details/5
        public ActionResult Details(int id)
        {
            var svc = FavoriteRecipeService();
            var favoriteRecipe = svc.GetFavoriteRecipeByID(id);
            return View(favoriteRecipe);


        }


        // GET: FavoriteRecipe/Create
        public ActionResult Create()


        {
            var recipeID = Guid.Parse(User.Identity.GetUserId());
            var recipeService = new RecipeService(recipeID);
            var recipeList = recipeService.GetRecipeByUserID(recipeID);

            ViewBag.RecipeID = new SelectList(recipeList, "RecipeID", "RecipeTitle");


            return View();

        }

        // POST: FavoriteRecipe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FavoriteRecipeCreate favoriteRecipe)
        {
            if (!ModelState.IsValid) return View(favoriteRecipe);

            var service = FavoriteRecipeService();

            if (service.CreateFavoriteRecipe(favoriteRecipe))

            {
                TempData["SaveResult"] = "YAY to Favorite Recipes!!";
                return RedirectToAction("Index");

            };

            ModelState.AddModelError("", "So Sad. No Favorite Recipe Created. Don't Give up!");

            return View(favoriteRecipe);




        }

        public FavoriteRecipeService FavoriteRecipeService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new FavoriteRecipeService(userID);
            return service;
        }

        // GET: FavoriteRecipe/Edit/5
        public ActionResult Edit(int id)
        {
            var service = FavoriteRecipeService();
            var detail = service.GetFavoriteRecipeByID(id);
            var model =
                new FavoriteRecipeEdit
                {
                    FavoriteRecipeID = detail.FavoriteRecipeID,
                    RecipeID = detail.RecipeID,
                    FavoriteList = detail.FavoriteList
                };
            return View(model);
        }

        // POST: FavoriteRecipe/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FavoriteRecipeEdit collection)
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

        // GET: FavoriteRecipe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FavoriteRecipe/Delete/5
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
