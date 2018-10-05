using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eDnevnik.Models;

namespace eDnevnik.Controllers
{
    public class ProfesorScaffController : Controller
    {
        private eDnevnik_v4Entities2 db = new eDnevnik_v4Entities2();

        // GET: ProfesorScaff
        public ActionResult Index()
        {
            return View(db.Profesori.ToList());
        }

        // GET: ProfesorScaff/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesori profesori = db.Profesori.Find(id);
            if (profesori == null)
            {
                return HttpNotFound();
            }
            return View(profesori);
        }

        // GET: ProfesorScaff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfesorScaff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_profesor,Id,korisnicko_ime,lozinka,administrator,ime,prezime")] Profesori profesori)
        {
            if (ModelState.IsValid)
            {
                db.Profesori.Add(profesori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profesori);
        }

        // GET: ProfesorScaff/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesori profesori = db.Profesori.Find(id);
            if (profesori == null)
            {
                return HttpNotFound();
            }
            return View(profesori);
        }

        // POST: ProfesorScaff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_profesor,Id,korisnicko_ime,lozinka,administrator,ime,prezime")] Profesori profesori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profesori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profesori);
        }

        // GET: ProfesorScaff/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesori profesori = db.Profesori.Find(id);
            if (profesori == null)
            {
                return HttpNotFound();
            }
            return View(profesori);
        }

        // POST: ProfesorScaff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profesori profesori = db.Profesori.Find(id);
            db.Profesori.Remove(profesori);
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
