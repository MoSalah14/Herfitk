using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Herfitk.Models;

public partial class HerfitkContext : DbContext
{
    public HerfitkContext()
    {
    }

    public HerfitkContext(DbContextOptions<HerfitkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientHerify> ClientHerifies { get; set; }

    public virtual DbSet<Herfiy> Herfiys { get; set; }

    public virtual DbSet<HerifyCategory> HerifyCategories { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC279B2D105D");

            entity.ToTable("Category");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Type).HasMaxLength(100);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Client__3214EC272790489E");

            entity.ToTable("Client");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.User).WithMany(p => p.Clients)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Client__User_ID__3F466844");
        });

        modelBuilder.Entity<ClientHerify>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Client_H__3214EC27824A65FA");

            entity.ToTable("Client_Herify");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClientId).HasColumnName("Client_ID");
            entity.Property(e => e.ClientReview).HasColumnName("Client_Review");
            entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.HerifyId).HasColumnName("Herify_ID");
            entity.Property(e => e.HerifyReview).HasColumnName("Herify_Review");
            entity.Property(e => e.State).HasMaxLength(50);

            entity.HasOne(d => d.Client).WithMany(p => p.ClientHerifies)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Client_He__Clien__4CA06362");

            entity.HasOne(d => d.Herify).WithMany(p => p.ClientHerifies)
                .HasForeignKey(d => d.HerifyId)
                .HasConstraintName("FK__Client_He__Herif__4D94879B");
        });

        modelBuilder.Entity<Herfiy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Herfiy__3214EC27C698B292");

            entity.ToTable("Herfiy");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Speciality).HasMaxLength(100);
            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.Zone).HasMaxLength(100);

            entity.HasOne(d => d.User).WithMany(p => p.Herfiys)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Herfiy__User_ID__4222D4EF");
        });

        modelBuilder.Entity<HerifyCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Herify_Category");

            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
            entity.Property(e => e.HerifyId).HasColumnName("Herify_ID");

            entity.HasOne(d => d.Category).WithMany()
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Herify_Ca__Categ__49C3F6B7");

            entity.HasOne(d => d.Herify).WithMany()
                .HasForeignKey(d => d.HerifyId)
                .HasConstraintName("FK__Herify_Ca__Herif__48CFD27E");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payment__3214EC2751EE6894");

            entity.ToTable("Payment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.HerifyId).HasColumnName("Herify_ID");
            entity.Property(e => e.PaymentTerm)
                .HasMaxLength(50)
                .HasColumnName("Payment_term");
            entity.Property(e => e.State).HasMaxLength(50);

            entity.HasOne(d => d.Herify).WithMany(p => p.Payments)
                .HasForeignKey(d => d.HerifyId)
                .HasConstraintName("FK__Payment__Herify___46E78A0C");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC27D1EB7E98");

            entity.ToTable("Role");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.User).WithMany(p => p.Roles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Role__User_ID__398D8EEE");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Staff__3214EC27832438F9");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.HireDate).HasColumnName("Hire_Date");
            entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.WorkHours).HasColumnName("Work_Hours");

            entity.HasOne(d => d.User).WithMany(p => p.Staff)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Staff__User_ID__3C69FB99");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC272A074D8C");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountState)
                .HasMaxLength(50)
                .HasColumnName("Account_State");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.NationalId)
                .HasMaxLength(15)
                .HasColumnName("National_ID");
            entity.Property(e => e.NationalIdImage).HasColumnName("NationalID_Image");
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.PersonalImage).HasColumnName("Personal_Image");
            entity.Property(e => e.Phone).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
