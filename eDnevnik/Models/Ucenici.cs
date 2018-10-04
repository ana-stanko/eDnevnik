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
    using System.ComponentModel.DataAnnotations;

    public partial class Ucenici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ucenici()
        {
            this.Dodeljene_ocene = new HashSet<Dodeljene_ocene>();
        }

        [Key]
        public int ID_ucenik { get; set; }
        public string Id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public int ID_odeljenje { get; set; }
        public System.DateTime godina_upisa { get; set; }
        public Nullable<bool> pol { get; set; }
        public Nullable<System.DateTime> datum_rodjenja { get; set; }
        public Nullable<int> JMBG { get; set; }
        public string roditelj_staratelj { get; set; }
        public string kontakt_telefon { get; set; }
        public string korisnicko_ime { get; set; }
        public string lozinka { get; set; }
        public string adresa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dodeljene_ocene> Dodeljene_ocene { get; set; }
        public virtual Odeljenja Odeljenja { get; set; }
    }
}
