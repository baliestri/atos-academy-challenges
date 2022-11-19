// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using Challenge02.Database;
using Microsoft.Extensions.Logging;

namespace Challenge02.Forms;

public partial class EditCustomerForm : Form {
  private readonly DatabaseContext _databaseContext;
  private readonly ILogger<EditCustomerForm> _logger;

  public EditCustomerForm(ILogger<EditCustomerForm> logger, DatabaseContext databaseContext) {
    InitializeComponent();

    _logger = logger;
    _databaseContext = databaseContext;
  }

  private void btnCancel_Click(object sender, EventArgs e) {
    _logger.LogInformation("Canceling customer edition");
    Close();
  }

  private void btnEdit_Click(object sender, EventArgs e) {
    if (string.IsNullOrWhiteSpace(txtFullName.Text)) {
      _logger.LogWarning("Fullname is empty");
      MessageBox.Show("O campo 'nome completo' não pode ser vazio.", "Erro", MessageBoxButtons.OK,
        MessageBoxIcon.Error);
      return;
    }

    var split = txtFullName.Text.Split(' ');

    if (split.Length < 2) {
      _logger.LogWarning("Fullname is invalid");
      MessageBox.Show("O campo 'nome completo' deve conter o primeiro e o último nome.", "Erro", MessageBoxButtons.OK,
        MessageBoxIcon.Error);
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

    if (_databaseContext.Customers
        .Except(_databaseContext.Customers.Where(x => x.FullName == cbCustomer.SelectedItem.ToString()))
        .Any(x => x.Email == txtEmail.Text)) {
      _logger.LogWarning("Email already exists");
      MessageBox.Show("O email informado já está cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    var customer = _databaseContext.Customers.First(x => x.FullName == cbCustomer.SelectedItem.ToString());

    customer.FirstName = firstName;
    customer.LastName = lastName;
    customer.Address = txtAddress.Text;
    customer.City = txtCity.Text;
    customer.State = txtState.Text;
    customer.Zip = txtZip.Text;
    customer.Email = txtEmail.Text;
    customer.Phone = txtPhone.Text ?? string.Empty;

    try {
      _logger.LogInformation("Editing customer");
      _databaseContext.Customers.AddAndSave(customer);
      MessageBox.Show("Cliente editado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

      txtFullName.Clear();
      txtAddress.Clear();
      txtCity.Clear();
      txtState.Clear();
      txtZip.Clear();
      txtEmail.Clear();
      txtPhone.Clear();
    }
    catch (Exception ex) {
      _logger.LogError(ex, "Failed to edit customer");
      MessageBox.Show("Ocorreu um erro ao editar o cliente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    _logger.LogInformation("Customer edited");
    cbCustomer.DataSource = _databaseContext.Customers.Select(x => x.FullName).ToList();
  }

  private void EditCustomerForm_Load(object sender, EventArgs e) =>
    cbCustomer.DataSource = _databaseContext.Customers.Select(x => x.FullName).ToList();

  private void cbCustomer_SelectedIndexChanged(object sender, EventArgs e) {
    var category = _databaseContext.Customers.First(x => x.FullName == cbCustomer.SelectedItem.ToString());

    txtFullName.Text = cbCustomer.SelectedItem.ToString();
    txtAddress.Text = category.Address;
    txtCity.Text = category.City;
    txtState.Text = category.State;
    txtZip.Text = category.Zip;
    txtEmail.Text = category.Email;
    txtPhone.Text = category.Phone;

    txtFullName.Enabled = true;
    txtAddress.Enabled = true;
    txtCity.Enabled = true;
    txtState.Enabled = true;
    txtZip.Enabled = true;
    txtEmail.Enabled = true;
    txtPhone.Enabled = true;
    btnEdit.Enabled = true;
  }
}
