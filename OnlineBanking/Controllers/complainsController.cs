using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineBanking.Models;

namespace OnlineBanking.Controllers
{
    [Authorize]
    public class complainsController : Controller
    {
        private OnlineBankingDBEntities db = new OnlineBankingDBEntities();

        // GET: complains
        public ActionResult Index()
        {
            var complains = db.complains.Include(c => c.customer);
            return View(complains.ToList());
        }

        // GET: complains/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            complain complain = db.complains.Find(id);
            if (complain == null)
            {
                return HttpNotFound();
            }
            return View(complain);
        }

        // GET: complains/Create
        public ActionResult Create()
        {
            ViewBag.Customer_id = new SelectList(db.customers, "Customer_Id", "FirstName");
            return View();
        }

        // POST: complains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Complain_Id,ComplainTo,ComplainFrom,Complain_Subject,DescriptionMsg,Date,Customer_id")] complain complain)
        {
            if (ModelState.IsValid)
            {
                db.complains.Add(complain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_id = new SelectList(db.customers, "Customer_Id", "FirstName", complain.Customer_id);
            return View(complain);
        }

        // GET: complains/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            complain complain = db.complains.Find(id);
            if (complain == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_id = new SelectList(db.customers, "Customer_Id", "FirstName", complain.Customer_id);
            return View(complain);
        }

        // POST: complains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Complain_Id,ComplainTo,ComplainFrom,Complain_Subject,DescriptionMsg,Date,Customer_id")] complain complain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_id = new SelectList(db.customers, "Customer_Id", "FirstName", complain.Customer_id);
            return View(complain);
        }

        // GET: complains/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            complain complain = db.complains.Find(id);
            if (complain == null)
            {
                return HttpNotFound();
            }
            return View(complain);
        }

        // POST: complains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            complain complain = db.complains.Find(id);
            db.complains.Remove(complain);
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
