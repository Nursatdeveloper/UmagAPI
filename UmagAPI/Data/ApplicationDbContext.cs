using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using UmagAPI.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace UmagAPI.Data {
    public class ApplicationDbContext : DbContext{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

        }

        public DbSet<Sale> TbSales{ get; set; }
        public DbSet<Supply> TbSupplies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Supply>()
                .ToTable("tbsupplies", schema: "application")
                .HasIndex(b => new { b.Barcode, b.SupplyTime });

            modelBuilder.Entity<Sale>()
                .ToTable("tbsales", schema: "application")
                .HasIndex(b => new { b.Barcode, b.SaleTime });

        }
    }
}
