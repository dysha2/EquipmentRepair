using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EquipmentRepair.Models
{
    public partial class EquipmentRepairContext : DbContext
    {
        public EquipmentRepairContext()
        {
        }

        public EquipmentRepairContext(DbContextOptions<EquipmentRepairContext> options)
            : base(options)
        {

        }

        public virtual DbSet<DataForLogin> DataForLogins { get; set; } = null!;
        public virtual DbSet<Manager> Managers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderInWork> OrderInWorks { get; set; } = null!;
        public virtual DbSet<OrderPriority> OrderPriorities { get; set; } = null!;
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public virtual DbSet<SalePoint> SalePoints { get; set; } = null!;
        public virtual DbSet<Specialist> Specialists { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB;Database = EquipmentRepair;Integrated Security = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataForLogin>(entity =>
            {
                entity.ToTable("DataForLogin");

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(200);
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("Manager");

                entity.HasIndex(e => e.DataForLoginId, "IX_Manager")
                    .IsUnique();

                entity.Property(e => e.FullName).HasMaxLength(80);

                entity.HasOne(d => d.DataForLogin)
                    .WithOne(p => p.Manager)
                    .HasForeignKey<Manager>(d => d.DataForLoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Manager_DataForLogin1");

                entity.HasOne(d => d.SalePoint)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.SalePointId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Manager_SalePoint");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(220);

                entity.HasOne(d => d.OrderPriority)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderPriorityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_OrderPriority");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_OrderStatus");

                entity.HasOne(d => d.SalePoint)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.SalePointId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_SalePoint");
            });

            modelBuilder.Entity<OrderInWork>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("OrderInWork");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.Comment).HasMaxLength(200);

                entity.Property(e => e.DateEnd).HasColumnType("date");

                entity.Property(e => e.DateStart).HasColumnType("date");

                entity.HasOne(d => d.Order)
                    .WithOne(p => p.OrderInWork)
                    .HasForeignKey<OrderInWork>(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderInWork_Order");

                entity.HasOne(d => d.Specialist)
                    .WithMany(p => p.OrderInWorks)
                    .HasForeignKey(d => d.SpecialistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderInWork_Specialist");
            });

            modelBuilder.Entity<OrderPriority>(entity =>
            {
                entity.ToTable("OrderPriority");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("OrderStatus");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<SalePoint>(entity =>
            {
                entity.ToTable("SalePoint");

                entity.Property(e => e.Address).HasMaxLength(70);

                entity.Property(e => e.Phone).HasMaxLength(30);
            });

            modelBuilder.Entity<Specialist>(entity =>
            {
                entity.ToTable("Specialist");

                entity.HasIndex(e => e.DataForLoginId, "IX_Specialist")
                    .IsUnique();

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(30);

                entity.HasOne(d => d.DataForLogin)
                    .WithOne(p => p.Specialist)
                    .HasForeignKey<Specialist>(d => d.DataForLoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Specialist_DataForLogin1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
