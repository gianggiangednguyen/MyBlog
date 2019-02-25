using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyBlog.Models
{
    public partial class MyBlogDbContext : DbContext
    {
        public MyBlogDbContext()
        {
        }

        public MyBlogDbContext(DbContextOptions<MyBlogDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blogs> Blogs { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Blogs>(entity =>
            {
                entity.Property(e => e.BlogId)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Category).IsUnicode(false);

                entity.Property(e => e.UserCreate).IsUnicode(false);

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("FK_Blogs_Categories");

                entity.HasOne(d => d.UserCreateNavigation)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.UserCreate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Blogs_Users");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.CategoryId)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}