using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETicaret.Models
{
    public class Cari
    {
        [Key]
        public int CariId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(18,ErrorMessage ="Max karakter sayısı 18 dir.")]
        [Required(ErrorMessage ="Bu alan zorunludur.")]
        public string CariAd { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(18)]
        [Required(ErrorMessage = "Bu alan zorunludur.")]

        public string CariSoyad { get; set; }



        [Column(TypeName = "varchar")]
        [StringLength(13)]
        [Required(ErrorMessage = "Bu alan zorunludur.")]

        public string CariSehir { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(20)]
        [Required(ErrorMessage = "Bu alan zorunludur.")]

        public string CariMail { get; set; }
        public bool Durum { get; set; }
        public virtual ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}