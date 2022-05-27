using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Concrete
{
    public class YorumPuan
    {
        [Key]
        public int YpID { get; set; }
        //------------------------------------------------
        [Column(TypeName ="Varchar")]
        [StringLength(1000)]
        public string Yorum { get; set; }
        //------------------------------------------------
        public byte Puan { get; set; }
        //------------------------------------------------
        //MUSTERİ TABLOM İLE İLİŞKİ KURULDU
        public int MusteriID { get; set; }
        public virtual Musteriler Musteriler { get; set; }
        //------------------------------------------------
        public bool YorumDurum { get; set; }
        //------------------------------------------------
        [Column(TypeName ="Smalldatetime")]
        public DateTime YorumT { get; set; }
        //------------------------------------------------
        //URUN TABLOM İLE İLİŞKİ KURULDU
        public int UrunID { get; set; }
        public virtual Urunlerim Urunlerim { get; set; }

    }
}