using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BusinessDetailsEF.Models
{
    public partial class appointo146updateContext : DbContext
    {
        public appointo146updateContext()
        {
        }

        public appointo146updateContext(DbContextOptions<appointo146updateContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointments> Appointments { get; set; }
        public virtual DbSet<BusinessDetails> BusinessDetails { get; set; }
        public virtual DbSet<Days> Days { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Timings> Timings { get; set; }
        public virtual DbSet<WorkignDays> WorkignDays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-MQOSVD7\\SQLEXPRESS;Initial Catalog=appointo-14-6-update;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointments>(entity =>
            {
                entity.HasKey(e => e.appointmentId)
                    .HasName("PK__Appointm__D06765FEDF54E5A8");

                entity.Property(e => e.Contact)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.address)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.date1).HasColumnType("date");

                entity.Property(e => e.status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.timeSlot)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Business_)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.Business_Id)
                    .HasConstraintName("FK__Appointme__Busin__5535A963");
            });

            modelBuilder.Entity<BusinessDetails>(entity =>
            {
                entity.HasKey(e => e.Business_Id)
                    .HasName("PK_BusinessDetails_1");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.BusinessToken).IsRequired();

                entity.Property(e => e.Business_Name).IsRequired();

                entity.Property(e => e.Business_Type).IsRequired();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Days>(entity =>
            {
                entity.HasKey(e => e.dayId)
                    .HasName("PK__Days__B0FA5F20D1C980AC");

                entity.Property(e => e.dayName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => e.serviceId)
                    .HasName("PK__Services__455070DFC11D1803");

                entity.Property(e => e.serviceName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Business_)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.Business_Id)
                    .HasConstraintName("FK__Services__Busine__5629CD9C");
            });

            modelBuilder.Entity<Timings>(entity =>
            {
                entity.HasKey(e => e.timeId)
                    .HasName("PK__Timings__96546181E0D3E493");

                entity.Property(e => e.endTime)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.startTime)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Business_)
                    .WithMany(p => p.Timings)
                    .HasForeignKey(d => d.Business_id)
                    .HasConstraintName("FK__Timings__Busines__5812160E");
            });

            modelBuilder.Entity<WorkignDays>(entity =>
            {
                entity.HasKey(e => e.workId)
                    .HasName("PK__WorkignD__F2686A38B3DA73A4");

                entity.HasOne(d => d.Business_)
                    .WithMany(p => p.WorkignDays)
                    .HasForeignKey(d => d.Business_Id)
                    .HasConstraintName("FK__WorkignDa__Busin__59063A47");

                entity.HasOne(d => d.day)
                    .WithMany(p => p.WorkignDays)
                    .HasForeignKey(d => d.dayid)
                    .HasConstraintName("FK__WorkignDa__dayid__59FA5E80");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
