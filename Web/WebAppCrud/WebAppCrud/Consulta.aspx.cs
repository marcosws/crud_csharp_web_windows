using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebAppCrud
{
    public partial class Consulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            Dados dados = new Dados();
            ds = dados.ConsultaSql("SELECT * FROM clientes");
            gridClientes.DataSource = ds;
            gridClientes.DataBind();
        }
    }
}