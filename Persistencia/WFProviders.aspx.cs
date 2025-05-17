using Logic;
using System;
using System.Data;
using System.Web.UI;

namespace Persistencia
{
    public partial class WFProviders : System.Web.UI.Page
    {
        ProvidersLogic objProv = new ProvidersLogic();
        private string _nit, _name;
        private int _id;
        private bool executed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showProviders();
            }
        }

        private void showProviders()
        {
            DataSet objData = objProv.showProviders();
            GVProvider.DataSource = objData;
            GVProvider.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            _nit = TBNit.Text;
            _name = TBName.Text;
            executed = objProv.saveProvider(_nit, _name);

            if (executed)
            {
                LblMsj.Text = "Se guardó exitosamente";
                showProviders();
            }
            else
            {
                LblMsj.Text = "Error al guardar";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(TBId.Text);
            _nit = TBNit.Text;
            _name = TBName.Text;
            executed = objProv.updateProvider(_id, _nit, _name);

            if (executed)
            {
                LblMsj.Text = "Se actualizó exitosamente";
                showProviders();
            }
            else
            {
                LblMsj.Text = "Error al actualizar";
            }
        }

        protected void GVProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBId.Text = GVProvider.SelectedRow.Cells[1].Text;
            TBNit.Text = GVProvider.SelectedRow.Cells[2].Text;
            TBName.Text = GVProvider.SelectedRow.Cells[3].Text;
        }
    }
}