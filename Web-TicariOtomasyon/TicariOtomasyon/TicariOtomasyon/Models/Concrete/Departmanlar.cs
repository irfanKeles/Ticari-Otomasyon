using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Concrete
{
    public class Departmanlar
    {
        [Key]
        public int DepartmanID { get; set; }
        //--------------------------------------------
        [StringLength(50)]
        [Column(TypeName = "Varchar")]
        public string DepartmanAd { get; set; }
        //--------------------------------------------
        public bool DepartmanDurum { get; set; }

        //BİR DEPAERTMAN BİRDEN FAZLA KEZ PERSONEL TABLOSUNDA BULUNA BİLİR
        public ICollection<Personel> personels { get; set; }
    }
}