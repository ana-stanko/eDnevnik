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

    public partial class Profesori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Profesori()
        {
            
            this.Dodeljeni_profesori = new HashSet<Dodeljeni_profesori>();
            this.Odeljenja = new HashSet<Odeljenja>();
            this.Predmetni_profesori = new HashSet<Predmetni_profesori>();
        }

        [Key]
        public int ID_profesor { get; set; }
        public string Id { get; set; }
        public string korisnicko_ime { get; set; }
        public string lozinka { get; set; }
        public bool administrator { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dodeljeni_profesori> Dodeljeni_profesori { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Odeljenja> Odeljenja { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Predmetni_profesori> Predmetni_profesori { get; set; }
    }
}
