using hoicham.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace hoicham.Infrastructure.AppDbContext
{
    public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		// DbSet for each entity
		public DbSet<Customer> Customers { get; set; }
		public DbSet<SaleOrder> SalesOrders { get; set; }
		public DbSet<SaleOrderItem> SalesOrderItems { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }
		public DbSet<AuditLog> AuditLogs { get; set; }
		public DbSet<ProductLocation> ProductLocations { get; set; }
		public DbSet<StockCount> StockCounts { get; set; }
		public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
		public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
		public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
		public DbSet<Warehouse> Warehouses { get; set; }
		public DbSet<ProductImage> ProductImages { get; set; }
		public DbSet<ProductPriceHistory> ProductPriceHistories { get; set; }
		public DbSet<ProductUnit> ProductUnits { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}

