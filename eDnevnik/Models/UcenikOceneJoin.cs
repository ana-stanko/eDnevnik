using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDnevnik.Models
{
    public class UcenikOceneJoin
    {
        [Key]
        public int ID_join {get; set;}
        public Ucenici ucenikJoin { get; set; }
        public Dodeljene_ocene ucenikDodeljeneJoin { get; set; }
        public Ocene ucenikOceneJoin { get; set; }
    }

}