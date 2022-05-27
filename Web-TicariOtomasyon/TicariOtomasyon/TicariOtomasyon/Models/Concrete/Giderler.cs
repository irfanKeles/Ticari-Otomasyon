using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Concrete
{
    public class Giderler
    {
        [Key]
        public int GiderID { get; set; }
        [StringLength(100)]
        [Column(TypeName = "Varchar")]
        public string GiderAciklama { get; set; }
        public DateTime GiderTarih { get; set; }
        public decimal GiderTutar { get; set; }
        public bool GiderDurum { get; set; }
    }
}