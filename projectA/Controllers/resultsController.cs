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
    public class resultsController : Controller
    {
        private ProjectBEntities db = new ProjectBEntities();

        // GET: results
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            IEnumerable<pond> ponds = db.ponds.SqlQuery("select * from pond").ToList();
            IEnumerable<fish_set> fish_set = db.fish_set.SqlQuery("select * from fish_set").ToList();
            IEnumerable<fish_food> fish_food = db.fish_food.SqlQuery("select * from fish_food").ToList();
            IEnumerable<additional_cost> addi = db.additional_cost.SqlQuery("select * from additional_cost").ToList();
            IEnumerable<sell> sell = db.sells.SqlQuery("select * from sell").ToList();

            var ab = from pl in ponds
                     where pl.user_id == userId
                     join fs in fish_set on pl.pond_id equals fs.pond_id into bc
                     join ff in fish_food on pl.pond_id equals ff.pond_id into cd
                     join ac in addi on pl.pond_id equals ac.pond_id into de
                     join sf in sell on pl.pond_id equals sf.pond_id into ef
                     select new result
                     {
                         pond_id = pl.pond_id,

                         total_cost = bc.Sum(m => m.fish_price) + cd.Sum(m => m.food_price) +
                           de.Sum(m => m.additional_cost_p),

                         total_sell= ef.Sum(m => m.fish_price),

                         profit_amount= ef.Sum(m => m.fish_price) - (bc.Sum(m => m.fish_price) + cd.Sum(m => m.food_price) +
                         de.Sum(m => m.additional_cost_p)),

                         lose_amount = ef.Sum(m => m.fish_price) - (bc.Sum(m => m.fish_price) + cd.Sum(m => m.food_price) +
                         de.Sum(m => m.additional_cost_p)),



                     };

            var result = from final_result in ab
                         join pl in ponds on final_result.pond_id equals pl.pond_id into g
                         from pl in g.DefaultIfEmpty()
                         select new fish_set_viewmodel
                         {
                             resultvm = final_result,
                             pondvm = pl

                         };

            return View(result);
        }

        // GET: results/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            result result = db.results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // GET: results/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "final_result_id,pond_id,total_cost,total_sell,profit_amount,lose_amount,date,user_id")] result result)
        {
            if (ModelState.IsValid)
            {
                db.results.Add(result);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(result);
        }

        // GET: results/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            result result = db.results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // POST: results/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "final_result_id,pond_id,total_cost,total_sell,profit_amount,lose_amount,date,user_id")] result result)
        {
            if (ModelState.IsValid)
            {
                db.Entry(result).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(result);
        }

        // GET: results/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            result result = db.results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // POST: results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            result result = db.results.Find(id);
            db.results.Remove(result);
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
