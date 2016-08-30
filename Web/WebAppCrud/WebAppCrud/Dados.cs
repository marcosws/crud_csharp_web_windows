using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebAppCrud
{
    public class Dados
    {
        public string erroSql;
        public string erroGen;

        public string strConexao = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\CRUD_CSHARP\Web\WebAppCrud\WebAppCrud\App_Data\WebAppCrud.mdf;Integrated Security=True;User Instance=True";

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
                    erroSql = ex.Message;
                }
                conexao.Close();
            }
            catch (Exception ex)
            {
                erroGen = ex.Message;
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
                    erroSql = ex.Message;
                }
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = comando;
                da.Fill(ds);
                conexao.Close();
            }
            catch (Exception ex)
            {
                erroGen = ex.Message;
            }

            return ds;
        }
        public string erroSqlMsg()
        {
            return erroSql;
        }
        public string erroGenMsg()
        {
            return erroGen;
        }
    }
}