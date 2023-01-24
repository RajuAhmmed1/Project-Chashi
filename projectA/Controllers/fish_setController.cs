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
    public class fish_setController : Controller
    {
        private ProjectBEntities db = new ProjectBEntities();

        // GET: fish_set
        public ActionResult Index()
        {
     
           
            string userID = this.User.Identity.GetUserId();
            IEnumerable<pond> pond = db.ponds.SqlQuery("select * from pond").ToList();
            IEnumerable<fish> fish = db.fish.SqlQuery("select * from fish").ToList();
            IEnumerable<fish_set> fish_set = db.fish_set.SqlQuery("select * from fish_set").ToList();
            ViewBag.tsf = fish_set;
            var ab = from fishset in fish_set
                     where fishset.user_id == userID
                     join
                     pl in pond on fishset.pond_id equals pl.pond_id into bc
                     from pl in bc.DefaultIfEmpty()
                     join
                     fs in fish on fishset.fish_id equals fs.fhis_id into cd
                     from fs in cd.DefaultIfEmpty()
                     select new fish_set_viewmodel
                     {
                         fishvm = fs,
                         pondvm = pl,
                         fish_setvm = fishset
                     };
            
            return View(ab);
        }

        // GET: fish_set/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fish_set fish_set = db.fish_set.Find(id);
            if (fish_set == null)
            {
                return HttpNotFound();
            }
            return View(fish_set);
        }

        // GET: fish_set/Create
        public ActionResult Create()
        {
            string userId = User.Identity.GetUserId();
            AspNetUser auser = db.AspNetUsers.Where(model => model.Id == userId).FirstOrDefault();
            //gets pond
            var ab = from pl in db.ponds
                     where pl.user_id == auser.Id
                     select pl;
            ViewBag.pondlist =new SelectList(ab,"pond_id","pond_name");

            //gets fish
            var bc = from fs in db.fish
                     where fs.user_id == auser.Id
                     select fs;
            ViewBag.fishlist = new SelectList(bc, "fhis_id", "fish_name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fish_set_id,pond_id,fish_id,fish_quantity,fish_contributore_name,fish_price,date,user_id,fish_weight")] fish_set fish_set)
        {
            if (User.Identity.IsAuthenticated)
            {
                string userId = User.Identity.GetUserId();
                AspNetUser auser = db.AspNetUsers.Where(model => model.Id == userId).FirstOrDefault();

                if (ModelState.IsValid)
                {
                    fish_set.user_id = auser.Id;
                    db.fish_set.Add(fish_set);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(fish_set);
        }

        // GET: fish_set/Edit/5
        public ActionResult Edit(int? id)
        {
            string userId = User.Identity.GetUserId();
            AspNetUser auser = db.AspNetUsers.Where(model => model.Id == userId).FirstOrDefault();
            //get pond
            var ab = from pl in db.ponds
                     where pl.user_id == auser.Id
                     select pl;
            ViewBag.pondlist = new SelectList(ab, "pond_id", "pond_name");

            //gets fish
            var bc = from fs in db.fish
                     where fs.user_id == auser.Id
                     select fs;
            ViewBag.fishlist = new SelectList(bc, "fhis_id", "fish_name");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fish_set fish_set = db.fish_set.Find(id);
            if (fish_set == null)
            {
                return HttpNotFound();
            }
            return View(fish_set);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fish_set_id,pond_id,fish_id,fish_quantity,fish_contributore_name,fish_price,date,user_id,fish_weight")] fish_set fish_set)
        {
            string userId = User.Identity.GetUserId();
            AspNetUser auser = db.AspNetUsers.Where(model => model.Id == userId).FirstOrDefault();
            if (ModelState.IsValid)
            {
                fish_set.user_id = auser.Id;
                db.Entry(fish_set).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fish_set);
        }

        // GET: fish_set/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fish_set fish_set = db.fish_set.Find(id);
            if (fish_set == null)
            {
                return HttpNotFound();
            }
            return View(fish_set);
        }

        // POST: fish_set/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fish_set fish_set = db.fish_set.Find(id);
            db.fish_set.Remove(fish_set);
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
