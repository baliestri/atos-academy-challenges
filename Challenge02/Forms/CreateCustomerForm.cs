// Copyright (c) Bruno Sales <me@baliestri.dev>. Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using Challenge02.Database;
using Challenge02.Database.Entities;
using Microsoft.Extensions.Logging;

namespace Challenge02.Forms;

public partial class CreateCustomerForm : Form {
  private readonly AppDbContext _appDbContext;
  private readonly ILogger<CreateCustomerForm> _logger;

  public CreateCustomerForm(ILogger<CreateCustomerForm> logger, AppDbContext appDbContext) {
    InitializeComponent();

    _logger = logger;
    _appDbContext = appDbContext;
  }

  private void btnCancel_Click(object sender, EventArgs e) {
    _logger.LogInformation("Canceling customer creation");
    Close();
  }

  private void btnCreate_Click(object sender, EventArgs e) {
    if (string.IsNullOrWhiteSpace(txtFullName.Text)) {
      _logger.LogWarning("Fullname is empty");
      MessageBox.Show(
        "O campo 'nome completo' não pode ser vazio.", "Erro", MessageBoxButtons.OK,
        MessageBoxIcon.Error
      );
      return;
    }

    var split = txtFullName.Text.Split(' ');

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

    if (_appDbContext.Customers.Any(x => x.Email == txtEmail.Text)) {
      _logger.LogWarning("Email already exists");
      MessageBox.Show("O email informado já está cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    var customer = new Customer {
      FirstName = firstName,
      LastName = lastName,
      Address = txtAddress.Text,
      City = txtCity.Text,
      State = txtState.Text,
      Zip = txtZip.Text,
      Email = txtEmail.Text,
      Phone = txtPhone.Text ?? string.Empty,
      PaymentMethod = 0
    };

    try {
      _logger.LogInformation("Creating customer");
      _appDbContext.Customers.Add(customer);
      _appDbContext.SaveChanges();
      MessageBox.Show("Cliente criado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

      txtFullName.Clear();
      txtAddress.Clear();
      txtCity.Clear();
      txtState.Clear();
      txtZip.Clear();
      txtEmail.Clear();
      txtPhone.Clear();
    }
    catch (Exception ex) {
      _logger.LogError(ex, "Failed to create customer");
      MessageBox.Show("Ocorreu um erro ao criar o cliente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    _logger.LogInformation("Customer created");
  }
}
