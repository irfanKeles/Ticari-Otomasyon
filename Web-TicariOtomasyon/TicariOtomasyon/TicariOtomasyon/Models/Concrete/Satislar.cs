using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Concrete
{
    public class Satislar
    {
        [Key]
        public int SatisID { get; set; }
        public int SatisAdet { get; set; }
        public decimal SatisFiyat { get; set; }
        public decimal SatisToplamFiyat { get; set; }
        public DateTime SatisTarihi { get; set; }
        public bool SatisDurum { get; set; }

        //! MUSTERİ BİRDEN FAZLA KEZ SATİS TABLOMDA BULUNA BİLİR
        public int MusteriID { get; set; }
        public virtual Musteriler Musteriler { get; set; }

        // BİR URUN BİRDEN FAZLA KEZ SATİS TABLOMDA BULUNABİLİR
        public int UrunID { get; set; }
        public virtual Urunlerim Urunlerim { get; set; }

        //BİR PERSONEL BİRDEN FAZLA KEZ SATIŞ TABLOMDA YER ALABİLİR
        public int PersonelID { get; set; }
        public virtual Personel Personel { get; set; }
    }
}