// Copyright (c) Bruno Sales <me@baliestri.dev>. Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using System.Reflection;
using Challenge02.Attributes;

namespace Challenge02.Extensions;

public static class TypeExtensions {
  public static PropertyInfo[] GetFilteredProperties(
    this Type type,
    BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance
  )
    => type.GetProperties(bindingFlags).Where(x => !x.HasAttribute<SkipPropertyAttribute>()).ToArray();
}
