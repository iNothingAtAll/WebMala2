<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFCategories.aspx.cs" Inherits="Persistencia.WFCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:TextBox ID="TBId" runat="server" Visible="false"></asp:TextBox><br />
        <asp:Label ID="LblDescription" runat="server" Text="Ingrese la descripcion"></asp:Label>
        <asp:TextBox ID="TBDescription" runat="server"></asp:TextBox>
        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click"/>
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click"/><br />
        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label><br />
    </div>

    <div>
        <asp:GridView ID="GVCategory" runat="server" CssClass="table table-hover" OnSelectedIndexChanged="GVCategory_SelectedIndexChanged"
            DataKeyNames="cat_id" OnRowDeleting="GVCategory_RowDeleting">
            <Columns>
                <asp:CommandField ShowSelectButton="true"/>
                <asp:CommandField ShowSelectButton="true"/>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
