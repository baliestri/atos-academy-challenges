// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using System.Reflection;
using Challenge02.Database;
using Microsoft.Extensions.Logging;
using SelectPdf;

namespace Challenge02.Forms;

public partial class EmitInvoiceForm : Form {
  private readonly ILogger<EmitInvoiceForm> _logger;
  private readonly DatabaseContext _databaseContext;

  public EmitInvoiceForm(ILogger<EmitInvoiceForm> logger, DatabaseContext databaseContext) {
    InitializeComponent();
    _logger = logger;
    _databaseContext = databaseContext;
  }

  private void EmitInvoiceForm_Load(object sender, EventArgs e) {
    cbCustomers.DataSource = _databaseContext.Customers.Select(c => c.FullName).ToList();

    listView.Columns.Clear();

    var columns = new[ ] {
      new ColumnHeader { Text = "Produto" }, new ColumnHeader { Text = "Preço total" },
      new ColumnHeader { Text = "Quantidade" }, new ColumnHeader { Text = "Cliente" },
      new ColumnHeader { Text = "Data do pedido" }, new ColumnHeader { Text = "Data do envio" },
      new ColumnHeader { Text = "Entregador" }, new ColumnHeader { Text = "Data do pagamento" }
    };

    listView.Columns.AddRange(columns);
  }

  private void btnEmit_Click(object sender, EventArgs e) {
    var nfeId = Guid.NewGuid();

    _logger.LogInformation("Emitting NFe {NFeId}", nfeId);

    using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Challenge02.Properties.invoice.html");
    using var reader = new StreamReader(stream!);
    var html = reader.ReadToEnd();

    var order = _databaseContext.Orders.First(o => o.Customer.FullName == cbCustomers.SelectedItem.ToString());
    var orderDetail = _databaseContext.OrderDetails.First(od => od.OrderId == order.Id);
    var payment = _databaseContext.Payments.First(p => p.CustomerId == order.CustomerId);

    html = html.Replace("{{nfeId}}", nfeId.ToString());
    html = html.Replace("{{customerId}}", order.CustomerId.ToString());
    html = html.Replace("{{customerFullName}}", order.Customer.FullName);
    html = html.Replace("{{paymentDate}}", payment.PaymentDate.ToString());
    html = html.Replace("{{orderDate}}", order.OrderDate.ToString());
    html = html.Replace("{{shipDate}}", order.ShipDate.ToString());
    html = html.Replace("{{totalValue}}", order.Total.ToString("C2"));
    html = html.Replace("{{shipperCompanyName}}", order.Shipper.CompanyName);
    html = html.Replace("{{shipperPhone}}", order.Shipper.Phone);
    html = html.Replace("{{shipperId}}", order.Shipper.Id.ToString());
    html = html.Replace("{{productName}}", orderDetail.Product.Name);
    html = html.Replace("{{quantity}}", orderDetail.Quantity.ToString());

    var converter = new HtmlToPdf();
    var doc = converter.ConvertHtmlString(html);

    saveFileDialog.FileName = $"nfe-{nfeId}.pdf";
    var path = saveFileDialog.ShowDialog() == DialogResult.OK ? saveFileDialog.FileName : null;

    if (path != null) {
      doc.Save(path);
      doc.Close();
    }

    _logger.LogInformation("NFe {NFeId} emitted", nfeId);
  }

  private void cbCustomers_SelectedIndexChanged(object sender, EventArgs e) {
    var orders = _databaseContext.Orders.Where(o => o.Customer.FullName == cbCustomers.SelectedItem.ToString());

    listView.Items.Clear();

    foreach (var order in orders) {
      var orderDetail = _databaseContext.OrderDetails.First(od => od.OrderId == order.Id);
      var payment = _databaseContext.Payments.First(p => p.CustomerId == order.CustomerId);
      var product = _databaseContext.Products.First(p => p.Id == orderDetail.ProductId);
      var shipper = _databaseContext.Shippers.First(s => s.Id == order.ShipperId);

      var item = new ListViewItem(product.Name);
      item.SubItems.Add(orderDetail.TotalPrice.ToString());
      item.SubItems.Add(orderDetail.Quantity.ToString());
      item.SubItems.Add(order.Customer.FullName);
      item.SubItems.Add(order.OrderDate.ToString());
      item.SubItems.Add(order.ShipDate.ToString());
      item.SubItems.Add(shipper.CompanyName);
      item.SubItems.Add(payment.PaymentDate.ToString());

      listView.Items.Add(item);
    }

    listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
  }

  private void listView_SelectedIndexChanged(object sender, EventArgs e)
    => btnEmit.Enabled = true;
}
