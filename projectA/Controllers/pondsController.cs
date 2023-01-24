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

namespace projectA.Controllers
{
    [Authorize]
    public class pondsController : Controller
    {
        private ProjectBEntities db = new ProjectBEntities();

        // GET: ponds
        public ActionResult Index()
        {
            AspNetUser ap = new AspNetUser();
            Session["user_id"] = User.Identity.GetUserId();
            var aa = Session["user_id"];

            var pd = from a in db.ponds
                     where aa.ToString() == a.user_id
                     select a;
            return View(pd);
        }

        // GET: ponds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pond pond = db.ponds.Find(id);
            if (pond == null)
            {
                return HttpNotFound();
            }
            return View(pond);
        }

        // GET: ponds/Create
        public ActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pond_id,pond_name,pond_size,pond_location,date,user_id")] pond pond)
        {
            AspNetUser ap = new AspNetUser();
            Session["user_id"] = User.Identity.GetUserId();
            var aa = Session["user_id"];
            var dd = db.AspNetUsers.Where(a => a.Id == aa.ToString()).FirstOrDefault();
  
                if (ModelState.IsValid)
                {
                   pond.user_id = dd.Id;
                    db.ponds.Add(pond);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            
            return View(pond);
        }

        // GET: ponds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pond pond = db.ponds.Find(id);
            if (pond == null)
            {
                return HttpNotFound();
            }
            return View(pond);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pond_id,pond_name,pond_size,pond_location,date,user_id")] pond pond)
        {
            string userId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                pond.user_id = userId;
                db.Entry(pond).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pond);
        }

        // GET: ponds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pond pond = db.ponds.Find(id);
            if (pond == null)
            {
                return HttpNotFound();
            }
             db.ponds.Remove(pond);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //// POST: ponds/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    pond pond = db.ponds.Find(id);
        //    db.ponds.Remove(pond);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
