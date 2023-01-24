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
    public class fishController : Controller
    {
        private ProjectBEntities db = new ProjectBEntities();

        // GET: fish
        public ActionResult Index()
        {
            string user= User.Identity.GetUserId();
            AspNetUser auser = db.AspNetUsers.Where(a => a.Id == user).FirstOrDefault();
            IEnumerable<fish> fish = db.fish.SqlQuery("select * from fish").ToList();
            var fishlist = from fs in fish
                           where fs.user_id == auser.Id
                           select fs;
            return View(fishlist);
        }

        // GET: fish/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fish fish = db.fish.Find(id);
            if (fish == null)
            {
                return HttpNotFound();
            }
            return View(fish);
        }

        // GET: fish/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fhis_id,fish_name,user_id")] fish fish)
        {
            if (User.Identity.IsAuthenticated)
            {
                Session["user_id"] = User.Identity.GetUserId();
                var abb = Session["user_id"].ToString();
                var ab = db.AspNetUsers.Where(a => a.Id == abb).FirstOrDefault();
                if (ModelState.IsValid)
                {
                    fish.user_id = ab.Id;
                    db.fish.Add(fish);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(fish);
        }

        // GET: fish/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fish fish = db.fish.Find(id);
            if (fish == null)
            {
                return HttpNotFound();
            }
            return View(fish);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fhis_id,fish_name,user_id")] fish fish)
        {
            string userId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                fish.user_id = userId;
                db.Entry(fish).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fish);
        }

        // GET: fish/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fish fish = db.fish.Find(id);
            if (fish == null)
            {
                return HttpNotFound();
            }
            return View(fish);
        }

        // POST: fish/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fish fish = db.fish.Find(id);
            db.fish.Remove(fish);
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
