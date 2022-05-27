using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Concrete
{
    public class FaturaIcerik
    {
        [Key]
        public int FaturaIcerikID { get; set; }
        [StringLength(30)]
        [Column(TypeName = "Varchar")]
        public string FaturaAcıklama { get; set; }
        public int FaturaMiktar { get; set; }
        public decimal FaturaBirimFiyat { get; set; }
        public decimal FaturaTutar { get; set; }
        public bool FaturaDurum { get; set; }

        //BİR FATURA İÇERİK BVİRDEN FAZLA KEZ FATURALAR TABLOMA GELEBİLİr
        public int FaturaID { get; set; }
        public virtual Faturalar Faturalar { get; set; }

    }
}