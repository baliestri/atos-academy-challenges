// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

namespace MauiCalculator.Services;

public interface ICalculatorService {
  double Add(double a, double b);
  double Subtract(double a, double b);
  double Multiply(double a, double b);
  double Divide(double a, double b);
}
