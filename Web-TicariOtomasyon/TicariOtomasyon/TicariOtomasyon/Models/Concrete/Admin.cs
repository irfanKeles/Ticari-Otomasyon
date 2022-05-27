using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [StringLength(11)]
        [Column(TypeName = "Varchar")]
        public string AdminKullaniciAd { get; set; }
        [StringLength(11)]
        [Column(TypeName = "Varchar")]
        public string AdminSifre { get; set; }
        [StringLength(1)]
        [Column(TypeName = "Char")]
        public string AdminYetki { get; set; }
        public bool AdminDurum { get; set; }
    }
}