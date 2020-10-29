using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETicaret.Models
{
    public class Gider
    {
        [Key]
        public int GiderId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Acıklama { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Tutar { get; set; }
    }
}