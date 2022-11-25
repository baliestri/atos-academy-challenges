// Copyright (c) Bruno Sales <me@baliestri.dev>. Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

namespace Challenge02.Database.Entities;

public sealed class Customer : Entity {
  public string FirstName { get; set; } = null!;
  public string LastName { get; set; } = null!;

  public string FullName => $"{FirstName} {LastName}";

  public string Address { get; set; } = null!;
  public string City { get; set; } = null!;
  public string State { get; set; } = null!;
  public string Zip { get; set; } = null!;
  public string? Phone { get; set; }
  public string Email { get; set; } = null!;
  public int PaymentMethod { get; set; }

  public IEnumerable<Order> Orders { get; set; } = null!;
}
