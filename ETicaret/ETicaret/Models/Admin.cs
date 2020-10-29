using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETicaret.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(10)]
        public string KullaniciAd { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(18)]
        public string Sifre { get; set; }
        [Column(TypeName = "char")]
        [StringLength(1)]
        public string Yetki { get; set; }

    }
}