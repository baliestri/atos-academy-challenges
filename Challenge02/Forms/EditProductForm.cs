// Copyright (c) Bruno Sales <me@baliestri.dev>. Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using Challenge02.Database;
using Microsoft.Extensions.Logging;

namespace Challenge02.Forms;

public partial class EditProductForm : Form {
  private readonly AppDbContext _context;
  private readonly ILogger<EditProductForm> _logger;

  public EditProductForm(AppDbContext context, ILogger<EditProductForm> logger) {
    _context = context;
    _logger = logger;

    InitializeComponent();
  }

  private void EditProductForm_Load(object sender, EventArgs e) {
    _logger.LogInformation("Loading form {FormName}...", nameof(EditProductForm));

    var products = _context.Products.Select(x => x.Name).ToList();
    var categories = _context.Categories.Select(x => x.Name).ToList();
    var suppliers = _context.Suppliers.Select(x => x.CompanyName).ToList();

    cbProduct.DataSource = products;
    cbCategory.DataSource = categories;
    cbSupplier.DataSource = suppliers;

    var selectedProduct = _context.Products.First();

    cbProduct.SelectedIndex = products.IndexOf(selectedProduct.Name);
    cbCategory.SelectedIndex = categories.IndexOf(
      selectedProduct.Category is not null ? selectedProduct.Category.Name : _context.Categories.First().Name
    );
    cbSupplier.SelectedIndex = suppliers.IndexOf(
      selectedProduct.Supplier is not null
        ? selectedProduct.Supplier.CompanyName
        : _context.Suppliers.First().CompanyName
    );

    txtName.Text = selectedProduct.Name;
    txtDescription.Text = selectedProduct.Description;
    txtPrice.Text = selectedProduct.UnitPrice.ToString();
  }

  private void btnAdd_Click(object sender, EventArgs e) {
    _logger.LogInformation("Editing product {ProductName}...", txtName.Text);

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

    var category = _context.Categories.First(x => x.Name == cbCategory.SelectedItem.ToString());
    var supplier = _context.Suppliers.First(x => x.CompanyName == cbSupplier.SelectedItem.ToString());

    var product = _context.Products.First(x => x.Name == cbProduct.SelectedItem.ToString()!);

    product.Category = category;
    product.Supplier = supplier;
    product.Name = txtName.Text;
    product.Description = txtDescription.Text;
    product.UnitPrice = price;

    try {
      _context.Products.Update(product);
      _context.SaveChanges();

      _logger.LogInformation("Product {ProductName} updated successfully.", txtName.Text);
    }
    catch (Exception ex) {
      _logger.LogError(ex, "Error while updating product {ProductName}.", txtName.Text);
      MessageBox.Show("Ocorreu um erro ao editar o produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }

  private void btnCancel_Click(object sender, EventArgs e)
    => Close();
}
