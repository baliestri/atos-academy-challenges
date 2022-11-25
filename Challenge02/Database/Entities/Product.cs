// Copyright (c) Bruno Sales <me@baliestri.dev>. Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using Challenge02.Attributes;

namespace Challenge02.Database.Entities;

public sealed class Product : Entity {
  public string Name { get; set; } = null!;
  public string Description { get; set; } = null!;
  public decimal UnitPrice { get; set; }
  public bool IsActive { get; set; }

  //public Guid CategoryId { get; set; }

  [SkipProperty]
  public Category Category { get; set; } = null!;

  //public Guid SupplierId { get; set; }

  [SkipProperty]
  public Supplier Supplier { get; set; } = null!;
}
