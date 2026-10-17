// Author: NHH

using Microsoft.EntityFrameworkCore;
using NetCoreLA7NHH.Models;

namespace NetCoreLA7NHH.Data
{
    public class NHHAppDbContext : DbContext
    {
        public NHHAppDbContext(DbContextOptions<NHHAppDbContext> options) : base(options)
        {
        }

        public DbSet<NHHCategory> NHHCategories { get; set; }

        public DbSet<NHHProduct> NHHProducts { get; set; }

        public DbSet<NHHBanner> NHHBanners { get; set; }

        public DbSet<NHHBlog> NHHBlogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NHHCategory>(e =>
            {
                e.HasIndex(x => x.Name).IsUnique();
                e.Property(x => x.Status).HasColumnType("tinyint");
                e.Property(x => x.CreatedDate).HasColumnType("date");
                e.Property(x => x.Image).HasColumnType("varchar(100)");
                e.Property(x => x.Description).HasColumnType("nvarchar(350)");
            });

            modelBuilder.Entity<NHHProduct>(e =>
            {
                e.HasIndex(x => x.Name).IsUnique();
                e.Property(x => x.Price).HasColumnType("float");
                e.Property(x => x.SalePrice).HasColumnType("float");
                e.Property(x => x.Status).HasColumnType("tinyint");
                e.Property(x => x.CreatedDate).HasColumnType("date");
                e.Property(x => x.Image).HasColumnType("varchar(100)");
                e.Property(x => x.Description).HasColumnType("nvarchar(350)");
                e.HasOne(x => x.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(x => x.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<NHHBanner>(e =>
            {
                e.HasIndex(x => x.Name).IsUnique();
                e.Property(x => x.Status).HasColumnType("tinyint");
                e.Property(x => x.Image).HasColumnType("varchar(100)");
                e.Property(x => x.Description).HasColumnType("nvarchar(350)");
            });

            modelBuilder.Entity<NHHBlog>(e =>
            {
                e.HasIndex(x => x.Name).IsUnique();
                e.Property(x => x.Status).HasColumnType("tinyint");
                e.Property(x => x.CreatedDate).HasColumnType("date");
                e.Property(x => x.Image).HasColumnType("varchar(100)");
                e.Property(x => x.Description).HasColumnType("nvarchar(350)");
            });
        }
    }
}
