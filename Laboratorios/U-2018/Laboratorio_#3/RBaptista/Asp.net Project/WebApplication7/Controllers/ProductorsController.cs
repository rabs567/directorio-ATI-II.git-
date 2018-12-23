using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class ProductorsController : Controller
    {
        private ProductorContext db = new ProductorContext();

        // GET: Productors
        public ActionResult Index()
        {
            return View(db.Productores.ToList());
        }

        // GET: Productors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productor productor = db.Productores.Find(id);
            if (productor == null)
            {
                return HttpNotFound();
            }
            return View(productor);
        }

        // GET: Productors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Director,Fecha")] Productor productor)
        {
            if (ModelState.IsValid)
            {
                db.Productores.Add(productor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productor);
        }

        // GET: Productors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productor productor = db.Productores.Find(id);
            if (productor == null)
            {
                return HttpNotFound();
            }
            return View(productor);
        }

        // POST: Productors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Director,Fecha")] Productor productor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productor);
        }

        // GET: Productors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productor productor = db.Productores.Find(id);
            if (productor == null)
            {
                return HttpNotFound();
            }
            return View(productor);
        }

        // POST: Productors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Productor productor = db.Productores.Find(id);
            db.Productores.Remove(productor);
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
    }
}
