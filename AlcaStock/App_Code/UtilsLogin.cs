using System.Data;
using System;
using System.Web;
using Models;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;

public class UtilsLogin
{
    #region Construtor
    public UtilsLogin() { }
    #endregion Construtor

    #region Propriedades

    public static UserLoginModel DadosUsuarioLogado
    {
        get
        {
            UserLoginModel infoUsuario = new UserLoginModel();

            if (HttpContext.Current.Session["DADOSUSUARIOLOGADO"] != null)
                infoUsuario = (UserLoginModel)HttpContext.Current.Session["DADOSUSUARIOLOGADO"];

            return infoUsuario;
        }
        set
        {
            HttpContext.Current.Session["DADOSUSUARIOLOGADO"] = value;
        }
    }

    public static PessoaModel PessoaUsuarioLogado
    {
        get
        {
            PessoaModel infoPessoa = new PessoaModel();

            if (HttpContext.Current.Session["NOMEUSUARIOLOGADO"] != null)
                infoPessoa = (PessoaModel)HttpContext.Current.Session["NOMEUSUARIOLOGADO"];

            return infoPessoa;
        }
        set
        {
            HttpContext.Current.Session["NOMEUSUARIOLOGADO"] = value;
        }
    }

    public static VwLoginModel VWUsuarioLogado
    {
        get
        {
            VwLoginModel infoVW_LOGIN = new VwLoginModel();

            if (HttpContext.Current.Session["VWUsuarioLogado"] != null)
                infoVW_LOGIN = (VwLoginModel)HttpContext.Current.Session["VWUsuarioLogado"];

            return infoVW_LOGIN;
        }
        set
        {
            HttpContext.Current.Session["VWUsuarioLogado"] = value;
        }
    }

    public static Boolean CodigoAtiva
    {
        get
        {
            Boolean _CodigoAtiva = false;

            if (HttpContext.Current.Session["CodigoAtiva"] != null)
                _CodigoAtiva = (Boolean)HttpContext.Current.Session["CodigoAtiva"];

            return _CodigoAtiva;
        }
        set
        {
            HttpContext.Current.Session["CodigoAtiva"] = value;
        }
    }

    public static string DATA_SESSION
    {
        get
        {
            string _DATA_SESSION = string.Empty;

            if (HttpContext.Current.Session["DATA_SESSION"] != null)
                _DATA_SESSION = HttpContext.Current.Session["DATA_SESSION"].ToString();

            return _DATA_SESSION;
        }
        set
        {
            HttpContext.Current.Session["DATA_SESSION"] = value;
        }
    }

    public static string HORA_INI_SESSION
    {
        get
        {
            string _HORA_INI_SESSION = string.Empty;

            if (HttpContext.Current.Session["HORA_INI_SESSION"] != null)
                _HORA_INI_SESSION = HttpContext.Current.Session["HORA_INI_SESSION"].ToString();

            return _HORA_INI_SESSION;
        }
        set
        {
            HttpContext.Current.Session["HORA_INI_SESSION"] = value;
        }
    }

    public static string HORA_FIM_SESSION
    {
        get
        {
            string _HORA_FIM_SESSION = string.Empty;

            if (HttpContext.Current.Session["HORA_FIM_SESSION"] != null)
                _HORA_FIM_SESSION = HttpContext.Current.Session["HORA_FIM_SESSION"].ToString();

            return _HORA_FIM_SESSION;
        }
        set
        {
            HttpContext.Current.Session["HORA_FIM_SESSION"] = value;
        }
    }

    public static string MsSql_Endereco
    {
        get
        {
            string _MSSQL_ENDERECO = string.Empty;

            if (HttpContext.Current.Session["MSSQL_ENDERECO"] != null)
                _MSSQL_ENDERECO = HttpContext.Current.Session["MSSQL_ENDERECO"].ToString();

            return _MSSQL_ENDERECO;
        }
        set
        {
            HttpContext.Current.Session["MSSQL_ENDERECO"] = value;
        }
    }

    public static string Bast_Municipio
    {
        get
        {
            string _BAST_MUNICIPIO = string.Empty;

            if (HttpContext.Current.Session["BAST_MUNICIPIO"] != null)
                _BAST_MUNICIPIO = HttpContext.Current.Session["BAST_MUNICIPIO"].ToString();

            return _BAST_MUNICIPIO;
        }
        set
        {
            HttpContext.Current.Session["BAST_MUNICIPIO"] = value;
        }
    }

    #endregion

    #region Metodos

    /// <summary>
    /// Método que retorna true or false para o usuário que esta realizando login
    /// </summary>
    /// <param name="Usuario">Nome do usuário que esta logando no sistema</param>
    /// <param name="Senha">Senha Descriptografada do usuário</param>
    /// <returns>Retorna Verdadeiro se a senha e o usuário forem idênticos ao armazenado no banco de dados</returns>
    public static bool Logon(string usuario, string senha)
    {
        try
        {
            dstLogin dst = new dstLogin();
            string ativo = "S";
            bool Permite = true;
            CodigoAtiva = false;

            bool ok = false;

            try
            {
                if (usuario.Length < 5)
                    Convert.ToInt32(usuario);
                else
                    Convert.ToInt32("a");
                ok = true;
                senha = senha.ToLower();
            }
            catch (Exception ex)
            {
                ok = false;
            }

            if (ok && ativo == "S" && Permite)
            {
                string SenhaTecnico = getIdentMensalNew(DateTime.Today.Month, DateTime.Today.Year, Convert.ToInt32(usuario)).ToLower();

                // Atualiza Senha Tecnico;
                Utilitarios.Exec_ProcSql("EXEC dbo.SIS_CADASTRA_LOGIN_TECNICO '" + usuario + "', '" + SenhaTecnico + "'");
            }

            Utilitarios.CamposPesq cp = new Utilitarios.CamposPesq();
            cp.FieldName[0] = "LOGIN";
            cp.FieldValue[0] = usuario;
            cp.FindNearest[0] = false;
            cp.FieldName[1] = "HASH";
            cp.FieldValue[1] = Utilitarios.Encrypt(senha);
            cp.FindNearest[1] = false;

            Utilitarios.Pesquisar(dst, "VW_LOGIN", cp, "LOGIN");

            DataTable dt = dst.VW_LOGIN;

            int CLIENTEID = 0;
            int PESSOAID = 0;

            // Verifica se existem registros na DataTable
            if (dt.Rows.Count > 0 && dt.Rows[0]["LOGIN_PORTAL"].ToString() != "S" && ativo == "S" && Permite)
            {
                if (UtilsLogin.VerificaBloqueio(Convert.ToInt32(dt.Rows[0]["USR_LOGIN_ID"])))
                {
                    if (UtilsLogin.VerificaDiaHorario(Convert.ToInt32(dt.Rows[0]["USR_LOGIN_ID"])))
                    {
                        if (UtilsLogin.VerificaFeriado(Convert.ToInt32(dt.Rows[0]["USR_LOGIN_ID"])))
                        {
                            if (UtilsLogin.VerificaAcessoIP(dt.Rows[0]["ACESSO_IP"].ToString()))
                            {
                                if (dt.Rows[0]["CLIENTE_ID"].ToString() != string.Empty)
                                    CLIENTEID = Convert.ToInt32(dt.Rows[0]["CLIENTE_ID"]);

                                if (dt.Rows[0]["PESSOA_ID"].ToString() != string.Empty)
                                    PESSOAID = Convert.ToInt32(dt.Rows[0]["PESSOA_ID"]);

                                dt.Columns.Add("NOME");

                                if (dt.Rows[0]["NOME_PERITO"].ToString() != string.Empty)
                                    dt.Rows[0]["NOME"] = dst.VW_LOGIN[0].NOME_PERITO.ToString();
                                else
                                    dt.Rows[0]["NOME"] = dst.VW_LOGIN[0].LOGIN.ToString();

                                // Verificar se o usuário esta ativo
                                if (dst.VW_LOGIN[0].ATIVO == false)
                                {
                                    DataTable dtBloq = Utilitarios.Pesquisar("SELECT MSG_USUARIO_BLOQUEADO FROM dbo.PARAMETRO_SIS");

                                    if (dt.Rows.Count > 0)
                                    {
                                        if (dtBloq.Rows[0]["MSG_USUARIO_BLOQUEADO"].ToString() != string.Empty)
                                            throw new Exception(dtBloq.Rows[0]["MSG_USUARIO_BLOQUEADO"].ToString());
                                        else
                                            throw new Exception("Favor dirigir-se ao setor de informática para desbloquear sua senha.");
                                    }
                                    else
                                        throw new Exception("Favor dirigir-se ao setor de informática para desbloquear sua senha.");
                                }

                                // Carrega dados na sessão
                                CarregarDadosSession(dt);
                                if (ok)
                                    AtualizaMenuPermissoes(dt);
                                //Salva data ultimo acesso
                                Utilitarios.Exec_StringSql("UPDATE USR_LOGIN SET DATA_ULTIMO_ACESSO='" + DateTime.Now + "' WHERE USR_LOGIN_ID=" + dt.Rows[0]["USR_LOGIN_ID"].ToString());

                                return true;
                            }
                            else
                            {
                                throw new Exception("Atenção, Usuário sem permissão de acesso por esse IP!");
                            }
                        }
                        else
                        {
                            throw new Exception("Atenção, Acesso não permitido!");
                        }
                    }
                    else
                    {
                        throw new Exception("Atenção, Limite de horário ultrapassado!");
                    }
                }
                else
                {
                    throw new Exception("Usuário bloqueado, Favor dirigir-se ao setor de informática para desbloquear sua senha!");
                }
            }
            else
            {
                // Tenta Realizar o Logon Tecnico;
                if (LogonTecnico(usuario, senha) && Permite && ativo == "S")
                    return true;
                else if (!Permite)
                {
                    CodigoAtiva = true;
                    throw new Exception("Horário não permitido. Favor entre em contato com seu coordenador para habilitar o seu acesso!");
                }
                else
                    throw new Exception("Usuário não encontrado ou senha inválida!");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static bool Logon(int id)
    {
        try
        {
            DataTable dt = Utilitarios.Pesquisar("SELECT * FROM VW_LOGIN WHERE USR_LOGIN_ID = " + id);

            int CLIENTEID = 0;
            int PESSOAID = 0;

            // Verifica se existem registros na DataTable
            if (dt.Rows.Count > 0 && dt.Rows[0]["LOGIN_PORTAL"].ToString() != "S")
            {
                if (dt.Rows[0]["CLIENTE_ID"].ToString() != string.Empty)
                    CLIENTEID = Convert.ToInt32(dt.Rows[0]["CLIENTE_ID"]);

                if (dt.Rows[0]["PESSOA_ID"].ToString() != string.Empty)
                    PESSOAID = Convert.ToInt32(dt.Rows[0]["PESSOA_ID"]);

                dt.Columns.Add("NOME");

                if (dt.Rows[0]["NOME_PERITO"].ToString() != string.Empty)
                    dt.Rows[0]["NOME"] = dt.Rows[0]["NOME_PERITO"].ToString();
                else
                    dt.Rows[0]["NOME"] = dt.Rows[0]["LOGIN"].ToString();

                // Verificar se o usuário esta ativo
                if (Convert.ToBoolean(dt.Rows[0]["ATIVO"]) == false)
                    throw new Exception("Favor dirigir-se ao setor de informática para desbloquear sua digital.");

                //Carrega dados na sessão
                CarregarDadosSession(dt);

                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// Método para retorna a Identidade Digital para Técnicos
    /// </summary>
    /// <param name="Mes"></param>
    /// <param name="Ano"></param>
    /// <param name="ID"></param>
    /// <returns></returns>
    public static string getIdentMensalNew(int Mes, int Ano, int ID)
    {
        Utilitarios UtilMt = new Utilitarios();
        string S = "AB0CD1EF2GH3IJ4LK5MN6WP7QR8ST9UV0XY1Z";
        ArrayList Listas = new ArrayList();
        string Aux;
        string Aux2;
        string AuxP = "";
        int P1 = 0;

        int PVar = 0;
        int IDX = 0;
        int sbstr = 0;
        double Numero = 0;
        double Numero1 = 0;
        double Numero2 = 0;
        double nun = 0;
        long INumero = 0;
        int J = 0;
        string Resultado = "";
        string SChar = "";
        string Str = "";
        string lstRest = "";
        Aux = UtilMt.Replique(S, 1000);

        P1 = (int)((ID * Mes) / 3);
        if (P1 == 0) P1 = 1;
        Aux2 = Aux.Substring(P1 - 1, (Aux.Length) - (P1 - 1));


        Numero1 = (Ano + Mes + ID);
        Numero2 = (Mes * 10);
        Numero2 = Numero2 / 3;
        nun = UtilMt.LogN(Numero2, Numero1);
        Str += nun;
        Str = UtilMt.Desmascara(Str.Substring(0, (10) - (0)));
        INumero = System.Int32.Parse((System.String)Str);



        if (INumero < 1000)
            INumero = INumero + 1000;

        System.Int32 Nu = (System.Int32)INumero;
        AuxP = Nu.ToString();

        String strtmp = "";
        for (int i = 0; i <= AuxP.Length; i++)
        {
            if (i == AuxP.Length)
            {
                //  strtmp = AuxP.Substring(i - 1, (i) - (i - 1));
                //  Listas.Add(strtmp);
            }
            else
            {
                strtmp = AuxP.Substring(i, 1);
                Listas.Add(strtmp);
            }
        }
        
        SupportClass.CollectionsSupport.Sort(Listas, null);

        PVar = (Ano + Mes + ID) % 3;

        for (int i = 0; i <= 3; i++)
        {
            lstRest = (string)Listas[i];
            IDX = System.Int32.Parse((System.String)lstRest);
            IDX = IDX + PVar;
            sbstr = (IDX) - (1);
            if (sbstr <= 0) sbstr = 0;

            Str = Aux2.Substring(sbstr, 1);
            SChar = Str.Substring(Str.Length - 1, (Str.Length) - (Str.Length - 1));

            if ((System.Object)Resultado != (System.Object)"")
            {
                J = 0;
                while (Resultado.IndexOf(SChar) >= 0)
                {
                    Str = Aux2.Substring(IDX + 3 + J - 1, 1);
                    SChar = Str;
                    J++;
                    if (IDX >= (Aux2.Length - 1))
                        break;
                }
            }
            Resultado = Resultado + SChar;
        }

        return Resultado + getIdentMensalNewNumero(Resultado + ID);
    }

    private static string getIdentMensalNewNumero(string ID)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(ID);
        Byte[] encodedBytes = md5.ComputeHash(originalBytes);

        string retorno = BitConverter.ToString(encodedBytes);
        retorno = retorno.Substring(0, 1) + retorno.Substring(retorno.Length - 1, 1);

        return retorno;
    }

    /// <summary>
    /// Metodo para logar com ID Técnico
    /// </summary>
    /// <param name="usuario"></param>
    /// <param name="senha"></param>
    /// <returns></returns>
    public static bool LogonTecnico(string ID, string senha)
    {
        bool ok = true;
        try
        {
            DateTime Hoje = DateTime.Now;
            //TESTA SE EH UM LOGIN É UM ID
            try
            {
                Convert.ToInt32(ID);
                ok = true;
            }
            catch (Exception ex)
            {
                ok = false;
            }

            if (ok)
            {
                if (senha.Length >= 6)
                {
                    string SenhaTecnico = getIdentMensalNew(Hoje.Month, Hoje.Year, Convert.ToInt32(ID)).ToLower();

                    //Atualiza Senha Tecnico;
                    Utilitarios.Exec_ProcSql("EXEC dbo.SIS_CADASTRA_LOGIN_TECNICO '" + ID + "', '" + SenhaTecnico + "'");

                    if (SenhaTecnico == senha.Replace("'", "").ToLower())
                    {
                        // Logou
                        dstLogin dst = new dstLogin();
                        Utilitarios.CamposPesq cp = new Utilitarios.CamposPesq();
                        cp.FieldName[0] = "LOGIN";
                        cp.FieldValue[0] = ID;
                        cp.FindNearest[0] = false;
                        cp.FieldName[1] = "HASH";
                        cp.FieldValue[1] = Utilitarios.Encrypt(SenhaTecnico.ToLower());
                        cp.FindNearest[1] = false;
                        cp.FieldName[2] = "TECNICO";
                        cp.FieldValue[2] = "S";
                        cp.FindNearest[2] = false;
                        Utilitarios.Pesquisar(dst, "VW_LOGIN", cp, "LOGIN");
                        DataTable dt = dst.VW_LOGIN;

                        int CLIENTEID = 0;
                        int PESSOAID = 0;

                        if (dt.Rows.Count > 0 && dt.Rows[0]["LOGIN_PORTAL"].ToString() != "S")
                        {
                            if (dt.Rows[0]["CLIENTE_ID"].ToString() != string.Empty)
                                CLIENTEID = Convert.ToInt32(dt.Rows[0]["CLIENTE_ID"]);

                            if (dt.Rows[0]["PESSOA_ID"].ToString() != string.Empty)
                                PESSOAID = Convert.ToInt32(dt.Rows[0]["PESSOA_ID"]);

                            dt.Columns.Add("NOME");

                            if (dt.Rows[0]["NOME_PERITO"].ToString() != string.Empty)
                                dt.Rows[0]["NOME"] = "TÉCNICO " + dst.VW_LOGIN[0].NOME_PERITO.ToString();
                            else
                                dt.Rows[0]["NOME"] = "TÉCNICO " + dst.VW_LOGIN[0].LOGIN.ToString();

                            //Carrega dados na sessão
                            CarregarDadosSession(dt);
                            if (ok)
                                AtualizaMenuPermissoes(dt);

                            return true;
                        }
                    }
                    else
                    {
                        throw new Exception("Usuário não encontrado ou senha inválida!");
                    }
                }
                else
                {
                    if (UtilsLicenca.VerificaIdParceiro(Convert.ToInt32(ID)))
                    {
                        string SenhaTecnico = getIdentMensalNew(Hoje.Month, Hoje.Year, Convert.ToInt32(ID)).ToLower().Substring(0, 4);

                        //Atualiza Senha Tecnico;
                        Utilitarios.Exec_ProcSql("EXEC dbo.SIS_CADASTRA_LOGIN_TECNICO '" + ID + "', '" + SenhaTecnico + "'");

                        if (SenhaTecnico == senha.Replace("'", "").ToLower())
                        {
                            //Logou
                            dstLogin dst = new dstLogin();
                            Utilitarios.CamposPesq cp = new Utilitarios.CamposPesq();
                            cp.FieldName[0] = "LOGIN";
                            cp.FieldValue[0] = ID;
                            cp.FindNearest[0] = false;
                            cp.FieldName[1] = "HASH";
                            cp.FieldValue[1] = Utilitarios.Encrypt(SenhaTecnico.ToLower());
                            cp.FindNearest[1] = false;
                            cp.FieldName[2] = "TECNICO";
                            cp.FieldValue[2] = "S";
                            cp.FindNearest[2] = false;
                            Utilitarios.Pesquisar(dst, "VW_LOGIN", cp, "LOGIN");
                            DataTable dt = dst.VW_LOGIN;

                            int CLIENTEID = 0;
                            int PESSOAID = 0;

                            if (dt.Rows.Count > 0 && dt.Rows[0]["LOGIN_PORTAL"].ToString() != "S")
                            {
                                if (dt.Rows[0]["CLIENTE_ID"].ToString() != string.Empty)
                                    CLIENTEID = Convert.ToInt32(dt.Rows[0]["CLIENTE_ID"]);

                                if (dt.Rows[0]["PESSOA_ID"].ToString() != string.Empty)
                                    PESSOAID = Convert.ToInt32(dt.Rows[0]["PESSOA_ID"]);

                                dt.Columns.Add("NOME");

                                if (dt.Rows[0]["NOME_PERITO"].ToString() != string.Empty)
                                    dt.Rows[0]["NOME"] = "TÉCNICO " + dst.VW_LOGIN[0].NOME_PERITO.ToString();
                                else
                                    dt.Rows[0]["NOME"] = "TÉCNICO " + dst.VW_LOGIN[0].LOGIN.ToString();

                                //Carrega dados na sessão
                                CarregarDadosSession(dt);
                                if (ok)
                                    AtualizaMenuPermissoes(dt);

                                return true;
                            }
                        }
                        else
                        {
                            throw new Exception("Usuário não encontrado ou senha inválida!");
                        }
                    }
                    else
                        throw new Exception("Atenção: Acesso não autorizado, por favor entre em contato!");
                }
            }
            else
                throw new Exception("Usuário não encontrado ou senha inválida!");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return false;
    }

    /// <summary>
    /// Método para realizar o Logoff do usuário logado
    /// </summary>
    /// <returns>Retorna Verdadeiro</returns>
    public static bool Logoff()
    {
        // Limpa as sessões
        HttpContext.Current.Session.RemoveAll();
        HttpContext.Current.Session.Clear();
        HttpContext.Current.Session.Abandon();
        HttpContext.Current.Items.Clear();
        HttpContext.Current.Application.Clear();
        return true;
    }

    /// <summary>
    /// Verifica se esta rodando em Modulo Bast
    /// </summary>
    /// <returns>true se for bast e false se nao for</returns>
    public static bool EhBast()
    {
        bool retorno;
        if ((UtilsLogin.MsSql_Endereco != null) & (!UtilsLogin.MsSql_Endereco.Equals(""))) retorno = true;
        else retorno = false;
        return retorno;
    }

    /// <summary>
    /// Carrega os dados do usuário logado na Session
    /// </summary>
    /// <param name="dt">DataTable</param>
    public static void CarregarDadosSession(DataTable dt)
    {
        UserLoginModel infoUsuario = new UserLoginModel();
        PessoaModel infoPessoa = new PessoaModel();
        VwLoginModel infoVWLogin = new VwLoginModel();


        if (dt.Rows[0]["USR_LOGIN_ID"].ToString() != string.Empty)
            infoUsuario.USR_LOGIN_ID = Convert.ToInt32(dt.Rows[0]["USR_LOGIN_ID"]);

        if (dt.Rows[0]["PESSOA_ID"].ToString() != string.Empty)
            infoUsuario.PESSOA_ID = Convert.ToInt32(dt.Rows[0]["PESSOA_ID"].ToString());

        if (dt.Rows[0]["LOGIN"].ToString() != string.Empty)
            infoUsuario.LOGIN = dt.Rows[0]["LOGIN"].ToString();

        if (dt.Rows[0]["HASH"].ToString() != string.Empty)
            infoUsuario.HASH = dt.Rows[0]["HASH"].ToString();

        if (dt.Rows[0]["DATA_VALIDADE"].ToString() != string.Empty)
            infoUsuario.DATA_VALIDADE = Convert.ToDateTime(dt.Rows[0]["DATA_VALIDADE"]);

        if (dt.Rows[0]["ORGAO_ID"].ToString() != string.Empty)
            infoUsuario.ORGAO_ID = Convert.ToInt32(dt.Rows[0]["ORGAO_ID"].ToString());

        if (dt.Rows[0]["USR_GRUPO_ID"].ToString() != string.Empty)
            infoUsuario.USR_GRUPO_ID = Convert.ToInt32(dt.Rows[0]["USR_GRUPO_ID"].ToString());

        if (dt.Rows[0]["CATEGORIA_EFETIVO"].ToString() != string.Empty)
            infoUsuario.CATEGORIA_EFETIVO = dt.Rows[0]["CATEGORIA_EFETIVO"].ToString();

        if (dt.Rows[0]["CATEGORIA_INATIVO"].ToString() != string.Empty)
            infoUsuario.CATEGORIA_INATIVO = dt.Rows[0]["CATEGORIA_INATIVO"].ToString();

        if (dt.Rows[0]["CATEGORIA_PENSIONISTA"].ToString() != string.Empty)
            infoUsuario.CATEGORIA_PENSIONISTA = dt.Rows[0]["CATEGORIA_PENSIONISTA"].ToString();

        if (dt.Rows[0]["NOME"].ToString() != string.Empty)
            infoPessoa.NOME = dt.Rows[0]["NOME"].ToString();

        if (dt.Rows[0]["CODIGO_CLIENTE"].ToString() != string.Empty)
            infoUsuario.CODIGO_CLIENTE = Convert.ToInt32(dt.Rows[0]["CODIGO_CLIENTE"].ToString());

        // Seta o ID do pacote utilizado pelo usuário
        if (dt.Rows[0]["PACOTE_ID"].ToString() != string.Empty)
            infoVWLogin.PACOTE_ID = Convert.ToInt32(dt.Rows[0]["PACOTE_ID"].ToString());

        if (dt.Rows[0]["SEGURADO_ID"].ToString() != string.Empty)
            infoUsuario.SEGURADO_ID = Convert.ToInt32(dt.Rows[0]["SEGURADO_ID"].ToString());

        if (dt.Rows[0]["WKF_SETOR_ID"].ToString() != string.Empty)
        {
            infoUsuario.SETOR_ID = Convert.ToInt32(dt.Rows[0]["WKF_SETOR_ID"].ToString());
            infoUsuario.SETOR = Utilitarios.Exec_StringSql_Return("SELECT NOME FROM WKF_SETORES WHERE WKF_SETOR_ID=" + dt.Rows[0]["WKF_SETOR_ID"].ToString());
        }

        infoVWLogin.TECNICO = dt.Rows[0]["TECNICO"].ToString();

        infoUsuario.DATA = DATA_SESSION;
        infoUsuario.HORA_INI = HORA_INI_SESSION;
        infoUsuario.HORA_FIM = HORA_FIM_SESSION;

        DadosUsuarioLogado = infoUsuario;
        PessoaUsuarioLogado = infoPessoa;
        VWUsuarioLogado = infoVWLogin;
    }

    public static void AtualizaMenuPermissoes(DataTable dt)
    {
        if (dt.Rows[0]["NOME_GRUPO"].ToString().ToUpper().IndexOf("MASTER") != -1 || dt.Rows[0]["NOME_GRUPO"].ToString().ToUpper().IndexOf("ADMINISTRADOR") != -1 || dt.Rows[0]["NOME_GRUPO"].ToString().ToUpper().IndexOf("AGENDA") != -1)
        {
            int max = Convert.ToInt32(Utilitarios.Exec_StringSql_Return("SELECT MAX(MENU_ID) FROM MENU_GRUPO WHERE USR_GRUPO_ID=" + dt.Rows[0]["USR_GRUPO_ID"].ToString()));
            Utilitarios.Exec_StringSql("INSERT INTO MENU_GRUPO (USR_GRUPO_ID,MENU_ID) SELECT " + dt.Rows[0]["USR_GRUPO_ID"].ToString() + ",M.MENU_ID FROM MENU M WHERE M.MENU_ID > " + max + " AND M.MENU_ID NOT IN (SELECT ID FROM LOG_MENU_PERMISSOES WHERE TIPO='M')");

            int max1 = Convert.ToInt32(Utilitarios.Exec_StringSql_Return("SELECT MAX(USR_PERMISSAO_ID) FROM USR_PERMISSAO_CONF WHERE USR_GRUPO_ID=" + dt.Rows[0]["USR_GRUPO_ID"].ToString()));
            Utilitarios.Exec_StringSql("INSERT INTO USR_PERMISSAO_CONF (USR_PERMISSAO_ID, USR_GRUPO_ID, USR_LOGIN_ID, PERMISSAO) SELECT P.USR_PERMISSAO_ID," + dt.Rows[0]["USR_GRUPO_ID"].ToString() + "," + UtilsLogin.DadosUsuarioLogado.USR_LOGIN_ID + ",'S' FROM getUSR_PERMISSOES() P WHERE P.USR_PERMISSAO_ID > " + max + " AND P.USR_PERMISSAO_ID NOT IN (SELECT ID FROM LOG_MENU_PERMISSOES WHERE TIPO='P')");
        }
    }

    public static bool VerificaBloqueio(int ID)
    {
        DataTable dt = Utilitarios.Pesquisar("SELECT COALESCE(BLOQUEIO_AUTOMATICO,'N')AS BLOQUEIO_AUTOMATICO,COALESCE(PRAZO_DIAS,0)AS PRAZO_DIAS, DATA_ULTIMO_ACESSO FROM USR_LOGIN WHERE USR_LOGIN_ID=" + ID);

        if (dt.Rows[0]["BLOQUEIO_AUTOMATICO"].ToString() == "S")
        {
            if (dt.Rows[0]["DATA_ULTIMO_ACESSO"] != null && dt.Rows[0]["DATA_ULTIMO_ACESSO"].ToString() != string.Empty)
            {
                if (Convert.ToDateTime(dt.Rows[0]["DATA_ULTIMO_ACESSO"]) != Convert.ToDateTime("1900-01-01"))
                {
                    if (Convert.ToDateTime(dt.Rows[0]["DATA_ULTIMO_ACESSO"]).AddDays(Convert.ToInt32(dt.Rows[0]["PRAZO_DIAS"])) < DateTime.Now)
                    {
                        Utilitarios.Exec_StringSql("UPDATE USR_LOGIN SET ATIVO=0 WHERE USR_LOGIN_ID=" + ID);
                        return false;
                    }
                    else
                        return true;
                }
                else
                    return true;
            }
            else
                return true;
        }
        else
            return true;
    }

    public static bool VerificaAcessoIP(string IP)
    {
        bool acao = true;

        if (IP != string.Empty)
        {
            string IP_ATUAL = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(IP_ATUAL) || IP_ATUAL.Equals("unknown", StringComparison.OrdinalIgnoreCase))
                IP_ATUAL = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            DataTable dt = Utilitarios.Pesquisar("SELECT * FROM dbo.getValoresSplit('" + IP + "', ';') WHERE '" + IP_ATUAL + "' LIKE ITEM");
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        else
            acao = true;

        return acao;
    }

    public static bool VerificaDiaHorario(int ID)
    {
        DataTable dt = Utilitarios.Pesquisar("SELECT COALESCE(DIA_HORARIO_ACESSO,'N')AS DIA_HORARIO_ACESSO FROM USR_LOGIN WHERE USR_LOGIN_ID=" + ID);
        bool acao = true;

        if (dt.Rows[0]["DIA_HORARIO_ACESSO"].ToString() == "S")
        {
            DataTable dt1 = Utilitarios.Pesquisar("SELECT MAT_INICIAL,MAT_FINAL,VESP_INICIAL,VESP_FINAL FROM USR_LOGIN_CARGA_HORARIA WHERE USR_LOGIN_ID=" + ID + " AND DIA_SEMANA=" + (int)DateTime.Now.DayOfWeek);
            if (dt1.Rows.Count > 0)
            {
                if (dt1.Rows[0]["MAT_INICIAL"].ToString() != string.Empty && dt1.Rows[0]["MAT_FINAL"].ToString() != string.Empty && dt1.Rows[0]["VESP_INICIAL"].ToString() == string.Empty && dt1.Rows[0]["VESP_FINAL"].ToString() == string.Empty)
                    if ((Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + dt1.Rows[0]["MAT_INICIAL"].ToString() + ":00") >= DateTime.Now || Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + dt1.Rows[0]["MAT_FINAL"].ToString() + ":00") >= DateTime.Now) && (Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + dt1.Rows[0]["MAT_INICIAL"].ToString() + ":00") <= DateTime.Now || Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + dt1.Rows[0]["MAT_FINAL"].ToString() + ":00") <= DateTime.Now))
                        acao = true;
                    else
                        acao = false;
                else if (dt1.Rows[0]["MAT_INICIAL"].ToString() != string.Empty && dt1.Rows[0]["MAT_FINAL"].ToString() != string.Empty && dt1.Rows[0]["VESP_INICIAL"].ToString() != string.Empty && dt1.Rows[0]["VESP_FINAL"].ToString() != string.Empty)
                    if (((Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + dt1.Rows[0]["MAT_INICIAL"].ToString() + ":00") >= DateTime.Now || Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + dt1.Rows[0]["MAT_FINAL"].ToString() + ":00") >= DateTime.Now) && (Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + dt1.Rows[0]["MAT_INICIAL"].ToString() + ":00") <= DateTime.Now || Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + dt1.Rows[0]["MAT_FINAL"].ToString() + ":00") <= DateTime.Now)) || ((Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + dt1.Rows[0]["VESP_INICIAL"].ToString() + ":00") >= DateTime.Now || Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + dt1.Rows[0]["VESP_FINAL"].ToString() + ":00") >= DateTime.Now) && (Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + dt1.Rows[0]["VESP_INICIAL"].ToString() + ":00") <= DateTime.Now || Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + dt1.Rows[0]["VESP_INICIAL"].ToString() + ":00") <= DateTime.Now)))
                        acao = true;
                    else
                        acao = false;
                else if (dt1.Rows[0]["MAT_INICIAL"].ToString() == string.Empty && dt1.Rows[0]["MAT_FINAL"].ToString() == string.Empty && dt1.Rows[0]["VESP_INICIAL"].ToString() != string.Empty && dt1.Rows[0]["VESP_FINAL"].ToString() != string.Empty)
                    if ((Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + dt1.Rows[0]["VESP_INICIAL"].ToString() + ":00") >= DateTime.Now || Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + dt1.Rows[0]["VESP_FINAL"].ToString() + ":00") >= DateTime.Now) && (Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + dt1.Rows[0]["VESP_INICIAL"].ToString() + ":00") <= DateTime.Now || Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + dt1.Rows[0]["VESP_INICIAL"].ToString() + ":00") <= DateTime.Now))
                        acao = true;
                    else
                        acao = false;
            }
            else
                acao = false;
        }
        else
            acao = true;

        return acao;
    }

    public static bool VerificaFeriado(int ID)
    {
        DataTable dt = Utilitarios.Pesquisar("SELECT COALESCE(DIA_HORARIO_ACESSO,'N')AS DIA_HORARIO_ACESSO,COALESCE(ACESSO_FERIADO,'N')AS ACESSO_FERIADO FROM USR_LOGIN WHERE USR_LOGIN_ID=" + ID);
        bool acao = true;

        if (dt.Rows[0]["DIA_HORARIO_ACESSO"].ToString() == "S")
        {
            DataTable dt1 = Utilitarios.Pesquisar("SELECT DISTINCT * FROM (SELECT CAST(CAST(ANO AS VARCHAR(4)) + '-' +CAST(MES AS VARCHAR(2)) + '-' +CAST(DIA AS VARCHAR(2)) AS DATE)AS FERIADO FROM dbo.FERIADO UNION " +
            "SELECT CAST(CAST(ANO AS VARCHAR(4)) + '-' +CAST(MES AS VARCHAR(2)) + '-' +CAST(DIA AS VARCHAR(2)) AS DATE)AS FERIADO FROM dbo.getFeriadosFixos())AS F");

            int y = 0;
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (Convert.ToDateTime(dt1.Rows[i]["FERIADO"]).ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd") && dt.Rows[0]["ACESSO_FERIADO"].ToString() == "N")
                    y++;
            }
            acao = (y == 0) ? true : false;
        }
        else
            acao = true;

        return acao;
    }

    /// <summary>
    /// Verifica se o usuário está logado. Caso esteja retorna true
    /// </summary>
    /// <returns>true se logado, false se não logado</returns>
    public static bool VerificarSeUsuarioLogado()
    {
        bool retorno = false;

        if (DadosUsuarioLogado.LOGIN != null)
            retorno = true;

        if ((UtilsLogin.MsSql_Endereco != null) & (!UtilsLogin.MsSql_Endereco.Equals(""))) retorno = true;

        return retorno;
    }

    public static void GravaLogAcesso(string DESCRICAO_MODULO, string IP, string VERSAO, string LOGIN, int USR_LOGIN_ID)
    {
        string sql = "INSERT INTO USR_ACESSO (USR_LOGIN_ID, USR_LOGIN, IP, VERSAO_SISTEMA, DESCRICAO_MODULO, DATA_HORA) " +
                     "VALUES (@USR_LOGIN_ID, @LOGIN, @IP, @VERSAO, @DESCRICAO_MODULO, GETDATE()); " +
                     "IF NOT EXISTS (SELECT * FROM CHAT_LOGIN WHERE USR_LOGIN_ID = @USR_LOGIN_ID) " +
                     "BEGIN " +
                     "    INSERT INTO CHAT_LOGIN (USR_LOGIN_ID) VALUES (@USR_LOGIN_ID); " +
                     "END " +
                     "ELSE " +
                     "BEGIN " +
                     "    UPDATE CHAT_LOGIN SET DATA = GETDATE() WHERE USR_LOGIN_ID = @USR_LOGIN_ID; " +
                     "END;";

        using (SqlConnection cnx = Utilitarios.GetOpenConnection())
        {
            using (SqlCommand cmd = new SqlCommand(sql, cnx))
            {
                cmd.Parameters.Add("@USR_LOGIN_ID", SqlDbType.Int).Value = USR_LOGIN_ID;
                cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar).Value = LOGIN;
                cmd.Parameters.Add("@IP", SqlDbType.VarChar).Value = IP;
                cmd.Parameters.Add("@VERSAO", SqlDbType.VarChar).Value = VERSAO;
                cmd.Parameters.Add("@DESCRICAO_MODULO", SqlDbType.VarChar).Value = DESCRICAO_MODULO;

                cmd.ExecuteNonQuery();
            }
        }
    }

    #endregion
}