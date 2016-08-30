using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;

namespace WinAppCrud
{
    class Dados
    {
        private string strConexao = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\CRUD_CSHARP\Win\WinAppCrud\WinAppCrud\WinAppDB.mdf;Integrated Security=True;User Instance=True";

        public void ExecutaSql(string sql)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(strConexao);
                SqlCommand comando = new SqlCommand(sql, conexao);
                conexao.Open();
                try
                {
                    comando.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erro de SQL: " + ex.Message);
                }
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        public DataSet ConsultaSql(string sql)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection conexao = new SqlConnection(strConexao);
                SqlCommand comando = new SqlCommand(sql, conexao);
                conexao.Open();
                try
                {
                    comando.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erro de SQL: " + ex.Message);
                }
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = comando;
                da.Fill(ds);
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            return ds;
        }
    }
}
