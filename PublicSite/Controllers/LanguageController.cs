using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace PublicSite.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        public ActionResult Index() => View();

        public ActionResult SetNewLanguage(string selectedLanguage)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);

            Response.Cookies.Add(new HttpCookie("language", selectedLanguage));

            return RedirectToAction("Index", "Home");
        }
    }    
}