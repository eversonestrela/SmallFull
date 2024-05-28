using ALCASTOCK.Geral;
using eWorld.UI;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public class Utilitarios
{
    #region Construtor

    public Utilitarios() { }

    #endregion Construtor

    #region CamposPesq

    /// <summary>
    /// Classe que será utilizada como sendo uma propriedade indexada 
    /// para a Classe CamposPesq e armazenará os campos que farão parte da pesquisa
    /// </summary>
    public class NomeCampos
    {
        protected ArrayList Campos;
        public NomeCampos()
        {
            // Construtor
            Campos = new ArrayList();
        }

        public string this[int Indice]
        {
            get
            {
                return (string)Campos[Indice];
            }
            set
            {
                if (Indice > (Campos.Count - 1))
                {
                    for (int i = 0; i < Indice; i++)
                        Campos.Add("");
                    Campos.Insert(Indice, value);
                }
                else
                    Campos[Indice] = value;
            }
        }
        // Retorna o Número de Condicões da Consulta
        public int Count
        {
            get
            {
                return Campos.Count;
            }
        }

    }

    /// <summary>
    /// Classe que será utilizada como sendo uma propriedade indexada 
    /// para a Classe CamposPesq e armazenará o tipo de pesquisa que será realizada (like ou igual)
    /// </summary>
    public class ProcuraAproximada
    {
        protected ArrayList Proc;
        public ProcuraAproximada()
        {
            // Construtor
            Proc = new ArrayList();
        }
        public bool this[int Indice]
        {
            get
            {
                return (bool)Proc[Indice];
            }
            set
            {
                if (Indice > (Proc.Count - 1))
                {
                    for (int i = 0; i < Indice; i++)
                        Proc.Add(false);
                    Proc.Insert(Indice, value);
                }
                else
                    Proc[Indice] = value;
            }
        }
    }

    /// <summary>
    /// Classe que será utilizada como sendo uma propriedade indexada para a 
    /// Classe CamposPesq e armazenará os valores do filtro de cada campo   
    /// </summary>
    public class ValorCampos
    {
        protected ArrayList Valores;
        public ValorCampos()
        {
            // Construtor
            Valores = new ArrayList();
        }
        public string this[int Indice]
        {
            get
            {
                return (string)Valores[Indice];
            }
            set
            {
                if (Indice > (Valores.Count - 1))
                {
                    for (int i = 0; i < Indice; i++)
                        Valores.Add("");
                    Valores.Insert(Indice, value);
                }
                else
                    Valores[Indice] = value;
            }
        }
    }

    /// <summary>
    /// Classe que será utilizada como sendo uma propriedade indexada para a 
    /// Classe CamposPesq e armazenará o tipo de procura aproximada(like) (T: Todo conteudo, I: Inicio, F:Fim)
    /// </summary>
    public class TipoProcuraAprox
    {
        protected ArrayList TpoPrcAprx;
        public TipoProcuraAprox()
        {
            // Construtor
            TpoPrcAprx = new ArrayList();
        }

        public string this[int Indice]
        {
            get
            {
                return (string)TpoPrcAprx[Indice];
            }
            set
            {
                if (Indice > (TpoPrcAprx.Count - 1))
                {
                    for (int i = 0; i < Indice; i++)
                        TpoPrcAprx.Add("");
                    TpoPrcAprx.Insert(Indice, value);
                }
                else
                    TpoPrcAprx[Indice] = value;
            }
        }
    }

    /// <summary>
    /// Classe principal que armazena e informa os parametros para a pesquisa que será realizada 
    /// </summary>
    public class CamposPesq
    {
        protected NomeCampos NomeCampoInterno;
        protected ValorCampos ValoresInterno;
        protected ProcuraAproximada ProcuraAproximadaInterno;
        protected TipoProcuraAprox TipoProcuraAproxInterno;

        public CamposPesq()
        {
            // Construtor
            NomeCampoInterno = new NomeCampos();
            ValoresInterno = new ValorCampos();
            ProcuraAproximadaInterno = new ProcuraAproximada();
            TipoProcuraAproxInterno = new TipoProcuraAprox();

        }

        public NomeCampos FieldName
        {
            get
            {
                return NomeCampoInterno;
            }
            set
            {
                NomeCampoInterno = value;
            }
        }

        public ValorCampos FieldValue
        {
            get
            {
                return ValoresInterno;
            }
            set
            {
                ValoresInterno = value;
            }
        }

        public ProcuraAproximada FindNearest
        {
            get
            {
                return ProcuraAproximadaInterno;
            }
            set
            {
                ProcuraAproximadaInterno = value;
            }
        }

        public TipoProcuraAprox FindNearestType
        {
            get
            {
                return TipoProcuraAproxInterno;
            }
            set
            {
                TipoProcuraAproxInterno = value;
            }
        }
    }

    #endregion CamposPesq

    #region Propriedades

    public static string conStr = ConfigurationSettings.AppSettings["ALCASTOCKConnectionString"];

    #endregion Propriedades

    #region Metodos

    /// <summary>
    /// Método que monta o camando select conforme os parametros informados na classe CamposPesq e realiza a pesquisa no banco de dados.
    /// </summary>
    /// <param name="dsPesq">DataSet não Tipado que irá receber o resultado da consulta</param>
    /// <param name="NomeView">Nome da View onde os dados serão pesquisados</param>
    /// <param name="Fields">Campos que serão utilizados para realizar a pesquisa e obter os registros</param>
    /// <param name="SelectPersonalizado">Utilizado para substituir o Select normalmente realizado em todos os campos da View, onde, este Select pode utilizar Distinct entre outros recursos.</param>
    /// <param name="Order">Campos, separados por vírgula para ordenação dos registros retornados pela pesquisa.</param>
    /// <param name="AdicionalWherePersonalizado">Cláusulas adicionais para utilização na Instrução Where, juntamente com os demais campos de pesquisa.</param>
    /// <param name="QtdeRegistros">Quantidade de registros para trazer na pesquisa realizada</param>
    public static void Pesquisar(DataSet dsPesq, string NomeView, CamposPesq Fields, string SelectPersonalizado, string Order, string AdicionalWherePersonalizado, string QtdeRegistros)
    {
        if (QtdeRegistros != null)
            QtdeRegistros = " TOP " + QtdeRegistros;

        if (Order != null)
            Order = " ORDER BY " + Order;

        int NumFiltros = Fields.FieldName.Count;
        //-> Variavel referente ao comando select
        string select = "";
        if ((SelectPersonalizado != "") && (SelectPersonalizado != null))
            select = " SET DATEFORMAT DMY SELECT " + QtdeRegistros + SelectPersonalizado + " FROM " + NomeView + " WHERE 1=1 ";
        else
            select = " SET DATEFORMAT DMY SELECT " + QtdeRegistros + " * FROM " + NomeView + " WHERE 1=1 ";

        //-> Monta a Condição 
        for (int i = 0; i < NumFiltros; i++)
        {
            //-> se o vetor estiver vazio na posicao, ignora a condição
            if (Fields.FieldName[i] != string.Empty)
            {
                //-> Verifica se a Procura é Aproximada
                if (Fields.FindNearest[i] == true)
                {
                    if (Fields.FindNearestType[i] == "T")
                        select = select + " AND " + Fields.FieldName[i] + " LIKE '" + "%" + Fields.FieldValue[i] + "%'";
                    else if (Fields.FindNearestType[i] == "I")
                        select = select + " AND " + Fields.FieldName[i] + " LIKE '%" + Fields.FieldValue[i] + "%'";
                    else if (Fields.FindNearestType[i] == "F")
                        select = select + " AND " + Fields.FieldName[i] + " LIKE '%" + Fields.FieldValue[i] + "'";
                }
                else
                    select = select + " AND " + Fields.FieldName[i] + " = '" + Fields.FieldValue[i] + "'";
            }
        }
        if ((AdicionalWherePersonalizado != "") && (AdicionalWherePersonalizado != null))
        {
            select = select + " AND " + AdicionalWherePersonalizado;
        }
        //-> Order By
        select = select + Order;
        //-> Cria o objeto de conexão
        SqlConnection cnx = GetOpenConnection();
        //-> Cria o objeto SQLDataAdapter
        SqlDataAdapter exec = new SqlDataAdapter();
        //-> Cria o SelectComand
        SqlCommand Comando = new SqlCommand();
        exec.SelectCommand = Comando;
        exec.SelectCommand.CommandTimeout = 960;
        Comando.Connection = cnx;
        Comando.CommandType = CommandType.Text;
        Comando.CommandText = select;
        //
        try
        {
            //-> Realiza a Consulta
            exec.Fill(dsPesq, NomeView);
        }
        finally
        {
            //-> Fecha a Connexão
            CloseConnection(cnx);
            exec.Dispose();
        }
    }

    /// <summary>
    /// Método que monta o camando select conforme os parametros informados na classe CamposPesq e realiza a pesquisa no banco de dados.
    /// </summary>
    /// <param name="dsPesq">DataSet não Tipado que irá receber o resultado da consulta</param>
    /// <param name="NomeView">Nome da View onde os dados serão pesquisados</param>
    /// <param name="Fields">Campos que serão utilizados para realizar a pesquisa e obter os registros</param>
    /// <param name="SelectPersonalizado">Utilizado para substituir o Select normalmente realizado em todos os campos da View, onde, este Select pode utilizar Distinct entre outros recursos.</param>
    /// <param name="Order">Campos, separados por vírgula para ordenação dos registros retornados pela pesquisa.</param>
    /// <param name="AdicionalWherePersonalizado">Cláusulas adicionais para utilização na Instrução Where, juntamente com os demais campos de pesquisa.</param>
    public static void Pesquisar(DataSet dsPesq, string NomeView, CamposPesq Fields, string SelectPersonalizado, string Order, string AdicionalWherePersonalizado)
    {
        if (Order != null)
            Order = " ORDER BY " + Order;

        int NumFiltros = Fields.FieldName.Count;
        //-> Variavel referente ao comando select
        string select = "";
        if ((SelectPersonalizado != "") && (SelectPersonalizado != null))
            select = " SET DATEFORMAT DMY SELECT " + SelectPersonalizado + " FROM " + NomeView + " WHERE 1=1 ";
        else
            select = " SET DATEFORMAT DMY SELECT * FROM " + NomeView + " WHERE 1=1 ";

        //-> Monta a Condição 
        for (int i = 0; i < NumFiltros; i++)
        {
            //-> se o vetor estiver vazio na posicao, ignora a condição
            if (Fields.FieldName[i] != string.Empty)
            {
                //-> Verifica se a Procura é Aproximada
                if (Fields.FindNearest[i] == true)
                {
                    if (Fields.FindNearestType[i] == "T")
                        select = select + " AND " + Fields.FieldName[i] + " LIKE '" + "%" + Fields.FieldValue[i] + "%'";
                    else if (Fields.FindNearestType[i] == "I")
                        select = select + " AND " + Fields.FieldName[i] + " LIKE '" + Fields.FieldValue[i] + "%'";
                    else if (Fields.FindNearestType[i] == "F")
                        select = select + " AND " + Fields.FieldName[i] + " LIKE '%" + Fields.FieldValue[i] + "'";

                }
                else

                    select = select + " AND " + Fields.FieldName[i] + " = '" + Fields.FieldValue[i] + "'";
            }
        }
        if ((AdicionalWherePersonalizado != "") && (AdicionalWherePersonalizado != null))
        {
            select = select + " AND " + AdicionalWherePersonalizado;
        }
        //-> Order By
        select = select + Order;
        //-> Cria o objeto de conexão
        SqlConnection cnx = GetOpenConnection();
        //-> Cria o objeto SQLDataAdapter
        SqlDataAdapter exec = new SqlDataAdapter();
        //-> Cria o SelectComand
        SqlCommand Comando = new SqlCommand();
        exec.SelectCommand = Comando;
        exec.SelectCommand.CommandTimeout = 960;
        Comando.Connection = cnx;
        Comando.CommandType = CommandType.Text;
        Comando.CommandText = select;
        //
        try
        {
            //-> Realiza a Consulta
            dsPesq.EnforceConstraints = false;
            exec.Fill(dsPesq, NomeView);
        }
        finally
        {
            CloseConnection(cnx);
            exec.Dispose();
        }
    }

    /// <summary>
    /// Método que monta o camando select conforme os parametros informados na classe CamposPesq e realiza a pesquisa no banco de dados.
    /// </summary>
    /// <param name="dsPesq"> DataSet onde será realizada a pesquisa</param>
    /// <param name="View"> View ou Tabela onde a pesquisa será realizada</param>
    /// <param name="Fields"> Campos que serão utilizados na pesquisa</param>
    /// <param name="QtdeRegistros">Qtde de registros para trazer na pesquisa</param>
    public static void Pesquisar(DataSet dsPesq, string NomeView, CamposPesq Fields, string Order, string QtdeRegistros)
    {
        if (QtdeRegistros != null)
            QtdeRegistros = " TOP " + QtdeRegistros;

        if (Order != null)
            Order = " ORDER BY " + Order;

        int NumFiltros = Fields.FieldName.Count;
        //-> Variavel referente ao comando select
        string select = " SET DATEFORMAT DMY SELECT " + QtdeRegistros + " * FROM " + NomeView + " WHERE 1=1 ";
        //-> Monta a Condição 
        for (int i = 0; i < NumFiltros; i++)
        {
            //-> se o vetor estiver vazio na posicao, ignora a condição
            if (Fields.FieldName[i] != string.Empty)
            {
                //-> Verifica se a Procura é Aproximada
                if (Fields.FindNearest[i] == true)
                {
                    if (Fields.FindNearestType[i] == "T")
                        select = select + " AND " + Fields.FieldName[i] + " LIKE '" + "%" + Fields.FieldValue[i] + "%'";
                    else if (Fields.FindNearestType[i] == "I")
                        select = select + " AND " + Fields.FieldName[i] + " LIKE '" + Fields.FieldValue[i] + "%'";
                    else if (Fields.FindNearestType[i] == "F")
                        select = select + " AND " + Fields.FieldName[i] + " LIKE '%" + Fields.FieldValue[i] + "'";
                }
                else
                    select = select + " AND " + Fields.FieldName[i] + " = '" + Fields.FieldValue[i] + "'";
            }
        }
        //-> Order By
        select = select + Order;
        //-> Cria o objeto de conexão
        SqlConnection cnx = GetOpenConnection();
        //-> Cria o objeto SQLDataAdapter
        SqlDataAdapter exec = new SqlDataAdapter();
        //-> Cria o SelectComand
        SqlCommand Comando = new SqlCommand();
        exec.SelectCommand = Comando;
        exec.SelectCommand.CommandTimeout = 960;
        Comando.Connection = cnx;
        Comando.CommandType = CommandType.Text;
        Comando.CommandText = select;
        //
        try
        {
            //-> Realiza a Consulta
            exec.Fill(dsPesq, NomeView);
        }
        finally
        {
            CloseConnection(cnx);
            exec.Dispose();
        }
    }

    /// <summary>
    /// Método que monta o camando select conforme os parametros informados na classe CamposPesq e realiza a pesquisa no banco de dados.
    /// </summary>
    /// <param name="dsPesq"> DataSet onde será realizada a pesquisa</param>
    /// <param name="View"> View ou Tabela onde a pesquisa será realizada</param>
    /// <param name="Fields"> Campos que serão utilizados na pesquisa</param>
    public static void Pesquisar(DataSet dsPesq, string NomeView, CamposPesq Fields, string Order)
    {
        if (Order != null)
            Order = " ORDER BY " + Order;

        int NumFiltros = Fields.FieldName.Count;
        // Variavel referente ao comando select
        string select = " SET DATEFORMAT DMY SELECT * FROM " + NomeView + " WHERE 1=1 ";
        // Monta a Condição 
        for (int i = 0; i < NumFiltros; i++)
        {
            // se o vetor estiver vazio na posicao, ignora a condição
            if (Fields.FieldName[i] != string.Empty)
            {
                // Verifica se a Procura é Aproximada
                if (Fields.FindNearest[i] == true)
                {
                    if (Fields.FindNearestType[i] == "T")
                        select = select + " AND " + Fields.FieldName[i] + " LIKE '" + "%" + Fields.FieldValue[i] + "%'";
                    else if (Fields.FindNearestType[i] == "I")
                        select = select + " AND " + Fields.FieldName[i] + " LIKE '" + Fields.FieldValue[i] + "%'";
                    else if (Fields.FindNearestType[i] == "F")
                        select = select + " AND " + Fields.FieldName[i] + " LIKE '%" + Fields.FieldValue[i] + "'";
                }
                else
                    select = select + " AND " + Fields.FieldName[i] + " = '" + Fields.FieldValue[i] + "'";
            }
        }
        // Order By
        select = select + Order;
        // Cria o objeto de conexão
        SqlConnection cnx = GetOpenConnection();
        // Cria o objeto SQLDataAdapter
        SqlDataAdapter exec = new SqlDataAdapter();
        // Cria o SelectComand
        SqlCommand Comando = new SqlCommand();
        exec.SelectCommand = Comando;
        exec.SelectCommand.CommandTimeout = 960;
        Comando.Connection = cnx;
        Comando.CommandType = CommandType.Text;
        Comando.CommandText = select;
        //
        try
        {
            // Realiza a Consulta
            exec.Fill(dsPesq, NomeView);
        }
        finally
        {
            CloseConnection(cnx);
            exec.Dispose();
        }
    }

    /// <summary>
    /// Método simples de pesquisa usando string SQL
    /// </summary>
    /// <param name="SQL">String SQL para consulta</param>
    /// <returns>Retorna uma DataTable de Registros</returns>
    public static DataTable Pesquisar(string SQL)
    {
        DataTable dt = new DataTable();

        // Cria o objeto de conexão
        SqlConnection cnx = GetOpenConnection();
        // Cria o objeto SQLDataAdapter
        SqlDataAdapter exec = new SqlDataAdapter();
        // Cria o SelectComand
        SqlCommand Comando = new SqlCommand();
        exec.SelectCommand = Comando;
        exec.SelectCommand.CommandTimeout = 1020;
        Comando.Connection = cnx;
        Comando.CommandType = CommandType.Text;
        Comando.CommandText = "SET DATEFORMAT DMY; " + SQL;

        try
        {
            // Realiza a Consulta
            exec.Fill(dt);
        }
        catch (SqlException ex)
        {
        }
        finally
        {
            CloseConnection(cnx);
            exec.Dispose();
            Comando.Dispose();
        }

        return dt;
    }

    /// <summary>
    /// Método que retorna uma sqlconnection aberta
    /// </summary>
    /// <returns> Retorna uma SQLConnection aberta</returns>
    public static SqlConnection GetOpenConnection()
    {
        if (conStr.IndexOf("Data Source") == -1)
            conStr = UtilsLicenca.Crip(conStr, false);

        SqlConnection conn = new SqlConnection(conStr);

        if (conn.ConnectionString.IndexOf("Data Source") == -1)
            conn.ConnectionString = UtilsLicenca.Crip(conn.ConnectionString, false);

        if (conn.State == ConnectionState.Closed)
            conn.Open();

        return conn;
    }

    /// <summary>
    /// Método responsável por fechar conexões abertas
    /// </summary>
    /// <param name="conn"></param>
    public static void CloseConnection(SqlConnection conn)
    {
        conn.Close();
        conn.Dispose();
    }

    /// <summary>
    /// Converte um valor int para string
    /// </summary>
    /// <param name="Vrl">Valor int a ser convertido</param>
    /// <returns>string</returns>
    public static string chr(int Vrl)
    {
        char Ch = (char)Vrl;
        return Ch.ToString();
    }

    /// <summary>
    /// Converte um valor string para int
    /// </summary>
    /// <param name="Str">Valor string a ser convertido</param>
    /// <returns>int</returns>
    private static int Ord(string Str)
    {
        return (int)Str[0];
    }

    public static string Exec_ProcSql_Return(String SQL)
    {   
        // Cria o objeto de conexão
        SqlConnection cnx = GetOpenConnection();
        // Cria o objeto SQLDataAdapter
        SqlDataAdapter exec = new SqlDataAdapter();
        // Cria o SelectComand
        SqlCommand Comando = new SqlCommand();
        Comando.CommandText = "SET DATEFORMAT DMY " + SQL;
        exec.SelectCommand = Comando;
        exec.SelectCommand.CommandTimeout = 1020;
        Comando.Connection = cnx;
        Comando.CommandType = CommandType.Text;

        string retorno = string.Empty;

        try
        {
            retorno = Convert.ToString(Comando.ExecuteScalar());
        }
        catch (SqlException e)
        {
            throw;
        }
        finally
        {
            CloseConnection(cnx);
            Comando.Dispose();
        }

        return retorno;
    }

    public static void Exec_ProcSql(String SQL)
    {
        // Cria o objeto de conexão
        SqlConnection cnx = GetOpenConnection();
        // Cria o SelectComand
        SqlCommand Comando = new SqlCommand("SET DATEFORMAT DMY; " + SQL, cnx);

        try
        {
            Comando.CommandTimeout = 1020;
            Comando.ExecuteNonQuery();
        }
        catch (SqlException e)
        {
            throw;
        }
        finally
        {
            CloseConnection(cnx);
            Comando.Dispose();
        }
    }

    public static string Exec_StringSql_Return(String SQL)
    {
        string retorno = string.Empty;
        // Cria o objeto de conexão
        SqlConnection cnx = GetOpenConnection();
        // Cria o objeto SQLDataAdapter
        SqlDataAdapter exec = new SqlDataAdapter();
        // Cria o SelectComand
        SqlCommand Comando = new SqlCommand();
        Comando.CommandText = "SET DATEFORMAT DMY " + SQL;
        exec.SelectCommand = Comando;
        exec.SelectCommand.CommandTimeout = 480;
        Comando.Connection = cnx;
        Comando.CommandType = CommandType.Text;
        retorno = Convert.ToString(Comando.ExecuteScalar());

        try
        {
        }
        catch
        {
            throw;
        }
        finally
        {
            exec.Dispose();
            CloseConnection(cnx);
            Comando.Dispose();
        }

        return retorno;
    }

    public static void Exec_StringSql(String SQL)
    {
        // Cria o objeto de conexão
        SqlConnection cnx = GetOpenConnection();
        // Cria o objeto SQLDataAdapter
        SqlDataAdapter exec = new SqlDataAdapter();
        // Cria o SelectComand
        SqlCommand Comando = new SqlCommand();
        Comando.CommandText = "SET DATEFORMAT DMY " + SQL;
        exec.SelectCommand = Comando;
        exec.SelectCommand.CommandTimeout = 480;
        Comando.Connection = cnx;
        Comando.CommandType = CommandType.Text;
        try
        {
            Comando.ExecuteNonQuery();
        }
        catch (SqlException e)
        {
            throw;
        }
        finally
        {
            exec.Dispose();
            CloseConnection(cnx);
            Comando.Dispose();
        }
    }

    /// <summary>
    /// Método que criptografa a senha digitada no campo Senha do form de Login, para comparação com o valor existente no banco de dados
    /// </summary>
    /// <param name="Snh">Senha informada pelo usuário</param>
    /// <returns>string</returns>
    public static string Encrypt(System.String Snh)
    {
        System.String Chave = "Jesus";
        System.String NovaSenha = "";
        System.String Senha = "";
        Senha = Snh.Replace("Z", "A");
        for (int x = 0; x <= Chave.Length - 1; x++)
        {
            NovaSenha = "";
            for (int i = 0; i <= Senha.Length; i++)
            {
                if (i != Senha.Length)
                    NovaSenha = NovaSenha + chr(Ord(Chave.Substring(x, (x + 1) - (x))) ^ Ord(Senha.Substring(i, (i + 1) - (i))));
            }
            Senha = NovaSenha;
        }
        return Senha;
    }

    /// <summary>
    /// Método para remover Pontuação
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string RetiraPontuacao(System.String str)
    {
        System.String retorno = " ";

        for (int i = 0; i <= str.Length - 1; i++)
        {
            if ((str.Substring(i, 1).Equals(".")) |
                (str.Substring(i, 1).Equals("!")) |
                (str.Substring(i, 1).Equals(":")) |
                (str.Substring(i, 1).Equals(";")) |
                (str.Substring(i, 1).Equals("?")) |
                (str.Substring(i, 1).Equals("/")) |
                (str.Substring(i, 1).Equals("*")) |
                (str.Substring(i, 1).Equals("-")) |
                (str.Substring(i, 1).Equals("+")) |
                (str.Substring(i, 1).Equals("_")) |
                (str.Substring(i, 1).Equals("(")) |
                (str.Substring(i, 1).Equals(")")) |
                (str.Substring(i, 1).Equals("&")) |
                (str.Substring(i, 1).Equals("~")) |
                (str.Substring(i, 1).Equals("^")) |
                (str.Substring(i, 1).Equals(",")))
                retorno = retorno + "  ";
            else
                retorno = retorno + str.Substring(i, 1).ToString();

        }

        String S = "";
        for (int i = 1; i <= retorno.Length - 1; i++)
        {
            if (retorno.Substring(i, 1).Equals(" "))
            {
                if (retorno.Substring(i, 1).Equals(" "))
                {
                    //Corrigido para o primeiro caracter se for " " não der erro.
                    if (retorno.Substring(i, 1).Equals(" ") || S.Substring(S.Length - 1, 1).Equals(" ") == false)
                    {
                        S = S + retorno.Substring(i, 1).ToString();
                    }
                }
            }
            else
                S = S + retorno.Substring(i, 1).ToString();
        }
        
        return S;
    }

    /// <summary>
    /// Método para replicar string em quantidades X
    /// </summary>
    /// <param name="Conteudo"></param>
    /// <param name="Qtd"></param>
    /// <returns></returns>
    public string Replique(System.String Conteudo, int Qtd)
    {
        int Qt = Qtd;
        System.Text.StringBuilder Res = new System.Text.StringBuilder("");
        while (Qt > 0)
        {
            Qt--;
            Res = Res.Append(Conteudo);
        }
        return Res.ToString();
    }

    /// <summary>
    /// Método para Desmascarar.
    /// </summary>
    /// <param name="Conteudo"></param>
    /// <returns></returns>
    public string Desmascara(string Conteudo)
    {
        string Rest = "";

        for (int c = 0; c <= Conteudo.Length - 1; c++)
        {
            if ((Conteudo.Substring(c, 1).Equals("0")) |
                    (Conteudo.Substring(c, 1).Equals("1")) |
                    (Conteudo.Substring(c, 1).Equals("2")) |
                    (Conteudo.Substring(c, 1).Equals("3")) |
                    (Conteudo.Substring(c, 1).Equals("4")) |
                    (Conteudo.Substring(c, 1).Equals("5")) |
                    (Conteudo.Substring(c, 1).Equals("6")) |
                    (Conteudo.Substring(c, 1).Equals("7")) |
                    (Conteudo.Substring(c, 1).Equals("8")) |
                    (Conteudo.Substring(c, 1).Equals("9")))
                Rest = Rest + Conteudo.Substring(c, 1);
            else
                Rest = Rest + "";
        }

        return Rest;
    }

    /// <summary>
    /// formata um valor sobre uma mascara no formato ex.:##/##/#### ou ##.###,##"
    /// </summary>
    /// valor a formatar
    /// <param name="valor"></param> 
    /// <param name="mascara no formato ex.:##/##/#### ou ##.###,##"></param>   
    public static string Mascara(string valor, string mascara)
    {
        StringBuilder dado = new StringBuilder();
        
        // remove caracteres não numéricos
        foreach (char c in valor)
        {
            if (Char.IsNumber(c))
                dado.Append(c);
        }
        int indMascara = mascara.Length;
        int indCampo = dado.Length;
        for (; indCampo > 0 && indMascara > 0;)
        {
            if (mascara[--indMascara] == '#')
                indCampo--;
        }
        StringBuilder saida = new StringBuilder();
        for (; indMascara < mascara.Length; indMascara++)
        {
            saida.Append((mascara[indMascara] == '#') ? dado[indCampo++] : mascara[indMascara]);
        }
        return saida.ToString();
    }

    /// <summary>
    /// Método para retornar um LogN de uma base
    /// </summary>
    /// <param name="Base"></param>
    /// <param name="X"></param>
    /// <returns></returns>
    public double LogN(double Base, double X)
    {
        double V = 0;

        V = System.Math.Log(X) / System.Math.Log(Base);
        return V;
    }

    /// <summary>
    /// Preencher um número com Zeros a Esquerda
    /// </summary>
    /// <param name="Numero"></param>
    /// <param name="Tamanho"></param>
    /// <returns></returns>
    public static string StrZero(int Numero, int Tamanho)
    {
        string str = string.Empty;
        str = Numero.ToString();
        Tamanho = Tamanho - str.Length;
        if (Tamanho > 0)
        {
            for (int i = 0; i < Tamanho; i++)
            {
                str = "0" + str;
            }
        }

        return str;
    }

    public static bool IsHttps()
    {
        return HttpContext.Current.Request.IsSecureConnection;
    }

    public static string CaminhoWEB()
    {
        string CaminhoWEB = HttpContext.Current.Request.ApplicationPath;
        if (CaminhoWEB.Equals("/") == false)
        {
            CaminhoWEB = HttpContext.Current.Request.ApplicationPath + "/";
        }
        return CaminhoWEB;
    }

    /// <summary>
    /// Método responsável por converter valor do banco de dados S ou N para true ou false
    /// </summary>
    /// <param name="Valor">Valor S ou N</param>
    /// <returns>True ou False</returns>
    public static bool ConverteSimNaoParaBool(string Valor)
    {
        if (Valor.ToUpper() == "S")
            return true;
        else
            return false;
    }

    public static int Exec_IntSql_Return(String SQL)
    {
        int retorno = 0;

        //-> Cria o objeto de conexão
        using (SqlConnection cnx = GetOpenConnection())
        using (SqlCommand Comando = new SqlCommand("SET DATEFORMAT DMY " + SQL, cnx))
        {
            try
            {
                Comando.CommandType = CommandType.Text;
                retorno = Convert.ToInt32(Comando.ExecuteScalar());
            }
            catch (Exception)
            {

            }
        }

        return retorno;
    }

    /// <summary>
    /// Método que remove os atributos de componentes
    /// </summary>
    /// <param name="controle">Controle que terá seus atributos removidos</param>
    /// <param name="atributo">Atributo do controle que será removido</param>
    public static void RemoverAtributo(Control controle, string atributo)
    {
        // Verifica se o controle é do tipo TextBox ou FieldTextBox
        if (controle.ToString() == "System.Web.UI.WebControls.TextBox" || controle.ToString() == "AGENDA.Controles.UI.FieldTextBox")
        {
            TextBox txt = (TextBox)controle;
            txt.Attributes.Remove(atributo);
        }
    }

    /// <summary>
    /// -> Metodo que prepara a execução das stored procedures
    /// </summary>
    /// <param name="Pagina"> Página onde será realizada a pesquisa de componentes</param>
    /// <param name="NomTabela"> Nome da Tabela onde será realizada a gravação das informações</param>
    /// <param name="ACAO"> Ação que será realizada dentro da procedure</param>
    public static void Gravar(System.Web.UI.Page Pagina, string NomTabela, string ACAO, DataSet ds2)
    {
        //-> Cria um datarow a partir do dataset
        DataRow Linha = ds2.Tables[NomTabela].NewRow();
        //
        int NumCampos = ds2.Tables[NomTabela].Columns.Count;
        //-> Alimenta a Linha com os valores preenchidos nos componentes
        for (int i = 0; i < NumCampos; i++)
        {
            if ((ds2.Tables[NomTabela].Columns[i].DataType == typeof(System.String)) || (ds2.Tables[NomTabela].Columns[i].DataType == typeof(System.Char)))
            {
                if (Pagina.FindControl("txt_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName) != null)
                {
                    if (((TextBox)Pagina.FindControl("txt_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).Text != string.Empty)
                        Linha[i] = ((TextBox)Pagina.FindControl("txt_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).Text;
                    else if ((ACAO == "I") && (((TextBox)Pagina.FindControl("txt_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).ReadOnly == true))
                        Linha[i] = "0";
                }
                else if (Pagina.FindControl("ddl_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName) != null)
                {
                    ListItem li = new ListItem();
                    li = ((DropDownList)Pagina.FindControl("ddl_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).SelectedItem;
                    if (li != null)
                    {
                        if (((DropDownList)Pagina.FindControl("ddl_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).SelectedItem.Value != string.Empty)
                            Linha[i] = ((DropDownList)Pagina.FindControl("ddl_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).SelectedItem.Value;
                    }
                }
                else if (Pagina.FindControl("rdbl_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName) != null)
                {
                    if (((RadioButtonList)Pagina.FindControl("rdbl_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).SelectedValue != string.Empty)
                        Linha[i] = ((RadioButtonList)Pagina.FindControl("rdbl_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).SelectedValue;
                }
            }
            else if ((ds2.Tables[NomTabela].Columns[i].DataType == typeof(System.Int16)) || (ds2.Tables[NomTabela].Columns[i].DataType == typeof(System.Int32)) || (ds2.Tables[NomTabela].Columns[i].DataType == typeof(System.Int64)))
            {
                if (Pagina.FindControl("txt_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName) != null)
                {
                    if (((TextBox)Pagina.FindControl("txt_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).Text != string.Empty)
                        Linha[i] = int.Parse(((TextBox)Pagina.FindControl("txt_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).Text);
                    else if ((ACAO == "I") && (((TextBox)Pagina.FindControl("txt_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).ReadOnly == true))
                        Linha[i] = 0;
                }
                else if (Pagina.FindControl("ddl_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName) != null)
                {
                    ListItem li = new ListItem();
                    li = ((DropDownList)Pagina.FindControl("ddl_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).SelectedItem;
                    if (li != null)
                    {
                        if (((DropDownList)Pagina.FindControl("ddl_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).SelectedItem.Value != string.Empty)
                            Linha[i] = int.Parse(((DropDownList)Pagina.FindControl("ddl_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).SelectedItem.Value);
                    }
                }
            }
            else if (ds2.Tables[NomTabela].Columns[i].DataType == typeof(System.Decimal))
            {
                if (Pagina.FindControl("txt_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName) != null)
                    if (((TextBox)Pagina.FindControl("txt_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).Text != string.Empty)
                        Linha[i] = Convert.ToDecimal(((TextBox)Pagina.FindControl("txt_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).Text);
            }
            else if (ds2.Tables[NomTabela].Columns[i].DataType == typeof(System.Double))
            {
                if (Pagina.FindControl("txt_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName) != null)
                    if (((TextBox)Pagina.FindControl("txt_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).Text != string.Empty)
                        Linha[i] = Convert.ToDouble(((TextBox)Pagina.FindControl("txt_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).Text);
            }
            else if (ds2.Tables[NomTabela].Columns[i].DataType == typeof(System.DateTime))
            {
                if (Pagina.FindControl("clp_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName) != null)
                {
                    if (Convert.ToString(((CalendarPopup)Pagina.FindControl("clp_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).SelectedDate) != string.Empty)
                    {
                        if (((CalendarPopup)Pagina.FindControl("clp_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).SelectedDate.ToString().Substring(0, 8) != "1/1/0001")
                            Linha[i] = ((CalendarPopup)Pagina.FindControl("clp_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).SelectedDate;
                    }
                }
                else if (Pagina.FindControl("txt_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName) != null)
                    if (Convert.ToString(((TextBox)Pagina.FindControl("txt_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).Text) != string.Empty)
                    {
                        if (((TextBox)Pagina.FindControl("txt_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).Text != "1/1/0001")
                            Linha[i] = Convert.ToDateTime(((TextBox)Pagina.FindControl("txt_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).Text);
                    }
            }
            else if (ds2.Tables[NomTabela].Columns[i].DataType == typeof(System.Boolean))
            {
                if (Pagina.FindControl("chk_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName) != null)
                {
                    if (((CheckBox)Pagina.FindControl("chk_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).Checked)
                        Linha[i] = 1;
                    else
                        Linha[i] = 0;
                }
                else if (Pagina.FindControl("ddl_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName) != null)
                {
                    if (((DropDownList)Pagina.FindControl("ddl_" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).SelectedValue == "1")
                        Linha[i] = 1;
                    else
                        Linha[i] = 0;
                }
                else if (Pagina.FindControl("rdbl" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName) != null)
                {
                    if (((RadioButtonList)Pagina.FindControl("rdbl" + NomTabela + "_" + ds2.Tables[NomTabela].Columns[i].ColumnName)).SelectedValue == "1")
                        Linha[i] = 1;
                    else
                        Linha[i] = 0;
                }
            }
        }
        ds2.Tables[NomTabela].Rows.Add(Linha);
        //-> Invoca o método de execução de Stored Procedure para a gravação dos dados 
        Utilitarios.Exec_sp(ds2, NomTabela, ACAO, Pagina);
    }

    /// <summary>
    /// //-> Metodo que abre a conexão, executa a stored procedure e fechar a connexão
    /// </summary>
    /// <param name="ds"> DataSet que contém a table que será manipulada</param>
    /// <param name="NomTabela"> Nome da Tabela onde será realizado o registro</param>
    /// <param name="ACAO"> Ação que será realizada dentro da procedure</param>
    /// <param name="Pagina"> Página onde serão pesquisados os componentes</param>
    public static void Exec_sp(DataSet ds, string NomTabela, string DML, System.Web.UI.Page Pagina)
    {
        //-> Cria o objeto de conexão
        SqlConnection cnx = GetOpenConnection();
        //-> Cria o objeto CommandText
        SqlCommand exec = new SqlCommand();
        //-> Aponta a propriedade TypeCommand do CommandText
        exec.CommandType = CommandType.StoredProcedure;
        //-> Aponta o nome da procedure para a propriedade CommandText
        exec.CommandText = "dbo.spMnt" + NomTabela;
        //-> Aponta o objeto de connexão para a propriedade 
        exec.Connection = cnx;
        try
        {
            //
            int NumCampos = ds.Tables[NomTabela].Columns.Count;
            //-> Adiciona e alimenta os parametros conforme a estrutura do dataset 
            exec.Parameters.Clear();
            //-> Passa como parametros na procedure os campos do dataset	
            exec.Parameters.Add("@ACAO", SqlDbType.Char);
            exec.Parameters[0].Value = DML;
            for (int i = 1; i <= NumCampos; i++)
            {
                //-> Cria o parametro
                exec.Parameters.Add("@" + ds.Tables[NomTabela].Columns[i - 1].ColumnName, ds.Tables[NomTabela].Columns[i - 1].DataType);
                //-> Alimenta o parametro
                exec.Parameters[i].Value = ds.Tables[NomTabela].Rows[0][i - 1];
            }

            exec.ExecuteNonQuery();

        }
        finally
        {
            CloseConnection(cnx);
            exec.Dispose();
        }
    }

    #endregion Metodos

    #region JavaScript
    /// <summary>
    /// Realiza a Atribuição das Funções Java Script existentes no 
    /// arquivo Geral.js existente na pasta Scripts do Projeto
    /// para os Objetos da página, de forma que estes tenham tratamentos
    /// genéricos nas páginas do sistema
    /// </summary>
    /// <param name="Pagina">A Página Atual que terá seus compenentes de formulário tratados</param>
    public static void AtribuirFuncoesJava(System.Web.UI.Page Pagina)
    {
        string scriptString;
        scriptString = @"<script language=""" + @"javascript""" + @" src=""" + Pagina.ResolveClientUrl("~/Library/Scripts/Mascaras.js") + @""" type=""" + @"text/javascript""" + @"></script>";

        if (!Pagina.IsClientScriptBlockRegistered("clientScript"))
            ScriptManager.RegisterClientScriptBlock(Pagina, Pagina.GetType(), "clientScript", scriptString, false);
        
        Containers(Pagina);
    }

    private static void Containers(Control controle)
    {
        for (int cont = 0; cont < controle.Controls.Count; cont++)
        {
            if (controle.Controls[cont].HasControls() == true)
            {
                Containers(controle.Controls[cont]);
            }
            else
            {
                DescobreClasse(controle.Controls[cont]);
            }
        }
    }

    /// <summary>
    /// Descobre a classe do controle para realizar a chamada do método
    /// específico para tratamento dos eventos destes componenentes
    /// </summary>
    /// <param name="controle">Controle o qual terá as funções java atribuídas aos seus eventos</param>
    private static void DescobreClasse(Control controle)
    {
        if (controle.ToString() == "System.Web.UI.WebControls.TextBox" || controle.ToString() == "AGENDA.Controles.UI.FieldTextBox")
        {
            int a = ((System.Web.UI.WebControls.TextBox)controle).CssClass.ToUpper().LastIndexOf("UPPER");

            if (((System.Web.UI.WebControls.TextBox)controle).CssClass.ToUpper() == "UPPER")
            {
                TratarEntradadeDados.Upper((System.Web.UI.WebControls.TextBox)controle);
            }
            else if (((System.Web.UI.WebControls.TextBox)controle).CssClass.ToUpper() == "CPF")
            {
                TratarEntradadeDados.CPF((System.Web.UI.WebControls.TextBox)controle);
            }
            else if (((System.Web.UI.WebControls.TextBox)controle).CssClass.ToUpper() == "CEP")
            {
                TratarEntradadeDados.CEP((System.Web.UI.WebControls.TextBox)controle);
            }
            else if (((System.Web.UI.WebControls.TextBox)controle).CssClass.ToUpper() == "CNPJ")
            {
                TratarEntradadeDados.CNPJ((System.Web.UI.WebControls.TextBox)controle);
            }
            else if (((System.Web.UI.WebControls.TextBox)controle).CssClass.ToUpper() == "MONEY")
            {
                TratarEntradadeDados.MONEY((System.Web.UI.WebControls.TextBox)controle);
            }
            else if (((System.Web.UI.WebControls.TextBox)controle).CssClass.ToUpper() == "DATE")
            {
                TratarEntradadeDados.MascaraData((System.Web.UI.WebControls.TextBox)controle);
            }
            else if (((System.Web.UI.WebControls.TextBox)controle).CssClass.ToUpper() == "CELULAR")
            {
                TratarEntradadeDados.MascaraCelular((System.Web.UI.WebControls.TextBox)controle);
            }
        }
        else if (controle.ToString() == "System.Web.UI.WebControls.DropDownList")
        {
            if (((System.Web.UI.WebControls.DropDownList)controle).CssClass.ToUpper() == "POSTJAVA")
            {
                TratarEntradadeDados.SetFilterDropdownlist((System.Web.UI.WebControls.DropDownList)controle, true);
            }
            else
            {
                TratarEntradadeDados.SetFilterDropdownlist((System.Web.UI.WebControls.DropDownList)controle);
            }
        }
        else if (controle.ToString() == "System.Web.UI.WebControls.Label")
        {

        }
        else if (controle.ToString() == "System.Web.UI.WebControls.CheckBox")
        {

        }
        else if (controle.ToString() == "System.Web.UI.WebControls.RadioButton")
        {

        }
        else if (controle.ToString() == "System.Web.UI.WebControls.ListBox")
        {

        }
        else if (controle.ToString() == "eWorld.UI.CalendarPopup")
        {
            TratarEntradadeDados.MascaraData((eWorld.UI.CalendarPopup)controle);
        }
        else if (controle.ToString() == "eWorld.UI.TimePicker")
        {

        }
        else if (controle.ToString() == "System.Web.UI.WebControls.LinkButton")
        {

        }
        else if (controle.ToString() == "System.WebUI.WebControls.ImageButton")
        {

        }
    }
    #endregion JavaScript
}