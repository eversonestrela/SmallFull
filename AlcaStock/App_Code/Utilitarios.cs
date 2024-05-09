using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;

public class Utilitarios
{
    #region Construtor

    public Utilitarios() { }

    #endregion Construtor

    #region CamposPesq

    /// <summary>
    /// Classe que ser� utilizada como sendo uma propriedade indexada 
    /// para a Classe CamposPesq e armazenar� os campos que far�o parte da pesquisa
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
        // Retorna o N�mero de Condic�es da Consulta
        public int Count
        {
            get
            {
                return Campos.Count;
            }
        }

    }

    /// <summary>
    /// Classe que ser� utilizada como sendo uma propriedade indexada 
    /// para a Classe CamposPesq e armazenar� o tipo de pesquisa que ser� realizada (like ou igual)
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
    /// Classe que ser� utilizada como sendo uma propriedade indexada para a 
    /// Classe CamposPesq e armazenar� os valores do filtro de cada campo   
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
    /// Classe que ser� utilizada como sendo uma propriedade indexada para a 
    /// Classe CamposPesq e armazenar� o tipo de procura aproximada(like) (T: Todo conteudo, I: Inicio, F:Fim)
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
    /// Classe principal que armazena e informa os parametros para a pesquisa que ser� realizada 
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
    /// M�todo que monta o camando select conforme os parametros informados na classe CamposPesq e realiza a pesquisa no banco de dados.
    /// </summary>
    /// <param name="dsPesq">DataSet n�o Tipado que ir� receber o resultado da consulta</param>
    /// <param name="NomeView">Nome da View onde os dados ser�o pesquisados</param>
    /// <param name="Fields">Campos que ser�o utilizados para realizar a pesquisa e obter os registros</param>
    /// <param name="SelectPersonalizado">Utilizado para substituir o Select normalmente realizado em todos os campos da View, onde, este Select pode utilizar Distinct entre outros recursos.</param>
    /// <param name="Order">Campos, separados por v�rgula para ordena��o dos registros retornados pela pesquisa.</param>
    /// <param name="AdicionalWherePersonalizado">Cl�usulas adicionais para utiliza��o na Instru��o Where, juntamente com os demais campos de pesquisa.</param>
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

        //-> Monta a Condi��o 
        for (int i = 0; i < NumFiltros; i++)
        {
            //-> se o vetor estiver vazio na posicao, ignora a condi��o
            if (Fields.FieldName[i] != string.Empty)
            {
                //-> Verifica se a Procura � Aproximada
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
        //-> Cria o objeto de conex�o
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
            //-> Fecha a Connex�o
            CloseConnection(cnx);
            exec.Dispose();
        }
    }

    /// <summary>
    /// M�todo que monta o camando select conforme os parametros informados na classe CamposPesq e realiza a pesquisa no banco de dados.
    /// </summary>
    /// <param name="dsPesq">DataSet n�o Tipado que ir� receber o resultado da consulta</param>
    /// <param name="NomeView">Nome da View onde os dados ser�o pesquisados</param>
    /// <param name="Fields">Campos que ser�o utilizados para realizar a pesquisa e obter os registros</param>
    /// <param name="SelectPersonalizado">Utilizado para substituir o Select normalmente realizado em todos os campos da View, onde, este Select pode utilizar Distinct entre outros recursos.</param>
    /// <param name="Order">Campos, separados por v�rgula para ordena��o dos registros retornados pela pesquisa.</param>
    /// <param name="AdicionalWherePersonalizado">Cl�usulas adicionais para utiliza��o na Instru��o Where, juntamente com os demais campos de pesquisa.</param>
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

        //-> Monta a Condi��o 
        for (int i = 0; i < NumFiltros; i++)
        {
            //-> se o vetor estiver vazio na posicao, ignora a condi��o
            if (Fields.FieldName[i] != string.Empty)
            {
                //-> Verifica se a Procura � Aproximada
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
        //-> Cria o objeto de conex�o
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
    /// M�todo que monta o camando select conforme os parametros informados na classe CamposPesq e realiza a pesquisa no banco de dados.
    /// </summary>
    /// <param name="dsPesq"> DataSet onde ser� realizada a pesquisa</param>
    /// <param name="View"> View ou Tabela onde a pesquisa ser� realizada</param>
    /// <param name="Fields"> Campos que ser�o utilizados na pesquisa</param>
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
        //-> Monta a Condi��o 
        for (int i = 0; i < NumFiltros; i++)
        {
            //-> se o vetor estiver vazio na posicao, ignora a condi��o
            if (Fields.FieldName[i] != string.Empty)
            {
                //-> Verifica se a Procura � Aproximada
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
        //-> Cria o objeto de conex�o
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
    /// M�todo que monta o camando select conforme os parametros informados na classe CamposPesq e realiza a pesquisa no banco de dados.
    /// </summary>
    /// <param name="dsPesq"> DataSet onde ser� realizada a pesquisa</param>
    /// <param name="View"> View ou Tabela onde a pesquisa ser� realizada</param>
    /// <param name="Fields"> Campos que ser�o utilizados na pesquisa</param>
    public static void Pesquisar(DataSet dsPesq, string NomeView, CamposPesq Fields, string Order)
    {
        if (Order != null)
            Order = " ORDER BY " + Order;

        int NumFiltros = Fields.FieldName.Count;
        // Variavel referente ao comando select
        string select = " SET DATEFORMAT DMY SELECT * FROM " + NomeView + " WHERE 1=1 ";
        // Monta a Condi��o 
        for (int i = 0; i < NumFiltros; i++)
        {
            // se o vetor estiver vazio na posicao, ignora a condi��o
            if (Fields.FieldName[i] != string.Empty)
            {
                // Verifica se a Procura � Aproximada
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
        // Cria o objeto de conex�o
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
    /// M�todo simples de pesquisa usando string SQL
    /// </summary>
    /// <param name="SQL">String SQL para consulta</param>
    /// <returns>Retorna uma DataTable de Registros</returns>
    public static DataTable Pesquisar(string SQL)
    {
        DataTable dt = new DataTable();

        // Cria o objeto de conex�o
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
    /// M�todo que retorna uma sqlconnection aberta
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
    /// M�todo respons�vel por fechar conex�es abertas
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
        // Cria o objeto de conex�o
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
        // Cria o objeto de conex�o
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
        // Cria o objeto de conex�o
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
        // Cria o objeto de conex�o
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
    /// M�todo que criptografa a senha digitada no campo Senha do form de Login, para compara��o com o valor existente no banco de dados
    /// </summary>
    /// <param name="Snh">Senha informada pelo usu�rio</param>
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
    /// M�todo para remover Pontua��o
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
                    //Corrigido para o primeiro caracter se for " " n�o der erro.
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
    /// M�todo para replicar string em quantidades X
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
    /// M�todo para Desmascarar.
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
        
        // remove caracteres n�o num�ricos
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
    /// M�todo para retornar um LogN de uma base
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
    /// Preencher um n�mero com Zeros a Esquerda
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

    #endregion Metodos
}