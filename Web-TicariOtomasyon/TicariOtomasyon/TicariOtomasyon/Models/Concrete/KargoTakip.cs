using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Concrete
{
    public class KargoTakip
    {
        [Key]
        public int KTakipid { get; set; }
        //---------------------------------------
        [Column(TypeName ="VarChar")]
        [StringLength(10)]
        public string TakiipKodu { get; set; }
        //---------------------------------------
        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string Aciklama { get; set; }
        //---------------------------------------
        public DateTime Tarih { get; set; }
        //---------------------------------------
        public bool KargoDurum { get; set; }
    }
}