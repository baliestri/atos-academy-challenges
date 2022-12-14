// Copyright (c) Bruno Sales <me@baliestri.dev>. Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

namespace Challenge02.Forms;

public partial class EditProductForm {
  /// <summary>
  /// Required designer variable.
  /// </summary>
  private System.ComponentModel.IContainer components = null;

  /// <summary>
  /// Clean up any resources being used.
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
  /// Required method for Designer support - do not modify
  /// the contents of this method with the code editor.
  /// </summary>
  private void InitializeComponent() {
      this.label1 = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.btnEdit = new System.Windows.Forms.Button();
      this.cbCategory = new System.Windows.Forms.ComboBox();
      this.txtDescription = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtPrice = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.cbSupplier = new System.Windows.Forms.ComboBox();
      this.btnCancel = new System.Windows.Forms.Button();
      this.label6 = new System.Windows.Forms.Label();
      this.cbProduct = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 53);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(48, 15);
      this.label1.TabIndex = 0;
      this.label1.Text = "Nome*:";
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(12, 71);
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(199, 23);
      this.txtName.TabIndex = 1;
      // 
      // btnEdit
      // 
      this.btnEdit.ForeColor = System.Drawing.Color.DodgerBlue;
      this.btnEdit.Location = new System.Drawing.Point(369, 188);
      this.btnEdit.Name = "btnEdit";
      this.btnEdit.Size = new System.Drawing.Size(75, 23);
      this.btnEdit.TabIndex = 7;
      this.btnEdit.Text = "Editar";
      this.btnEdit.UseVisualStyleBackColor = true;
      this.btnEdit.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // cbCategory
      // 
      this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbCategory.FormattingEnabled = true;
      this.cbCategory.Location = new System.Drawing.Point(245, 115);
      this.cbCategory.Name = "cbCategory";
      this.cbCategory.Size = new System.Drawing.Size(199, 23);
      this.cbCategory.TabIndex = 4;
      // 
      // txtDescription
      // 
      this.txtDescription.Location = new System.Drawing.Point(245, 71);
      this.txtDescription.Name = "txtDescription";
      this.txtDescription.Size = new System.Drawing.Size(199, 23);
      this.txtDescription.TabIndex = 2;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(245, 53);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(66, 15);
      this.label2.TabIndex = 4;
      this.label2.Text = "Descri????o*:";
      // 
      // txtPrice
      // 
      this.txtPrice.Location = new System.Drawing.Point(12, 115);
      this.txtPrice.Name = "txtPrice";
      this.txtPrice.Size = new System.Drawing.Size(199, 23);
      this.txtPrice.TabIndex = 3;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 97);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(45, 15);
      this.label3.TabIndex = 5;
      this.label3.Text = "Pre??o*:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(245, 97);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(61, 15);
      this.label4.TabIndex = 6;
      this.label4.Text = "Categoria:";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(12, 141);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(70, 15);
      this.label5.TabIndex = 8;
      this.label5.Text = "Fornecedor:";
      // 
      // cbSupplier
      // 
      this.cbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbSupplier.FormattingEnabled = true;
      this.cbSupplier.Location = new System.Drawing.Point(12, 159);
      this.cbSupplier.Name = "cbSupplier";
      this.cbSupplier.Size = new System.Drawing.Size(432, 23);
      this.cbSupplier.TabIndex = 5;
      // 
      // btnCancel
      // 
      this.btnCancel.ForeColor = System.Drawing.Color.Red;
      this.btnCancel.Location = new System.Drawing.Point(12, 188);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 6;
      this.btnCancel.Text = "Cancelar";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(12, 9);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(53, 15);
      this.label6.TabIndex = 10;
      this.label6.Text = "Produto:";
      // 
      // cbProduct
      // 
      this.cbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbProduct.FormattingEnabled = true;
      this.cbProduct.Location = new System.Drawing.Point(12, 27);
      this.cbProduct.Name = "cbProduct";
      this.cbProduct.Size = new System.Drawing.Size(432, 23);
      this.cbProduct.TabIndex = 9;
      // 
      // EditProductForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(456, 226);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.cbProduct);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.cbSupplier);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtPrice);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtDescription);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cbCategory);
      this.Controls.Add(this.btnEdit);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = "EditProductForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "MiniERP - Editar produto";
      this.TopMost = true;
      this.Load += new System.EventHandler(this.EditProductForm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

  }

  #endregion

  private Label label1;
  private TextBox txtName;
  private Button btnEdit;
  private ComboBox cbCategory;
  private TextBox txtDescription;
  private Label label2;
  private TextBox txtPrice;
  private Label label3;
  private Label label4;
  private Label label5;
  private ComboBox cbSupplier;
  private Button btnCancel;
  private Label label6;
  private ComboBox cbProduct;
}
