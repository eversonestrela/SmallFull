using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace Alcastock.Repositorios
{
    public class ProdutoRepositorio
    {
        private readonly string _connectionString;

        public ProdutoRepositorio()
        {
            _connectionString = Utilitarios.conStr;
        }

        public List<ProdutoModel> Consultar(string tipoConsulta, string descricao)
        {
            List<ProdutoModel> produtos = new List<ProdutoModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                SELECT * FROM PRODUTOS WHERE 1=1";

                if (tipoConsulta == "0")
                    query += " AND NOME LIKE @DESCRICAO";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@DESCRICAO", "%" + descricao + "%");

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProdutoModel produto = new ProdutoModel
                    {
                        PRODUTO_ID = int.Parse(reader["PESSOA_ID"].ToString()),
                        CODIGO = reader["CODIGO"].ToString(),
                        TIPO = reader["TIPO"].ToString(),
                        NOME = reader["NOME"].ToString(),
                        GRUPO = reader["GRUPO"].ToString(),
                        MARCA = reader["MARCA"].ToString(),
                        UNIDADE_MEDIDA = reader["UNIDADE_MEDIDA"].ToString(),
                        CUSTO = Convert.ToDecimal(reader["CUSTO"].ToString()),
                        LUCRO_ESPERADO = Convert.ToDecimal(reader["LUCRO_ESPERADO"].ToString()),
                        PERC_LUCRO = Convert.ToDecimal(reader["PERC_LUCRO"].ToString()),
                        PRECO_VENDA = Convert.ToDecimal(reader["PRECO_VENDA"].ToString()),
                        CONTROLA_ESTOQUE = reader["CONTROLA_ESTOQUE"].ToString(),
                        ESTOQUE_MININO = int.Parse(reader["ESTOQUE_MININO"].ToString()),
                        ESTOQUE_ATUAL = int.Parse(reader["ESTOQUE_ATUAL"].ToString()),
                        STATUS = int.Parse(reader["STATUS"].ToString()),
                        SIS_DATA_INSERT = Convert.ToDateTime(reader["SIS_DATA_INSERT"]),
                        SIS_DATA_UPDATE = Convert.ToDateTime(reader["SIS_DATA_UPDATE"])
                    };

                    produtos.Add(produto);
                }
            }

            return produtos;
        }

        public List<ProdutoModel> ConsultarPorId(string produtoId)
        {
            List<ProdutoModel> produtos = new List<ProdutoModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                SELECT * FROM PRODUTOS WHERE PRODUTO_ID = @PRODUTO_ID";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@PRODUTO_ID", produtoId);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProdutoModel produto = new ProdutoModel
                    {
                        PRODUTO_ID = int.Parse(reader["PESSOA_ID"].ToString()),
                        CODIGO = reader["CODIGO"].ToString(),
                        TIPO = reader["TIPO"].ToString(),
                        NOME = reader["NOME"].ToString(),
                        GRUPO = reader["GRUPO"].ToString(),
                        MARCA = reader["MARCA"].ToString(),
                        UNIDADE_MEDIDA = reader["UNIDADE_MEDIDA"].ToString(),
                        CUSTO = Convert.ToDecimal(reader["CUSTO"].ToString()),
                        LUCRO_ESPERADO = Convert.ToDecimal(reader["LUCRO_ESPERADO"].ToString()),
                        PERC_LUCRO = Convert.ToDecimal(reader["PERC_LUCRO"].ToString()),
                        PRECO_VENDA = Convert.ToDecimal(reader["PRECO_VENDA"].ToString()),
                        CONTROLA_ESTOQUE = reader["CONTROLA_ESTOQUE"].ToString(),
                        ESTOQUE_MININO = int.Parse(reader["ESTOQUE_MININO"].ToString()),
                        ESTOQUE_ATUAL = int.Parse(reader["ESTOQUE_ATUAL"].ToString()),
                        STATUS = int.Parse(reader["STATUS"].ToString()),
                        SIS_DATA_INSERT = Convert.ToDateTime(reader["SIS_DATA_INSERT"]),
                        SIS_DATA_UPDATE = Convert.ToDateTime(reader["SIS_DATA_UPDATE"])
                    };

                    produtos.Add(produto);
                }
            }

            return produtos;
        }

        /// <summary>
        /// Método para salvar o produto
        /// </summary>
        /// <param name="produto">ProdutoModel</param>
        public void Salvar(ProdutoModel produto)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"SET DATEFORMAT DMY; INSERT INTO PESSOAS (NOME, CPF, DATA_NASC, SEXO, NOME_MAE, CPF_MAE, NOME_PAI, CPF_PAI
                                , TELEFONE_RESIDENCIAL, TELEFONE_CELULAR, EMAIL, SIS_USUARIO_INSERT, SIS_DATA_INSERT)
                                VALUES (@NOME, @CPF, @DATA_NASC, @SEXO, @NOME_MAE, @CPF_MAE, @NOME_PAI, @CPF_PAI,
                                @TELEFONE_RESIDENCIAL, @TELEFONE_CELULAR, @EMAIL, @SIS_USUARIO_INSERT, @SIS_DATA_INSERT)";

                SqlCommand cmd = new SqlCommand(query, connection);
                SqlParameter[] parms = GetSqlParameterArray(produto);
                for (int i = 0; i <= parms.Length - 1; i++)
                {
                    cmd.Parameters.Add(parms[i]);
                }

                //string sqlDebug = query;
                //foreach (SqlParameter param in cmd.Parameters)
                //{
                //    sqlDebug = sqlDebug.Replace(param.ParameterName, param.Value.ToString());
                //}

                //// Registrar ou exibir a string SQL final para depuração
                //System.Diagnostics.Debug.WriteLine(sqlDebug);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Método para atualizar o produto
        /// </summary>
        /// <param name="pessoaId">id do produto</param>
        /// <param name="produto">Model PRODUTOS</param>
        public void Atualizar(int produtoId, ProdutoModel produto)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    SET DATEFORMAT DMY;
                    UPDATE PESSOAS
                    SET NOME = @NOME, CPF = @CPF, DATA_NASC = @DATA_NASC, SEXO = @SEXO, NOME_MAE = @NOME_MAE,
                    CPF_MAE = @CPF_MAE, NOME_PAI = @NOME_PAI, CPF_PAI = @CPF_PAI, TELEFONE_RESIDENCIAL = @TELEFONE_RESIDENCIAL,
                    TELEFONE_CELULAR = @TELEFONE_CELULAR, EMAIL = @EMAIL, SIS_USUARIO_UPDATE = @SIS_USUARIO_UPDATE, SIS_DATA_UPDATE = @SIS_DATA_UPDATE
                    WHERE PRODUTO_ID = @PRODUTO_ID";

                SqlCommand cmd = new SqlCommand(query, connection);
                SqlParameter[] parms = GetSqlParameterArray(produto);
                for (int i = 0; i <= parms.Length - 1; i++)
                {
                    cmd.Parameters.Add(parms[i]);
                }

                cmd.Parameters.AddWithValue("@PRODUTO_ID", produtoId);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Método para excluir o produto
        /// </summary>
        /// <param name="pessoa">PESSOA_ID</param>
        public void Excluir(int produtoId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    DELETE PRODUTOS WHERE PRODUTO_ID = @PRODUTO_ID;";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@PRODUTO_ID", produtoId);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        #region Parameters

        public static SqlParameter[] GetSqlParameterArray()
        {
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("CODIGO", DbType.String),
                new SqlParameter("TIPO", DbType.String),
                new SqlParameter("NOME", DbType.String),
                new SqlParameter("GRUPO", DbType.String),
                new SqlParameter("MARCA", DbType.String),
                new SqlParameter("UNIDADE_MEDIDA", DbType.String),
                new SqlParameter("CUSTO", DbType.Decimal),
                new SqlParameter("LUCRO_ESPERADO", DbType.Decimal),
                new SqlParameter("PERC_LUCRO", DbType.Decimal),
                new SqlParameter("PRECO_VENDA", DbType.Decimal),
                new SqlParameter("CONTROLA_ESTOQUE", DbType.String),
                new SqlParameter("ESTOQUE_MININO", DbType.Int32),
                new SqlParameter("ESTOQUE_ATUAL", DbType.Int32),
                new SqlParameter("STATUS", DbType.Int32),
                new SqlParameter("SIS_USUARIO_INSERT",DbType.String),
                new SqlParameter("SIS_DATA_INSERT",DbType.DateTime),
                new SqlParameter("SIS_USUARIO_UPDATE",DbType.String),
                new SqlParameter("SIS_DATA_UPDATE",DbType.DateTime)
            };

            for (int i = 0; i <= parms.Length - 1; i++)
            {
                parms[i].Value = DBNull.Value;
            }

            return parms;
        }

        public static SqlParameter[] GetSqlParameterArray(ProdutoModel x)
        {
            SqlParameter[] parms = GetSqlParameterArray();

            if (x.CODIGO != null)
                parms[0].Value = x.CODIGO;

            if (x.TIPO != null)
                parms[1].Value = x.TIPO;

            if (x.NOME != null)
                parms[2].Value = x.NOME;

            if (x.GRUPO != null)
                parms[3].Value = x.GRUPO;

            if (x.MARCA != null)
                parms[4].Value = x.MARCA;

            if (x.UNIDADE_MEDIDA != null)
                parms[5].Value = x.UNIDADE_MEDIDA;

            if (x.CUSTO != 0)
                parms[6].Value = x.CUSTO;

            if (x.LUCRO_ESPERADO != 0)
                parms[7].Value = x.LUCRO_ESPERADO;

            if (x.PERC_LUCRO != 0)
                parms[8].Value = x.PERC_LUCRO;

            if (x.PRECO_VENDA != 0)
                parms[9].Value = x.PRECO_VENDA;

            if (x.CONTROLA_ESTOQUE != null)
                parms[10].Value = x.CONTROLA_ESTOQUE;

            if (x.ESTOQUE_MININO != null)
                parms[11].Value = x.ESTOQUE_MININO;

            if (x.ESTOQUE_ATUAL != null)
                parms[12].Value = x.ESTOQUE_ATUAL;

            if (x.STATUS != 0)
                parms[13].Value = x.STATUS;

            if (x.SIS_USUARIO_INSERT != null)
                parms[14].Value = x.SIS_USUARIO_INSERT;

            if (x.SIS_DATA_INSERT != null)
                parms[15].Value = x.SIS_DATA_INSERT;

            if (x.SIS_USUARIO_UPDATE != null)
                parms[16].Value = x.SIS_USUARIO_UPDATE;

            if (x.SIS_DATA_UPDATE != null)
                parms[17].Value = x.SIS_DATA_UPDATE;

            return parms;
        }

        #endregion Parameters
    }
}