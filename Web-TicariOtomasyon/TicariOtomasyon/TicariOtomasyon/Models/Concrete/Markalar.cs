using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Concrete
{
    public class Markalar
    {
        [Key]
        public int MarkaID { get; set; }
        [StringLength(50)]
        [Column(TypeName = "Varchar")]
        public string MarkaAd { get; set; }
        [StringLength(500)]
        [Column(TypeName = "Varchar")]
        public string MarkaLogo { get; set; }
        public bool MarkaDurum { get; set; }
        //BiR MARKA BİRDEN ÇOK KEZ URUNLER TABLOSUNA GİDEBİLĞİR
        public ICollection<Urunlerim> urunlerims { get; set; }
    }
}