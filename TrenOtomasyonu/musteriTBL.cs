//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrenOtomasyonu
{
    using System;
    using System.Collections.Generic;
    
    public partial class musteriTBL
    {
        public short musteriID { get; set; }
        public string musteriAd { get; set; }
        public string musteriSoyad { get; set; }
        public Nullable<byte> seferTürü { get; set; }
        public string gidisSeferSaati { get; set; }
        public string nereden { get; set; }
        public string nereye { get; set; }
        public Nullable<decimal> biletFiyatı { get; set; }
        public Nullable<byte> koltukAdet { get; set; }
        public string gelisSeferSaati { get; set; }
        public string Koltukları { get; set; }
        public string TCNO { get; set; }
    }
}