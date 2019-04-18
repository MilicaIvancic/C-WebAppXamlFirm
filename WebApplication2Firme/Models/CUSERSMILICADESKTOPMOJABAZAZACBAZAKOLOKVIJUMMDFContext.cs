using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication2Firme.Models
{
    public partial class CUSERSMILICADESKTOPMOJABAZAZACBAZAKOLOKVIJUMMDFContext : DbContext
    {
        public CUSERSMILICADESKTOPMOJABAZAZACBAZAKOLOKVIJUMMDFContext()
        {
        }

        public CUSERSMILICADESKTOPMOJABAZAZACBAZAKOLOKVIJUMMDFContext(DbContextOptions<CUSERSMILICADESKTOPMOJABAZAZACBAZAKOLOKVIJUMMDFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Firma> Firma { get; set; }
        public virtual DbSet<FirmaProizvod> FirmaProizvod { get; set; }
        public virtual DbSet<Proizvod> Proizvod { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Milica\\Desktop\\mojaBazaZaC#\\bazaKolokvijum.mdf;Integrated Security=True;Connect Timeout=30");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Firma>(entity =>
            {
                entity.HasKey(e => e.IdFirma);

                entity.Property(e => e.IdFirma).HasColumnName("idFirma");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasColumnName("naziv")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<FirmaProizvod>(entity =>
            {
                entity.HasKey(e => e.IdFirmaProizvod);

                entity.Property(e => e.IdFirmaProizvod).HasColumnName("idFirmaProizvod");

                entity.Property(e => e.Broj).HasColumnName("broj");

                entity.Property(e => e.Datum)
                    .IsRequired()
                    .HasColumnName("datum")
                    .HasMaxLength(50);

                entity.Property(e => e.IdFirma).HasColumnName("idFirma");

                entity.Property(e => e.IdProizvod).HasColumnName("idProizvod");

                entity.HasOne(d => d.IdProizvodNavigation)
                    .WithMany(p => p.FirmaProizvod)
                    .HasForeignKey(d => d.IdProizvod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FirmaProizvod_Firma");

                entity.HasOne(d => d.IdProizvod1)
                    .WithMany(p => p.FirmaProizvod)
                    .HasForeignKey(d => d.IdProizvod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FirmaProizvod_Proizvod");
            });

            modelBuilder.Entity<Proizvod>(entity =>
            {
                entity.HasKey(e => e.IdProizvod);

                entity.Property(e => e.IdProizvod).HasColumnName("idProizvod");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasColumnName("naziv")
                    .HasMaxLength(50);
            });
        }
    }
}
