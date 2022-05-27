using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Concrete
{
    public class Urunlerim
    {
        [Key]
        public int UrunID { get; set; }
        //-------------------------------------------------
        [StringLength(70)]
        [Column(TypeName = "Varchar")]
        public string UrunAd { get; set; }
        //-------------------------------------------------
        [StringLength(5000)]
        [Column(TypeName = "Varchar")]
        public string UrunFoto { get; set; }
        //-------------------------------------------------
        [StringLength(2000)]
        [Column(TypeName = "Varchar")]
        public string UrunBilgi { get; set; }
        //-------------------------------------------------
        public short UrunStok { get; set; }
        //-------------------------------------------------
        public decimal UrunAlisFiyat { get; set; }
        //-------------------------------------------------
        public decimal UrunSatisFiyat { get; set; }
        //-------------------------------------------------
        public bool UrunDurum { get; set; }

        //bir kategori birden fazla kez urun tabloma geliyor
        public int KategoriID { get; set; }
        public virtual Kategoriler Kategoriler { get; set; }

        //ÜRÜN MARKASI İLE İLİŞKİ KURULACAK
        public int MarkaID { get; set; }
        public virtual Markalar Markalar { get; set; }

        //BİR ÜRÜN BİRDEN FAZLAKEZ SATİS TABLOMDA GİDEBİLİR
        public ICollection<Satislar> satislars { get; set; }
        //detasy sayfa ilişkisi
        public ICollection<Detay> detays { get; set; }
        //detasy sayfa ilişkisi
        public ICollection<YorumPuan> yorumPuans { get; set; }
    }
}