using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CS4790A3.Models;
using CS4790A3.Data;
using CS4790A3.Services;

namespace CS4790A3.Controllers
{
    public class AccountController : Controller
    {
        private readonly SiteContext _context;

        public AccountController(SiteContext context)
        {
            _context = context;
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            user.accountType = 1;
            if(ModelState.IsValid)
            {

                
                user.Password = UserService.encryptPassword(user.Password);
                user.ConfirmPassword = user.Password;

                using (_context)
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();

                }
                ModelState.Clear();
                ViewBag.Message = user.userName + " successfully registered";
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            user.Password = UserService.encryptPassword(user.Password);
            using (_context)
            {
                var usr = _context.Users.Single(u => u.userName == user.userName && u.Password == user.Password);
                if (usr != null)
                {
                    HttpContext.Session.SetInt32("UserID" , usr.UserID);
                    HttpContext.Session.SetString("UserName",usr.userName);
                    HttpContext.Session.SetInt32("UserLevel", usr.accountType);
                    return RedirectToAction("LoggedIn");
                } else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }
                return View();
            }
        }

        public ActionResult LoggedIn()
        {
            if (HttpContext.Session.GetInt32("UserID") != null)
            {
                return Redirect("/");
            } else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }

    }
}