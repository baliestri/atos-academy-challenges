// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

namespace Challenge02.Forms;

partial class CreateOrderForm {
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtOrderDate = new System.Windows.Forms.DateTimePicker();
            this.dtShipDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbShipper = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtQuantity = new System.Windows.Forms.MaskedTextBox();
            this.dtPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(13, 364);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente*:";
            // 
            // cbCustomer
            // 
            this.cbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Location = new System.Drawing.Point(12, 27);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(359, 23);
            this.cbCustomer.TabIndex = 3;
            this.cbCustomer.SelectedIndexChanged += new System.EventHandler(this.cbCustomer_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Data do pedido*:";
            // 
            // dtOrderDate
            // 
            this.dtOrderDate.CustomFormat = "";
            this.dtOrderDate.Location = new System.Drawing.Point(12, 71);
            this.dtOrderDate.Name = "dtOrderDate";
            this.dtOrderDate.Size = new System.Drawing.Size(359, 23);
            this.dtOrderDate.TabIndex = 5;
            // 
            // dtShipDate
            // 
            this.dtShipDate.CustomFormat = "";
            this.dtShipDate.Location = new System.Drawing.Point(12, 115);
            this.dtShipDate.Name = "dtShipDate";
            this.dtShipDate.Size = new System.Drawing.Size(359, 23);
            this.dtShipDate.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data do envio*:";
            // 
            // cbShipper
            // 
            this.cbShipper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShipper.FormattingEnabled = true;
            this.cbShipper.Location = new System.Drawing.Point(12, 159);
            this.cbShipper.Name = "cbShipper";
            this.cbShipper.Size = new System.Drawing.Size(359, 23);
            this.cbShipper.TabIndex = 9;
            this.cbShipper.SelectedIndexChanged += new System.EventHandler(this.cbShipper_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Empresa de entrega*:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Preço Total (R$)*:";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(12, 203);
            this.txtTotalPrice.Mask = "$ 999,999.00";
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(359, 23);
            this.txtTotalPrice.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Data do pagamento*:";
            // 
            // cbProduct
            // 
            this.cbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProduct.FormattingEnabled = true;
            this.cbProduct.Location = new System.Drawing.Point(12, 291);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(359, 23);
            this.cbProduct.TabIndex = 15;
            this.cbProduct.SelectedIndexChanged += new System.EventHandler(this.cbProduct_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Produto*:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 317);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "Quantidade*:";
            // 
            // btnCreate
            // 
            this.btnCreate.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnCreate.Location = new System.Drawing.Point(297, 364);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 18;
            this.btnCreate.Text = "Criar";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(13, 335);
            this.txtQuantity.Mask = "000";
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(359, 23);
            this.txtQuantity.TabIndex = 19;
            // 
            // dtPaymentDate
            // 
            this.dtPaymentDate.CustomFormat = "";
            this.dtPaymentDate.Location = new System.Drawing.Point(12, 247);
            this.dtPaymentDate.Name = "dtPaymentDate";
            this.dtPaymentDate.Size = new System.Drawing.Size(359, 23);
            this.dtPaymentDate.TabIndex = 20;
            // 
            // CreateOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 401);
            this.Controls.Add(this.dtPaymentDate);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbProduct);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbShipper);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtShipDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtOrderDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCustomer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CreateOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MiniERP - Criar pedido";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CreateOrderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

  }

  #endregion

  private Button btnCancel;
  private Label label1;
  private ComboBox cbCustomer;
  private Label label2;
  private DateTimePicker dtOrderDate;
  private DateTimePicker dtShipDate;
  private Label label3;
  private ComboBox cbShipper;
  private Label label4;
  private Label label5;
  private MaskedTextBox txtTotalPrice;
  private Label label6;
  private ComboBox cbProduct;
  private Label label7;
  private Label label8;
  private Button btnCreate;
  private MaskedTextBox txtQuantity;
  private DateTimePicker dtPaymentDate;
}