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

            HttpCookie cookie = Request.Cookies["sisprevlogin"];
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Library\";

            string imgLogo = path + "Images\\" + UtilsLogin.Bast_Municipio + "_logo_sisprev_web.gif";
            string imgLadoDireito = path + "Images_Cliente\\" + UtilsLogin.Bast_Municipio + "_lado_direito_logo.gif";
            string imgLogoCliente = path + "Images_Cliente\\" + UtilsLogin.Bast_Municipio + "_logo.gif";

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
        }

        this.Form.DefaultButton = btnLogin.UniqueID;
        string Titulo = "";

        if (Titulo.Trim() == string.Empty)
            Titulo = "SISPREV WEB - Sistema de Gest�o de Regime Pr�prio de Previd�ncia Social";

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
                            throw new Exception("Entre com seu ID T�cnico e senha!");
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
                                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "msg", "<script>alert('Aten��o: Biometria ou Assinatura Digital n�o encontrada!');</script>", false);
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
                        // N�o verificado
                        Response.Write("Falha na verifica��o do reCaptcha.");
                    }
                }
            }
            else
            {
                // Token n�o foi encontrado no formul�rio
                Response.Write("Token reCaptcha est� faltando.");
            }

        }
        catch (Exception ex)
        {
            //UtilsLogin.GravaLogAcesso("LOGIN/FALHA", Request.UserHostAddress.ToString(), Utilitarios.Exec_StringSql_Return("SELECT SISTEMA + ' / BD: ' + BD FROM dbo.getVersaoSistema(0)"), txtUSER.Text, 0);

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
        loginNew.Visible = true;
    }

    private void GravaSessao()
    {
        //REMOVE SESS�O DO BANCO
        Utilitarios.Exec_StringSql("DELETE FROM SESSOES WHERE USR_LOGIN_ID=" + UtilsLogin.DadosUsuarioLogado.USR_LOGIN_ID);

        //GERA NOVA SESS�O
        Random rnd = new Random(DateTime.Now.Millisecond);
        Sessoes.SESSION_ID = rnd.Next().ToString();

        string IP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(IP) || IP.Equals("unknown", StringComparison.OrdinalIgnoreCase))
            Sessoes.IP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        else
            Sessoes.IP = IP;

        // GRAVA NOVA SESS�O
        Utilitarios.Exec_StringSql("INSERT INTO SESSOES (SESSAO_ID,USR_LOGIN_ID,IP) VALUES ('" + Sessoes.SESSION_ID + "'," + UtilsLogin.DadosUsuarioLogado.USR_LOGIN_ID + ",'" + Sessoes.IP + "');");
    }
}
