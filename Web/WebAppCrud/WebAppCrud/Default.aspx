<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppCrud.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>CRUD ASP.NET</h1>
            <br /><br />
            <a href="Consulta.aspx">Consulta</a>
            <br /><br />
            <table>
                <tr>
                    <td><asp:Label ID="LabelNome" runat="server" Text="Nome: " ></asp:Label></td>
                    <td><asp:TextBox ID="TextoNome" runat="server" ></asp:TextBox></td>
                </tr>
                <tr>
                     <td><asp:Label ID="LabelEmail" runat="server"  Text="Email: " ></asp:Label></td>
                     <td><asp:TextBox ID="TextoEmail" runat="server" ></asp:TextBox></td>
                </tr>
                <tr>
                     <td><asp:Label ID="LabelDescricao" runat="server"  Text="Descricao: " ></asp:Label></td>
                     <td><asp:TextBox ID="TextoDescricao" runat="server" ></asp:TextBox></td>
                </tr>
            </table>
            <asp:Button ID="BotaoIncluirAlterar" runat="server" onclick="IncluirAlterarCadastro" Text="" ></asp:Button>
            <br /><br />
            <td><asp:Label ID="LabelStatus" runat="server"  Text="Status: " ></asp:Label></td>
        </div>
    </form>
</body>
</html>
