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
    public class additional_costController : Controller
    {
        private ProjectBEntities db = new ProjectBEntities();

        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var ab = from addi_cost in db.additional_cost
                     where addi_cost.user_id == userId
                     join pl in db.ponds on addi_cost.pond_id equals pl.pond_id into bc
                     from pl in bc.DefaultIfEmpty()
                     select new fish_set_viewmodel
                     {
                         addivm = addi_cost,
                         pondvm = pl
                     };
            return View(ab);
        }

        // GET: additional_cost/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            additional_cost additional_cost = db.additional_cost.Find(id);
            if (additional_cost == null)
            {
                return HttpNotFound();
            }
            return View(additional_cost);
        }

        // GET: additional_cost/Create
        public ActionResult Create()
          {
            string userId = User.Identity.GetUserId();
            AspNetUser auser = db.AspNetUsers.Where(model => model.Id == userId).FirstOrDefault();
            //gets pond
            var ab = from pl in db.ponds
                     where pl.user_id == auser.Id
                     select pl;
            ViewBag.pondlist = new SelectList(ab, "pond_id", "pond_name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "addi_cost_id,pond_id,additional_cost_p,additional_cost_name,user_id,date")] additional_cost additional_cost)
        {
            if (User.Identity.IsAuthenticated)
            {
                string userId = User.Identity.GetUserId();
                AspNetUser auser = db.AspNetUsers.Where(model => model.Id == userId).FirstOrDefault();
                //if (additional_cost.pond_id == null)
                //{
                //    var a = "this field is required";
                //    ViewBag.error = a;
                //}
                if (ModelState.IsValid)
                {
                   
                    additional_cost.user_id = auser.Id;
                    db.additional_cost.Add(additional_cost);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(additional_cost);
        }

        // GET: additional_cost/Edit/5
        public ActionResult Edit(int? id)
        {
            string userId = User.Identity.GetUserId();
            AspNetUser auser = db.AspNetUsers.Where(model => model.Id == userId).FirstOrDefault();
            //gets pond
            var ab = from pl in db.ponds
                     where pl.user_id == auser.Id
                     select pl;
            ViewBag.pondlist = new SelectList(ab, "pond_id", "pond_name");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            additional_cost additional_cost = db.additional_cost.Find(id);
            if (additional_cost == null)
            {
                return HttpNotFound();
            }
            return View(additional_cost);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "addi_cost_id,pond_id,additional_cost_p,additional_cost_name,user_id,date")] additional_cost additional_cost)
        {
            string userId = User.Identity.GetUserId();
            AspNetUser auser = db.AspNetUsers.Where(model => model.Id == userId).FirstOrDefault();
            if (ModelState.IsValid)
            {
                additional_cost.user_id = auser.Id;
                db.Entry(additional_cost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(additional_cost);
        }

        // GET: additional_cost/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            additional_cost additional_cost = db.additional_cost.Find(id);
            if (additional_cost == null)
            {
                return HttpNotFound();
            }
            return View(additional_cost);
        }

        // POST: additional_cost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            additional_cost additional_cost = db.additional_cost.Find(id);
            db.additional_cost.Remove(additional_cost);
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
