using eDnevnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace eDnevnik.Controllers
{
    public class UceniciController : Controller
    {
        // GET: Ucenici
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUcenici()
        {
            using (eDnevnik_v4Entities2 dc = new eDnevnik_v4Entities2())
            {
                dc.Configuration.LazyLoadingEnabled = false;
                var ucenicis = dc.Ucenici.OrderBy(a => a.ime).ToList();
                return Json(new { data = ucenicis }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            using (eDnevnik_v4Entities2 dc = new eDnevnik_v4Entities2())
            {
                var v = dc.Ucenici.Where(a => a.ID_ucenik == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult Save(Ucenici uc)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (eDnevnik_v4Entities2 dc = new eDnevnik_v4Entities2())
                {
                    if (uc.ID_ucenik > 0)
                    {
                        var v = dc.Ucenici.Where(a => a.ID_ucenik == uc.ID_ucenik).FirstOrDefault();
                        if (v != null)

                        //Edit
                        {
                            v.ime = uc.ime;
                            v.prezime = uc.prezime;
                            //v.ID_odeljenje = uc.ID_odeljenje;
                            v.godina_upisa = uc.godina_upisa;
                            v.pol = uc.pol;
                            v.datum_rodjenja = uc.datum_rodjenja;
                            v.JMBG = uc.JMBG;
                            v.roditelj_staratelj = uc.roditelj_staratelj;
                            v.kontakt_telefon = uc.kontakt_telefon;
                            v.korisnicko_ime = uc.korisnicko_ime;
                            v.lozinka = uc.lozinka;
                            v.adresa = uc.adresa;


                        }
                    }
                    else
                    {
                        dc.Ucenici.Add(uc);
                    }
                    dc.SaveChanges();
                    status = true;

                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            using (eDnevnik_v4Entities2 dc = new eDnevnik_v4Entities2())
            {
                var v = dc.Ucenici.Where(a => a.ID_ucenik == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);

                }
                else
                {
                    return HttpNotFound();
                }
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteUcenici(int? id)
        {
            bool status = false;
            using (eDnevnik_v4Entities2 dc = new eDnevnik_v4Entities2())

            {
                var v = dc.Ucenici.Where(a => a.ID_ucenik == id).FirstOrDefault();
                if (v != null)
                {
                    dc.Ucenici.Remove(v);
                    dc.SaveChanges();
                    status = true;


                }


            }

            return new JsonResult { Data = new { status = status } };
        }
    }
}



    
