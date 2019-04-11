using HealthyEats.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthyEats.WebMVC.Controllers
{
    public class YummyFoodController : Controller
    {
        // GET: YummyFood
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new YummyFoodService(userID);
            var model = service.GetYummyFoods();

            return View(model);
        }

        // GET: YummyFood/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: YummyFood/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YummyFood/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: YummyFood/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: YummyFood/Edit/5
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

        // GET: YummyFood/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: YummyFood/Delete/5
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
