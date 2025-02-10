using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM;

public class DefaultContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<SaleProduct> SaleProducts { get; set; }


    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Sale>()
            .HasOne(s => s.Customer) 
            .WithMany(c => c.Sales)
            .HasForeignKey(s => s.CustomerId);

        modelBuilder.Entity<SaleProduct>()
            .HasKey(sp => new { sp.SaleId, sp.ProductId }); 

        modelBuilder.Entity<SaleProduct>()
            .HasOne(sp => sp.Sale)
            .WithMany(s => s.SaleProducts)
            .HasForeignKey(sp => sp.SaleId);

        modelBuilder.Entity<SaleProduct>()
            .HasOne(sp => sp.Product)
            .WithMany(p => p.SaleProducts)
            .HasForeignKey(sp => sp.ProductId);

        base.OnModelCreating(modelBuilder);
    }
}
public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
{
    public DefaultContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<DefaultContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseSqlServer(
               connectionString,
               b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.WebApi")
        );

        return new DefaultContext(builder.Options);
    }
}