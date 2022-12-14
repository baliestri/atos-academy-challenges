// Copyright (c) Bruno Sales <me@baliestri.dev>. Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using System.Resources;
using Challenge02.Database;
using Challenge02.Database.Entities;
using Microsoft.Extensions.Logging;

namespace Challenge02.Forms;

public partial class CreateCategoryForm : Form {
  private readonly AppDbContext _appDbContext;
  private readonly ILogger<CreateCategoryForm> _logger;
  private readonly ResourceManager _resourceManager;

  public CreateCategoryForm(ILogger<CreateCategoryForm> logger, AppDbContext appDbContext) {
    InitializeComponent();

    _logger = logger;
    _appDbContext = appDbContext;
    _resourceManager = new ResourceManager(typeof(CreateCategoryForm));
  }

  private void btnCancel_Click(object sender, EventArgs e) {
    _logger.LogInformation("Cancel button clicked");
    Close();
  }

  private void btnCreate_Click(object sender, EventArgs e) {
    _logger.LogInformation("Creating category");
    if (string.IsNullOrWhiteSpace(txtName.Text)) {
      _logger.LogWarning("Name is empty");
      MessageBox.Show(
        _resourceManager.GetString("NAME_REQUIRED_ERROR"), _resourceManager.GetString("ERROR_TITLE"),
        MessageBoxButtons.OK, MessageBoxIcon.Error
      );
      return;
    }

    if (_appDbContext.Categories.Any(c => c.Name == txtName.Text)) {
      _logger.LogWarning("Category already exists");
      MessageBox.Show(
        _resourceManager.GetString("DUPLICATE_NAME_ERROR"), _resourceManager.GetString("ERROR_TITLE"),
        MessageBoxButtons.OK, MessageBoxIcon.Error
      );
      return;
    }

    var category = new Category { Name = txtName.Text, Description = txtDescription.Text ?? string.Empty };

    _appDbContext.Categories.Add(category);
    _appDbContext.SaveChanges();
    _logger.LogInformation("Category created");
  }
}
