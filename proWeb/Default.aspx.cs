using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace proWeb {
    public partial class _Default : Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                List<ENCategory> categories = new ENCategory().ReadAll();
                ddlCategory.Items.Clear();
                foreach (ENCategory cat in categories) {
                    ddlCategory.Items.Add(new ListItem(cat.Name, cat.Id.ToString()));
                }
            }
        }

        private ENProduct GetProductFromForm() {
            ENProduct en = new ENProduct();
            en.Code = Code.Text.Trim();
            en.Name = Name.Text.Trim();
            en.Amount = int.TryParse(Amount.Text, out int amt) ? amt : 0;
            en.Price = float.TryParse(Price.Text, out float prc) ? prc : 0;
            en.Category = int.Parse(ddlCategory.SelectedValue);
            en.CreationDate = DateTime.TryParse(Date.Text, out DateTime dt) ? dt : DateTime.Now;
            return en;
        }

        private void FillForm(ENProduct en) {
            Code.Text = en.Code;
            Name.Text = en.Name;
            Amount.Text = en.Amount.ToString();
            Price.Text = en.Price.ToString();
            Date.Text = en.CreationDate.ToString("yyyy-MM-dd");
            ddlCategory.SelectedValue = en.Category.ToString();
        }

        protected void BtnCreate_Click(object sender, EventArgs e) {
            ENProduct en = GetProductFromForm();
            // Comprobar que no existe ya un producto con ese Code
            ENProduct check = new ENProduct();
            check.Code = en.Code;
            if (check.Read()) {
                LblMessage.Text = "Error: ya existe un producto con ese Code.";
                return;
            }
            if (en.Create()) {
                LblMessage.Text = "Producto creado correctamente.";
                ClearForm();

            } else
                LblMessage.Text = "Error al crear el producto.";
        }

        protected void BtnUpdate_Click(object sender, EventArgs e) {
            ENProduct en = GetProductFromForm();
            // Comprobar que existe un producto con ese Code
            ENProduct check = new ENProduct();
            check.Code = en.Code;
            if (!check.Read()) {
                LblMessage.Text = "Error: no existe un producto con ese Code.";
                return;
            }
            if (en.Update())
                LblMessage.Text = "Producto actualizado correctamente.";
            else
                LblMessage.Text = "Error al actualizar el producto.";
        }

        protected void BtnDelete_Click(object sender, EventArgs e) {
            ENProduct en = new ENProduct();
            en.Code = Code.Text.Trim();
            if (en.Delete())
                LblMessage.Text = "Producto eliminado correctamente.";
            else
                LblMessage.Text = "Error al eliminar el producto.";
        }

        protected void BtnRead_Click(object sender, EventArgs e) {
            ENProduct en = new ENProduct();
            en.Code = Code.Text.Trim();
            if (en.Read()) {
                FillForm(en);
                LblMessage.Text = "Producto leído correctamente.";
            } else
                LblMessage.Text = "Error: no se encontró el producto.";
        }

        protected void BtnReadFirst_Click(object sender, EventArgs e) {
            ENProduct en = new ENProduct();
            if (en.ReadFirst()) {
                FillForm(en);
                LblMessage.Text = "Primer producto leído correctamente.";
            } else
                LblMessage.Text = "Error: no hay productos en la base de datos.";
        }

        protected void BtnReadPrev_Click(object sender, EventArgs e) {
            ENProduct en = new ENProduct();
            en.Code = Code.Text.Trim();
            if (en.ReadPrev()) {
                FillForm(en);
                LblMessage.Text = "Producto anterior leído correctamente.";
            } else
                LblMessage.Text = "Error: no hay producto anterior.";
        }

        protected void BtnReadNext_Click(object sender, EventArgs e) {
            ENProduct en = new ENProduct();
            en.Code = Code.Text.Trim();
            if (en.ReadNext()) {
                FillForm(en);
                LblMessage.Text = "Producto siguiente leído correctamente.";
            } else
                LblMessage.Text = "Error: no hay producto siguiente.";
        }

        private void ClearForm() {
            Code.Text = "";
            Name.Text = "";
            Amount.Text = "";
            Price.Text = "";
            Date.Text = "";
            ddlCategory.SelectedIndex = 0;
        }
    }
}