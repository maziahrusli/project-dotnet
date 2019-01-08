using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using project_dotnet.Models;

namespace project_dotnet.Controllers
{
    public class Feedbacks2Controller : Controller
    {
        private db1Entities db = new db1Entities();

        // GET: Feedbacks2
        public ActionResult Index()
        {
            return View(db.Feedbacks.ToList());
        }

        // GET: Feedbacks2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // GET: Feedbacks2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Feedbacks2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MatricNo,FullName,Residential,Answer")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Feedbacks.Add(feedback);
                return RedirectToAction("Index");
            }
            var response = Request["g-recaptcha-response"];
            string secretKey = "6LdUIIcUAAAAAMBc-yYrc-gJIvVQJC5EgILCl1a-";
            var Client = new WebClient();
            var result = Client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            bool v = (bool)obj.SelectToken("success");
            var status = v;
            ViewBag.Message = status ? "Google reCaptcha validation success" : "Google reCaptcha validation Failed!!";



            return View(feedback);
        }

        // GET: Feedbacks2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: Feedbacks2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MatricNo,FullName,Residential,Answer")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feedback);
        }

        // GET: Feedbacks2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: Feedbacks2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feedback feedback = db.Feedbacks.Find(id);
            db.Feedbacks.Remove(feedback);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //[HttpPost]
        //public ActionResult FormSubmit()
        //{
        //    var response = Request["g-recaptcha-response"];
        //    string secretKey = "6LdUIIcUAAAAAMBc-yYrc-gJIvVQJC5EgILCl1a-";
        //    var Client = new WebClient();
        //    var result = Client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
        //    var obj = JObject.Parse(result);
        //    bool v = (bool)obj.SelectToken("success");
        //    var status = v;
        //    ViewBag.Message = status ? "Google reCaptcha validation success" : "Google reCaptcha validation Failed!!";

        //    return View("Index");

        //}

        public ActionResult SaveRecord(FeedbackViewModel model)
        {
            try
            {
                db1Entities db = new db1Entities();
                Feedback fdbk = new Feedback();

                Feedback feedback = new Feedback();

               // feedback.MatricNo = fdbk.MatricNo;
                //feedback.FullName = fdbk.FullName;
                //feedback.Residential = fdbk.Residential;
                //feedback.Answer = fdbk.Answer;

                db.Feedbacks.Add(feedback);
                db.SaveChanges(feedback);

                int latestId = fdbk.Id;
                

            }
            catch (Exception e)
            {
                throw e;
            }

            return RedirectToAction("Index");

        }
    }
}
