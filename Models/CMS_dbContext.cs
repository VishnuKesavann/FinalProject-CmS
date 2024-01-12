using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FinalProject.Models
{
    public partial class CMS_dbContext : DbContext
    {
        public CMS_dbContext()
        {
        }

        public CMS_dbContext(DbContextOptions<CMS_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Billgen> Billgen { get; set; }
        public virtual DbSet<Diagno> Diagno { get; set; }
        public virtual DbSet<Doc> Doc { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Recep> Recep { get; set; }
        public virtual DbSet<Ulogin> Ulogin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = VISHNU\\SQLEXPRESS; Initial Catalog = CMS_db; Integrated security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.AId)
                    .HasName("PK__appointm__566AFA9AF40938AA");

                entity.ToTable("appointment");

                entity.Property(e => e.AId).HasColumnName("a_id");

                entity.Property(e => e.ADate)
                    .HasColumnName("a_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.AStatus)
                    .HasColumnName("a_status")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Scheduled')");

                entity.Property(e => e.DId).HasColumnName("d_id");

                entity.Property(e => e.PId).HasColumnName("p_id");

                entity.Property(e => e.PPhno).HasColumnName("p_phno");

                entity.Property(e => e.PReason)
                    .HasColumnName("p_reason")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.D)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.DId)
                    .HasConstraintName("FK__appointmen__d_id__46E78A0C");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.PId)
                    .HasConstraintName("FK__appointmen__p_id__45F365D3");
            });

            modelBuilder.Entity<Billgen>(entity =>
            {
                entity.HasKey(e => e.BId)
                    .HasName("PK__billgen__4E29C30DE47FC18F");

                entity.ToTable("billgen");

                entity.Property(e => e.BId).HasColumnName("b_id");

                entity.Property(e => e.AId).HasColumnName("a_id");

                entity.Property(e => e.BStatus)
                    .HasColumnName("b_status")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Unpaid')");

                entity.Property(e => e.PId).HasColumnName("p_id");

                entity.HasOne(d => d.A)
                    .WithMany(p => p.Billgen)
                    .HasForeignKey(d => d.AId)
                    .HasConstraintName("FK__billgen__a_id__4AB81AF0");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.Billgen)
                    .HasForeignKey(d => d.PId)
                    .HasConstraintName("FK__billgen__p_id__4BAC3F29");
            });

            modelBuilder.Entity<Diagno>(entity =>
            {
                entity.HasKey(e => e.RepId)
                    .HasName("PK__diagno__DC905AF4E80914AE");

                entity.ToTable("diagno");

                entity.Property(e => e.RepId).HasColumnName("rep_id");

                entity.Property(e => e.AId).HasColumnName("a_id");

                entity.Property(e => e.DNotes)
                    .HasColumnName("d_notes")
                    .HasColumnType("text");

                entity.Property(e => e.DPres)
                    .HasColumnName("d_pres")
                    .HasColumnType("text");

                entity.Property(e => e.LabTest)
                    .HasColumnName("lab_test")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PDiag)
                    .HasColumnName("p_diag")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PId).HasColumnName("p_id");

                entity.Property(e => e.PMed)
                    .HasColumnName("p_med")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.A)
                    .WithMany(p => p.Diagno)
                    .HasForeignKey(d => d.AId)
                    .HasConstraintName("FK__diagno__a_id__4E88ABD4");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.Diagno)
                    .HasForeignKey(d => d.PId)
                    .HasConstraintName("FK__diagno__p_id__4F7CD00D");
            });

            modelBuilder.Entity<Doc>(entity =>
            {
                entity.HasKey(e => e.DId)
                    .HasName("PK__doc__D95F582BB3F90F8A");

                entity.ToTable("doc");

                entity.HasIndex(e => e.UId)
                    .HasName("UQ__doc__B51D3DEBA23AC4D5")
                    .IsUnique();

                entity.Property(e => e.DId).HasColumnName("d_id");

                entity.Property(e => e.ConFee).HasColumnName("con_fee");

                entity.Property(e => e.DName)
                    .IsRequired()
                    .HasColumnName("d_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DSpec)
                    .HasColumnName("d_spec")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UId).HasColumnName("u_id");

                entity.HasOne(d => d.U)
                    .WithOne(p => p.Doc)
                    .HasForeignKey<Doc>(d => d.UId)
                    .HasConstraintName("FK__doc__u_id__3B75D760");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PK__patient__82E06B91FF93A874");

                entity.ToTable("patient");

                entity.Property(e => e.PId).HasColumnName("p_id");

                entity.Property(e => e.PAddress)
                    .HasColumnName("p_address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PAge).HasColumnName("p_age");

                entity.Property(e => e.PDiag)
                    .HasColumnName("p_diag")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PDov)
                    .HasColumnName("p_dov")
                    .HasColumnType("date");

                entity.Property(e => e.PGender)
                    .HasColumnName("p_gender")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PName)
                    .IsRequired()
                    .HasColumnName("p_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PPhno).HasColumnName("p_phno");

                entity.Property(e => e.PPres)
                    .HasColumnName("p_pres")
                    .HasColumnType("text");

                entity.Property(e => e.RId).HasColumnName("r_id");

                entity.HasOne(d => d.R)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.RId)
                    .HasConstraintName("FK__patient__r_id__4222D4EF");
            });

            modelBuilder.Entity<Recep>(entity =>
            {
                entity.HasKey(e => e.RId)
                    .HasName("PK__recep__C4762327DE7F030D");

                entity.ToTable("recep");

                entity.HasIndex(e => e.UId)
                    .HasName("UQ__recep__B51D3DEBDA5E94FE")
                    .IsUnique();

                entity.Property(e => e.RId).HasColumnName("r_id");

                entity.Property(e => e.RName)
                    .IsRequired()
                    .HasColumnName("r_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UId).HasColumnName("u_id");

                entity.HasOne(d => d.U)
                    .WithOne(p => p.Recep)
                    .HasForeignKey<Recep>(d => d.UId)
                    .HasConstraintName("FK__recep__u_id__3F466844");
            });

            modelBuilder.Entity<Ulogin>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__ulogin__DD70126414E793DE");

                entity.ToTable("ulogin");

                entity.HasIndex(e => e.Uname)
                    .HasName("UQ__ulogin__C7D2484EA28AD2FB")
                    .IsUnique();

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Uname)
                    .IsRequired()
                    .HasColumnName("uname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Upwd)
                    .IsRequired()
                    .HasColumnName("upwd")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
