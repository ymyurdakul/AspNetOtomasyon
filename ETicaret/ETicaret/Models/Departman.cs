using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETicaret.Models
{
    public class Departman
    {
        [Key]
        public int DepartmanID { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(18)]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string DepartmanAd { get; set; }
        public bool Durum { get; set; }
        public virtual ICollection<Personel> Personels { get; set; }
    }
}