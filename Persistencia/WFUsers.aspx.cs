using Logic;
using Logic;
using SimpleCrypto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Persistencia
{
    public partial class WFUsers : System.Web.UI.Page
    {
        UsersLogic objUse = new UsersLogic();
        private string _mail, _contrasena, _salt, _state, _encryptedPassword;
        private int _id;
        private bool executed = false;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showUsers();
            }
        }

        private void showUsers()
        {
            DataSet objData = new DataSet();
            objData = objUse.showUsers();
            GVUsers.DataSource = objData;
            GVUsers.DataBind();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            ICryptoService cryptoService = new PBKDF2();
            _mail = TBMail.Text;
            _contrasena = TBContrasena.Text;
            _state = DDLState.SelectedValue;
            _salt = cryptoService.GenerateSalt();
            _encryptedPassword = cryptoService.Compute(_contrasena);

            executed = objUse.saveUsers(_mail, _encryptedPassword, _salt, _state);

            if (executed)
            {
                LblMsj.Text = "Se guardo exitosamente";
                showUsers();
                }
            else
            {
                LblMsj.Text = "Error al guardar";
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            ICryptoService cryptoService = new PBKDF2();
            _id = Convert.ToInt32(LblId.Text);
            _mail = TBMail.Text;
            _contrasena = TBContrasena.Text;
            _state = DDLState.SelectedValue;
            _salt = cryptoService.GenerateSalt();
            _encryptedPassword = cryptoService.Compute(_contrasena);

            executed = objUse.updateUsers(_id, _mail, _encryptedPassword, _salt, _state);

            if (executed)
            {
                LblMsj.Text = "Se actualizo exitosamente";
                showUsers();
            }
            else
            {
                LblMsj.Text = "Error al actualizan";
            }
        }

        protected void GVUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblId.Text = GVUsers.SelectedRow.Cells[0].Text;
            TBMail.Text = GVUsers.SelectedRow.Cells[1].Text;
            DDLState.SelectedValue = GVUsers.SelectedRow.Cells[4].Text;
        }
    }
}