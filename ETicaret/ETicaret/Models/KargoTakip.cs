using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETicaret.Models
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipId { get; set; }
        
        public string TakipKod { get; set; }
        public string Acıklama { get; set; }
        public DateTime Tarih { get; set; }
    }
}