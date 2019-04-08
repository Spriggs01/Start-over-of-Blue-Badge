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
    public class FavoriteRecipeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FavoriteRecipe
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FavoriteRecipeService(userId);
            var model = service.GetFavoriteRecipes();
            return View(db.FavoriteRecipes.ToList());
        }

        // GET: FavoriteRecipe/Details/5
        public ActionResult Details(int id)
        {
            var svc = CreateFavoriteRecipeService();
            var model = svc.GetFavoriteRecipeByID(id);

            return View(model);
        }

        // GET: FavoriteRecipe/Create
        public ActionResult Create(FavoriteRecipeCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateFavoriteRecipeService();

            if (service.CreateFavoriteRecipe(model))
            {
                TempData["SaveResult"] = "YAY to Favorite Recipes!!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Such a sad moment! No Favorite Recipe Created");

            return View(model);
        }
        
           

        
        
        

        private FavoriteRecipeService CreateFavoriteRecipeService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new FavoriteRecipeService(userID);
            return service;
        }


        // POST: FavoriteRecipe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FavoriteRecipeID,FavoriteList,UserID")] FavoriteRecipe favoriteRecipe)
        {
            if (ModelState.IsValid)
            {
                db.FavoriteRecipes.Add(favoriteRecipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(favoriteRecipe);
        }

        // GET: FavoriteRecipe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavoriteRecipe favoriteRecipe = db.FavoriteRecipes.Find(id);
            if (favoriteRecipe == null)
            {
                return HttpNotFound();
            }
            return View(favoriteRecipe);
        }

        // POST: FavoriteRecipe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FavoriteRecipeID,FavoriteList,UserID")] FavoriteRecipe favoriteRecipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(favoriteRecipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(favoriteRecipe);
        }

        // GET: FavoriteRecipe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavoriteRecipe favoriteRecipe = db.FavoriteRecipes.Find(id);
            if (favoriteRecipe == null)
            {
                return HttpNotFound();
            }
            return View(favoriteRecipe);
        }

        // POST: FavoriteRecipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FavoriteRecipe favoriteRecipe = db.FavoriteRecipes.Find(id);
            db.FavoriteRecipes.Remove(favoriteRecipe);
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
