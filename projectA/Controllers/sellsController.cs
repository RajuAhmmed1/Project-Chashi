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
    public class sellsController : Controller
    {
        private ProjectBEntities db = new ProjectBEntities();
        public ActionResult Index()
        {

            string userID = this.User.Identity.GetUserId();
            IEnumerable<pond> pond = db.ponds.SqlQuery("select * from pond").ToList();
            IEnumerable<fish> fish = db.fish.SqlQuery("select * from fish").ToList();
            IEnumerable<sell> sell = db.sells.SqlQuery("select * from sell").ToList();

            var ab = from sl in sell
                     where sl.user_id == userID
                     join
                     pl in pond on sl.pond_id equals pl.pond_id into bc
                     from pl in bc.DefaultIfEmpty()
                     join
                     fs in fish on sl.fish_id equals fs.fhis_id into cd
                     from fs in cd.DefaultIfEmpty()
                     select new fish_set_viewmodel
                     {
                         fishvm = fs,
                         pondvm = pl,
                         sellvm = sl
                     };

            return View(ab);
        }

        // GET: sells/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sell sell = db.sells.Find(id);
            if (sell == null)
            {
                return HttpNotFound();
            }
            return View(sell);
        }

        // GET: sells/Create
        public ActionResult Create()
        {
            string userId = User.Identity.GetUserId();
            AspNetUser auser = db.AspNetUsers.Where(model => model.Id == userId).FirstOrDefault();
            //gets pond
            var ab = from pl in db.ponds
                     where pl.user_id == auser.Id
                     select pl;
            ViewBag.pondlist = new SelectList(ab,"pond_id","pond_name");
            //gets fish
            //var bc = from fs in db.fish
            //         where fs.user_id == auser.Id
            //         select fs;
            //ViewBag.fishlist = new SelectList(bc,"fhis_id","fish_name");
            IEnumerable<sell> sell = db.sells.SqlQuery("select * from sell").ToList();
            IEnumerable<fish> fish = db.fish.SqlQuery("select * from fish").ToList();
            ////var bc = from sl in sell
            ////         where sl.user_id == userId
            ////         join
            ////         fs in fish on sl.fish_id equals fs.fhis_id into cd
            ////         from fs in cd.DefaultIfEmpty()
            ////         select new fish_set_viewmodel
            ////         {
            ////             fishvm = fs,
            ////             sellvm = sl
            ////         };
            //var bc = new fish_set_viewmodel();
            //var a = bc.sellvm;
            //var b = bc.fishvm;
            return View();
        }
        public JsonResult GetStateList(int? pond_id)
        {
            string userId = User.Identity.GetUserId();
            IEnumerable<fish> fl = db.fish.SqlQuery("select * from fish").ToList();
            IEnumerable<pond> pl = db.ponds.SqlQuery("select * from pond").ToList();
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable<fish_set> fishlist = db.fish_set.SqlQuery("select * from fish_set").ToList();
            IEnumerable<sell> sell = db.sells.SqlQuery("select * from sell").ToList();
            var ab = from fs in fishlist
                     where fs.user_id == userId
                     where fs.pond_id == pond_id
                     group fs by fs.fish_id into g
                     select new fish_set
                     {
                         fish_id = g.Key
                     };
            var cd = from abc in ab
                     join fll in fl on abc.fish_id equals fll.fhis_id into g
                     from fll in g.DefaultIfEmpty()

                     select new fish_set_viewmodel
                     {
                         fishvm = fll,
                         fish_setvm = abc
                     };
            //ViewBag.fishlist = cd;


            return Json(cd,JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sell_id,pond_id,fish_id,client_name,sell_location,fish_quantity,fish_weight,fish_price,date,user_id")] sell sell)
        {
          
           
            if (User.Identity.IsAuthenticated)
            {
                string userId = User.Identity.GetUserId();
                AspNetUser auser = db.AspNetUsers.Where(model => model.Id == userId).FirstOrDefault();
                if (ModelState.IsValid)
                {
                    sell.user_id = auser.Id;
                    db.sells.Add(sell);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
             }

            return View();
        }

        // GET: sells/Edit/5
        public ActionResult Edit(int? id)
        {
            string userId = User.Identity.GetUserId();
            AspNetUser auser = db.AspNetUsers.Where(model => model.Id == userId).FirstOrDefault();
            //gets pond
            var ab = from pl in db.ponds
                     where pl.user_id == auser.Id
                     select pl;
            ViewBag.pondlist = new SelectList(ab, "pond_id", "pond_name");
            //gets fish
            //var bc = from fs in db.fish
            //         where fs.user_id == auser.Id
            //         select fs;
            //ViewBag.fishlist = new SelectList(bc, "fhis_id", "fish_name");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sell sell = db.sells.Find(id);
            if (sell == null)
            {
                return HttpNotFound();
            }
            return View(sell);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sell_id,pond_id,fish_id,client_name,sell_location,fish_quantity,fish_weight,fish_price,date,user_id")] sell sell)
        {
            string userId = User.Identity.GetUserId();
    
            if (ModelState.IsValid)
            {
                sell.user_id = userId;
                db.Entry(sell).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sell);
        }

        // GET: sells/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sell sell = db.sells.Find(id);
            if (sell == null)
            {
                return HttpNotFound();
            }
            return View(sell);
        }

        // POST: sells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sell sell = db.sells.Find(id);
            db.sells.Remove(sell);
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
