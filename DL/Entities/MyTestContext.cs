using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DL.Entities
{
    public partial class MyTestContext : DbContext
    {
        public MyTestContext()
        {
        }

        public MyTestContext(DbContextOptions<MyTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Admin__UserId__3C34F16F");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.Property(e => e.Cuisine)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Zipcode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.Content)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ReviewDate).HasColumnType("date");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("FK__Reviews__Restaur__395884C4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Reviews__UserId__3864608B");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
