// Copyright (c) Bruno Sales <me@baliestri.dev>. Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using Challenge02.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Challenge02.Database;

public sealed class AppDbContext : DbContext {
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<Category> Categories { get; set; } = null!;
  public DbSet<Customer> Customers { get; set; } = null!;
  public DbSet<Order> Orders { get; set; } = null!;
  public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
  public DbSet<Product> Products { get; set; } = null!;
  public DbSet<Shipper> Shippers { get; set; } = null!;
  public DbSet<Supplier> Suppliers { get; set; } = null!;
  public DbSet<Payment> Payments { get; set; } = null!;
  public DbSet<User> Users { get; set; } = null!;
}
