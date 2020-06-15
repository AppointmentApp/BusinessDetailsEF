using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BusinessDetailsEF.Models
{
    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
        {
        }

        public MyDBContext(DbContextOptions<MyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BusinessDetails> BusinessDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
                var configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessDetails>(entity =>
            {
                entity.HasKey(e => e.Business_Id)
                    .HasName("PK_BusinessDetails_1");

                entity.Property(e => e.Business_Id).HasColumnName("Business_Id");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.Business_Name)
                    .IsRequired()
                    .HasColumnName("Business_Name");

                entity.Property(e => e.BusinessToken).IsRequired();

                entity.Property(e => e.Business_Type)
                    .IsRequired()
                    .HasColumnName("Business_Type");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Contact_Number)
                    .IsRequired()
                    .HasColumnName("Contact_Number")
                    .HasMaxLength(12);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
