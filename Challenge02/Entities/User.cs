// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using Challenge02.Attributes;

namespace Challenge02.Entities;

public sealed class User : Entity {
  public string FirstName { get; set; } = null!;
  public string LastName { get; set; } = null!;

  [SkipProperty]
  public string FullName => $"{FirstName} {LastName}";

  public string Email { get; set; } = null!;
  public string Password { get; set; } = null!;
  public string Salt { get; set; } = null!;
}
