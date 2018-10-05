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
    public class ProfesorController : Controller
    {
        // GET: Profesor
        public ActionResult IndexList()
        {
            eDnevnik_v4Entities2 eDent = new eDnevnik_v4Entities2();
            List<Profesori> prof = eDent.Profesori.ToList();
            
            return View(prof);
        }

        public ActionResult Index(int Id)
        {
            eDnevnik_v4Entities2 eDent = new eDnevnik_v4Entities2();
            Profesori prof = eDent.Profesori.Single(p => p.ID_profesor == Id);

            return View(prof);
        }

        public ActionResult IzmenaOcena(int Id)
        {
            eDnevnik_v4Entities2 eDent = new eDnevnik_v4Entities2();


            return View();
        }

        [HttpGet]
        public ActionResult NoviProfesor()
        {
            return View();
        }

       

    }
}