using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETicaret.Models
{
    public class Fatura
    {
        [Key]
        public int FaturaID { get; set; }
        [Column(TypeName = "char")]
        [StringLength(1)]
        public string FaturaSeriNo { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(6)]
        public string FaturaSıraNo { get; set; }
        public DateTime Tarih { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(35)]
        public string VergiDairesi { get; set; }
        public DateTime Saat { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string TeslimEden { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }
         public decimal Toplam { get; set; }
        public virtual ICollection<FaturaKalem> FaturaKalems { get; set; }

    }
}