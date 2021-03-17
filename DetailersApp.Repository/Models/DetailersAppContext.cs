using System;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DetailersApp.Repository.Models
{
    public partial class DetailersAppContext : DbContext
    {
        public DetailersAppContext()
        {
        }

        public DetailersAppContext(DbContextOptions<DetailersAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PotentialCustomer> PotentialCustomers { get; set; }
        public virtual DbSet<RealCustomer> RealCustomers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:detailers-app.database.windows.net,1433;Initial Catalog=DetailersApp;Persist Security Info=False;User ID=jvargas;Password=admin123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<PotentialCustomer>(entity =>
            {
                entity.ToTable("PotentialCustomer");

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.RealCustomer)
                    .WithMany(p => p.InverseRealCustomer)
                    .HasForeignKey(d => d.RealCustomerId)
                    .HasConstraintName("FK__Potential__RealC__656C112C");
            });

            modelBuilder.Entity<RealCustomer>(entity =>
            {
                entity.ToTable("RealCustomer");

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.PotentialCustomer)
                    .WithMany(p => p.RealCustomers)
                    .HasForeignKey(d => d.PotentialCustomerId)
                    .HasConstraintName("FK__RealCusto__Poten__6477ECF3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
