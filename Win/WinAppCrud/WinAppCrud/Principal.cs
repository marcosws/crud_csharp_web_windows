using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinAppCrud
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        const string INCLUIR = "incluir";
        const string ALTERAR = "alterar";
        const string EXCLUIR = "excluir";
        const string CONSULTAR = "consulta";

        public string Operacao;
        public string codigo;

        private string DataHoraCorrente()
        {
            string datahora = DateTime.Now.ToString("u");
            datahora = datahora.Replace("Z", "");
            return datahora;
        }
        private void desabilitaBota()
        {
            btIncluir.Enabled = false;
            btAlterar.Enabled = false;
            btExcluir.Enabled = false;
            btConsultar.Enabled = false;
            btConfirmar.Enabled = true;
            btCancelar.Enabled = true;
        }
        private void Executa(string operacao)
        {
            Dados dados = new Dados();
            if (operacao == INCLUIR)
            {
                dados.ExecutaSql("INSERT INTO clientes(nome,email,descricao,dt_atualizacao) VALUES('" + edNome.Text + "','" + edEmail.Text + "','" + edDescricao.Text + "','" + this.DataHoraCorrente() + "')");
                this.consulta();
            }
            else if (operacao == ALTERAR)
            {
                dados.ExecutaSql("UPDATE clientes SET nome='" + edNome.Text + "',email='" + edEmail.Text + "',descricao='" + edDescricao.Text + "',dt_atualizacao='" + this.DataHoraCorrente() + "' WHERE codigo = " + edCodigo.Text);
                this.consulta();
            }
            else if (operacao == EXCLUIR)
            {
                dados.ExecutaSql("DELETE FROM clientes WHERE codigo = " + edCodigo.Text);
                this.consulta();
            }
            else if (operacao == CONSULTAR)
            {
                this.consulta();
            }
        }
        private void consulta()
        {
            Dados dados = new Dados();
            DataSet ds = new DataSet();
            ds = dados.ConsultaSql("SELECT codigo AS Codigo, nome AS Nome, email AS E_mail, descricao AS Descricao, dt_atualizacao AS Atualizacao FROM clientes");
            gridClientes.DataSource = ds;
            gridClientes.DataMember = ds.Tables[0].TableName;
        }
        private void btConfirmar_Click(object sender, EventArgs e)
        {
            btIncluir.Enabled = true;
            btAlterar.Enabled = true;
            btExcluir.Enabled = true;
            btConsultar.Enabled = true;
            btConfirmar.Enabled = false;
            btCancelar.Enabled = false;

            this.Executa(Operacao);
        }

        private void btIncluir_Click(object sender, EventArgs e)
        {
            this.desabilitaBota();
            this.Operacao = INCLUIR;
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            this.desabilitaBota();
            this.Operacao = ALTERAR;
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            this.desabilitaBota();
            this.Operacao = EXCLUIR;
        }

        private void btConsultar_Click(object sender, EventArgs e)
        {
            this.desabilitaBota();
            this.Operacao = CONSULTAR;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            btIncluir.Enabled = true;
            btAlterar.Enabled = true;
            btExcluir.Enabled = true;
            btConsultar.Enabled = true;
            btConfirmar.Enabled = false;
            btCancelar.Enabled = false;
        }

        private void gridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow linhaGrid = this.gridClientes.Rows[e.RowIndex];
            edCodigo.Text = linhaGrid.Cells[0].Value.ToString();
            edNome.Text = linhaGrid.Cells[1].Value.ToString();
            edEmail.Text = linhaGrid.Cells[2].Value.ToString();
            edDescricao.Text = linhaGrid.Cells[3].Value.ToString();
        }
    }
}
