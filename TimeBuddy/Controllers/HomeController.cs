using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeBuddy.Models;

namespace TimeBuddy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int timeZoneOffset = 120, string culture = "sk-SK")
        {
            var serverTimeDiff = -1 * (int)(DateTime.UtcNow - DateTime.Now).TotalMinutes;
            var model = new Times()
            {
                DefaultTime = GetDateString(serverTimeDiff, culture),
                CulturelessTime = GetDateString(timeZoneOffset),
                LocalTime = GetDateString(timeZoneOffset, culture),
            };

            return View(model);
        }

        public JsonResult GetCurrentDateTime()
        {
            return Json(DateTime.Now,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDateTimeString(int timeZoneOffset = 0, string culture = "sk-SK")
        {
            return Json(GetDateString(timeZoneOffset,culture), JsonRequestBehavior.AllowGet);
        }

        private string GetDateString(int? timeZoneOffset = null, string culture = "sk-SK")
        {
            var now = DateTime.UtcNow;
            if (timeZoneOffset.HasValue)
            {
                now = now.AddMinutes(timeZoneOffset.Value);
            }

            return now.ToString(new CultureInfo(culture));
        }
    }
}