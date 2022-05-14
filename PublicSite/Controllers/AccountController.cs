using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Dal;
using DataAccessLayer.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PublicSite.Models;

namespace PublicSite.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string username = model.Username;
            string password = model.Password;
            string hashedPassword = Cryptographing.HashPassword(password);

            AspNetUser user = RepoFactory.GetRepo().AuthUser(username, hashedPassword);
            if (user == null)
            {
                return View(model);
            }
            Session["user"] = user;
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                string userEmail = model.Email;
                string userName = model.UserName;
                string phoneNumber = model.PhoneNumber;
                string address = model.Address;
                string inputPassword = model.Password;
                string hashedPassword = Cryptographing.HashPassword(inputPassword);

                RepoFactory.GetRepo().RegisterUser(new AspNetUser
                {
                    UserName = userName,
                    PhoneNumber = phoneNumber,
                    Address = address,
                    PasswordHash = hashedPassword,
                    Email = userEmail,
                });

                return RedirectToAction("Index", "Home");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        //
        // GET: /Account/LogOff
        public ActionResult LogOff()
        {
            Session["user"] = null;            
            return RedirectToAction("Index", "Home");
        }
    }
}