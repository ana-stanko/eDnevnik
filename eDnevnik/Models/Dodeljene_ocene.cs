//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eDnevnik.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dodeljene_ocene
    {
        public int ID_D_ocena { get; set; }
        public int ID_ucenik { get; set; }
        public int ID_predmet { get; set; }
        public int ID_ocena { get; set; }
        public System.DateTime datum_unosa { get; set; }
        public string tip_ocene { get; set; }
        public string komentar { get; set; }
    
        public virtual Ocene Ocene { get; set; }
        public virtual Predmeti Predmeti { get; set; }
        public virtual Tipovi_ocena Tipovi_ocena { get; set; }
        public virtual Ucenici Ucenici { get; set; }
    }
}
