using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TicariOtomasyon.Models.Kategori_urun
{
    public class KategoriUrunList
    {
        public IEnumerable<SelectListItem> KATEGORILER { get; set; }
        public IEnumerable<SelectListItem> URUNLER { get; set; }
    }
}