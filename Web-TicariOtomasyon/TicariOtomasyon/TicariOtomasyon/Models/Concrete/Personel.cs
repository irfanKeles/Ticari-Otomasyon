using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Concrete
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        [StringLength(25)]
        [Column(TypeName = "Varchar")]
        public string PersonelAd { get; set; }
        [StringLength(25)]
        [Column(TypeName = "Varchar")]
        public string PersonelSoyad { get; set; }
        [StringLength(25)]
        [Column(TypeName = "Varchar")]
        public string PersonelMail { get; set; }
        [StringLength(250)]
        [Column(TypeName = "Varchar")]
        public string PersonelAdres { get; set; }
        [StringLength(500)]
        [Column(TypeName = "Varchar")]
        public string PersonelFoto { get; set; }
        [StringLength(11)]
        [Column(TypeName = "Varchar")]
        public string PersonelSifre { get; set; }
        public DateTime PersonelDT { get; set; }
        [StringLength(15)]
        [Column(TypeName = "Varchar")]
        public string PersonelTelNo { get; set; }
        public bool Cinsiyet { get; set; }
        public bool PersonelDurum { get; set; }

        //DEPARTMAN TABLOSUYLA İŞİLKİ KURULACAK
        public int DepartmanID { get; set; }
        public virtual Departmanlar Departman { get; set; }

        //BİR PERSONEL BİRDEN FAZLA KEZ SATIŞ TABLOSUNDA BULUNUP SATIŞ YAPABİLİR
        public ICollection<Satislar> satislars { get; set; }
        //Sehir Tablomdaki veri birden fazla kez personel tablomda buluna bilir
        public int? SehirID { get; set; }
        public virtual Sehirler Sehirler { get; set; }
    }
}