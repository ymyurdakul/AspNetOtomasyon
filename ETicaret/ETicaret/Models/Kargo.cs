using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaret.Models
{
    public class Kargo
    {
        public int KargoId { get; set; }
        public string Acıklama { get; set; }
        public string TakipKodu { get; set; }
        public string Personel { get; set; }
        public string Alıcı { get; set; }
        public string Tarih { get; set; }
    }
}