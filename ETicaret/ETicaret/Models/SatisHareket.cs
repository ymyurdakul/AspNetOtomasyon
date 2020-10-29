using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETicaret.Models
{
    public class SatisHareket
    {
        [Key]
        public int SatisId { get; set; }
        //ürün
        //cari
        //personel

        [DataType("date",ErrorMessage ="Tarih Girilmesi Zorunludur")]
        public DateTime Tarih { get; set; }
        [Required(ErrorMessage ="Adet alanı zorunludur.")]
        public int Adet { get; set; }
        [Required(ErrorMessage = "Adet alanı zorunludur.")]

        public decimal Fiyat { get; set; }
        [Required(ErrorMessage = "Fiyat alanı zorunludur.")]

        public decimal ToplamTutar { get; set; }
        [Required(ErrorMessage = "Tuta alanı zorunludur.")]

        public int UrunId { get; set; }
        public virtual Urun Urun { get; set; }
        [Required(ErrorMessage = "CAri alanı zorunludur.")]

        public int CariId { get; set; }
        public virtual Cari Cari { get; set; }
        [Required(ErrorMessage = "Personel alanı zorunludur.")]

        public int PersonelId { get; set; }
        public virtual Personel Personel { get; set; }
    }
}