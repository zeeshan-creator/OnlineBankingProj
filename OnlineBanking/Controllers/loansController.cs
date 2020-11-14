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
    public class loansController : Controller
    {
        private OnlineBankingDBEntities db = new OnlineBankingDBEntities();

        // GET: loans
        public ActionResult Index()
        {
            return View(db.loans.ToList());
        }

        // GET: loans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loan loan = db.loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // GET: loans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: loans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Loan_Id,Customer_Id,Amount,Duration,StartDate,MonthlyInstallment,Month")] loan loan)
        {
            if (ModelState.IsValid)
            {
                db.loans.Add(loan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loan);
        }

        // GET: loans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loan loan = db.loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // POST: loans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Loan_Id,Customer_Id,Amount,Duration,StartDate,MonthlyInstallment,Month")] loan loan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loan);
        }

        // GET: loans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loan loan = db.loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // POST: loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            loan loan = db.loans.Find(id);
            db.loans.Remove(loan);
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
