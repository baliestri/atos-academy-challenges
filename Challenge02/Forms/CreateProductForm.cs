// Copyright (c) Bruno Sales <me@baliestri.dev>. Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using Challenge02.Database;
using Challenge02.Database.Entities;
using Microsoft.Extensions.Logging;

namespace Challenge02.Forms;

public partial class CreateProductForm : Form {
  private readonly AppDbContext _context;
  private readonly ILogger<CreateProductForm> _logger;

  public CreateProductForm(AppDbContext context, ILogger<CreateProductForm> logger) {
    _context = context;
    _logger = logger;

    InitializeComponent();
  }

  private void CreateProductForm_Load(object sender, EventArgs e) {
    _logger.LogInformation("Loading form {FormName}...", nameof(CreateProductForm));

    var categories = _context.Categories.Select(x => x.Name).ToList();
    var suppliers = _context.Suppliers.Select(x => x.CompanyName).ToList();

    cbCategory.DataSource = categories;
    cbSupplier.DataSource = suppliers;
  }

  private void btnAdd_Click(object sender, EventArgs e) {
    _logger.LogInformation("Adding product {ProductName}...", txtName.Text);

    if (string.IsNullOrWhiteSpace(txtName.Text)) {
      MessageBox.Show("O campo nome não pode ser vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    if (string.IsNullOrWhiteSpace(txtDescription.Text)) {
      MessageBox.Show("O campo descrição não pode ser vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    if (string.IsNullOrWhiteSpace(txtPrice.Text)) {
      MessageBox.Show("O campo preço não pode ser vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    if (!decimal.TryParse(txtPrice.Text, out var price)) {
      MessageBox.Show("O campo preço deve ser um número.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    var category = _context.Categories.First(x => x.Name == cbCategory.SelectedItem.ToString()!);
    var supplier = _context.Suppliers.First(x => x.CompanyName == cbSupplier.SelectedItem.ToString()!);

    var product = new Product {
      Name = txtName.Text,
      Description = txtDescription.Text,
      UnitPrice = price,
      Category = category,
      Supplier = supplier
    };

    try {
      _context.Products.Add(product);
      _context.SaveChanges();

      _logger.LogInformation("Product {ProductName} added successfully.", txtName.Text);
    }
    catch (Exception ex) {
      _logger.LogError(ex, "Error while adding product {ProductName}.", txtName.Text);
      MessageBox.Show("Ocorreu um erro ao adicionar o produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }

  private void btnCancel_Click(object sender, EventArgs e)
    => Close();
}
