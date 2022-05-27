using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicariOtomasyon.Models.Concrete;

namespace TicariOtomasyon.Models.IEnumerable
{
    public class GlobalIEnumerable
    {
        public IEnumerable<Urunlerim> Iurunlerims { get; set; }
        public IEnumerable<YorumPuan> IyorumPuans { get; set; }
        public IEnumerable<Musteriler> Imusterilers { get; set; }
        public IEnumerable<Detay> Idetays { get; set; }
        public IEnumerable<Kategoriler> Ikategorilers { get; set; }
        public IEnumerable<Urunlerim> Ioneri { get; set; }
        public IEnumerable<Personel> Ipersonel { get; set; }
        public IEnumerable<Satislar> Isatis { get; set; }
        public IEnumerable<Faturalar> Ifaturalar { get; set; }
        public IEnumerable<FaturaIcerik> Ifaturaicerik { get; set; }
    }
}