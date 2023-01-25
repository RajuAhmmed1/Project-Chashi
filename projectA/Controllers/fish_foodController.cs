using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projectA;
using projectA.Models;
using Microsoft.AspNet.Identity;

namespace projectA.Controllers
{
    [Authorize]
    public class fish_foodController : Controller
    {
        private ProjectBEntities db = new ProjectBEntities();

        // GET: fish_food
      
        public ActionResult Index()
        {
            IEnumerable<pond> pond = db.ponds.SqlQuery("select * from pond").ToList();
            IEnumerable<food> food = db.foods.SqlQuery("select * from food").ToList();
            IEnumerable<fish_food> fish_food = db.fish_food.SqlQuery("select * from fish_food").ToList();
            string userID = this.User.Identity.GetUserId();
            var ab = from ffd in fish_food
                     where ffd.user_id.ToString() == userID
                     join pl in pond on ffd.pond_id equals pl.pond_id into bc
                     from pl in bc.DefaultIfEmpty()
                     join fl in food on ffd.food_id equals fl.food_id into cd
                     from fl in cd.DefaultIfEmpty()
                     select new fish_set_viewmodel
                     {
                         pondvm = pl,
                         foodvm=fl,
                         fish_foodvm=ffd
                     };
           
            return View(ab);
        }

        // GET: fish_food/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fish_food fish_food = db.fish_food.Find(id);
            if (fish_food == null)
            {
                return HttpNotFound();
            }
            return View(fish_food);
        }

        // GET: fish_food/Create
        public ActionResult Create()
        {
            string userId = User.Identity.GetUserId();
            AspNetUser auser = db.AspNetUsers.Where(model => model.Id == userId).FirstOrDefault();
            //get pond
            var ab = from pl in db.ponds
                     where pl.user_id == auser.Id
                     select pl;
            ViewBag.pondlist =new SelectList(ab,"pond_id","pond_name");

            //get fish
            var bc = from fl in db.foods
                     where fl.user_id == auser.Id
                     select fl;
            ViewBag.foodlist = new SelectList(bc,"food_id","food_name");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fish_food_id,food_name,food_price,food_quantity,food_company_name,pond_id,user_id,date,food_id")] fish_food fish_food)
        {
            if (User.Identity.IsAuthenticated)
            {
                string userId = User.Identity.GetUserId();
                AspNetUser auser = db.AspNetUsers.Where(model => model.Id == userId).FirstOrDefault();
                if (ModelState.IsValid)
                {
                    fish_food.user_id = auser.Id;
                    db.fish_food.Add(fish_food);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(fish_food);
        }

        // GET: fish_food/Edit/5
        public ActionResult Edit(int? id)
        {
            string userId = User.Identity.GetUserId();
            AspNetUser auser = db.AspNetUsers.Where(model => model.Id == userId).FirstOrDefault();
            //get pond
            var ab = from pl in db.ponds
                     where pl.user_id == auser.Id
                     select pl;
            ViewBag.pondlist = new SelectList(ab, "pond_id", "pond_name");

            //get fish
            var bc = from fl in db.foods
                     where fl.user_id == auser.Id
                     select fl;
            ViewBag.foodlist = new SelectList(bc, "food_id", "food_name");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fish_food fish_food = db.fish_food.Find(id);
            if (fish_food == null)
            {
                return HttpNotFound();
            }
            return View(fish_food);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fish_food_id,food_name,food_price,food_quantity,food_company_name,pond_id,user_id,date,food_id")] fish_food fish_food)
        {
            string userId = User.Identity.GetUserId();
            AspNetUser auser = db.AspNetUsers.Where(model => model.Id == userId).FirstOrDefault();
            if (ModelState.IsValid)
            {
                fish_food.user_id = auser.Id;
                db.Entry(fish_food).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fish_food);
        }

        // GET: fish_food/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fish_food fish_food = db.fish_food.Find(id);
            if (fish_food == null)
            {
                return HttpNotFound();
            }
            return View(fish_food);
        }

        // POST: fish_food/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fish_food fish_food = db.fish_food.Find(id);
            db.fish_food.Remove(fish_food);
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
