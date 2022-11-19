// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using System.Text;

namespace Challenge02.Entities;

public class Entity {
  public Guid Id { get; set; } = Guid.NewGuid();

  public new virtual string ToString() {
    var stringBuilder = new StringBuilder();

    foreach (var property in GetType().GetProperties()) {
      stringBuilder.AppendLine($"{property.Name}: {property.GetValue(this)}");
    }

    return stringBuilder.ToString();
  }
}
