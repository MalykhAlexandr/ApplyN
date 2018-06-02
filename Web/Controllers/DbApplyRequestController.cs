using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using F.Web.Models;

namespace F.Web.Controllers
{
    public class DbApplyRequestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DbApplyRequests
        public ActionResult Index()
        {
            return View(db.ApplyRequests.ToList());
        }

        /*private new ActionResult View(object p)
        {
            throw new NotImplementedException();
        }*/

        // GET: DbApplyRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DbApplyRequest dbApplyRequest = db.ApplyRequests.Find(id);
            if (dbApplyRequest == null)
            {
                return HttpNotFound();
            }
            return View(dbApplyRequest);
        }

        // GET: DbApplyRequests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DbApplyRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Filled, FullName, Age, Citizenship, Position, WorkingLeg, Height, Weight, AgeStartCareer, CountTraums, TimeTraums, TraumаNow, Traums, Strength1, Strength2, Strength3,WeakSides1, WeakSides2, WeakSides3")] DbApplyRequest dbApplyRequest)
        {
            if (ModelState.IsValid)
            {
                db.ApplyRequests.Add(dbApplyRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dbApplyRequest);
        }
        
        // GET: DbApplyRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DbApplyRequest dbApplyRequest = db.ApplyRequests.Find(id);
            if (dbApplyRequest == null)
            {
                return HttpNotFound();
            }
            return View(dbApplyRequest);
        }
        
        //POST: DbRideRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DbApplyRequest dbApplyRequest = db.ApplyRequests.Find(id);
            db.ApplyRequests.Remove(dbApplyRequest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       // GET: DbRideRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DbApplyRequest dbApplyRequest = db.ApplyRequests.Find(id);
            if (dbApplyRequest == null)
            {
                return HttpNotFound();
            }
            return View(dbApplyRequest);
        }

        // POST: DbRideRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Filled, FullName, Age, Citizenship, Position, WorkingLeg, Height, Weight, AgeStartCareer, CountTraums, TimeTraums, TraumаNow, Traums, Strength1, Strength2, Strength3,WeakSides1, WeakSides2, WeakSides3")] DbApplyRequest dbApplyRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dbApplyRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dbApplyRequest);
        }
        
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}