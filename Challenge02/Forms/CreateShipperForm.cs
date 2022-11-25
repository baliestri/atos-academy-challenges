// Copyright (c) Bruno Sales <me@baliestri.dev>. Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using System.Resources;
using Challenge02.Database;
using Challenge02.Database.Entities;
using Microsoft.Extensions.Logging;

namespace Challenge02.Forms;

public partial class CreateShipperForm : Form {
  private readonly AppDbContext _appDbContext;
  private readonly ILogger<CreateShipperForm> _logger;
  private readonly ResourceManager _resourceManager;

  public CreateShipperForm(ILogger<CreateShipperForm> logger, AppDbContext appDbContext) {
    InitializeComponent();

    _logger = logger;
    _appDbContext = appDbContext;
    _resourceManager = new ResourceManager(typeof(CreateShipperForm));
  }

  private void btnCancel_Click(object sender, EventArgs e) {
    _logger.LogInformation("Cancel button clicked");
    Close();
  }

  private void btnCreate_Click(object sender, EventArgs e) {
    _logger.LogInformation("Creating shipper");
    if (string.IsNullOrWhiteSpace(txtName.Text)) {
      _logger.LogWarning("Name is empty");
      MessageBox.Show(
        _resourceManager.GetString("NAME_REQUIRED_ERROR"), _resourceManager.GetString("ERROR_TITLE"),
        MessageBoxButtons.OK, MessageBoxIcon.Error
      );
      return;
    }

    if (_appDbContext.Shippers.Any(c => c.CompanyName == txtName.Text)) {
      _logger.LogWarning("Category already exists");
      MessageBox.Show(
        _resourceManager.GetString("DUPLICATE_NAME_ERROR"), _resourceManager.GetString("ERROR_TITLE"),
        MessageBoxButtons.OK, MessageBoxIcon.Error
      );
      return;
    }

    if (string.IsNullOrWhiteSpace(txtPhone.Text)) {
      _logger.LogWarning("Phone is empty");
      MessageBox.Show("O campo 'telefone' não pode ser vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    var shipper = new Shipper { CompanyName = txtName.Text, Phone = txtPhone.Text };

    _appDbContext.Shippers.Add(shipper);
    _appDbContext.SaveChanges();
    _logger.LogInformation("Shipper created");
  }
}
