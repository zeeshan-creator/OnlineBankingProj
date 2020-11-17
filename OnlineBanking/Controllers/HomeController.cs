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
            if (ModelState.IsValid)
            {
                var email = db.customers.Where(x => x.Email == data.Email).SingleOrDefault();
                var password = db.customers.Where(x => x.Email == data.Email && x.Password == data.Password).SingleOrDefault();

                

                if (email == null)
                {
                    TempData["msg"] = "Email Doesn't Exist";
                    return View();
                }

                if (email != null)
                {
                    if (password == null)
                    {
                        TempData["msg"] = "Password Is Wrong..!";
                        return View();
                    }

                    var user = db.customers.Where(x => x.Email == data.Email).SingleOrDefault();


                    Session["user"] = user.FirstName;
                    Session["id"] = user.Customer_Id;
                    ViewBag.User = user;

                    FormsAuthentication.SetAuthCookie(user.FirstName,false);
                    Session["userEmail"] = user.Email;
                    return RedirectToAction("Index");
                }

            }
                TempData["somethingWentWrong"] = "Something Went Wrong";

                return View();

        }

        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }

}