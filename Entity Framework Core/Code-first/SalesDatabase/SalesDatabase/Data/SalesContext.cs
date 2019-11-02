namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connection.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(e =>
            {
                e.HasKey(k => k.ProductId);

                e.Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

                e.Property(p => p.Description)
                .HasMaxLength(250)
                .IsRequired(false)
                .IsUnicode(true)
                .HasDefaultValue("No description");

                e.Property(p => p.Price)
                .IsRequired(true);

            });

            modelBuilder.Entity<Sale>(e =>
            {
                e.HasKey(k => k.SaleId);

                e.Property(p => p.Date)
                .IsRequired(true)
                .HasColumnType("DATETIME2")
                .HasDefaultValueSql("GETDATE()");

                e.HasOne(s => s.Product)
                .WithMany(p => p.Sales)
                .HasForeignKey(s => s.ProductId);

                e.HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerId);

                e.HasOne(s => s.Store)
                .WithMany(st => st.Sales)
                .HasForeignKey(s => s.StoreId);
            });

            modelBuilder.Entity<Store>(e =>
            {
                e.HasKey(st => st.StoreId);

                e.Property(p => p.Name)
                .HasMaxLength(80)
                .IsUnicode(true)
                .IsRequired(true);

            });

            modelBuilder.Entity<Customer>(e =>
            {
                e.HasKey(c => c.CustomerId);

                e.Property(p => p.Name)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired(true);

                e.Property(p => p.Email)
                .HasMaxLength(80)
                .IsUnicode(false);

                e.Property(p => p.CreditCardNumber)
                .IsRequired(true);

            });
        }

    }
}
