// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using Challenge02.Attributes;
using Challenge02.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Challenge02.Entities;

public sealed class Customer : Entity {
  public string FirstName { get; set; } = null!;
  public string LastName { get; set; } = null!;

  [SkipProperty]
  public string FullName => $"{FirstName} {LastName}";

  public string Address { get; set; } = null!;
  public string City { get; set; } = null!;
  public string State { get; set; } = null!;
  public string Zip { get; set; } = null!;
  public string? Phone { get; set; }
  public string Email { get; set; } = null!;
  public int PaymentMethod { get; set; }

  [SkipProperty]
  public IEnumerable<Order> Orders
    => Program.Services.GetRequiredService<DatabaseContext>().Orders.Where(x => x.CustomerId == Id);
}
