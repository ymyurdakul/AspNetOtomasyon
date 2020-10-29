using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace ETicaret.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cari> Carilers { get; set; }
        public DbSet<Departman> Departmans { get; set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<Fatura> Fatulars { get; set; }
        public DbSet<Gider> Gider { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<SatisHareket> SatisHarekets { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }

        public DbSet<Kargo> Kargos { get; set; }
        public DbSet<KargoTakip> KargoTakips { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<FaturaKalem>()
               .HasRequired(e => e.Fatura)
               .WithMany(d => d.FaturaKalems);

            modelBuilder.Entity<Personel>()
                .HasRequired(e => e.Departman)
                .WithMany(d => d.Personels);

            modelBuilder.Entity<SatisHareket>()
              .HasRequired(e => e.Personel)
              .WithMany(d => d.SatisHarekets);

            modelBuilder.Entity<SatisHareket>()
          .HasRequired(e => e.Cari)
          .WithMany(d => d.SatisHarekets);

            base.OnModelCreating(modelBuilder);
        }
    }
}