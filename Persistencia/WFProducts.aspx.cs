using Data;
using Logic;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Persistencia
{
    public partial class WFProducts : System.Web.UI.Page
    {
        ProductsData objPro = new ProductsData();
        CategoryLogic objCat = new CategoryLogic();
        ProvidersLogic objPrv = new ProvidersLogic();

        private string _code, _description;
        private int _id, _quantity, _fkCategory, _fkProduct;
        private double _price;
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showProducts();
                showCategoriesDDL();
                showProvidersDDL();
            }
        }
        private void showProducts()
        {
            DataSet objData = new DataSet();
            objData = objPro.showProducts();
            GVProducts.DataSource = objData;
            GVProducts.DataBind();

        }

        private void showCategoriesDDL()
        {
            DDLCategories.DataSource = objCat.showCategories();
            DDLCategories.DataValueField = "cat_id";
            DDLCategories.DataTextField = "cat_description";
            DDLCategories.DataBind();
            DDLCategories.Items.Insert(0, "Seleccione");

        }

        protected void GVPProducts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[8].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[8].Visible = false;
            }
        }

        private void showProvidersDDL()
        {
            DDLProviders.DataSource = objPrv.showProvidersDDL();
            DDLProviders.DataValueField = "prov_id";
            DDLProviders.DataTextField = "prov_nombre";
            DDLProviders.DataBind();
            DDLProviders.Items.Insert(0, "Seleccione");
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _code = TBCode.Text;
            _description = TBDescription.Text;
            _quantity = Convert.ToInt32(TBQuantity.Text);
            _price = Convert.ToDouble(TBPrice.Text);
            _fkCategory = Convert.ToInt32(DDLCategories.SelectedValue);
            _fkProduct = Convert.ToInt32(DDLProviders.SelectedValue);

            executed = objPro.saveProducts(_code, _description, _quantity, _price, _fkCategory, _fkProduct);
            if (executed)
            {
                LblMsj.Text = "Se guardo exitosamente";
                showProducts();
            }
            else
            {
                LblMsj.Text = "Error al guardar";
            }
        }

        protected void BrunUpdate_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(TBId.Text);
            _code = TBCode.Text;
            _description = TBDescription.Text;
            _quantity = Convert.ToInt32(TBQuantity.Text);
            _price = Convert.ToDouble(TBPrice.Text);
            _fkCategory = Convert.ToInt32(DDLCategories.SelectedValue);
            _fkProduct = Convert.ToInt32(DDLProviders.SelectedValue);
            executed = objPro.updateProducts(_id, _code, _description, _quantity, _price, _fkCategory, _fkProduct);

            if (executed)
            {
                LblMsj.Text = "Se actualizo exitosamente";
                showProducts();
            }
            else
            {
                LblMsj.Text = "Error al actualizar";
            }
        }
        protected void GVProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBId.Text = GVProducts.SelectedRow.Cells[1].Text;
            TBCode.Text = GVProducts.SelectedRow.Cells[2].Text;
            TBDescription.Text = GVProducts.SelectedRow.Cells[3].Text;
            TBQuantity.Text = GVProducts.SelectedRow.Cells[4].Text;
            TBPrice.Text = GVProducts.SelectedRow.Cells[5].Text;
            DDLCategories.SelectedValue = GVProducts.SelectedRow.Cells[6].Text;
            DDLProviders.SelectedValue = GVProducts.SelectedRow.Cells[8].Text;
        }
    }
}