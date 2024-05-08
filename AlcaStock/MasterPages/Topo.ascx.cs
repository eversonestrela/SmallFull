using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Threading;

public partial class MasterPages_Topo : System.Web.UI.UserControl
{
    public int UserId = 0;
    public string NomeUsuario = string.Empty;

    private string MUDALOGOS
    {
        get
        {
            string mudalogos = string.Empty;

            if (Session["MudaLogos"] != null)
                mudalogos = Session["MudaLogos"].ToString();

            return mudalogos;
        }
        set
        {
            Session["MudaLogos"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        Label1.Text = "<b>Logado(s):</b> " + Convert.ToString(Application["conta"]);

        // Seta os parametros para visualização do ícone
        string path = (Utilitarios.IsHttps() ? "https://" : "http://") + this.Request.ServerVariables["HTTP_HOST"].ToString() + this.Request.ApplicationPath + "/";
        string ImgIcone = path + "Library/MasterPages/ico_cliente.ico";

        if (Session["ICO_CLIENTE"] != null)
        {
            string mostra_ico = Session["ICO_CLIENTE"].ToString();

            if (mostra_ico == "S")
            {
                ico_cliente.Text = "<link href='" + ImgIcone + "' rel='shortcut icon'>";
            }
        }

        Label1.Visible = (!UtilsLogin.EhBast());

        //if (UtilsLogin.PessoaUsuarioLogado.NOME != null)
        //    lblNomeUsuario.Text = "<b>Usuário: </b> " + UtilsLogin.PessoaUsuarioLogado.NOME.ToString();
        //if (UtilsLogin.DadosUsuarioLogado.SETOR_ID != null)
        //    lbLotacao.Text = "<b>Lotação:</b> " + UtilsLogin.DadosUsuarioLogado.SETOR.ToString();

        lblNomeUsuario.Text = "<b>Usuário: </b> Pedro Wenner";
        lbLotacao.Text = "<b>Lotação: </b> TI";

        if (!IsPostBack)
        {
            path = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\Library\\";

            //string imgLogo = path + "Images\\" + UtilsLogin.Bast_Municipio + "_logo_sisprev_web.gif";
            //string imgLadoDireito = path + "Images_Cliente\\" + UtilsLogin.Bast_Municipio + "_lado_direito_logo.gif";

            //Logo.ImageUrl = File.Exists(imgLogo) ? ResolveUrl("~/Library/Images/" + UtilsLogin.Bast_Municipio + "_logo_sisprev_web.gif") : Logo.ImageUrl;
            //LadoDireito.ImageUrl = File.Exists(imgLadoDireito) ? ResolveUrl("~/Library/Images_Cliente/" + UtilsLogin.Bast_Municipio + "_lado_direito_logo.gif") : LadoDireito.ImageUrl;
        }
        
        //UserId = (int)UtilsLogin.DadosUsuarioLogado.USR_LOGIN_ID;
        //NomeUsuario = UtilsLogin.PessoaUsuarioLogado.NOME.ToString();
    }
}
