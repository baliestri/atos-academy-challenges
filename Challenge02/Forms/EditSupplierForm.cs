// Copyright (c) Bruno Sales <me@baliestri.dev>. Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using Challenge02.Database;
using Microsoft.Extensions.Logging;

namespace Challenge02.Forms;

public partial class EditSupplierForm : Form {
  private readonly AppDbContext _appDbContext;
  private readonly ILogger<EditSupplierForm> _logger;

  public EditSupplierForm(ILogger<EditSupplierForm> logger, AppDbContext appDbContext) {
    InitializeComponent();

    _logger = logger;
    _appDbContext = appDbContext;
  }

  private void btnCancel_Click(object sender, EventArgs e) {
    _logger.LogInformation("Canceling supplier edition");
    Close();
  }

  private void btnEdit_Click(object sender, EventArgs e) {
    if (string.IsNullOrWhiteSpace(txtCompanyName.Text)) {
      _logger.LogWarning("Fullname is empty");
      MessageBox.Show(
        "O campo 'nome completo' não pode ser vazio.", "Erro", MessageBoxButtons.OK,
        MessageBoxIcon.Error
      );
      return;
    }

    if (string.IsNullOrWhiteSpace(txtCompanyName.Text)) {
      _logger.LogWarning("Company name is empty");
      MessageBox.Show(
        "O campo 'nome da empresa' não pode ser vazio.", "Erro", MessageBoxButtons.OK,
        MessageBoxIcon.Error
      );
      return;
    }

    var split = txtCompanyName.Text.Split(' ');

    if (split.Length < 2) {
      _logger.LogWarning("Fullname is invalid");
      MessageBox.Show(
        "O campo 'nome completo' deve conter o primeiro e o último nome.", "Erro", MessageBoxButtons.OK,
        MessageBoxIcon.Error
      );
      return;
    }

    var firstName = split.First();
    var lastName = split.Skip(1).Aggregate((x, y) => $"{x} {y}");

    if (string.IsNullOrWhiteSpace(txtAddress.Text)) {
      _logger.LogWarning("Address is empty");
      MessageBox.Show("O campo 'endereço' não pode ser vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    if (string.IsNullOrWhiteSpace(txtCity.Text)) {
      _logger.LogWarning("City is empty");
      MessageBox.Show("O campo 'cidade' não pode ser vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    if (string.IsNullOrWhiteSpace(txtState.Text)) {
      _logger.LogWarning("State is empty");
      MessageBox.Show("O campo 'estado' não pode ser vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    if (string.IsNullOrWhiteSpace(txtZip.Text)) {
      _logger.LogWarning("Zip is empty");
      MessageBox.Show("O campo 'CEP' não pode ser vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    if (string.IsNullOrWhiteSpace(txtEmail.Text)) {
      _logger.LogWarning("Email is empty");
      MessageBox.Show("O campo 'email' não pode ser vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    if (_appDbContext.Suppliers.Any(x => x.CompanyName == txtCompanyName.Text)) {
      _logger.LogWarning("Company name already exists");
      MessageBox.Show("Já existe um fornecedor com esse nome.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    if (_appDbContext.Suppliers
        .Except(_appDbContext.Suppliers.Where(x => x.CompanyName == cbSupplier.SelectedItem.ToString()))
        .Any(x => x.Email == txtEmail.Text)) {
      _logger.LogWarning("Email already exists");
      MessageBox.Show("O email informado já está cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    var supplier = _appDbContext.Suppliers.First(x => x.CompanyName == cbSupplier.SelectedItem.ToString());

    supplier.CompanyName = txtCompanyName.Text;
    supplier.FirstName = firstName;
    supplier.LastName = lastName;
    supplier.Address = txtAddress.Text;
    supplier.City = txtCity.Text;
    supplier.State = txtState.Text;
    supplier.Zip = txtZip.Text;
    supplier.Email = txtEmail.Text;
    supplier.Phone = txtPhone.Text ?? string.Empty;

    try {
      _logger.LogInformation("Creating supplier");
      _appDbContext.Suppliers.Update(supplier);
      _appDbContext.SaveChanges();
      MessageBox.Show("Fornecedor criado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

      txtCompanyName.Clear();
      txtFullName.Clear();
      txtAddress.Clear();
      txtCity.Clear();
      txtState.Clear();
      txtZip.Clear();
      txtEmail.Clear();
      txtPhone.Clear();
    }
    catch (Exception ex) {
      _logger.LogError(ex, "Failed to create supplier");
      MessageBox.Show("Ocorreu um erro ao criar o fornecedor.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    _logger.LogInformation("Supplier created");
    cbSupplier.DataSource = _appDbContext.Suppliers.Select(x => x.CompanyName).ToList();
  }

  private void EditSupplierForm_Load(object sender, EventArgs e) =>
    cbSupplier.DataSource = _appDbContext.Suppliers.Select(x => x.CompanyName).ToList();

  private void cbSupplier_SelectedIndexChanged(object sender, EventArgs e) {
    var company = _appDbContext.Suppliers.First(x => x.CompanyName == cbSupplier.SelectedItem.ToString());

    txtCompanyName.Text = cbSupplier.SelectedItem.ToString();
    txtFullName.Text = company.FullName;
    txtAddress.Text = company.Address;
    txtCity.Text = company.City;
    txtState.Text = company.State;
    txtZip.Text = company.Zip;
    txtEmail.Text = company.Email;
    txtPhone.Text = company.Phone;
  }
}
