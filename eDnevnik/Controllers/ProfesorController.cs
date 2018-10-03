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
        public ActionResult Index(int Id)
        {
            ApplicationContext applicationContext = new ApplicationContext();
            
            Profesori profesor = applicationContext.Profesoris.Single(prof => prof.ID_profesor == Id);
            return View(profesor);
        }
    }
}