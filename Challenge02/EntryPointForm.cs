// Copyright (c) Bruno Sales <me@baliestri.dev>. Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using System.Resources;
using System.Security.Cryptography;
using Challenge02.Database;
using Challenge02.Database.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Logging;

namespace Challenge02;

public partial class EntryPointForm : Form {
  private readonly AppDbContext _appDbContext;
  private readonly ILogger<EntryPointForm> _logger;
  private readonly ResourceManager _resourceManager;

  public EntryPointForm(AppDbContext appDbContext, ILogger<EntryPointForm> logger) {
    InitializeComponent();
    _resourceManager = new ResourceManager(typeof(EntryPointForm));
    _appDbContext = appDbContext;
    _logger = logger;
  }

  public bool IsAuthenticated { get; private set; }

  private void btnRegister_Click(object sender, EventArgs e) {
    _logger.LogInformation("Registering user {Email}", txtEmailRegister.Text);
    if (string.IsNullOrWhiteSpace(txtNameRegister.Text)) {
      _logger.LogWarning("Name is empty");
      MessageBox.Show(
        _resourceManager.GetString("NAME_REQUIRED_ERROR"), _resourceManager.GetString("ERROR_TITLE"),
        MessageBoxButtons.OK, MessageBoxIcon.Error
      );
      return;
    }

    var split = txtNameRegister.Text.Trim().Split(' ');

    if (split.Length < 2) {
      _logger.LogWarning("Name is too short");
      MessageBox.Show(
        _resourceManager.GetString("NAME_INVALID_ERROR"), _resourceManager.GetString("ERROR_TITLE"),
        MessageBoxButtons.OK, MessageBoxIcon.Error
      );
      return;
    }

    if (string.IsNullOrWhiteSpace(txtEmailRegister.Text)) {
      _logger.LogWarning("Email is empty");
      MessageBox.Show(
        _resourceManager.GetString("EMAIL_REQUIRED_ERROR"), _resourceManager.GetString("ERROR_TITLE"),
        MessageBoxButtons.OK, MessageBoxIcon.Error
      );
      return;
    }

    if (string.IsNullOrWhiteSpace(txtPwdRegister.Text)) {
      _logger.LogWarning("Password is empty");
      MessageBox.Show(
        _resourceManager.GetString("PASSWORD_REQUIRED_ERROR"), _resourceManager.GetString("ERROR_TITLE"),
        MessageBoxButtons.OK, MessageBoxIcon.Error
      );
      return;
    }

    if (txtPwdRegister.Text.Length < 8) {
      _logger.LogWarning("Password is too short");
      MessageBox.Show(
        _resourceManager.GetString("PASSWORD_INVALID_ERROR"), _resourceManager.GetString("ERROR_TITLE"),
        MessageBoxButtons.OK, MessageBoxIcon.Error
      );
      return;
    }

    if (_appDbContext.Users.Any(u => u.Email == txtEmailRegister.Text)) {
      _logger.LogWarning("Email already exists");
      MessageBox.Show(
        _resourceManager.GetString("EMAIL_EXISTS_ERROR"), _resourceManager.GetString("ERROR_TITLE"),
        MessageBoxButtons.OK, MessageBoxIcon.Error
      );
      return;
    }

    var salt = RandomNumberGenerator.GetBytes(128 / 8);
    var hashedPwd =
      Convert.ToBase64String(
        KeyDerivation.Pbkdf2(
          txtPwdRegister.Text, salt, KeyDerivationPrf.HMACSHA512, 10000,
          256 / 8
        )
      );

    var firstName = split.First();
    var lastName = string.Join(string.Empty, split.Skip(1));

    var user = new User {
      FirstName = firstName,
      LastName = lastName,
      Email = txtEmailRegister.Text,
      Password = hashedPwd,
      Salt = Convert.ToBase64String(salt)
    };

    try {
      _logger.LogInformation("Adding user {Email} to database", user.Email);

      _appDbContext.Users.Add(user);
      _appDbContext.SaveChanges();

      MessageBox.Show(
        _resourceManager.GetString("REGISTER_SUCCESS"), _resourceManager.GetString("SUCCESS_TITLE"),
        MessageBoxButtons.OK, MessageBoxIcon.Information
      );
    }
    catch (Exception ex) {
      _logger.LogError(ex, "An error occurred while adding a new user.");
      MessageBox.Show(
        _resourceManager.GetString("REGISTER_ERROR"), _resourceManager.GetString("ERROR_TITLE"),
        MessageBoxButtons.OK, MessageBoxIcon.Error
      );
    }
  }

  private void btnLogin_Click(object sender, EventArgs e) {
    _logger.LogInformation("Logging in user {Email}", txtEmailLogin.Text);
    if (string.IsNullOrWhiteSpace(txtEmailLogin.Text)) {
      _logger.LogWarning("Email is empty");
      MessageBox.Show(
        _resourceManager.GetString("EMAIL_REQUIRED_ERROR"), _resourceManager.GetString("ERROR_TITLE"),
        MessageBoxButtons.OK, MessageBoxIcon.Error
      );
      return;
    }

    if (string.IsNullOrWhiteSpace(txtPwdLogin.Text)) {
      _logger.LogWarning("Password is empty");
      MessageBox.Show(
        _resourceManager.GetString("PASSWORD_REQUIRED_ERROR"), _resourceManager.GetString("ERROR_TITLE"),
        MessageBoxButtons.OK, MessageBoxIcon.Error
      );
      return;
    }

    var user = _appDbContext.Users.FirstOrDefault(u => u.Email == txtEmailLogin.Text);

    if (user is null) {
      _logger.LogWarning("User {Email} not found", txtEmailLogin.Text);
      MessageBox.Show(
        _resourceManager.GetString("EMAIL_NOT_FOUND_ERROR"), _resourceManager.GetString("ERROR_TITLE"),
        MessageBoxButtons.OK, MessageBoxIcon.Error
      );
      return;
    }

    var salt = Convert.FromBase64String(user.Salt);

    var hashedPwd =
      Convert.ToBase64String(
        KeyDerivation.Pbkdf2(
          txtPwdLogin.Text, salt, KeyDerivationPrf.HMACSHA512, 10000,
          256 / 8
        )
      );

    if (hashedPwd != user.Password) {
      _logger.LogWarning("Password for user {Email} is invalid", txtEmailLogin.Text);
      MessageBox.Show(
        _resourceManager.GetString("PASSWORD_DOES_NOT_MATCH_ERROR"),
        _resourceManager.GetString("ERROR_TITLE"),
        MessageBoxButtons.OK, MessageBoxIcon.Error
      );
      return;
    }

    _logger.LogInformation("User {Email} logged in successfully", txtEmailLogin.Text);
    IsAuthenticated = true;

    Close();
  }

  private void txtPwdLogin_KeyDown(object sender, KeyEventArgs e) {
    if (e.KeyCode == Keys.Enter) {
      e.SuppressKeyPress = true;
      e.Handled = true;

      btnLogin.PerformClick();
    }
  }

  private void txtPwdRegister_KeyDown(object sender, KeyEventArgs e) {
    if (e.KeyCode == Keys.Enter) {
      e.SuppressKeyPress = true;
      e.Handled = true;

      btnRegister.PerformClick();
    }
  }

  private void tabControl_TabIndexChanged(object sender, EventArgs e)
    => ActiveControl = tabControl.SelectedTab == tabControl.TabPages["tabLogin"] ? txtEmailLogin : txtEmailRegister;

  private void EntryPointForm_Load(object sender, EventArgs e)
    => txtEmailLogin.Focus();
}
