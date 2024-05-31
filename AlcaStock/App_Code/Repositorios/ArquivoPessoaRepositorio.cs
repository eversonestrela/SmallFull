using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Models;

namespace Alcastock.Repositorios
{
    public class ArquivoPessoaRepositorio
    {
        private readonly string _connectionString;

        public ArquivoPessoaRepositorio()
        {
            _connectionString = Utilitarios.conStr;
        }

        public List<ArquivoPessoaModel> ConsultarArquivoPessoasPorId(int? pessoaId)
        {
            List<ArquivoPessoaModel> arquivosPessoaModel = new List<ArquivoPessoaModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"SELECT * FROM ARQUIVOS_PESSOAS WHERE PESSOA_ID = @PESSOA_ID";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@PESSOA_ID", pessoaId);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ArquivoPessoaModel arquivoPessoaModel = new ArquivoPessoaModel
                    {
                        ARQUIVOS_PESSOAS_ID = int.Parse(reader["ARQUIVOS_PESSOAS_ID"].ToString()),
                        PESSOA_ID = int.Parse(reader["PESSOA_ID"].ToString()),
                        NAME = reader["NAME"].ToString(),
                        DATA = Convert.ToDateTime(reader["DATA"]),
                        MIME = reader["MIME"].ToString(),
                        DADOS = reader["DADOS"] != DBNull.Value ? (byte[])reader["DADOS"] : null
                    };

                    arquivosPessoaModel.Add(arquivoPessoaModel);
                }
            }

            return arquivosPessoaModel;
        }

        public void SalvarImagem(ArquivoPessoaModel arquivoPessoa)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO ARQUIVOS_PESSOAS(PESSOA_ID, NAME, DATA, MIME, DADOS) VALUES (@PESSOA_ID, @NAME, @DATA, @MIME, @DADOS)";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlParameter[] parms = GetSqlParameterArray(arquivoPessoa);
                
                for (int i = 0; i <= parms.Length - 1; i++)
                {
                    cmd.Parameters.Add(parms[i]);
                }

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeletarImagem(int? pessoaId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"DELETE ARQUIVOS_PESSOAS WHERE PESSOA_ID = @PESSOA_ID";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@PESSOA_ID", pessoaId);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        #region Parameters

        public static SqlParameter[] GetSqlParameterArray()
        {
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("ARQUIVOS_PESSOAS_ID", DbType.Int32),
                new SqlParameter("PESSOA_ID", DbType.Int32),
                new SqlParameter("NAME", DbType.String),
                new SqlParameter("DATA", DbType.DateTime),
                new SqlParameter("MIME", DbType.String),
                new SqlParameter("DADOS", DbType.Binary)
                
            };

            for (int i = 0; i <= parms.Length - 1; i++)
            {
                parms[i].Value = DBNull.Value;
            }

            return parms;
        }

        public static SqlParameter[] GetSqlParameterArray(ArquivoPessoaModel x)
        {
            SqlParameter[] parms = GetSqlParameterArray();

            if (x.ARQUIVOS_PESSOAS_ID != null)
                parms[0].Value = x.ARQUIVOS_PESSOAS_ID;

            if (x.PESSOA_ID != null)
                parms[1].Value = x.PESSOA_ID;

            if (x.NAME != null)
                parms[2].Value = x.NAME;

            if (x.DATA != null)
                parms[3].Value = x.DATA;

            if (x.MIME != null)
                parms[4].Value = x.MIME;

            if (x.DADOS != null)
                parms[5].Value = x.DADOS;

            return parms;
        }

        #endregion Parameters
    }
}