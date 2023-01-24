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
    public class pond_detailController : Controller
    {
        private ProjectBEntities db = new ProjectBEntities();

        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            IEnumerable<pond> pl = db.ponds.SqlQuery("select * from pond").ToList();
            IEnumerable<sell> sf = db.sells.SqlQuery("select * from sell").ToList();
            IEnumerable<fish_set> fs = db.fish_set.SqlQuery("select * from fish_set").ToList();

            var viewmodel = from pondlist in pl where pondlist.user_id == userId
                            join fss in sf on pondlist.pond_id equals fss.pond_id into a
                            join fishset in fs on pondlist.pond_id equals fishset.pond_id into b
                            select new pond_detail
                            {
                                pond_id=pondlist.pond_id,
                                pond_details_id = pondlist.pond_id,
                                total_avail_fish = b.Sum(m => m.fish_quantity) - a.Sum(m => m.fish_quantity),
                                total_sell_fish = a.Sum(m => m.fish_quantity),
                                total_set_fish = b.Sum(m => m.fish_quantity)
                            };
            var ab = from vm in viewmodel
                     join pondlist in pl on vm.pond_id equals pondlist.pond_id into g
                     from pondlist in g.DefaultIfEmpty()
                     select new fish_set_viewmodel
                     {
                         pondvm = pondlist,
                         pond_detailvm = vm
                     };
            return View(ab);
        }

        // GET: pond_detail/Details/5
        public ActionResult Details(int? id)
        {
            string userId = User.Identity.GetUserId();
            IEnumerable<pond> pondlist = db.ponds.SqlQuery("select * from pond").ToList();
            IEnumerable<fish_set> fs = db.fish_set.SqlQuery("select * from fish_set").ToList();
            IEnumerable<fish> f = db.fish.SqlQuery("select * from fish").ToList();
            IEnumerable<sell> s = db.sells.SqlQuery("select * from sell").ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pond p = db.ponds.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            //get data from set_fish table
            var ab = from setfish in fs
                     where setfish.user_id == userId
                     where p.pond_id == setfish.pond_id
                     group setfish by setfish.fish_id into g
                     select new set_fish_details
                     {
                         id = g.Key,
                         sfish_quantity = g.Sum(item => item.fish_quantity)
                     };
            var abb = from sl in ab
                      join fishlist in f on sl.id equals fishlist.fhis_id into g
                      from fishlist in g.DefaultIfEmpty()
                      select new fish_set_viewmodel
                      {
                          sfdvm=sl,
                          fishvm=fishlist,
                      };

            //get data from sell table
            var bc = from sellfish in s
                     where sellfish.user_id == userId
                     where p.pond_id == sellfish.pond_id
                     group sellfish by sellfish.fish_id into g
                     select new sell_fish_details
                     {
                         id = g.Key,
                         sfish_quantity = g.Sum(item => item.fish_quantity)
                     };
            var abb1 = from sll in bc
                      join fishlist in f on sll.id equals fishlist.fhis_id into g
                      from fishlist in g.DefaultIfEmpty()
                      select new fish_set_viewmodel
                      {
                          slfdvm = sll,
                          fishvm = fishlist,
                      };

            ViewBag.set_fish = abb;
            ViewBag.sell_fish = abb1;

            var viewmodel = new fish_set_viewmodel();
            var a = viewmodel.sfdvm;
            var b = viewmodel.slfdvm;

            return View(viewmodel);
        }

        // GET: pond_detail/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pond_details_id,pond_id,total_set_fish,total_sell_fish,total_avail_fish,user_id")] pond_detail pond_detail)
        {
            if (ModelState.IsValid)
            {
                db.pond_detail.Add(pond_detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pond_detail);
        }

        // GET: pond_detail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pond_detail pond_detail = db.pond_detail.Find(id);
            if (pond_detail == null)
            {
                return HttpNotFound();
            }
            return View(pond_detail);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pond_details_id,pond_id,total_set_fish,total_sell_fish,total_avail_fish,user_id")] pond_detail pond_detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pond_detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pond_detail);
        }

        // GET: pond_detail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pond_detail pond_detail = db.pond_detail.Find(id);
            if (pond_detail == null)
            {
                return HttpNotFound();
            }
            return View(pond_detail);
        }

        // POST: pond_detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pond_detail pond_detail = db.pond_detail.Find(id);
            db.pond_detail.Remove(pond_detail);
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
