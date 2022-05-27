using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Concrete
{
    public class Musteriler
    {
        [Key]
        public int MusteriID { get; set; }
        //----------------------------------------
        [Display(Name ="Müşteri Adı")]
        [StringLength(25)]
        [Column(TypeName = "Varchar")]
        public string MusteriAD { get; set; }
        //----------------------------------------
        [StringLength(25)]
        [Column(TypeName = "Varchar")]
        public string MusteriSoyad { get; set; }
        //----------------------------------------
        [StringLength(11)]
        [Column(TypeName = "Varchar")]
        public string MusteriSifre { get; set; }
        //----------------------------------------
        [StringLength(15)]
        [Column(TypeName = "Varchar")]
        public string MusteriTelNo { get; set; }
        //----------------------------------------
        [StringLength(500)]
        [Column(TypeName = "Varchar")]
        public string MusteriFoto { get; set; }
        //----------------------------------------
        [StringLength(250)]
        [Column(TypeName = "Varchar")]
        public string MusteriAdres { get; set; }
        //----------------------------------------
        [StringLength(25)]
        [Column(TypeName = "Varchar")]
        public string MusteriMail { get; set; }
        //----------------------------------------
        [DisplayName("Doğum Tarihi")]
        public DateTime MusteriDT { get; set; }
        //----------------------------------------
        public bool Cinsiyet { get; set; }
        //----------------------------------------
        public bool MusteriDurum { get; set; }
        //----------------------------------------
        //SATIŞ TABLOMLA İLİŞKİLENECEK
        public ICollection<Satislar> satislars { get; set; }
        //----------------------------------------
        //SATIŞ TABLOMLA İLİŞKİLENECEK
        public  ICollection<YorumPuan> yorumPuans { get; set; }
        //Sehir  Tablomdaki veriler birden fazla kez müşteri tabloöma gele bilir
        public int? SehirID { get; set; }
        public Sehirler Sehirler { get; set; }
    }
}