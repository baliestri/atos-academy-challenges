// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using Challenge02.Attributes;
using Challenge02.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Challenge02.Entities;

public sealed class Payment : Entity {
  public Guid CustomerId { get; set; }

  [SkipProperty]
  public Customer Customer
    => Program.Services.GetRequiredService<DatabaseContext>().Customers[CustomerId];

  public DateTime PaymentDate { get; set; }
  public decimal Amount { get; set; }
}
