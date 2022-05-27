using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Concrete
{
    public class Detay
    {
        [Key]
        public int DetayID { get; set; }
        //-------------------------------------------------------------
        [Column(TypeName ="Varchar")]
        [StringLength(2000)]
        public string Acıklama { get; set; }
        //-------------------------------------------------------------
        // URUN TABLOSU İLE İLİŞKİ
        public int? UrunID { get; set; }
        public virtual Urunlerim Urunlerim { get; set; }

    }
}