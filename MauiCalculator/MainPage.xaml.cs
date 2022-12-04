using MauiCalculator.Extensions;
using MauiCalculator.Services;

namespace MauiCalculator;

public partial class MainPage : ContentPage {
  private readonly ICalculatorService _calculator;

  private string _currentValue = "0";
  private string _format = "N0";
  private string _operator = string.Empty;
  private string _previousValue = "0";

  public MainPage() {
    _calculator = new CalculatorService();

    InitializeComponent();
  }

  private void OnClear(object sender, EventArgs e) {
    ResultText.Text = "0";
    CurrentCalculation.Text = string.Empty;
    _currentValue = "0";
    _previousValue = "0";
    _operator = string.Empty;
  }

  private void OnClearEntry(object sender, EventArgs e)
    => ResultText.Text = "0";

  private void OnPercentage(object sender, EventArgs e) {
    _format = "N2";
    _previousValue = _currentValue;
    _operator = "×";
    _currentValue = "0.01";

    OnCalculate(this, null);
  }

  private void OnSelectNumber(object sender, EventArgs e) {
    var pressedValue = ((Button)sender).Text;

    if (ResultText.Text == "0") {
      ResultText.Text = pressedValue;
    }
    else {
      ResultText.Text += pressedValue;
    }

    _currentValue = ResultText.Text;
  }

  private void OnSelectOperator(object sender, EventArgs e) {
    var pressedOperator = ((Button)sender).Text;

    if (_currentValue.EndsWith(".")) {
      _currentValue = _currentValue.TrimEnd('.');
    }

    if (_currentValue != "0") {
      _operator = pressedOperator;
      _previousValue = _currentValue;
      _currentValue = "0";
      CurrentCalculation.Text = $"{_previousValue} {_operator}";
      ResultText.Text = "0";
    }
  }

  private void OnCalculate(object sender, EventArgs e) {
    if (string.IsNullOrEmpty(_operator) ||
        string.IsNullOrEmpty(_previousValue)) {
      return;
    }

    var firstValue = double.Parse(_previousValue);
    var secondValue = double.Parse(_currentValue);

    var result = _operator switch {
      "+" => _calculator.Add(firstValue, secondValue),
      "-" => _calculator.Subtract(firstValue, secondValue),
      "×" => _calculator.Multiply(firstValue, secondValue),
      "÷" => _calculator.Divide(firstValue, secondValue),
      _ => throw new InvalidOperationException("Invalid operator")
    };

    ResultText.Text = result.ToTrimmedString(_format);
    CurrentCalculation.Text = $"{_previousValue} {_operator} {_currentValue}";
    _currentValue = result.ToTrimmedString(_format);
    _previousValue = "0";
    _operator = string.Empty;
  }

  private void OnNegate(object sender, EventArgs e)
    => ResultText.Text = ResultText.Text.StartsWith("-") ? ResultText.Text[1..] : $"-{ResultText.Text}";
}
