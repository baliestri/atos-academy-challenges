// Copyright (c) Bruno Sales <me@baliestri.dev>. Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using Challenge02.Database;
using Microsoft.Extensions.Logging;

namespace Challenge02.Forms;

public partial class EditShipperForm : Form {
  private readonly AppDbContext _appDbContext;
  private readonly ILogger<EditShipperForm> _logger;

  public EditShipperForm(ILogger<EditShipperForm> logger, AppDbContext appDbContext) {
    InitializeComponent();

    _logger = logger;
    _appDbContext = appDbContext;
  }

  private void btnCancel_Click(object sender, EventArgs e) {
    _logger.LogInformation("Canceling edit category");
    Close();
  }

  private void EditShipperForm_Load(object sender, EventArgs e) =>
    cbShippers.DataSource = _appDbContext.Shippers.Select(x => x.CompanyName).ToList();

  private void cbShippers_SelectedIndexChanged(object sender, EventArgs e) {
    txtName.Text = cbShippers.SelectedItem.ToString();
    txtPhone.Text = _appDbContext.Shippers.First(x => x.CompanyName == txtName.Text).Phone;

    txtName.Enabled = true;
    txtPhone.Enabled = true;
    btnEdit.Enabled = true;
  }

  private void btnEdit_Click(object sender, EventArgs e) {
    var shipper = _appDbContext.Shippers.First(x => x.CompanyName == cbShippers.SelectedItem.ToString());

    shipper.CompanyName = txtName.Text;
    shipper.Phone = txtPhone.Text;

    try {
      _appDbContext.Shippers.Update(shipper);
      _appDbContext.SaveChanges();
    }
    catch (Exception ex) {
      _logger.LogError(ex, "Error editing shipper");
      MessageBox.Show("Não foi possível editar o entregador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    _logger.LogInformation("Shipper {Shipper} edited", shipper.CompanyName);
    MessageBox.Show("Entregador editado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

    cbShippers.DataSource = _appDbContext.Shippers.Select(x => x.CompanyName).ToList();
  }
}
