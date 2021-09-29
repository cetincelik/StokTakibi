using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StokTakibiEntities.Concrete;

namespace StokTakibiDataAccess.Concrete.EntityFramework.Contexts
{
    public class StokTakibiContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-NMB9USM;initial catalog=DbStokTakibi;integrated security=true");
        }
        // public StokTakibiContext(DbContextOptions<StokTakibiContext> options) : base(options) { }





        public DbSet<Kategoriler> Kategoriler { get; set; }
        public DbSet<Birimler> Birimler { get; set; }
        
        public DbSet<Markalar> Markalar { get; set; }
        public DbSet<Musteriler> Musteriler { get; set; }
        public DbSet<Satislar> Satislar { get; set; }
        public DbSet<Sepet> Sepet { get; set; }
        public DbSet<Urunler> Urunler { get; set; }


        public DbSet<Kullanicilar> Kullanicilar{ get; set; }
        public DbSet<KullaniciRolleri> KullaniciRolleri{ get; set; }
        public DbSet<Roller> Roller{ get; set; }
       
       
    }
}

