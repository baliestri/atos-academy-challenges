// Copyright (c) Bruno Sales <me@baliestri.dev>. Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using Challenge02.Database;
using Microsoft.Extensions.Logging;

namespace Challenge02.Forms;

public partial class EditCategoryForm : Form {
  private readonly AppDbContext _appDbContext;
  private readonly ILogger<EditCategoryForm> _logger;

  public EditCategoryForm(ILogger<EditCategoryForm> logger, AppDbContext appDbContext) {
    InitializeComponent();

    _logger = logger;
    _appDbContext = appDbContext;
  }

  private void btnCancel_Click(object sender, EventArgs e) {
    _logger.LogInformation("Canceling edit category");
    Close();
  }

  private void EditCategoryForm_Load(object sender, EventArgs e) =>
    cbCategories.DataSource = _appDbContext.Categories.Select(x => x.Name).ToList();

  private void cbCategories_SelectedIndexChanged(object sender, EventArgs e) {
    txtName.Text = cbCategories.SelectedItem.ToString();
    txtDescription.Text = _appDbContext.Categories.FirstOrDefault(x => x.Name == txtName.Text)?.Description;

    txtName.Enabled = true;
    txtDescription.Enabled = true;
    btnEdit.Enabled = true;
  }

  private void btnEdit_Click(object sender, EventArgs e) {
    var category = _appDbContext.Categories.First(x => x.Name == cbCategories.SelectedItem.ToString());

    category.Name = txtName.Text;
    category.Description = txtDescription.Text;

    try {
      _appDbContext.Categories.Update(category);
      _appDbContext.SaveChanges();
    }
    catch (Exception ex) {
      _logger.LogError(ex, "Error editing category");
      MessageBox.Show("Não foi possível editar a categoria", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    _logger.LogInformation("Category {Category} edited", category.Name);
    MessageBox.Show("Categoria editada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

    cbCategories.DataSource = _appDbContext.Categories.Select(x => x.Name).ToList();
  }
}
