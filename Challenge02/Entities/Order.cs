// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using Challenge02.Attributes;
using Challenge02.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Challenge02.Entities;

public sealed class Order : Entity {
  public Guid CustomerId { get; set; }

  [SkipProperty]
  public Customer Customer
    => Program.Services.GetRequiredService<DatabaseContext>().Customers[CustomerId];

  public DateTime OrderDate { get; set; }
  public DateTime ShipDate { get; set; }

  public Guid ShipperId { get; set; }

  [SkipProperty]
  public Shipper Shipper
    => Program.Services.GetRequiredService<DatabaseContext>().Shippers[ShipperId];

  public decimal Total { get; set; }
  public bool IsActive { get; set; }

  public Guid PaymentId { get; set; }

  [SkipProperty]
  public Payment Payment
    => Program.Services.GetRequiredService<DatabaseContext>().Payments[PaymentId];
}

public sealed class OrderDetail : Entity {
  public Guid OrderId { get; set; }

  [SkipProperty]
  public Order Order
    => Program.Services.GetRequiredService<DatabaseContext>().Orders[OrderId];

  public Guid ProductId { get; set; }

  [SkipProperty]
  public Product Product
    => Program.Services.GetRequiredService<DatabaseContext>().Products[ProductId];

  public int Quantity { get; set; }
  public decimal TotalPrice { get; set; }
}
