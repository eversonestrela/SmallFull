using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace Alcastock.Repositorios
{
    public class PessoaRepositorio
    {
        private readonly string _connectionString;

        public PessoaRepositorio()
        {
            _connectionString = Utilitarios.conStr;
        }

        public bool CpfUnique(string cpf)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM PESSOAS WHERE CPF = @CPF";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CPF", cpf);

                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public void Salvar(PessoaModel pessoa)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"SET DATEFORMAT DMY; INSERT INTO PESSOAS (NOME, CPF, DATA_NASC, SEXO, NOME_MAE, CPF_MAE, NOME_PAI, CPF_PAI
                                , TELEFONE_RESIDENCIAL, TELEFONE_CELULAR, EMAIL, SIS_USUARIO_INSERT, SIS_DATA_INSERT)
                                VALUES (@NOME, @CPF, @DATA_NASC, @SEXO, @NOME_MAE, @CPF_MAE, @NOME_PAI, @CPF_PAI,
                                @TELEFONE_RESIDENCIAL, @TELEFONE_CELULAR, @EMAIL, @SIS_USUARIO_INSERT, @SIS_DATA_INSERT)";

                SqlCommand cmd = new SqlCommand(query, connection);
                SqlParameter[] parms = GetSqlParameterArray(pessoa);
                for (int i = 0; i <= parms.Length - 1; i++)
                {
                    cmd.Parameters.Add(parms[i]);
                }

                string sqlDebug = query;
                foreach (SqlParameter param in cmd.Parameters)
                {
                    sqlDebug = sqlDebug.Replace(param.ParameterName, param.Value.ToString());
                }

                // Registrar ou exibir a string SQL final para depuração
                System.Diagnostics.Debug.WriteLine(sqlDebug);

                connection.Open();
                cmd.ExecuteScalar();
            }
        }

        #region Parameters

        public static SqlParameter[] GetSqlParameterArray()
        {
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("CPF", DbType.String),
                new SqlParameter("NOME", DbType.String),
                new SqlParameter("SEXO", DbType.String),
                new SqlParameter("DATA_NASC", DbType.DateTime),
                new SqlParameter("NOME_MAE", DbType.String),
                new SqlParameter("CPF_MAE", DbType.String),
                new SqlParameter("NOME_PAI", DbType.String),
                new SqlParameter("CPF_PAI", DbType.String),
                new SqlParameter("TELEFONE_RESIDENCIAL", DbType.String),
                new SqlParameter("TELEFONE_CELULAR",DbType.String),
                new SqlParameter("EMAIL",DbType.String),
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

        public static SqlParameter[] GetSqlParameterArray(PessoaModel x)
        {
            SqlParameter[] parms = GetSqlParameterArray();

            if (x.CPF != null)
                parms[0].Value = x.CPF;

            if (x.NOME != null)
                parms[1].Value = x.NOME;

            if (x.SEXO != null)
                parms[2].Value = x.SEXO;

            if (x.DATA_NASC != null)
                parms[3].Value = x.DATA_NASC;

            if (x.NOME_MAE != null)
                parms[4].Value = x.NOME_MAE;

            if (x.CPF_MAE != null)
                parms[5].Value = x.CPF_MAE;

            if (x.NOME_PAI != null)
                parms[6].Value = x.NOME_PAI;

            if (x.CPF_PAI != null)
                parms[7].Value = x.CPF_PAI;

            if (x.TELEFONE_RESIDENCIAL != null)
                parms[8].Value = x.TELEFONE_RESIDENCIAL;

            if (x.TELEFONE_CELULAR != null)
                parms[9].Value = x.TELEFONE_CELULAR;
            
            if (x.EMAIL != null)
                parms[10].Value = x.EMAIL;
            
            if (x.SIS_USUARIO_INSERT != null)
                parms[11].Value = x.SIS_USUARIO_INSERT;

            if (x.SIS_DATA_INSERT != null)
                parms[12].Value = x.SIS_DATA_INSERT;

            if (x.SIS_USUARIO_UPDATE != null)
                parms[13].Value = x.SIS_USUARIO_UPDATE;

            if (x.SIS_DATA_UPDATE != null)
                parms[14].Value = x.SIS_DATA_UPDATE;

            return parms;
        }

        #endregion Parameters
    }
}