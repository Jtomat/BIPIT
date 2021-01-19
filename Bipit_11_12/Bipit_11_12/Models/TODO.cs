using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bipit_11_12.Models
{
    [Table("TODO")]
    public class TODO : IHasName
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("Res")]
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }


        public ICollection<Res> Res { get; set; }
    }
}