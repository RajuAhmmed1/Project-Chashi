using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projectA;
using Microsoft.AspNet.Identity;
using projectA.Models;

namespace projectA.Controllers
{
    [Authorize]
    public class foodsController : Controller
    {
       
        private ProjectBEntities db = new ProjectBEntities(); 
        // GET: foods
        public ActionResult Index()
        {
            string user = User.Identity.GetUserId();
            var ab = from food in db.foods
                     where food.user_id == user
                     select food;
            return View(ab);
        }

        // GET: foods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            food food = db.foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // GET: foods/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "food_id,food_name,user_id")] food food)
        {
            if (User.Identity.IsAuthenticated)
            {
                string user = User.Identity.GetUserId();
                AspNetUser auser = db.AspNetUsers.Where(a => a.Id == user).FirstOrDefault();

                if (ModelState.IsValid)
                {
                    food.user_id = auser.Id;
                    db.foods.Add(food);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(food);
        }

        // GET: foods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            food food = db.foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "food_id,food_name,user_id")] food food)
        {
            string userId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                food.user_id = userId;
                db.Entry(food).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(food);
        }

        // GET: foods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            food food = db.foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // POST: foods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            food food = db.foods.Find(id);
            db.foods.Remove(food);
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
