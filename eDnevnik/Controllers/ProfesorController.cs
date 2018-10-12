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
    public class ProfesorController : Controller
    {
        private eDnevnik_v4Entities2 db = new eDnevnik_v4Entities2();

        // GET: Profesor
        public ActionResult Index()
        {
            return View(db.Profesori.ToList());
        }

        public ActionResult Pocetna(int id=1)
        {
            eDnevnik_v4Entities2 db = new eDnevnik_v4Entities2();
            Profesori prof = db.Profesori.Single(p => p.ID_profesor == id);

            return View(prof);
        }

        public ActionResult Ocene(int? id)
        {
            eDnevnik_v4Entities2 db = new eDnevnik_v4Entities2();

            List<Ucenici> uc = db.Ucenici.ToList();
            List<Ocene> oc = db.Ocene.ToList();
            List<Dodeljene_ocene> doc = db.Dodeljene_ocene.ToList();

            var ucenikOceneJoin = from uce in db.Ucenici
                                  join doce in db.Dodeljene_ocene on uce.ID_ucenik equals doce.ID_ucenik
                                  join oce in db.Ocene on doce.ID_ocena equals oce.ID_ocena
                                  select new UcenikOceneJoin { ucenikJoin = uce, ucenikDodeljeneJoin = doce, ucenikOceneJoin = oce };

            return View(ucenikOceneJoin);
        }

        // GET: Profesor/Details/5
        public ActionResult Profil(int? id)
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

        

        // GET: Profesor/Edit/5
        public ActionResult IzmenaProfila(int? id)
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



        // POST: Profesor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IzmenaProfila([Bind(Include = "ID_profesor,Id,korisnicko_ime,lozinka,administrator,ime,prezime")] Profesori profesori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profesori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Pocetna");
            }
            return View(profesori);
        }


        // GET: Dodeljene_ocene/Create
        [HttpGet]
        public ActionResult NovaOcena(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            
            Dodeljene_ocene dodeljene_ocene = db.Dodeljene_ocene.First(x=>  x.Ucenici.ID_ucenik == id);
            
            if (dodeljene_ocene == null)
            {
                return HttpNotFound();
            }
            

            var ocena = db.Ocene.Select(s => new { Text = s.ocena + " (" + s.opis + ")", Value = s.ID_ocena }).ToList();
            ViewBag.OcenaList = new SelectList(ocena, "Value", "Text");
            ViewBag.ID_ocena = new SelectList(db.Ocene, "ID_ocena", "ocena");
            ViewBag.ID_predmet = new SelectList(db.Predmeti, "ID_predmet", "naziv_predmeta");
            ViewBag.tip_ocene = new SelectList(db.Tipovi_ocena, "tip_ocene", "tip_ocene");
            ViewBag.ID_ucenik = new SelectList(db.Ucenici, "ID_ucenik", "ID_ucenik");
            return View(dodeljene_ocene);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NovaOcena([Bind(Include = "ID_D_ocena,ID_ucenik,ID_predmet,ID_ocena,datum_unosa,tip_ocene,komentar")] Dodeljene_ocene dodeljene_ocene)
        {
            if (ModelState.IsValid)
            {
                db.Dodeljene_ocene.Add(dodeljene_ocene);
                db.SaveChanges();
                return RedirectToAction("Ocene");
            }

            ViewBag.ID_ocena = new SelectList(db.Ocene, "ID_ocena", "ocena", dodeljene_ocene.ID_ocena);
            ViewBag.ID_predmet = new SelectList(db.Predmeti, "ID_predmet", "naziv_predmeta", dodeljene_ocene.ID_predmet);
            ViewBag.tip_ocene = new SelectList(db.Tipovi_ocena, "tip_ocene", "tip_ocene", dodeljene_ocene.tip_ocene);
            ViewBag.ID_ucenik = new SelectList(db.Ucenici, "ID_ucenik", "ID_ucenik", dodeljene_ocene.ID_ucenik);
            return View(dodeljene_ocene);
        }


        // GET: Dodeljene_ocene/Details/5
        public ActionResult Izmeni()
        {
            var dodeljene_ocene = db.Dodeljene_ocene.Include(d => d.Ocene).Include(d => d.Predmeti).Include(d => d.Tipovi_ocena).Include(d => d.Ucenici);

            return View(dodeljene_ocene.ToList());
        }


        // GET: Dodeljene_ocene/Edit/5
        public ActionResult IzmenaOcene(int? id)
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

            var ocena = db.Ocene.Select(s => new {Text = s.ocena + " (" + s.opis +")", Value = s.ID_ocena}).ToList();
            ViewBag.OcenaList = new SelectList(ocena, "Value", "Text");
            ViewBag.ID_ocena = new SelectList(db.Ocene, "ID_ocena", "ocena", dodeljene_ocene.ID_ocena);
            ViewBag.ID_predmet = new SelectList(db.Predmeti, "ID_predmet", "naziv_predmeta", dodeljene_ocene.ID_predmet);
            ViewBag.tip_ocene = new SelectList(db.Tipovi_ocena, "tip_ocene", "tip_ocene", dodeljene_ocene.tip_ocene);
            ViewBag.ID_ucenik = new SelectList(db.Ucenici, "ID_ucenik", "ID_ucenik", dodeljene_ocene.ID_ucenik);
            return View(dodeljene_ocene);
        }

        // POST: Dodeljene_ocene/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IzmenaOcene([Bind(Include = "ID_D_ocena,ID_ucenik,ID_predmet,ID_ocena,datum_unosa,tip_ocene,komentar")] Dodeljene_ocene dodeljene_ocene)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dodeljene_ocene).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Izmeni");
            }
            ViewBag.ID_ocena = new SelectList(db.Ocene, "ID_ocena", "ocena", dodeljene_ocene.ID_ocena);
            ViewBag.ID_predmet = new SelectList(db.Predmeti, "ID_predmet", "naziv_predmeta", dodeljene_ocene.ID_predmet);
            ViewBag.tip_ocene = new SelectList(db.Tipovi_ocena, "tip_ocene", "tip_ocene", dodeljene_ocene.tip_ocene);
            ViewBag.ID_ucenik = new SelectList(db.Ucenici, "ID_ucenik", "ID_ucenik", dodeljene_ocene.ID_ucenik);
            return View(dodeljene_ocene);
        }

        // GET: Dodeljene_ocene/Delete/5
        public ActionResult BrisanjeOcene(int? id)
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
        [HttpPost, ActionName("BrisanjeOcene")]
        [ValidateAntiForgeryToken]
        public ActionResult BrisanjeOcenePotvrda(int id)
        {
            Dodeljene_ocene dodeljene_ocene = db.Dodeljene_ocene.Find(id);
            db.Dodeljene_ocene.Remove(dodeljene_ocene);
            db.SaveChanges();
            return RedirectToAction("Izmeni");
        }




    }
}
