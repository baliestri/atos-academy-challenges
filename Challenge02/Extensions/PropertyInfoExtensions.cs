// Copyright (c) Bruno Sales <me@baliestri.dev>. Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using System.Reflection;

namespace Challenge02.Extensions;

public static class PropertyInfoExtensions {
  public static IEnumerable<T> GetAttributes<T>(this PropertyInfo propertyInfo) where T : Attribute
    => propertyInfo.GetCustomAttributes(typeof(T), true).Cast<T>();

  public static bool HasAttribute<T>(this PropertyInfo propertyInfo) where T : Attribute
    => propertyInfo.GetAttributes<T>().Any();
}
