using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDnevnik.Models
{
    [MetadataType(typeof(UceniciMetadata))]
    public partial class Ucenici
    {

    }
    public class UceniciMetadata
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite Ime")]

        public string ime { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite Prezime")]
        public string prezime { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite odeljenje")]
        public string ID_odeljenje { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite godinu upisa")]
        public string godina_upisa { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite pol")]
        public string pol { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite datum rodjenja")]
        public string datum_rodjenja { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite jmbg")]
        public string JMBG { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite ime roditelja")]
        public string roditelj_staratelj { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite kontakt telefon")]
        public string kontakt_telefon { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite korisnicko ime")]
        public string korisnicko_ime { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite lozinku")]
        [DataType(DataType.Password)]
        public string lozinka { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite adresu")]
        public string adresa { get; set; }

    }
}
