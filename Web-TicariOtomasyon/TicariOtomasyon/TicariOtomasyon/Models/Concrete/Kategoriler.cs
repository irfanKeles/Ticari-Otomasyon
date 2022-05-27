using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Concrete
{
    public class Kategoriler
    {
        [Key]
        public int KategoriID { get; set; }
        //-------------------------------------------------------
        [StringLength(50)]
        [Column(TypeName = "Varchar")]
        public string KategoriAd { get; set; }
        //-------------------------------------------------------
        public bool KategoriDurum { get; set; }
        //bir kategori birden fazla kez ürün tablosunbda bulunabilir
        public ICollection<Urunlerim> urunlerims { get; set; }
    }
}