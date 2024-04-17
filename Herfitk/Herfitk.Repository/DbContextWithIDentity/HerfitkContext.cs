using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Herfitk.Core.Models.Data;

public partial class HerfitkContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
{
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

    public virtual DbSet<Staff> Staff { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AppUser>(entity =>
        {
            modelBuilder.Entity<AppUser>()
                .HasOne(u => u.Role)
                .WithOne()
                .HasForeignKey<AppUser>(u => u.UserRoleID);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC279B2D105D");

            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryName).HasMaxLength(100);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Client__3214EC272790489E");

            entity.ToTable("Client");

            entity.HasIndex(e => e.UserId, "IX_Client_User_ID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.ClientUser).WithOne(p => p.UserClient)
                        .HasForeignKey<Client>(d => d.UserId)
                .HasConstraintName("FK__Client__User_ID__3F466844");
        });

        modelBuilder.Entity<ClientHerify>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Client_H__3214EC27824A65FA");

            entity.ToTable("Client_Herify");

            entity.HasIndex(e => e.ClientId, "IX_Client_Herify_Client_ID");

            entity.HasIndex(e => e.HerifyId, "IX_Client_Herify_Herify_ID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClientId).HasColumnName("Client_ID");
            entity.Property(e => e.ClientReview).HasColumnName("Client_Review");
            entity.Property(e => e.HerifyId).HasColumnName("Herify_ID");

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

            entity.HasIndex(e => e.UserId, "IX_Herfiy_User_ID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Speciality).HasMaxLength(100);
            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.Zone).HasMaxLength(100);

            entity.HasOne(d => d.HerfiyUser).WithOne(p => p.UserHerify)
            .HasForeignKey<Herfiy>(d => d.UserId)
                .HasConstraintName("FK__Herfiy__User_ID__4222D4EF");
        });

        modelBuilder.Entity<HerifyCategory>(entity =>
        {
            modelBuilder.Entity<HerifyCategory>()
            .HasKey(hc => new { hc.CategoryId, hc.HerifyId });

            entity.HasIndex(e => e.CategoryId, "IX_Herify_Category_Category_ID");

            entity.HasIndex(e => e.HerifyId, "IX_Herify_Category_Herify_ID");

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

            entity.HasIndex(e => e.HerifyId, "IX_Payment_Herify_ID");

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
        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Staff__3214EC27832438F9");

            entity.HasIndex(e => e.UserId, "IX_Staff_User_ID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.HireDate).HasColumnName("Hire_Date");
            entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.WorkHours).HasColumnName("Work_Hours");

            entity.HasOne(d => d.StaffUser).WithOne(p => p.UserStaff)
            .HasForeignKey<Staff>(d => d.UserId)

                .HasConstraintName("FK__Staff__User_ID__3C69FB99");
        });

        //OnModelCreatingPartial(modelBuilder);
    }

    //private partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}