// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

namespace Challenge02;

partial class EntryPointForm {
  /// <summary>
  ///  Required designer variable.
  /// </summary>
  private System.ComponentModel.IContainer components = null;

  /// <summary>
  ///  Clean up any resources being used.
  /// </summary>
  /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
  protected override void Dispose(bool disposing) {
    if (disposing && (components != null)) {
      components.Dispose();
    }
    base.Dispose(disposing);
  }

  #region Windows Form Designer generated code

  /// <summary>
  ///  Required method for Designer support - do not modify
  ///  the contents of this method with the code editor.
  /// </summary>
  private void InitializeComponent() {
            this.lblName = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpLogin = new System.Windows.Forms.TabPage();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPwdLogin = new System.Windows.Forms.TextBox();
            this.txtEmailLogin = new System.Windows.Forms.TextBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.tpRegister = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtNameRegister = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmailRegister = new System.Windows.Forms.TextBox();
            this.txtPwdRegister = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tpLogin.SuspendLayout();
            this.tpRegister.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblName.Location = new System.Drawing.Point(60, 21);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(217, 65);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "MiniERP";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpLogin);
            this.tabControl.Controls.Add(this.tpRegister);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl.Location = new System.Drawing.Point(0, 109);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(337, 284);
            this.tabControl.TabIndex = 0;
            this.tabControl.TabIndexChanged += new System.EventHandler(this.tabControl_TabIndexChanged);
            // 
            // tpLogin
            // 
            this.tpLogin.Controls.Add(this.btnLogin);
            this.tpLogin.Controls.Add(this.txtPwdLogin);
            this.tpLogin.Controls.Add(this.txtEmailLogin);
            this.tpLogin.Controls.Add(this.lblPwd);
            this.tpLogin.Controls.Add(this.lblEmail);
            this.tpLogin.Location = new System.Drawing.Point(4, 24);
            this.tpLogin.Name = "tpLogin";
            this.tpLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tpLogin.Size = new System.Drawing.Size(329, 256);
            this.tpLogin.TabIndex = 0;
            this.tpLogin.Text = "Entrar";
            this.tpLogin.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(127, 195);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Entrar";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPwdLogin
            // 
            this.txtPwdLogin.Location = new System.Drawing.Point(23, 130);
            this.txtPwdLogin.Name = "txtPwdLogin";
            this.txtPwdLogin.PasswordChar = '•';
            this.txtPwdLogin.PlaceholderText = "••••••••";
            this.txtPwdLogin.Size = new System.Drawing.Size(283, 23);
            this.txtPwdLogin.TabIndex = 2;
            this.txtPwdLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPwdLogin_KeyDown);
            // 
            // txtEmailLogin
            // 
            this.txtEmailLogin.Location = new System.Drawing.Point(23, 65);
            this.txtEmailLogin.Name = "txtEmailLogin";
            this.txtEmailLogin.PlaceholderText = "admin@minierp.com";
            this.txtEmailLogin.Size = new System.Drawing.Size(283, 23);
            this.txtEmailLogin.TabIndex = 1;
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(23, 112);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(39, 15);
            this.lblPwd.TabIndex = 0;
            this.lblPwd.Text = "Senha";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(23, 47);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 15);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "Email:";
            // 
            // tpRegister
            // 
            this.tpRegister.Controls.Add(this.label3);
            this.tpRegister.Controls.Add(this.btnRegister);
            this.tpRegister.Controls.Add(this.txtNameRegister);
            this.tpRegister.Controls.Add(this.label1);
            this.tpRegister.Controls.Add(this.label2);
            this.tpRegister.Controls.Add(this.txtEmailRegister);
            this.tpRegister.Controls.Add(this.txtPwdRegister);
            this.tpRegister.Location = new System.Drawing.Point(4, 24);
            this.tpRegister.Name = "tpRegister";
            this.tpRegister.Padding = new System.Windows.Forms.Padding(3);
            this.tpRegister.Size = new System.Drawing.Size(329, 256);
            this.tpRegister.TabIndex = 1;
            this.tpRegister.Text = "Registrar";
            this.tpRegister.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Senha";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(128, 208);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.Text = "Registrar";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtNameRegister
            // 
            this.txtNameRegister.Location = new System.Drawing.Point(23, 61);
            this.txtNameRegister.Name = "txtNameRegister";
            this.txtNameRegister.PlaceholderText = "Augusto Franco";
            this.txtNameRegister.Size = new System.Drawing.Size(283, 23);
            this.txtNameRegister.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nome:";
            // 
            // txtEmailRegister
            // 
            this.txtEmailRegister.Location = new System.Drawing.Point(23, 110);
            this.txtEmailRegister.Name = "txtEmailRegister";
            this.txtEmailRegister.PlaceholderText = "admin@minierp.com";
            this.txtEmailRegister.Size = new System.Drawing.Size(283, 23);
            this.txtEmailRegister.TabIndex = 2;
            // 
            // txtPwdRegister
            // 
            this.txtPwdRegister.Location = new System.Drawing.Point(23, 159);
            this.txtPwdRegister.Name = "txtPwdRegister";
            this.txtPwdRegister.PasswordChar = '•';
            this.txtPwdRegister.PlaceholderText = "••••••••";
            this.txtPwdRegister.Size = new System.Drawing.Size(283, 23);
            this.txtPwdRegister.TabIndex = 3;
            this.txtPwdRegister.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPwdRegister_KeyDown);
            // 
            // EntryPointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 393);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EntryPointForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MiniERP";
            this.Load += new System.EventHandler(this.EntryPointForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tpLogin.ResumeLayout(false);
            this.tpLogin.PerformLayout();
            this.tpRegister.ResumeLayout(false);
            this.tpRegister.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

  }

  #endregion

  private Label lblName;
  private TabControl tabControl;
  private TabPage tpLogin;
  private Button btnLogin;
  private TextBox txtPwdLogin;
  private TextBox txtEmailLogin;
  private Label lblPwd;
  private Label lblEmail;
  private TabPage tpRegister;
  private Button btnRegister;
  private TextBox txtEmailRegister;
  private TextBox txtNameRegister;
  private Label label1;
  private Label label2;
  private Label label3;
  private TextBox txtPwdRegister;
}
