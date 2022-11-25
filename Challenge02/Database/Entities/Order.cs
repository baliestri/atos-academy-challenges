// Copyright (c) Bruno Sales <me@baliestri.dev>. Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using System.ComponentModel.DataAnnotations;
using Challenge02.Attributes;

namespace Challenge02.Database.Entities;

public sealed class Order : Entity {
  //public Guid CustomerId { get; set; }

  [SkipProperty]
  public Customer Customer { get; set; } = null!;

  public DateTime OrderDate { get; set; }
  public DateTime ShipDate { get; set; }

  //public Guid ShipperId { get; set; }

  [SkipProperty]
  public Shipper Shipper { get; set; } = null!;

  public decimal Total { get; set; }
  public bool IsActive { get; set; }

  //public Guid PaymentId { get; set; }

  [SkipProperty]
  [Required]
  public Payment Payment { get; set; } = null!;
}

public sealed class OrderDetail : Entity {
  //public Guid OrderId { get; set; }

  [SkipProperty]
  public Order Order { get; set; } = null!;

  //public Guid ProductId { get; set; }

  [SkipProperty]
  public Product Product { get; set; } = null!;

  public int Quantity { get; set; }
  public decimal TotalPrice { get; set; }
}
