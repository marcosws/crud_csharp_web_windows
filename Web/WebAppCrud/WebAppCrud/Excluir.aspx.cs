using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebAppCrud
{
    public partial class Excluir : System.Web.UI.Page
    {
        string Excluir_ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            Excluir_ID = Request.QueryString["excluir_id"];
            if (Excluir_ID == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Dados dados = new Dados();
                DataSet ds = new DataSet();
                ds = dados.ConsultaSql("SELECT * FROM clientes WHERE codigo = " + Excluir_ID);
                gridExcluir.DataSource = ds;
                gridExcluir.DataBind();
            }
        }
        protected void ExcluirCadastro(object sender, EventArgs e)
        {
            Dados dados = new Dados();
            dados.ExecutaSql("DELETE FROM clientes WHERE codigo = " + Excluir_ID);
            if (dados.erroGenMsg() != null)
            {
                LabelStatus.Text += dados.erroGenMsg();
            }
            if (dados.erroSqlMsg() != null)
            {
                LabelStatus.Text += dados.erroSqlMsg();
            }
            else
            {
                Response.Redirect("Consulta.aspx");
            }
        }
        protected void CancelarExclusao(object sender, EventArgs e)
        {
            Response.Redirect("Consulta.aspx");
        }
    }
}