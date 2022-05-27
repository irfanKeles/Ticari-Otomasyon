using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Concrete
{
    public class KargoDetay
    {
        [Key]
        public int KTid { get; set; }
        //---------------------------------------
        [Column(TypeName = "VarChar")]
        [StringLength(300)]
        public string Aciklama { get; set; }
        //---------------------------------------
        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        public string TakipKodu { get; set; }
        //---------------------------------------
        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string Alici { get; set; }
        //---------------------------------------
        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string Personel { get; set; }
        //---------------------------------------
        public DateTime Tarih { get; set; }
        //---------------------------------------
        public bool KargoDurum { get; set; }
    }
}