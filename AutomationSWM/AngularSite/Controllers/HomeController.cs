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
        AutomationDBEntities1 db = new AutomationDBEntities1();
        TEST_STATUS_TB tb = new TEST_STATUS_TB();

      

        // GET: Home
        public ActionResult Index()
        {
            return View(db.TEST_STATUS_TB.OrderByDescending(c => c.Creation_Time)/*.Take(10)*/.ToList());
        }

        public ActionResult About()
        {
        


            return View(db.TEST_STATUS_TB.OrderByDescending(c => c.Creation_Time)/*.Take(10)*/.ToList());

        
        }

        public ActionResult Contact()
        {
            return View(db.TEST_STATUS_TB.OrderByDescending(c => c.Creation_Time)/*.Take(10)*/.ToList());
        }
    }
}