using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Concrete
{
    public class Yapilacaklar
    {
        [Key]
        public int YapilacakID { get; set; }
        //--------------------------------------
        [Column(TypeName ="Varchar")]
        [StringLength(100)]
        public string YIcerik { get; set; }
        //--------------------------------------
        [Column(TypeName ="bit")]
        public bool YDurum { get; set; }
    }
}