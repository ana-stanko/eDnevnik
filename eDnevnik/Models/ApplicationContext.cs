using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace eDnevnik.Models
{
    public class ApplicationContext
    {
        public DbSet<Profesori> Profesoris { get; set; }
        public DbSet<Odeljenja> Odeljenjas { get; set; }
        public DbSet<Ocene> Ocenes { get; set; }
        public DbSet<Ucenici> Ucenicis { get; set; }
        public DbSet<Predmeti> Predmetis { get; set; }
        public DbSet<Tipovi_ocena> Tipovi_Ocenas { get; set; }
        public DbSet<Dodeljene_ocene> Dodeljene_Ocenes { get; set; }
        public DbSet<Dodeljeni_profesori> Dodeljeni_Profesoris { get; set; }
        public DbSet<Predmetni_profesori> Predmetni_Profesoris { get; set; }
    }
}