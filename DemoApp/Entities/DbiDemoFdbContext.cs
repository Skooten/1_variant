using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Entities;

public partial class DbiDemoFdbContext : DbContext
{
    public DbiDemoFdbContext()
    {
    }

    public DbiDemoFdbContext(DbContextOptions<DbiDemoFdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<MaterialSupplier> MaterialSuppliers { get; set; }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<SupplierType> SupplierTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseFirebird("DataSource=localhost;Port=3050;Database=/dbi/demo.fdb;Username=sysdba;Password=xxXX12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("RDB$PRIMARY3");

            entity.ToTable("MATERIAL");

            entity.HasIndex(e => e.MaterialType, "RDB$FOREIGN4");

            entity.HasIndex(e => e.MaterialId, "RDB$PRIMARY3").IsUnique();

            entity.Property(e => e.MaterialId).HasColumnName("MATERIAL_ID");
            entity.Property(e => e.MaterialName)
                .HasMaxLength(100)
                .HasColumnName("MATERIAL_NAME");
            entity.Property(e => e.MaterialType).HasColumnName("MATERIAL_TYPE");
            entity.Property(e => e.MinimalQuantity)
                .HasColumnType("DECIMAL(15,2)")
                .HasColumnName("MINIMAL_QUANTITY");
            entity.Property(e => e.QuantityInStock)
                .HasColumnType("DECIMAL(15,2)")
                .HasColumnName("QUANTITY_IN_STOCK");
            entity.Property(e => e.QuantityPerPackage)
                .HasColumnType("DECIMAL(15,2)")
                .HasColumnName("QUANTITY_PER_PACKAGE");
            entity.Property(e => e.Unit)
                .HasMaxLength(5)
                .HasColumnName("UNIT");
            entity.Property(e => e.UnitCost)
                .HasColumnType("DECIMAL(15,2)")
                .HasColumnName("UNIT_COST");

            entity.HasOne(d => d.MaterialTypeNavigation).WithMany(p => p.Materials)
                .HasForeignKey(d => d.MaterialType)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("INTEG_4");
        });

        modelBuilder.Entity<MaterialSupplier>(entity =>
        {
            entity.HasKey(e => e.MaterialSupplierId).HasName("RDB$PRIMARY8");

            entity.ToTable("MATERIAL_SUPPLIER");

            entity.HasIndex(e => e.MaterialName, "RDB$FOREIGN10");

            entity.HasIndex(e => e.SupplierName, "RDB$FOREIGN9");

            entity.HasIndex(e => e.MaterialSupplierId, "RDB$PRIMARY8").IsUnique();

            entity.Property(e => e.MaterialSupplierId).HasColumnName("MATERIAL_SUPPLIER_ID");
            entity.Property(e => e.MaterialName).HasColumnName("MATERIAL_NAME");
            entity.Property(e => e.SupplierName).HasColumnName("SUPPLIER_NAME");

            entity.HasOne(d => d.MaterialNameNavigation).WithMany(p => p.MaterialSuppliers)
                .HasForeignKey(d => d.MaterialName)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("INTEG_10");

            entity.HasOne(d => d.SupplierNameNavigation).WithMany(p => p.MaterialSuppliers)
                .HasForeignKey(d => d.SupplierName)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("INTEG_9");
        });

        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.HasKey(e => e.MaterialTypeId).HasName("RDB$PRIMARY2");

            entity.ToTable("MATERIAL_TYPE");

            entity.HasIndex(e => e.MaterialTypeId, "RDB$PRIMARY2").IsUnique();

            entity.Property(e => e.MaterialTypeId).HasColumnName("MATERIAL_TYPE_ID");
            entity.Property(e => e.MaterialTypeName)
                .HasMaxLength(100)
                .HasColumnName("MATERIAL_TYPE_NAME");
            entity.Property(e => e.PercentageDefectiveMaterial)
                .HasColumnType("DECIMAL(5,4)")
                .HasColumnName("PERCENTAGE_DEFECTIVE_MATERIAL");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.ProductTypeId).HasName("RDB$PRIMARY1");

            entity.ToTable("PRODUCT_TYPE");

            entity.HasIndex(e => e.ProductTypeId, "RDB$PRIMARY1").IsUnique();

            entity.Property(e => e.ProductTypeId).HasColumnName("PRODUCT_TYPE_ID");
            entity.Property(e => e.ProductTypeCoefficient)
                .HasColumnType("DECIMAL(10,2)")
                .HasColumnName("PRODUCT_TYPE_COEFFICIENT");
            entity.Property(e => e.ProductTypeName)
                .HasMaxLength(100)
                .HasColumnName("PRODUCT_TYPE_NAME");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("RDB$PRIMARY6");

            entity.ToTable("SUPPLIER");

            entity.HasIndex(e => e.SupplierType, "RDB$FOREIGN7");

            entity.HasIndex(e => e.SupplierId, "RDB$PRIMARY6").IsUnique();

            entity.Property(e => e.SupplierId).HasColumnName("SUPPLIER_ID");
            entity.Property(e => e.SupplierDate)
                .HasColumnType("DATE")
                .HasColumnName("SUPPLIER_DATE");
            entity.Property(e => e.SupplierInn)
                .HasMaxLength(100)
                .HasColumnName("SUPPLIER_INN");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(100)
                .HasColumnName("SUPPLIER_NAME");
            entity.Property(e => e.SupplierRating).HasColumnName("SUPPLIER_RATING");
            entity.Property(e => e.SupplierType).HasColumnName("SUPPLIER_TYPE");

            entity.HasOne(d => d.SupplierTypeNavigation).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.SupplierType)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("INTEG_7");
        });

        modelBuilder.Entity<SupplierType>(entity =>
        {
            entity.HasKey(e => e.SupplierTypeId).HasName("RDB$PRIMARY5");

            entity.ToTable("SUPPLIER_TYPE");

            entity.HasIndex(e => e.SupplierTypeId, "RDB$PRIMARY5").IsUnique();

            entity.Property(e => e.SupplierTypeId).HasColumnName("SUPPLIER_TYPE_ID");
            entity.Property(e => e.SupplierTypeName)
                .HasMaxLength(100)
                .HasColumnName("SUPPLIER_TYPE_NAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
