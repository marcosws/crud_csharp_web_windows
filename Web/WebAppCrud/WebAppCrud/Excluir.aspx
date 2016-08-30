<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Excluir.aspx.cs" Inherits="WebAppCrud.Excluir" %>

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
    <asp:GridView ID="gridExcluir" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="codigo" HeaderText="Código" />
            <asp:BoundField DataField="nome" HeaderText="Nome" />
            <asp:BoundField DataField="email" HeaderText="EMail" />
            <asp:BoundField DataField="dt_atualizacao" HeaderText="Atualizacao" />
            <asp:BoundField DataField="descricao" HeaderText="Descricao" />
        </Columns>
    </asp:GridView>
    <br /><br />
    <asp:Button ID="BotaoExcluir" runat="server" OnClick="ExcluirCadastro" Text="Excluir"/>
    <asp:Button ID="BotaoCancelar" runat="server" OnClick="CancelarExclusao" Text="Cancelar"/>
    <br /><br />
    <asp:Label ID="LabelStatus" runat="server"  Text="Status: " ></asp:Label>
    </div>
    </form>
</body>
</html>
