// Copyright (c) Bruno Sales <me@baliestri.dev>. Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using System.ComponentModel.DataAnnotations;
using Challenge02.Attributes;

namespace Challenge02.Database.Entities;

public sealed class Payment : Entity {
  //public Guid CustomerId { get; set; }

  [SkipProperty]
  [Required]
  public Customer Customer { get; set; } = null!;

  public DateTime PaymentDate { get; set; }
  public decimal Amount { get; set; }
}
