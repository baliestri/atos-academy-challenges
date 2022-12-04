// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

namespace MauiCalculator.Extensions;

public static class DoubleExtensions {
  public static string ToTrimmedString(this double value, string format) {
    var str = value.ToString(format);

    if (str.Contains(".")) {
      str = str.TrimEnd('0');

      if (str.EndsWith(".")) {
        str = str.TrimEnd('.');
      }
    }

    return str;
  }
}
