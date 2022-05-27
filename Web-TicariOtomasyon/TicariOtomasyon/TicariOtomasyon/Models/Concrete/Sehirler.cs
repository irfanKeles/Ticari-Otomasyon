using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Concrete
{
    public class Sehirler
    {
        [Key]
        public int SehirID { get; set; }
        //---------------------------------------------
        [Column(TypeName ="Varchar")]
        [StringLength(14)]
        public string SehirAd { get; set; }
        //---------------------------------------------
        public bool SehirDurum { get; set; }
        //---------------------------------------------
        //İLİŞKİLER
        public ICollection<Personel> personels { get; set; }
        //---------------------------------------------
        public ICollection<Musteriler> musterilers { get; set; }

    }
}