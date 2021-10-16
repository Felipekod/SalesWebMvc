using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

namespace SalesWebMvc.Models
{
    public class SalesMvcContext : DbContext
    {
        public SalesMvcContext (DbContextOptions<SalesMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Departement> Departement { get; set; }
        public DbSet<Vendeur> Vendeur { get; set; }
        public DbSet<EnregistrementVentes> EnregistrementVentes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departement>(entity =>
            {
                entity.HasKey(e => e.Id).IsClustered(false);

                entity.ToTable("departement");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Nom).HasMaxLength(50).HasColumnName("Nom");

            });

            modelBuilder.Entity<Vendeur>(entity =>
            {
                entity.HasKey(e => e.Id).IsClustered(false);

                entity.ToTable("vendeur");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.NomComplet).HasMaxLength(50).HasColumnName("NomComplet");

                entity.Property(e => e.Email).HasMaxLength(50).HasColumnName("Email");

                entity.Property(e => e.DateNaissance).HasColumnType("date").HasColumnName("DateNaissance");

                entity.Property(e => e.SalaireBase).HasColumnName("SalaireBase");

                entity.HasOne(d => d.Departament)
                    .WithMany(p => p.Vendeurs)
                    .HasForeignKey(d => d.Id);

            });
        }
    }
}