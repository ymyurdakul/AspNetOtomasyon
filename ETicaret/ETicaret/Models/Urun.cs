using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETicaret.Models
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(18)]
        [Required(ErrorMessage = "Bu alan zorunludur.")]

        public string UrunAd { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(18)]
        [Required(ErrorMessage = "Bu alan zorunludur.")]

        public string Marka { get; set; }
        public short Stok { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]

        public decimal AlısFiyat { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]

        public decimal SatısFiyat { get; set; }
        public bool Durum { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }

        //  public int KategoriId { get; set; }
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual ICollection<SatisHareket> SatisHarekets { get; set; }

        public string Detay { get; set; }
        public string Ekstra { get; set; }

    }
}