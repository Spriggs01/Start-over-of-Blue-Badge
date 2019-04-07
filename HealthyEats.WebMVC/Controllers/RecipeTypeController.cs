using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HealthyEats.WebMVC.Data;
using HealtyEats.Models;

namespace HealthyEats.WebMVC.Controllers
{
    public class RecipeTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RecipeType
        public ActionResult Index()
        {
            var model = new RecipeTypeListItem[0];
            return View(db.RecipeTypes.ToList());
        }

        // GET: RecipeType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeType recipeType = db.RecipeTypes.Find(id);
            if (recipeType == null)
            {
                return HttpNotFound();
            }
            return View(recipeType);
        }

        // GET: RecipeType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecipeType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipeTypeID,TypeName,Dietary")] RecipeType recipeType)
        {
            if (ModelState.IsValid)
            {
                db.RecipeTypes.Add(recipeType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipeType);
        }

        // GET: RecipeType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeType recipeType = db.RecipeTypes.Find(id);
            if (recipeType == null)
            {
                return HttpNotFound();
            }
            return View(recipeType);
        }

        // POST: RecipeType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecipeTypeID,TypeName,Dietary")] RecipeType recipeType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipeType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipeType);
        }

        // GET: RecipeType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeType recipeType = db.RecipeTypes.Find(id);
            if (recipeType == null)
            {
                return HttpNotFound();
            }
            return View(recipeType);
        }

        // POST: RecipeType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecipeType recipeType = db.RecipeTypes.Find(id);
            db.RecipeTypes.Remove(recipeType);
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
