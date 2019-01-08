using Newtonsoft.Json.Linq;
using project_dotnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace project_dotnet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

       
        public ActionResult Feedback()
        {
            db1Entities db = new db1Entities();
            

            return View();
        }

        [HttpGet]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }

            catch
            {
                return View();
            }
        }

       
    }

}