// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using Challenge02.Attributes;
using Challenge02.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Challenge02.Entities;

public sealed class Category : Entity {
  public string Name { get; set; } = null!;
  public string? Description { get; set; }

  [SkipProperty]
  public IEnumerable<Product> Products
    => Program.Services.GetRequiredService<DatabaseContext>().Products.Where(x => x.CategoryId == Id);
}
