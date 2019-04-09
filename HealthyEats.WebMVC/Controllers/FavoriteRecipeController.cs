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
            return View();
        }

        // GET: FavoriteRecipe/Create
        public ActionResult Create()
        {
            return View();
        
        }

        // POST: FavoriteRecipe/Create
        [HttpPost]
        public ActionResult Create(FavoriteRecipeCreate favoriteRecipe)
        {
            if (!ModelState.IsValid)
            {
                return View(favoriteRecipe);
            }
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new FavoriteRecipeService(userID);

            service.CreateFavoriteRecipe(favoriteRecipe);

            return RedirectToAction("Index");


        }

        // GET: FavoriteRecipe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FavoriteRecipe/Edit/5
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
