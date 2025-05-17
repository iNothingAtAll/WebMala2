<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFUsers.aspx.cs" Inherits="Persistencia.WFUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="LblId" runat="server" Text=""></asp:Label>
    <asp:Label ID="Labell" runat="server" Text="Ingress el correo"></asp:Label>
    <asp:TextBox ID="TBMail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Ingress la contraseña"></asp:Label>
    <asp:TextBox ID="TBContrasena" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Label ID="Labels" runat="server" Text="Estado"></asp:Label>
    <asp:DropDownList ID="DDLState" runat="server" CssClass="form-select">
        <asp:ListItem Value="0">Selecciones </asp:ListItem>
        <asp:ListItem Value="Activo">Activos </asp:ListItem>
        <asp:ListItem Value="Inactivo">Inactivos </asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="BtnSave_Click" />
    <asp:Button ID="BtnUpdate" runat="server" CssClass="btn btn-primary" Text="Actualizar" OnClick="BtnUpdate_Click" />
    <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
    <br />
    <asp:GridView ID="GVUsers" runat="server" CssClass="table" AutodeneratedColumns="False"
        OnSelectedIndexChanged="GVUsers_SelectedIndexChanged">
        <Columns>
        <asp:BoundField DataField="usu_id" HeaderText="Id" />
        <asp:BoundField DataField="usu_correo" HeaderText="Correo" />
        <asp:BoundField DataField="usu_contrasena" HeaderText="Contraseña" />
        <asp:BoundField DataField="usu_salt" HeaderText="Salt" />
        <asp:BoundField DataField="usu_estado" HeaderText="Estado" />
        <asp:CommandField ShowSelectButton="True" />
    </Columns>
    </asp:GridView>
</asp:Content>
