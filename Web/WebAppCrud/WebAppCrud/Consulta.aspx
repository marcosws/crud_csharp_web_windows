<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="WebAppCrud.Consulta" %>

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
        <a href="Default.aspx">Incluir</a>
        <br /><br />
        <asp:GridView ID="gridClientes" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField Datafield="codigo" HeaderText="Código" />
                <asp:BoundField DataField="nome" HeaderText="Nome" />
                <asp:BoundField DataField="email" HeaderText="E-Mail" />
                <asp:BoundField DataField="descricao" HeaderText="Descricao" />
                <asp:BoundField DataField="dt_atualizacao" HeaderText="Atualizacao" />
                <asp:TemplateField>
                    <HeaderTemplate>Operação</HeaderTemplate>
                    <ItemTemplate>
                        <a href="Default.aspx?alterar_id=<%#Eval("codigo") %>">Alterar</a>
                        <% Response.Write(" | "); %>
                        <a href="Excluir.aspx?excluir_id=<%#Eval("codigo") %>">Excluir</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
