using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebAppCrud
{
    public partial class Default : System.Web.UI.Page
    {
        
        string Alterar_ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            Alterar_ID = Request.QueryString["alterar_id"];
            if (Alterar_ID == null)
            {
                BotaoIncluirAlterar.Text = "Incluir";
            }
            else
            {
                BotaoIncluirAlterar.Text = "Alterar";
                Dados dados = new Dados();
                DataSet ds = new DataSet();
                ds = dados.ConsultaSql("SELECT nome, email, descricao FROM clientes WHERE codigo = " + Alterar_ID);
                if (TextoNome.Text == "")
                {
                    TextoNome.Text = ds.Tables[0].Rows[0]["nome"].ToString();
                    TextoEmail.Text = ds.Tables[0].Rows[0]["email"].ToString();
                    TextoDescricao.Text = ds.Tables[0].Rows[0]["descricao"].ToString();
                }
            }
        }
        protected void IncluirAlterarCadastro(object sender, EventArgs e)
        {
            Dados dados = new Dados();
            if (Alterar_ID == null)
            {
                //incluir
                dados.ExecutaSql("INSERT INTO clientes(nome,email,descricao) VALUES('" + TextoNome.Text + "','" + TextoEmail.Text + "','" + TextoDescricao.Text + "')");
                if (dados.erroGenMsg() != null)
                {
                    LabelStatus.Text += dados.erroGenMsg();
                }
                else if (dados.erroSqlMsg() != null)
                {
                    LabelStatus.Text += dados.erroSqlMsg();
                }
                else
                {
                    Response.Redirect("Consulta.aspx");
                }
            }
            else
            {
                //alterar
                dados.ExecutaSql("UPDATE clientes SET nome='" + TextoNome.Text + "',email='" + TextoEmail.Text + "',descricao='" + TextoDescricao.Text + "' WHERE codigo = " + Alterar_ID);
                if (dados.erroGenMsg() != null)
                {
                    LabelStatus.Text += dados.erroGenMsg();
                }
                else if (dados.erroSqlMsg() != null)
                {
                    LabelStatus.Text += dados.erroSqlMsg();
                }
                else
                {
                    Response.Redirect("Consulta.aspx");
                }
            }
            
        }

    }
}