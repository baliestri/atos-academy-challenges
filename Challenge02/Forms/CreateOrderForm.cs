// Copyright (c) Bruno Sales <me@baliestri.dev>. Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using System.Globalization;
using Challenge02.Database;
using Challenge02.Database.Entities;
using Microsoft.Extensions.Logging;

namespace Challenge02.Forms;

public partial class CreateOrderForm : Form {
  private readonly AppDbContext _appDbContext;
  private readonly ILogger<CreateOrderForm> _logger;

  public CreateOrderForm(ILogger<CreateOrderForm> logger, AppDbContext appDbContext) {
    InitializeComponent();

    _logger = logger;
    _appDbContext = appDbContext;
  }

  private void CreateOrderForm_Load(object sender, EventArgs e) {
    cbCustomer.DataSource = _appDbContext.Customers.Select(c => c.FullName).ToList();
    cbShipper.DataSource = _appDbContext.Shippers.Select(s => s.CompanyName).ToList();
    cbProduct.DataSource = _appDbContext.Products.Select(p => p.Name).ToList();

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

    MessageBox.Show(cbCustomer.SelectedItem.ToString());
    MessageBox.Show(cbShipper.SelectedItem.ToString());
    MessageBox.Show(cbProduct.SelectedItem.ToString());

    if (string.IsNullOrWhiteSpace(txtQuantityFormatted)) {
      _logger.LogWarning("User tried to create an order without a quantity.");
      MessageBox.Show("O campo 'quantidade' não pode ser vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    if (!int.TryParse(txtQuantityFormatted, out var quantity)) {
      _logger.LogWarning("User tried to create an order with an invalid quantity.");
      MessageBox.Show(
        "O campo 'quantidade' deve ser um número inteiro.", "Erro", MessageBoxButtons.OK,
        MessageBoxIcon.Error
      );
      return;
    }

    if (!double.TryParse(
          txtTotalPriceFormatted, NumberStyles.Any, CultureInfo.InvariantCulture,
          out var totalPrice
        )) {
      _logger.LogWarning("User tried to create an order with an invalid total price.");
      MessageBox.Show("O campo 'preço total' não é válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    var customer = _appDbContext.Customers.ToList().First(c => c.FullName == cbCustomer.SelectedItem.ToString());
    var shipper = _appDbContext.Shippers.ToList().First(s => s.CompanyName == cbShipper.SelectedItem.ToString());
    var product = _appDbContext.Products.ToList().First(p => p.Name == cbProduct.SelectedItem.ToString());

    var payment = new Payment {
      Customer = customer,
      PaymentDate = dtPaymentDate.Value,
      Amount = (decimal)totalPrice
    };

    var order = new Order {
      Customer = customer,
      OrderDate = dtOrderDate.Value,
      ShipDate = dtShipDate.Value,
      Shipper = shipper,
      Total = (decimal)totalPrice,
      IsActive = true,
      Payment = payment
    };

    var orderDetails = new OrderDetail {
      Order = order,
      Product = product,
      Quantity = quantity,
      TotalPrice = (decimal)totalPrice
    };

    try {
      _appDbContext.Payments.Add(payment);
      _appDbContext.Orders.Add(order);
      _appDbContext.OrderDetails.Add(orderDetails);
      _appDbContext.SaveChanges();

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

  private void cbCustomer_SelectedIndexChanged(object sender, EventArgs e)
    => cbCustomer.Text = cbCustomer.SelectedItem.ToString();

  private void cbShipper_SelectedIndexChanged(object sender, EventArgs e)
    => cbShipper.Text = cbShipper.SelectedItem.ToString();

  private void cbProduct_SelectedIndexChanged(object sender, EventArgs e)
    => cbProduct.Text = cbProduct.SelectedItem.ToString();
}
