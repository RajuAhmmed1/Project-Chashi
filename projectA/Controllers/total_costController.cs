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
    public class total_costController : Controller
    {
        private ProjectBEntities db = new ProjectBEntities();

        // GET: total_cost
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            IEnumerable<pond> ponds = db.ponds.SqlQuery("select * from pond").ToList();
            IEnumerable<fish_set> fish_set = db.fish_set.SqlQuery("select * from fish_set").ToList();
            IEnumerable<fish_food> fish_food = db.fish_food.SqlQuery("select * from fish_food").ToList();
            IEnumerable<additional_cost> addi = db.additional_cost.SqlQuery("select * from additional_cost").ToList();
            IEnumerable<total_cost> tc = db.total_cost.SqlQuery("select * from total_cost").ToList();
            var ab = from pl in ponds
                     where pl.user_id == userId
                     join fishset in fish_set on pl.pond_id equals fishset.pond_id into bc 
                     join fishfood in fish_food on pl.pond_id equals fishfood.pond_id into cd
                     join additionalcost in addi on pl.pond_id equals additionalcost.pond_id into ef
                     select new total_cost
                     {

                         pond_id = pl.pond_id,
                         total_fish_cost=bc.Sum(item=>item.fish_price),
                         total_additional_cost = ef.Sum(item => item.additional_cost_p),
                         total_food_cost =cd.Sum(item=>item.food_price),
                         total_cost_p= bc.Sum(item => item.fish_price)+ ef.Sum(item => item.additional_cost_p) + cd.Sum(item => item.food_price)

                     };
            var abb = from tcc in ab
                      join pl in ponds on tcc.pond_id equals pl.pond_id into g
                      from pl in g.DefaultIfEmpty()
                      select new fish_set_viewmodel
                      {
                          tcvm = tcc,
                          pondvm = pl
                      };
            //var final = ab.ToList();
            return View(abb);
        }

        // GET: total_cost/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            total_cost total_cost = db.total_cost.Find(id);
            if (total_cost == null)
            {
                return HttpNotFound();
            }
            return View(total_cost);
        }

        // GET: total_cost/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "total_cost_id,pond_id,total_fish_cost,total_food_cost,total_additional_cost,total_cost1,user_id")] total_cost total_cost)
        {
            if (ModelState.IsValid)
            {
                db.total_cost.Add(total_cost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(total_cost);
        }

        // GET: total_cost/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            total_cost total_cost = db.total_cost.Find(id);
            if (total_cost == null)
            {
                return HttpNotFound();
            }
            return View(total_cost);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "total_cost_id,pond_id,total_fish_cost,total_food_cost,total_additional_cost,total_cost1,user_id")] total_cost total_cost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(total_cost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(total_cost);
        }

        // GET: total_cost/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            total_cost total_cost = db.total_cost.Find(id);
            if (total_cost == null)
            {
                return HttpNotFound();
            }
            return View(total_cost);
        }

        // POST: total_cost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            total_cost total_cost = db.total_cost.Find(id);
            db.total_cost.Remove(total_cost);
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
