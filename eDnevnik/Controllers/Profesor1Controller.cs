using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eDnevnik.Models;

namespace eDnevnik.Controllers
{
    public class Profesor1Controller : Controller
    {
            eDnevnik_v4Entities2 eDent = new eDnevnik_v4Entities2();
        private int id;

        // GET: Profesor
        public ActionResult IndexList()
        {
            List<Profesori> prof = eDent.Profesori.ToList();
            
            return View(prof);
        }

        public ActionResult Index(int Id)
        {
            eDnevnik_v4Entities2 eDent = new eDnevnik_v4Entities2();
            Profesori prof = eDent.Profesori.Single(p => p.ID_profesor == Id);

            return View(prof);
        }

        public ActionResult IzmenaOcena()
        {
            eDnevnik_v4Entities2 eDent = new eDnevnik_v4Entities2();

            List<Ucenici> uc = eDent.Ucenici.ToList();
            List<Ocene> oc = eDent.Ocene.ToList();
            List<Dodeljene_ocene> doc = eDent.Dodeljene_ocene.ToList();

            var ucenikOceneJoin = from uce in eDent.Ucenici
                          join doce in eDent.Dodeljene_ocene on uce.ID_ucenik equals doce.ID_ucenik
                          join oce in eDent.Ocene on doce.ID_ocena equals oce.ID_ocena
                          select new UcenikOceneJoin { ucenikJoin = uce, ucenikDodeljeneJoin = doce, ucenikOceneJoin = oce };
            
            return View(ucenikOceneJoin);
        }

        
        [HttpGet]
        public ActionResult Unesi()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Unesi([Bind(Include = "ID_D_Ocena, ID_ucenik, naziv_predmeta, ID_ocena, datum_unosa, tip_ocene, komentar")] Dodeljene_ocene dodeljene_Ocene)
        {
            Profesori prof = eDent.Profesori.Single(p => p.ID_profesor == id);
            Dodeljene_ocene dod_oc = eDent.Dodeljene_ocene.Single(d => d.ID_ucenik == dodeljene_Ocene.ID_ucenik);

            if (ModelState.IsValid)
            {
                eDent.Dodeljene_ocene.Add(dodeljene_Ocene);
                eDent.SaveChanges();
                return RedirectToAction("IzmenaOcena");
            }

            return View(dod_oc);
        }


        // GET: Dodeljene_ocene/Create
        public ActionResult Create(int id)
        {
            ViewBag.ID_ocena = new SelectList(eDent.Ocene, "ID_ocena", "ocena");
            ViewBag.ID_ucenik =  id;
            ViewBag.ID_predmet = new SelectList(eDent.Predmeti, "ID_predmet", "naziv_predmeta");
            ViewBag.tip_ocene = new SelectList(eDent.Tipovi_ocena, "tip_ocene", "tip_ocene");
            return View();
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_D_ocena,ID_ucenik,ID_predmet,ID_ocena,datum_unosa,tip_ocene,komentar")] Dodeljene_ocene dodeljene_ocene)
        {
            if (ModelState.IsValid)
            {
                eDent.Dodeljene_ocene.Add(dodeljene_ocene);
                eDent.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ocena = new SelectList(eDent.Ocene, "ID_ocena", "ocena", dodeljene_ocene.ID_ocena);
            ViewBag.ID_predmet = new SelectList(eDent.Predmeti, "ID_predmet", "naziv_predmeta", dodeljene_ocene.ID_predmet);
            ViewBag.tip_ocene = new SelectList(eDent.Tipovi_ocena, "tip_ocene", "tip_ocene", dodeljene_ocene.tip_ocene);
            ViewBag.ID_ucenik = new SelectList(eDent.Ucenici, "ID_ucenik", "Id", dodeljene_ocene.ID_ucenik);
            return View(dodeljene_ocene);
        }


        public ActionResult Izmeni()
        {
            return View();
        }

        public ActionResult Obrisi()
        {
            return View();
        }
        

    }
}