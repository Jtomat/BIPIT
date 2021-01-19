using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Bipit_11_12.Models
{
    public class proxy : IPrincipal
    {
        public bool Aut;
        public string txt;
        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            return true;
        }
    }
    public class Res
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? ID_user { get; set; }
        public int? ID_todo { get; set; }
        [ForeignKey("ID_user")]
        public Users User { get; set; }
        [ForeignKey("ID_todo")]
        public TODO TODO { get; set; }
        public DateTime Date { get; set; }


    }
}