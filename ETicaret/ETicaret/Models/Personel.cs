using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETicaret.Models
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(18)]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [Display(Name ="Personel Ad")]
        public string PersonelAd { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(18)]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [Display(Name = "Personel Soyad")]

        public string PersonelSoyad { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(180)]
        [Display(Name = "Personel Görsel")]

        public string PersonelGorsel { get; set; }

        public int DepartmanId { get; set; }
        public virtual Departman Departman { get; set; }

        public virtual ICollection<SatisHareket> SatisHarekets { get; set; }
        [Display(Name = "Personel Tanıtım")]

        public string Tanıtım { get; set; }
        [Display(Name = "Personel Okul")]

        public string Okul { get; set; }


    }
}