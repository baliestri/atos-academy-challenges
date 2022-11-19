// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

namespace Challenge02;

partial class MainForm {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCreateShipper = new System.Windows.Forms.Button();
            this.btnCreateSupplier = new System.Windows.Forms.Button();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.btnCreateCustomer = new System.Windows.Forms.Button();
            this.btnCreateCategory = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEditShipper = new System.Windows.Forms.Button();
            this.btnEditorSupplier = new System.Windows.Forms.Button();
            this.btnEditCategory = new System.Windows.Forms.Button();
            this.btnEditCustomer = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnEmit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCreateShipper);
            this.groupBox1.Controls.Add(this.btnCreateSupplier);
            this.groupBox1.Controls.Add(this.btnCreateOrder);
            this.groupBox1.Controls.Add(this.btnCreateCustomer);
            this.groupBox1.Controls.Add(this.btnCreateCategory);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criar";
            // 
            // btnCreateShipper
            // 
            this.btnCreateShipper.Location = new System.Drawing.Point(125, 51);
            this.btnCreateShipper.Name = "btnCreateShipper";
            this.btnCreateShipper.Size = new System.Drawing.Size(75, 23);
            this.btnCreateShipper.TabIndex = 4;
            this.btnCreateShipper.Text = "Entregador";
            this.btnCreateShipper.UseVisualStyleBackColor = true;
            this.btnCreateShipper.Click += new System.EventHandler(this.btnCreateShipper_Click);
            // 
            // btnCreateSupplier
            // 
            this.btnCreateSupplier.Location = new System.Drawing.Point(44, 51);
            this.btnCreateSupplier.Name = "btnCreateSupplier";
            this.btnCreateSupplier.Size = new System.Drawing.Size(75, 23);
            this.btnCreateSupplier.TabIndex = 3;
            this.btnCreateSupplier.Text = "Fornecedor";
            this.btnCreateSupplier.UseVisualStyleBackColor = true;
            this.btnCreateSupplier.Click += new System.EventHandler(this.btnCreateSupplier_Click);
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Location = new System.Drawing.Point(168, 22);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(75, 23);
            this.btnCreateOrder.TabIndex = 2;
            this.btnCreateOrder.Text = "Pedido";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // btnCreateCustomer
            // 
            this.btnCreateCustomer.Location = new System.Drawing.Point(87, 22);
            this.btnCreateCustomer.Name = "btnCreateCustomer";
            this.btnCreateCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnCreateCustomer.TabIndex = 1;
            this.btnCreateCustomer.Text = "Cliente";
            this.btnCreateCustomer.UseVisualStyleBackColor = true;
            this.btnCreateCustomer.Click += new System.EventHandler(this.btnCreateCustomer_Click);
            // 
            // btnCreateCategory
            // 
            this.btnCreateCategory.Location = new System.Drawing.Point(6, 22);
            this.btnCreateCategory.Name = "btnCreateCategory";
            this.btnCreateCategory.Size = new System.Drawing.Size(75, 23);
            this.btnCreateCategory.TabIndex = 0;
            this.btnCreateCategory.Text = "Categoria";
            this.btnCreateCategory.UseVisualStyleBackColor = true;
            this.btnCreateCategory.Click += new System.EventHandler(this.btnCreateCategory_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEditShipper);
            this.groupBox2.Controls.Add(this.btnEditorSupplier);
            this.groupBox2.Controls.Add(this.btnEditCategory);
            this.groupBox2.Controls.Add(this.btnEditCustomer);
            this.groupBox2.Location = new System.Drawing.Point(267, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 83);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Editar";
            // 
            // btnEditShipper
            // 
            this.btnEditShipper.Location = new System.Drawing.Point(125, 51);
            this.btnEditShipper.Name = "btnEditShipper";
            this.btnEditShipper.Size = new System.Drawing.Size(75, 23);
            this.btnEditShipper.TabIndex = 8;
            this.btnEditShipper.Text = "Entregador";
            this.btnEditShipper.UseVisualStyleBackColor = true;
            this.btnEditShipper.Click += new System.EventHandler(this.btnEditShipper_Click);
            // 
            // btnEditorSupplier
            // 
            this.btnEditorSupplier.Location = new System.Drawing.Point(44, 51);
            this.btnEditorSupplier.Name = "btnEditorSupplier";
            this.btnEditorSupplier.Size = new System.Drawing.Size(75, 23);
            this.btnEditorSupplier.TabIndex = 7;
            this.btnEditorSupplier.Text = "Fornecedor";
            this.btnEditorSupplier.UseVisualStyleBackColor = true;
            this.btnEditorSupplier.Click += new System.EventHandler(this.btnEditorSupplier_Click);
            // 
            // btnEditCategory
            // 
            this.btnEditCategory.Location = new System.Drawing.Point(6, 22);
            this.btnEditCategory.Name = "btnEditCategory";
            this.btnEditCategory.Size = new System.Drawing.Size(75, 23);
            this.btnEditCategory.TabIndex = 5;
            this.btnEditCategory.Text = "Categoria";
            this.btnEditCategory.UseVisualStyleBackColor = true;
            this.btnEditCategory.Click += new System.EventHandler(this.btnEditCategory_Click);
            // 
            // btnEditCustomer
            // 
            this.btnEditCustomer.Location = new System.Drawing.Point(87, 22);
            this.btnEditCustomer.Name = "btnEditCustomer";
            this.btnEditCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnEditCustomer.TabIndex = 6;
            this.btnEditCustomer.Text = "Cliente";
            this.btnEditCustomer.UseVisualStyleBackColor = true;
            this.btnEditCustomer.Click += new System.EventHandler(this.btnEditCustomer_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(12, 101);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(249, 23);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "Consultar";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnEmit
            // 
            this.btnEmit.Location = new System.Drawing.Point(267, 101);
            this.btnEmit.Name = "btnEmit";
            this.btnEmit.Size = new System.Drawing.Size(205, 23);
            this.btnEmit.TabIndex = 3;
            this.btnEmit.Text = "Emitir NF-e";
            this.btnEmit.UseVisualStyleBackColor = true;
            this.btnEmit.Click += new System.EventHandler(this.btnEmit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 134);
            this.Controls.Add(this.btnEmit);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MiniERP";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

  }

  #endregion

  private GroupBox groupBox1;
  private Button btnCreateShipper;
  private Button btnCreateSupplier;
  private Button btnCreateOrder;
  private Button btnCreateCustomer;
  private Button btnCreateCategory;
  private GroupBox groupBox2;
  private Button btnEditShipper;
  private Button btnEditorSupplier;
  private Button btnEditCategory;
  private Button btnEditCustomer;
  private Button btnQuery;
  private Button btnEmit;
}