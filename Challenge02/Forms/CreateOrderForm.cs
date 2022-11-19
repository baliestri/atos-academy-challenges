// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using System.Globalization;
using Challenge02.Database;
using Challenge02.Entities;
using Microsoft.Extensions.Logging;

namespace Challenge02.Forms;

public partial class CreateOrderForm : Form {
  private readonly DatabaseContext _databaseContext;
  private readonly ILogger<CreateOrderForm> _logger;

  public CreateOrderForm(ILogger<CreateOrderForm> logger, DatabaseContext databaseContext) {
    InitializeComponent();

    _logger = logger;
    _databaseContext = databaseContext;
  }

  private void CreateOrderForm_Load(object sender, EventArgs e) {
    cbCustomer.DataSource = _databaseContext.Customers.Select(c => c.FullName).ToList();
    cbShipper.DataSource = _databaseContext.Shippers.Select(s => s.CompanyName).ToList();
    cbProduct.DataSource = _databaseContext.Products.Select(p => p.Name).ToList();

    dtOrderDate.MaxDate = DateTime.Now;
  }

  private void btnCancel_Click(object sender, EventArgs e) {
    _logger.LogInformation("User canceled the order creation.");
    Close();
  }

  private void btnCreate_Click(object sender, EventArgs e) {
    var txtQuantityFormatted = txtQuantity.Text.Trim();

    var txtTotalPriceFormatted = txtTotalPrice.Text.Trim()
      .Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol, string.Empty)
      .Replace(".", string.Empty)
      .Replace(",", ".");

    MessageBox.Show(txtQuantityFormatted);
    MessageBox.Show(txtTotalPriceFormatted);

    if (string.IsNullOrWhiteSpace(txtQuantityFormatted)) {
      _logger.LogWarning("User tried to create an order without a quantity.");
      MessageBox.Show("O campo 'quantidade' não pode ser vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    if (!int.TryParse(txtQuantityFormatted, out var quantity)) {
      _logger.LogWarning("User tried to create an order with an invalid quantity.");
      MessageBox.Show("O campo 'quantidade' deve ser um número inteiro.", "Erro", MessageBoxButtons.OK,
        MessageBoxIcon.Error);
      return;
    }

    if (!double.TryParse(txtTotalPriceFormatted, NumberStyles.Any, CultureInfo.InvariantCulture,
          out var totalPrice)) {
      _logger.LogWarning("User tried to create an order with an invalid total price.");
      MessageBox.Show("O campo 'preço total' não é válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    var payment = new Payment {
      CustomerId = _databaseContext.Customers[cbCustomer.SelectedIndex].Id,
      PaymentDate = dtPaymentDate.Value,
      Amount = (decimal)totalPrice
    };

    var order = new Order {
      CustomerId = _databaseContext.Customers[cbCustomer.SelectedIndex].Id,
      OrderDate = dtOrderDate.Value,
      ShipDate = dtShipDate.Value,
      ShipperId = _databaseContext.Shippers[cbShipper.SelectedIndex].Id,
      Total = (decimal)totalPrice,
      IsActive = true,
      PaymentId = payment.Id
    };

    var orderDetails = new OrderDetail {
      OrderId = order.Id,
      ProductId = _databaseContext.Products[cbProduct.SelectedIndex].Id,
      Quantity = quantity,
      TotalPrice = (decimal)totalPrice
    };

    try {
      _databaseContext.Payments.AddAndSave(payment);
      _databaseContext.Orders.AddAndSave(order);
      _databaseContext.OrderDetails.AddAndSave(orderDetails);

      MessageBox.Show("Pedido criado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    catch (Exception ex) {
      _logger.LogError(ex, "An error occurred while creating the order.");
      MessageBox.Show("Ocorreu um erro ao criar o pedido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    _logger.LogInformation("User created a new order.");

    txtQuantity.Clear();
    txtTotalPrice.Clear();
  }
}
