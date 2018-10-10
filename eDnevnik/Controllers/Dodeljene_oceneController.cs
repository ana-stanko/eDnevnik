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
    public class Dodeljene_oceneController : Controller
    {
        private eDnevnik_v4Entities2 db = new eDnevnik_v4Entities2();

        // GET: Dodeljene_ocene
        public ActionResult Index()
        {
            var dodeljene_ocene = db.Dodeljene_ocene.Include(d => d.Ocene).Include(d => d.Predmeti).Include(d => d.Tipovi_ocena).Include(d => d.Ucenici);
            return View(dodeljene_ocene.ToList());
        }

        // GET: Dodeljene_ocene/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dodeljene_ocene dodeljene_ocene = db.Dodeljene_ocene.Find(id);
            if (dodeljene_ocene == null)
            {
                return HttpNotFound();
            }
            return View(dodeljene_ocene);
        }

        // GET: Dodeljene_ocene/Create
        public ActionResult Create()
        {
            ViewBag.ID_ocena = new SelectList(db.Ocene, "ID_ocena", "ocena");
            ViewBag.ID_predmet = new SelectList(db.Predmeti, "ID_predmet", "naziv_predmeta");
            ViewBag.tip_ocene = new SelectList(db.Tipovi_ocena, "tip_ocene", "tip_ocene");
            ViewBag.ID_ucenik = new SelectList(db.Ucenici, "ID_ucenik", "Id");
            return View();
        }

        // POST: Dodeljene_ocene/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_D_ocena,ID_ucenik,ID_predmet,ID_ocena,datum_unosa,tip_ocene,komentar")] Dodeljene_ocene dodeljene_ocene)
        {
            if (ModelState.IsValid)
            {
                db.Dodeljene_ocene.Add(dodeljene_ocene);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ocena = new SelectList(db.Ocene, "ID_ocena", "ocena", dodeljene_ocene.ID_ocena);
            ViewBag.ID_predmet = new SelectList(db.Predmeti, "ID_predmet", "naziv_predmeta", dodeljene_ocene.ID_predmet);
            ViewBag.tip_ocene = new SelectList(db.Tipovi_ocena, "tip_ocene", "tip_ocene", dodeljene_ocene.tip_ocene);
            ViewBag.ID_ucenik = new SelectList(db.Ucenici, "ID_ucenik", "Id", dodeljene_ocene.ID_ucenik);
            return View(dodeljene_ocene);
        }

        // GET: Dodeljene_ocene/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dodeljene_ocene dodeljene_ocene = db.Dodeljene_ocene.Find(id);
            if (dodeljene_ocene == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ocena = new SelectList(db.Ocene, "ID_ocena", "ocena", dodeljene_ocene.ID_ocena);
            ViewBag.ID_predmet = new SelectList(db.Predmeti, "ID_predmet", "naziv_predmeta", dodeljene_ocene.ID_predmet);
            ViewBag.tip_ocene = new SelectList(db.Tipovi_ocena, "tip_ocene", "tip_ocene", dodeljene_ocene.tip_ocene);
            ViewBag.ID_ucenik = new SelectList(db.Ucenici, "ID_ucenik", "Id", dodeljene_ocene.ID_ucenik);
            return View(dodeljene_ocene);
        }

        // POST: Dodeljene_ocene/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_D_ocena,ID_ucenik,ID_predmet,ID_ocena,datum_unosa,tip_ocene,komentar")] Dodeljene_ocene dodeljene_ocene)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dodeljene_ocene).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ocena = new SelectList(db.Ocene, "ID_ocena", "ocena", dodeljene_ocene.ID_ocena);
            ViewBag.ID_predmet = new SelectList(db.Predmeti, "ID_predmet", "naziv_predmeta", dodeljene_ocene.ID_predmet);
            ViewBag.tip_ocene = new SelectList(db.Tipovi_ocena, "tip_ocene", "tip_ocene", dodeljene_ocene.tip_ocene);
            ViewBag.ID_ucenik = new SelectList(db.Ucenici, "ID_ucenik", "Id", dodeljene_ocene.ID_ucenik);
            return View(dodeljene_ocene);
        }

        // GET: Dodeljene_ocene/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dodeljene_ocene dodeljene_ocene = db.Dodeljene_ocene.Find(id);
            if (dodeljene_ocene == null)
            {
                return HttpNotFound();
            }
            return View(dodeljene_ocene);
        }

        // POST: Dodeljene_ocene/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dodeljene_ocene dodeljene_ocene = db.Dodeljene_ocene.Find(id);
            db.Dodeljene_ocene.Remove(dodeljene_ocene);
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
