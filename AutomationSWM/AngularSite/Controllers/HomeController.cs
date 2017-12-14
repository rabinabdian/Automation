using AutomationSWM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularSite.Controllers
{
    public class HomeController : Controller
    {
        AutomationDBEntities db = new AutomationDBEntities();
        TEST_STATUS_TB tb = new TEST_STATUS_TB();

        //List<TEST_STATUS_TB> ls = (from t in db.TEST_STATUS_TB
        //                           orderby t.Test_ID ascending
        //                           select t;
        //                           );


        // GET: Home
        public ActionResult Index()
        {
            return View(db.TEST_STATUS_TB.OrderByDescending(c => c.Creation_Time)/*.Take(10)*/.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}