<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Persistencia.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LblUsuario" runat="server" Text="Usuario"></asp:Label>
            <asp:TextBox ID="TxtUsuserio" runat="server"></asp:TextBox> <br />

            <asp:Label ID="LblContrasenya" runat="server" Text="Contraseña"></asp:Label>
            <asp:TextBox ID="TxtContrasenya" runat="server" TextMode="Password"></asp:TextBox> <br />

            <asp:Button ID="BtnIniciar" runat="server" Text="Iniciar"></asp:Button><br />
            <asp:Label ID="LblMensaje" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
