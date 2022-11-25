// Copyright (c) Bruno Sales <me@baliestri.dev>. Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using Challenge02.Attributes;

namespace Challenge02.Database.Entities;

public sealed class Category : Entity {
  public string Name { get; set; } = null!;
  public string? Description { get; set; }

  [SkipProperty]
  public IEnumerable<Product> Products { get; set; } = null!;
}
