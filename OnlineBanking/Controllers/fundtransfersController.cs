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
    public class fundtransfersController : Controller
    {
        private OnlineBankingDBEntities db = new OnlineBankingDBEntities();

        // GET: fundtransfers
        public ActionResult Index()
        {
            var fundtransfers = db.fundtransfers.Include(f => f.customer);
            return View(fundtransfers.ToList());
        }

        // GET: fundtransfers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fundtransfer fundtransfer = db.fundtransfers.Find(id);
            if (fundtransfer == null)
            {
                return HttpNotFound();
            }
            return View(fundtransfer);
        }

        // GET: fundtransfers/Create
        public ActionResult Create()
        {
            ViewBag.CustumerId = new SelectList(db.customers, "Customer_Id", "FirstName");
            return View();
        }

        // POST: fundtransfers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FundTransferId,Debit_Amount,Credit_Amount,date,CustumerId")] fundtransfer fundtransfer)
        {
            if (ModelState.IsValid)
            {
                db.fundtransfers.Add(fundtransfer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustumerId = new SelectList(db.customers, "Customer_Id", "FirstName", fundtransfer.CustumerId);
            return View(fundtransfer);
        }

        // GET: fundtransfers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fundtransfer fundtransfer = db.fundtransfers.Find(id);
            if (fundtransfer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustumerId = new SelectList(db.customers, "Customer_Id", "FirstName", fundtransfer.CustumerId);
            return View(fundtransfer);
        }

        // POST: fundtransfers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FundTransferId,Debit_Amount,Credit_Amount,date,CustumerId")] fundtransfer fundtransfer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fundtransfer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustumerId = new SelectList(db.customers, "Customer_Id", "FirstName", fundtransfer.CustumerId);
            return View(fundtransfer);
        }

        // GET: fundtransfers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fundtransfer fundtransfer = db.fundtransfers.Find(id);
            if (fundtransfer == null)
            {
                return HttpNotFound();
            }
            return View(fundtransfer);
        }

        // POST: fundtransfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fundtransfer fundtransfer = db.fundtransfers.Find(id);
            db.fundtransfers.Remove(fundtransfer);
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
