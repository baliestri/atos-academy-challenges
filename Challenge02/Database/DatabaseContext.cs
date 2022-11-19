// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using Challenge02.Entities;
using Microsoft.Extensions.Logging;

namespace Challenge02.Database;

public sealed class DatabaseContext {
  public DatabaseSet<Category> Categories { get; }
  public DatabaseSet<Customer> Customers { get; }
  public DatabaseSet<Order> Orders { get; }
  public DatabaseSet<OrderDetail> OrderDetails { get; }
  public DatabaseSet<Product> Products { get; }
  public DatabaseSet<Shipper> Shippers { get; }
  public DatabaseSet<Supplier> Suppliers { get; }
  public DatabaseSet<Payment> Payments { get; }
  public DatabaseSet<User> Users { get; }

  public DatabaseContext(ILogger<DatabaseContext> logger) {
    logger.LogInformation("Initializing database context...");
    Categories = new DatabaseSet<Category>();
    Customers = new DatabaseSet<Customer>();
    Orders = new DatabaseSet<Order>();
    OrderDetails = new DatabaseSet<OrderDetail>();
    Products = new DatabaseSet<Product>();
    Shippers = new DatabaseSet<Shipper>();
    Suppliers = new DatabaseSet<Supplier>();
    Payments = new DatabaseSet<Payment>();
    Users = new DatabaseSet<User>();
    logger.LogInformation("Database context initialized.");
  }
}
