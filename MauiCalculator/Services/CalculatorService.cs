// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

namespace MauiCalculator.Services;

public class CalculatorService : ICalculatorService {
  public double Add(double a, double b) => a + b;
  public double Subtract(double a, double b) => a - b;
  public double Multiply(double a, double b) => a * b;
  public double Divide(double a, double b) => a / b;
}
