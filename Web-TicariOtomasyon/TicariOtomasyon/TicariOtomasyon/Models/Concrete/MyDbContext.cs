using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Concrete
{
    public class MyDbContext : DbContext
    {
        public DbSet<Kategoriler> kategorilers { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Departmanlar> departmanlars { get; set; }
        public DbSet<FaturaIcerik> faturaIceriks { get; set; }
        public DbSet<Faturalar> faturalars { get; set; }
        public DbSet<Giderler> giderlers { get; set; }
        public DbSet<Markalar> Markalars { get; set; }
        public DbSet<Musteriler> musterilers { get; set; }
        public DbSet<Personel> personels { get; set; }
        public DbSet<Satislar> satislars { get; set; }
        public DbSet<Urunlerim> urunlerims { get; set; }
        public DbSet<Detay> detays { get; set; }
        public DbSet<YorumPuan> yorumPuans { get; set; }
        public DbSet<Sehirler> sehirlers { get; set; }
        public DbSet<Yapilacaklar> yapilacaklars { get; set; }
        public DbSet<KargoDetay> kargoDetays { get; set; }
        public DbSet<KargoTakip> kargoTakips { get; set; }
        public DbSet<Mesajlar> mesajlars { get; set; }
    }
}