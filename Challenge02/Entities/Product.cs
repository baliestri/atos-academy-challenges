// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using Challenge02.Attributes;
using Challenge02.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Challenge02.Entities;

public sealed class Product : Entity {
  public string Name { get; set; } = null!;
  public string Description { get; set; } = null!;
  public decimal UnitPrice { get; set; }
  public bool IsActive { get; set; }

  public Guid CategoryId { get; set; }

  [SkipProperty]
  public Category Category
    => Program.Services.GetRequiredService<DatabaseContext>().Categories[CategoryId];

  public Guid SupplierId { get; set; }

  [SkipProperty]
  public Supplier Supplier
    => Program.Services.GetRequiredService<DatabaseContext>().Suppliers[SupplierId];
}
