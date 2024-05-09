using System;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Net;

public partial class Login_Login : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // VERIFICA SE VEIO DO EXECUTAVEL DA ASSINATURA DIGITAL
            loginNew.Visible = true;
            divBloqueado.Visible = false;

            HttpCookie cookie = Request.Cookies["sisprevlogin"];
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Library\";

            string imgLogo = path + "Images\\" + UtilsLogin.Bast_Municipio + "_logo_sisprev_web.gif";
            string imgLadoDireito = path + "Images_Cliente\\" + UtilsLogin.Bast_Municipio + "_lado_direito_logo.gif";
            string imgLogoCliente = path + "Images_Cliente\\" + UtilsLogin.Bast_Municipio + "_logo.gif";

            Logo.ImageUrl = File.Exists(imgLogo) ? ResolveClientUrl("~/Library/Images/" + UtilsLogin.Bast_Municipio + "_logo_sisprev_web.gif") : Logo.ImageUrl;
            LogoCliente.ImageUrl = File.Exists(imgLogoCliente) ? ResolveClientUrl("~/Library/Images_Cliente/" + UtilsLogin.Bast_Municipio + "_logo.gif") : LogoCliente.ImageUrl;

            if (cookie != null)
            {
                String strCookieValue = cookie.Value.ToString();
                txtUSER.Text = strCookieValue.Replace("'", "");
                txtUSER.Visible = false;
                LabelLogin.Visible = true;
                LabelLogin.Text = strCookieValue + ", ";
                LimparCookieLogin.Visible = true;
            }
            else
            {
                txtUSER.Focus();
            }

            //dstCRUD dst = new dstCRUD();
            //Utilitarios.CamposPesq cp = new Utilitarios.CamposPesq();
            //Utilitarios.Pesquisar(dst, "PARAMETRO_SIS", cp, "PREFEITURA");
            //if (dst.PARAMETRO_SIS.Rows.Count > 0)
            //{
            //    if (dst.PARAMETRO_SIS[0]["ENDERECO"] != DBNull.Value)
            //        lbEndereco.Text = dst.PARAMETRO_SIS[0].ENDERECO.ToString().ToUpper();

            //    if (dst.PARAMETRO_SIS[0]["NUMERO"] != DBNull.Value)
            //        lbNumero.Text = dst.PARAMETRO_SIS[0].NUMERO.ToString().ToUpper();

            //    if (dst.PARAMETRO_SIS[0]["BAIRRO"] != DBNull.Value)
            //        lbBairro.Text = dst.PARAMETRO_SIS[0].BAIRRO.ToString().ToUpper();

            //    if (dst.PARAMETRO_SIS[0]["FONE_FUNDO"] != DBNull.Value)
            //        lbTelefone.Text = dst.PARAMETRO_SIS[0].FONE_FUNDO.ToString().ToUpper();

            //    if (dst.PARAMETRO_SIS[0]["FAX_FUNDO"] != DBNull.Value)
            //        lbFax.Text = dst.PARAMETRO_SIS[0].FAX_FUNDO.ToString().ToUpper();

            //    if (dst.PARAMETRO_SIS[0]["CEP"] != DBNull.Value)
            //        lbCEP.Text = dst.PARAMETRO_SIS[0].CEP.ToString().ToUpper();

            //    if (dst.PARAMETRO_SIS[0]["CIDADE_ID"] != DBNull.Value)
            //    {
            //        DataTable CIDADE_UF = Utilitarios.Pesquisar("SELECT UF,NOME FROM CIDADES WHERE CIDADE_ID=" + dst.PARAMETRO_SIS[0].CIDADE_ID.ToString());
            //        lbEstado.Text = CIDADE_UF.Rows[0]["UF"].ToString().ToUpper();
            //        lbCidade.Text = CIDADE_UF.Rows[0]["NOME"].ToString().ToUpper();
            //    }

            //    lblSite.Text = dst.PARAMETRO_SIS[0]["SITE_FUNDO"].ToString();
            //    lblSite.OnClientClick = "javascript:window.open('http://" + lblSite.Text.Replace("http://", "") + "', 'WebSite', '');";
            //}
            // FIM
        }

        this.Form.DefaultButton = btnLogin.UniqueID;
        //string Titulo = Utilitarios.Exec_StringSql_Return("SELECT COALESCE(VALOR_PARAMETRO,'SISPREV WEB - Sistema de Gestão de Regime Próprio de " +
        //                "Previdência Social') FROM PARAMETROS_SISPREVWEB WHERE DESCRICAO LIKE '%TituloSistema%'");
        
        string Titulo = "";

        if (Titulo.Trim() == string.Empty)
            Titulo = "SISPREV WEB - Sistema de Gestão de Regime Próprio de Previdência Social";

        this.Title = Titulo;
        ScriptManager.RegisterStartupScript(this, GetType(), "JsResolucao", "Resolucao();", true);
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            Response.StatusCode = 401;
            string responseCaptcha = recaptchaResponse.Value;
            if (!string.IsNullOrEmpty(responseCaptcha))
            {
                string recaptchaSecretKey = "6LdpEHsoAAAAAO14OR-6mLOF0Acf54uqofeZyZXF";
                string recaptchaUrl = "https://www.google.com/recaptcha/api/siteverify?secret=" + recaptchaSecretKey + "&response=" + responseCaptcha;
                using (WebClient client = new WebClient())
                {
                    string response = client.DownloadString(recaptchaUrl);
                    System.Web.Script.Serialization.JavaScriptSerializer jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    dynamic captchaResult = jsSerializer.Deserialize<dynamic>(response);
                    bool success = captchaResult["success"];
                    var score = captchaResult["score"];
                    if (success && Convert.ToDecimal(score) >= Convert.ToDecimal(0.5))
                    {
                        Response.StatusCode = 200;
                        Response.Write("reCaptcha verificado com sucesso!");

                        string popup = string.Empty;

                        //127867
                        if (txtUSER.Text.Replace("'", "").ToUpper().Contains("AGENDA") || txtUSER.Text.Replace("'", "").ToUpper().Contains("TESTE"))
                            throw new Exception("Entre com seu ID Técnico e senha!");
                        else
                        {
                            if (hddDigital.Value != string.Empty)
                            {
                                if (UtilsLogin.Logon(Convert.ToInt32(hddDigital.Value)))
                                {
                                    GravaSessao();
                                    //UtilsLogin.GravaLogAcesso("LOGIN/ACESSO", Context.Request.UserHostAddress.ToString(), Utilitarios.Exec_StringSql_Return("SELECT SISTEMA + ' / BD: ' + BD FROM dbo.getVersaoSistema(0)"), UtilsLogin.DadosUsuarioLogado.LOGIN, (int)UtilsLogin.DadosUsuarioLogado.USR_LOGIN_ID);

                                    string MSSQL_DATABASE = "";
                                    string window = "SISPREV";
                                    if (UtilsLogin.Bast_Municipio != string.Empty)
                                    {
                                        MSSQL_DATABASE = "?MSSQL_DATABASE=" + UtilsLogin.Bast_Municipio;
                                    }
                                    Response.Redirect("../../Inicial.aspx");
                                }
                                else
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "msg", "<script>alert('Atenção: Biometria ou Assinatura Digital não encontrada!');</script>", false);
                                }
                            }
                            else if (UtilsLogin.Logon(txtUSER.Text.Replace("'", ""), txtPassWord.Text.Replace("'", "")) && hddDigital.Value == string.Empty)
                            {
                                GravaSessao();
                                //UtilsLogin.GravaLogAcesso("LOGIN/ACESSO", Context.Request.UserHostAddress.ToString(), Utilitarios.Exec_StringSql_Return("SELECT SISTEMA + ' / BD: ' + BD FROM dbo.getVersaoSistema(0)"), txtUSER.Text, (int)UtilsLogin.DadosUsuarioLogado.USR_LOGIN_ID);

                                HttpCookie cookie = new HttpCookie("sisprevlogin");
                                cookie.Value = txtUSER.Text.Replace("'", "");
                                cookie.Expires = DateTime.Now.AddDays(7);
                                Response.Cookies.Add(cookie);

                                string MSSQL_DATABASE = "";
                                string window = "SISPREV";
                                if (UtilsLogin.Bast_Municipio != string.Empty)
                                {
                                    MSSQL_DATABASE = "?MSSQL_DATABASE=" + UtilsLogin.Bast_Municipio;
                                }

                                Response.Redirect("../../Inicial.aspx");
                            }
                        }
                    }
                    else
                    {
                        // Não verificado
                        Response.Write("Falha na verificação do reCaptcha.");
                    }
                }
            }
            else
            {
                // Token não foi encontrado no formulário
                Response.Write("Token reCaptcha está faltando.");
            }

        }
        catch (Exception ex)
        {
            //UtilsLogin.GravaLogAcesso("LOGIN/FALHA", Request.UserHostAddress.ToString(), Utilitarios.Exec_StringSql_Return("SELECT SISTEMA + ' / BD: ' + BD FROM dbo.getVersaoSistema(0)"), txtUSER.Text, 0);

            divBloqueado.Visible = false;
            loginNew.Visible = true;
            string msg = ex.Message.Replace("'", " ");
            txtPassWord.Focus();
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "MSG", "<script>alert('" + msg + "');history.back();</script>", false);
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {

    }

    protected void LimparCookieLogin_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("sisprevlogin");
        cookie.Values.Clear();
        cookie.Value = "";
        cookie.Expires = DateTime.Now.AddDays(-1);
        LimparCookieLogin.Visible = false;
        LabelLogin.Visible = false;
        txtUSER.Text = "";
        txtUSER.Visible = true;
        divBloqueado.Visible = false;
        loginNew.Visible = true;
    }

    private void GravaSessao()
    {
        //REMOVE SESSÃO DO BANCO
        Utilitarios.Exec_StringSql("DELETE FROM SESSOES WHERE USR_LOGIN_ID=" + UtilsLogin.DadosUsuarioLogado.USR_LOGIN_ID);

        //GERA NOVA SESSÃO
        Random rnd = new Random(DateTime.Now.Millisecond);
        Sessoes.SESSION_ID = rnd.Next().ToString();

        string IP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(IP) || IP.Equals("unknown", StringComparison.OrdinalIgnoreCase))
            Sessoes.IP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        else
            Sessoes.IP = IP;

        // GRAVA NOVA SESSÃO
        Utilitarios.Exec_StringSql("INSERT INTO SESSOES (SESSAO_ID,USR_LOGIN_ID,IP) VALUES ('" + Sessoes.SESSION_ID + "'," + UtilsLogin.DadosUsuarioLogado.USR_LOGIN_ID + ",'" + Sessoes.IP + "');");
    }
}
