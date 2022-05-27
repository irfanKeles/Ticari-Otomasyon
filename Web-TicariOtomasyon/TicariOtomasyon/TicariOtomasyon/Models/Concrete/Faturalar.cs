using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Concrete
{
    public class Faturalar
    {
        [Key]
        public int FaturaID { get; set; }

        [StringLength(1)]
        [Column(TypeName = "Varchar")]
        public string FaturaSeriNO { get; set; }

        [StringLength(6)]
        [Column(TypeName = "Varchar")]
        public string FaturaSıraNo { get; set; }
        public DateTime FaturaTarih { get; set; }
        public DateTime FaturaSaat { get; set; }
        [StringLength(100)]
        [Column(TypeName = "Varchar")]
        public string FaturaVergiDairesi { get; set; }
        [StringLength(50)]
        [Column(TypeName = "Varchar")]
        public string FaturKesen { get; set; }
        [StringLength(50)]
        [Column(TypeName = "Varchar")]
        public string FaturAlan { get; set; }
        public decimal ToplamTutar { get; set; }
        public bool FaturDurum { get; set; }

        //BİR FATURA virden fazla kesz içerik kısmına gidebilir
        public ICollection<FaturaIcerik> faturaIceriks { get; set; }

    }
}