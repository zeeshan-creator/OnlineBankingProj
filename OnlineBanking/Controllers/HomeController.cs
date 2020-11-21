using OnlineBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineBanking.Controllers
{
    public class HomeController : Controller
    {
        OnlineBankingDBEntities db = new OnlineBankingDBEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult signup()
        {
            ViewBag.AccountTypeId = new SelectList(db.AccountTypes, "Account_Id", "Account_Type");
            return View();
        }

        [HttpPost]
        public ActionResult signup(customer data)
        {
            if (ModelState.IsValid)
            {
                db.customers.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountTypeId = new SelectList(db.AccountTypes, "Account_Id", "Account_Type", data.AccountTypeId);
            return View(data);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(customer data)
        {
            var res = db.customers.Where(a => a.FirstName == data.FirstName && a.LastName == data.LastName).SingleOrDefault();
            if (res != null)
            {
                Session["id"] = res.AccountTypeId;
                return RedirectToAction("fetchaccount");
            }

            else
            {
                ViewBag.error = "invalid email and password";
            }
            return View();
        }
        public ActionResult fetchaccount()

        {
            int id = Convert.ToInt32(Session["id"]);
            var res = db.customers.Where(a => a.AccountTypeId == id);

            return View(res);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }

}