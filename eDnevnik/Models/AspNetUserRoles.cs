using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eDnevnik.Models
{
    public class AspNetUserRoles
    {
        [ForeignKey("AspNetRoles")]
        [Column(Order = 1)]
        public string RoleId { get; set; }

        [ForeignKey("AspNetUsers")]
        [Column(Order = 2)]
        public string UserId { get; set; }
    }
}