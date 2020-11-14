using OnlineBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineBanking.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        OnlineBankingDBEntities db = new OnlineBankingDBEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login() => View();

        //[Route("Login")]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Admin data)
        {
            var email = db.Admins.Where(x => x.Username == data.Username).SingleOrDefault();
            var password = db.Admins.Where(x => x.Username == data.Username && x.Password == data.Password).SingleOrDefault();

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

                var AdminName = db.Admins.Where(x => x.Username == data.Username).SingleOrDefault();

                Session["user"] = AdminName.Username;

                FormsAuthentication.SetAuthCookie(AdminName.Username, false);

                return RedirectToAction("Index");
            }

            TempData["msg"] = "Something Went Wrong";

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