// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using Challenge02.Database;
using Microsoft.Extensions.Logging;

namespace Challenge02.Forms;

public partial class QueryForm : Form {
  private readonly ILogger<QueryForm> _logger;
  private readonly DatabaseContext _databaseContext;

  public QueryForm(ILogger<QueryForm> logger, DatabaseContext databaseContext) {
    InitializeComponent();

    _logger = logger;
    _databaseContext = databaseContext;
  }

  private void cbTable_SelectedIndexChanged(object sender, EventArgs e) {
    switch (cbTable.SelectedIndex) {
      case 0:
        selectedTableCategories();
        break;

      case 1:
        selectedTableCustomers();
        break;

      case 2:
        selectedTableOrderDetails();
        break;

      case 3:
        selectedTablePayments();
        break;

      case 4:
        selectedTableProducts();
        break;

      case 5:
        selectedTableShippers();
        break;

      case 6:
        selectedTableSuppliers();
        break;

      case 7:
        selectedTableUsers();
        break;

      default:
        listView.Columns.Clear();
        listView.Items.Clear();
        break;
    }
  }

  private void selectedTableCategories() {
    _logger.LogInformation("Categories table selected");

    listView.Columns.Clear();
    listView.Items.Clear();

    var columns = new[ ] {
      new ColumnHeader { Text = "Nome" }, new ColumnHeader { Text = "Descrição" },
      new ColumnHeader { Text = "Produtos" }
    };
    var categories = _databaseContext.Categories;

    listView.Columns.AddRange(columns);

    categories.ForEach(category => {
      var item = new ListViewItem(category.Name);
      item.SubItems.Add(category.Description);
      item.SubItems.Add(category.Products.Count().ToString());

      listView.Items.Add(item);
    });

    listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
  }

  private void selectedTableCustomers() {
    _logger.LogInformation("Customers table selected");

    listView.Columns.Clear();
    listView.Items.Clear();

    var columns = new[ ] {
      new ColumnHeader { Text = "Nome completo" }, new ColumnHeader { Text = "Endereço" },
      new ColumnHeader { Text = "Cidade" }, new ColumnHeader { Text = "Estado" }, new ColumnHeader { Text = "CEP" },
      new ColumnHeader { Text = "Telefone" }, new ColumnHeader { Text = "Email" }, new ColumnHeader { Text = "Pedidos" }
    };
    var customers = _databaseContext.Customers;

    listView.Columns.AddRange(columns);

    customers.ForEach(customer => {
      var item = new ListViewItem(customer.FullName);
      item.SubItems.Add(customer.Address);
      item.SubItems.Add(customer.City);
      item.SubItems.Add(customer.State);
      item.SubItems.Add(customer.Zip);
      item.SubItems.Add(customer.Phone);
      item.SubItems.Add(customer.Email);
      item.SubItems.Add(customer.Orders.Count().ToString());

      listView.Items.Add(item);
    });

    listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
  }

  private void selectedTableOrderDetails() {
    _logger.LogInformation("Order details table selected");

    listView.Columns.Clear();
    listView.Items.Clear();

    var columns = new[ ] {
      new ColumnHeader { Text = "Produto" }, new ColumnHeader { Text = "Preço total" },
      new ColumnHeader { Text = "Quantidade" }, new ColumnHeader { Text = "Cliente" },
      new ColumnHeader { Text = "Data do pedido" }, new ColumnHeader { Text = "Data de entrega" },
      new ColumnHeader { Text = "Entregador" }
    };
    var orderDetails = _databaseContext.OrderDetails;

    listView.Columns.AddRange(columns);

    orderDetails.ForEach(orderDetail => {
      var item = new ListViewItem(orderDetail.Product.Name);
      item.SubItems.Add(orderDetail.TotalPrice.ToString("C"));
      item.SubItems.Add(orderDetail.Quantity.ToString());
      item.SubItems.Add(orderDetail.Order.Customer.FullName);
      item.SubItems.Add(orderDetail.Order.OrderDate.ToString("dd/MM/yyyy"));
      item.SubItems.Add(orderDetail.Order.ShipDate.ToString("dd/MM/yyyy"));
      item.SubItems.Add(orderDetail.Order.Shipper.CompanyName);

      listView.Items.Add(item);
    });

    listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
  }

  private void selectedTablePayments() {
    _logger.LogInformation("Payments table selected");

    listView.Columns.Clear();
    listView.Items.Clear();

    var columns = new[ ] {
      new ColumnHeader { Text = "Cliente" }, new ColumnHeader { Text = "Data do pagamento" },
      new ColumnHeader { Text = "Valor" }
    };
    var payments = _databaseContext.Payments;

    listView.Columns.AddRange(columns);

    payments.ForEach(payment => {
      var item = new ListViewItem(payment.Customer.FullName);
      item.SubItems.Add(payment.PaymentDate.ToString("dd/MM/yyyy"));
      item.SubItems.Add(payment.Amount.ToString("C"));

      listView.Items.Add(item);
    });

    listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
  }

  private void selectedTableProducts() {
    _logger.LogInformation("Products table selected");

    listView.Columns.Clear();
    listView.Items.Clear();

    var columns = new[ ] {
      new ColumnHeader { Text = "Nome" }, new ColumnHeader { Text = "Descrição" },
      new ColumnHeader { Text = "Preço Unitário" }, new ColumnHeader { Text = "Categoria" },
      new ColumnHeader { Text = "Fornecedor" }, new ColumnHeader { Text = "Ativo" }
    };
    var products = _databaseContext.Products;

    listView.Columns.AddRange(columns);

    products.ForEach(product => {
      var item = new ListViewItem(product.Name);
      item.SubItems.Add(product.Description);
      item.SubItems.Add(product.UnitPrice.ToString("C"));
      item.SubItems.Add(product.Category.Name);
      item.SubItems.Add(product.Supplier.CompanyName);
      item.SubItems.Add(product.IsActive ? "Sim" : "Não");

      listView.Items.Add(item);
    });

    listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
  }

  private void selectedTableShippers() {
    _logger.LogInformation("Shippers table selected");

    listView.Columns.Clear();
    listView.Items.Clear();

    var columns = new[ ] {
      new ColumnHeader { Text = "Nome" }, new ColumnHeader { Text = "Telefone" }, new ColumnHeader { Text = "Pedidos" }
    };
    var shippers = _databaseContext.Shippers;

    listView.Columns.AddRange(columns);

    shippers.ForEach(shipper => {
      var item = new ListViewItem(shipper.CompanyName);
      item.SubItems.Add(shipper.Phone);
      item.SubItems.Add(shipper.Orders.Count().ToString());

      listView.Items.Add(item);
    });

    listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
  }

  private void selectedTableSuppliers() {
    _logger.LogInformation("Suppliers table selected");

    listView.Columns.Clear();
    listView.Items.Clear();

    var columns = new[ ] {
      new ColumnHeader { Text = "Nome" }, new ColumnHeader { Text = "Endereço" }, new ColumnHeader { Text = "Cidade" },
      new ColumnHeader { Text = "Estado" }, new ColumnHeader { Text = "CEP" }, new ColumnHeader { Text = "Telefone" },
      new ColumnHeader { Text = "Email" }, new ColumnHeader { Text = "Produtos" }
    };
    var suppliers = _databaseContext.Suppliers;

    listView.Columns.AddRange(columns);

    suppliers.ForEach(supplier => {
      var item = new ListViewItem(supplier.CompanyName);
      item.SubItems.Add(supplier.Address);
      item.SubItems.Add(supplier.City);
      item.SubItems.Add(supplier.State);
      item.SubItems.Add(supplier.Zip);
      item.SubItems.Add(supplier.Phone);
      item.SubItems.Add(supplier.Email);
      item.SubItems.Add(supplier.Products.Count().ToString());

      listView.Items.Add(item);
    });

    listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
  }

  private void selectedTableUsers() {
    _logger.LogInformation("Users table selected");

    listView.Columns.Clear();
    listView.Items.Clear();

    var columns = new[ ] { new ColumnHeader { Text = "Nome" }, new ColumnHeader { Text = "Email" } };
    var users = _databaseContext.Users;

    listView.Columns.AddRange(columns);

    users.ForEach(user => {
      var item = new ListViewItem(user.FullName);
      item.SubItems.Add(user.Email);

      listView.Items.Add(item);
    });

    listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
  }
}
