// Copyright (c) Bruno Sales <me@baliestri.dev>. Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using Challenge02.Forms;

namespace Challenge02;

public partial class MainForm : Form {
  private readonly CreateCategoryForm _createCategory;
  private readonly CreateCustomerForm _createCustomer;
  private readonly CreateOrderForm _createOrder;
  private readonly CreateProductForm _createProduct;
  private readonly CreateShipperForm _createShipper;
  private readonly CreateSupplierForm _createSupplier;
  private readonly EditCategoryForm _editCategory;
  private readonly EditCustomerForm _editCustomer;
  private readonly EditProductForm _editProduct;
  private readonly EditShipperForm _editShipper;
  private readonly EditSupplierForm _editSupplier;
  private readonly EmitInvoiceForm _emitInvoice;
  private readonly QueryForm _queryForm;

  public MainForm(
    QueryForm queryForm, CreateCategoryForm createCategory,
    EditCategoryForm editCategory, CreateCustomerForm createCustomer, EditCustomerForm editCustomer,
    CreateSupplierForm createSupplier, EditSupplierForm editSupplier, CreateShipperForm createShipper,
    EditShipperForm editShipper, CreateOrderForm createOrder, EmitInvoiceForm emitInvoice,
    CreateProductForm createProduct, EditProductForm editProduct
  ) {
    InitializeComponent();

    _queryForm = queryForm;
    _createCategory = createCategory;
    _editCategory = editCategory;
    _createCustomer = createCustomer;
    _editCustomer = editCustomer;
    _createSupplier = createSupplier;
    _editSupplier = editSupplier;
    _createShipper = createShipper;
    _editShipper = editShipper;
    _createOrder = createOrder;
    _emitInvoice = emitInvoice;
    _createProduct = createProduct;
    _editProduct = editProduct;
  }

  private void btnCreateCategory_Click(object sender, EventArgs e)
    => _createCategory.ShowDialog();

  private void btnQuery_Click(object sender, EventArgs e)
    => _queryForm.ShowDialog();

  private void btnEditCategory_Click(object sender, EventArgs e)
    => _editCategory.ShowDialog();

  private void btnCreateCustomer_Click(object sender, EventArgs e)
    => _createCustomer.ShowDialog();

  private void btnEditCustomer_Click(object sender, EventArgs e)
    => _editCustomer.ShowDialog();

  private void btnCreateSupplier_Click(object sender, EventArgs e)
    => _createSupplier.ShowDialog();

  private void btnEditorSupplier_Click(object sender, EventArgs e)
    => _editSupplier.ShowDialog();

  private void btnCreateShipper_Click(object sender, EventArgs e)
    => _createShipper.ShowDialog();

  private void btnEditShipper_Click(object sender, EventArgs e)
    => _editShipper.ShowDialog();

  private void btnCreateOrder_Click(object sender, EventArgs e)
    => _createOrder.ShowDialog();

  private void btnEmit_Click(object sender, EventArgs e)
    => _emitInvoice.ShowDialog();

  private void btnAddProduct_Click(object sender, EventArgs e)
    => _createProduct.ShowDialog();

  private void btnEditProduct_Click(object sender, EventArgs e)
    => _editProduct.ShowDialog();
}
