// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using Challenge02.Attributes;
using Challenge02.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Challenge02.Entities;

public sealed class Shipper : Entity {
  public string CompanyName { get; set; } = null!;
  public string Phone { get; set; } = null!;

  [SkipProperty]
  public IEnumerable<Order> Orders
    => Program.Services.GetRequiredService<DatabaseContext>().Orders.Where(x => x.ShipperId == Id);
}
