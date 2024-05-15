using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

/// <summary>
/// Summary description for AppBasePage
/// </summary>
public class AppBasePage : Page
{
    protected override void OnLoad(EventArgs e)
    {
        bool ok = false;
        bool Permite = true;
        string hora = DateTime.Now.ToShortTimeString();
        string data = DateTime.Now.ToShortDateString();
        bool PermiteLink = true;

        try
        {
            Convert.ToInt32(UtilsLogin.DadosUsuarioLogado.LOGIN);
            ok = true;
            if (!string.IsNullOrEmpty(UtilsLogin.DadosUsuarioLogado.HORA_FIM) && !string.IsNullOrEmpty(UtilsLogin.DadosUsuarioLogado.DATA))
                if (Convert.ToDateTime(UtilsLogin.DadosUsuarioLogado.DATA) == Convert.ToDateTime(data) && (Convert.ToDateTime(hora) >= Convert.ToDateTime(UtilsLogin.DadosUsuarioLogado.HORA_INI)
                     && Convert.ToDateTime(hora) <= Convert.ToDateTime(UtilsLogin.DadosUsuarioLogado.HORA_FIM)))
                    Permite = true;
                else
                {
                    Utilitarios.Exec_ProcSql("UPDATE USR_LOGIN SET HASH_TECNICO = NULL WHERE LOGIN = '" + UtilsLogin.DadosUsuarioLogado.LOGIN + "'");
                    Response.Redirect("~/Login/Login.aspx");
                }
        }
        catch (Exception ex)
        {
            ok = false;
        }

        string versao = string.Empty;

        if (Session["versao"] != null)
            versao = " - Versão: " + Session["versao"].ToString();

        string Titulo = "";
        //string Titulo = Utilitarios.Exec_StringSql_Return("SELECT COALESCE(VALOR_PARAMETRO,'SISPREV WEB - Sistema de Gestão de Regime Próprio de " +
        //                "Previdência Social') FROM PARAMETROS_SISPREVWEB WHERE DESCRICAO LIKE '%TituloSistema%'");

        if (Titulo.Trim() == string.Empty)
            Titulo = "SISPREV WEB - Sistema de Gestão de Regime Próprio de Previdência Social";

        this.Title = Titulo + versao;

        string url = HttpContext.Current.Request.Url.ToString().ToLower();
        if (url.IndexOf("sisprevweb") > 0)
        {
            url = Server.UrlDecode(Request.Url.PathAndQuery.Substring(1, Request.Url.PathAndQuery.Length - 1).ToLower());
            int x = url.IndexOf("/");
            url = url.Substring(x + 1, url.Length - (x + 1));
        }
        else
        {
            url = Server.UrlDecode(Request.Url.PathAndQuery.Substring(1, Request.Url.PathAndQuery.Length - 1).ToLower());
        }

        if (Utilitarios.Exec_IntSql_Return("SELECT COUNT(*) FROM MENU WHERE LOWER(URL) LIKE '%" + url + "'") > 0)
        {
            PermiteLink = Utilitarios.Exec_IntSql_Return("SELECT COUNT(*) FROM VW_MENU_GRUPO WHERE (USR_GRUPO_ID = " + UtilsLogin.DadosUsuarioLogado.USR_GRUPO_ID +
                " AND LOWER(URL) LIKE '%" + url + "%') ") > 0;
        }

        //if (UtilsLogin.DadosUsuarioLogado.USR_LOGIN_ID == null)
        //    Response.Redirect("~/Paginas/Login/Login.aspx");
        //else if (Utilitarios.ConverteSimNaoParaBool(Utilitarios.Exec_StringSql_Return("SELECT TOP 1 ATUALIZANDO FROM PARAMETRO_SIS")))
        //{
        //    Response.Redirect("~/Paginas/Login/AvisoLogin.aspx?erro=Aguarde estamos atualizando o sistema!");
        //}
        //else
        //{
        //    if (Sessoes.SESSION_ID != null)
        //    {
        //        DataTable dt = Utilitarios.Pesquisar("SELECT SESSAO_ID,COALESCE(IP,'0.0.0.0')AS IP FROM SESSOES WHERE USR_LOGIN_ID = " + UtilsLogin.DadosUsuarioLogado.USR_LOGIN_ID);
        //        if (dt.Rows.Count > 0)
        //        {
        //            if (dt.Rows[0]["SESSAO_ID"].ToString() == Sessoes.SESSION_ID)
        //            {
        //                if (!UtilsLogin.VerificarSeUsuarioLogado())
        //                {
        //                    if (Request.QueryString["SEGURADO_ALTERACAO_ID"] != null)
        //                        Session["URL"] = "Segurado/Portal_Segurado.aspx?" + Request.QueryString["SEGURADO_ALTERACAO_ID"].ToString(); ;

        //                    Response.Redirect("~/Login/Login.aspx");
        //                }
        //            }
        //            else
        //            {
        //                Sessoes.IP_ANTERIOR = dt.Rows[0]["IP"].ToString();
        //                Response.Redirect("~/Login/AvisoLogin.aspx");
        //            }
        //        }
        //        else
        //        {
        //            if (!UtilsLogin.VerificarSeUsuarioLogado())
        //            {
        //                if (Request.QueryString["SEGURADO_ALTERACAO_ID"] != null)
        //                    Session["URL"] = "Segurado/Portal_Segurado.aspx?" + Request.QueryString["SEGURADO_ALTERACAO_ID"].ToString(); ;

        //                Response.Redirect("~/Login/Login.aspx");
        //            }
        //        }
        //    }
        //    else
        //        Response.Redirect("~/Login/Login.aspx");
        //}

        if (!IsPostBack)
        {
            //Session.Remove("CONSULTA");
            //Session.Remove("GRIDRESULTADOS");
            //Session.Remove("INDEXGRID");
        }

        if (PermiteLink == false)
        {
            Response.Redirect("~/Inicial.aspx");
        }

        Header.Controls.Add(new LiteralControl(PageUtility.GetCSSInclude(Utilitarios.CaminhoWEB() + "Library/Estilos/estilo_padrao.css")));
        Header.Controls.Add(new LiteralControl(PageUtility.GetCSSInclude(Utilitarios.CaminhoWEB() + "Library/Estilos/Default.css")));
        Header.Controls.Add(new LiteralControl(PageUtility.GetCSSInclude(Utilitarios.CaminhoWEB() + "Library/Estilos/Controles.css")));
        Header.Controls.Add(new LiteralControl(PageUtility.GetCSSInclude(Utilitarios.CaminhoWEB() + "Library/Estilos/LayoutConsulta.css")));
        Header.Controls.Add(new LiteralControl(PageUtility.GetCSSInclude(Utilitarios.CaminhoWEB() + "Library/Estilos/ToolBar.css")));
        Header.Controls.Add(new LiteralControl(PageUtility.GetClientScriptInclude(Utilitarios.CaminhoWEB() + "Library/Scripts/Mascaras.js")));
        Header.Controls.Add(new LiteralControl(PageUtility.GetClientScriptInclude(Utilitarios.CaminhoWEB() + "Library/Scripts/jquery.js")));
        Header.Controls.Add(new LiteralControl(PageUtility.GetClientScriptInclude(Utilitarios.CaminhoWEB() + "Library/Scripts/teclaf1.js")));
        Header.Controls.Add(new LiteralControl(PageUtility.GetClientScriptInclude(Utilitarios.CaminhoWEB() + "Library/Chat/Scripts/jquery.titlealert.min.js")));
        Header.Controls.Add(new LiteralControl(PageUtility.GetCSSInclude(Utilitarios.CaminhoWEB() + "Library/Chat/ChatJs/Styles/jquery.chatjs.css")));
        base.OnLoad(e);
    }

    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        System.IO.StringWriter stringWriter = new System.IO.StringWriter();
        HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
        base.Render(htmlWriter);
        string html = stringWriter.ToString();
        int StartPoint = html.IndexOf("<input type=\"hidden\" name=\"__VIEWSTATE\"");

        if (StartPoint >= 0)
        {
            int EndPoint = html.IndexOf("/>", StartPoint) + 2;
            string viewstateInput = html.Substring(StartPoint, EndPoint - StartPoint);
            html = html.Remove(StartPoint, EndPoint - StartPoint);
            int FormEndStart = html.IndexOf("</form>") - 1;
            if (FormEndStart >= 0)
            {
                html = html.Insert(FormEndStart, viewstateInput);
            }
        }
        writer.Write(html);
        Label lbl = null;
        // Grava Log de acesso
        if (this.Page.Master != null)
            lbl = (Label)this.Page.Master.FindControl("lblTituloPagina");
        else lbl = (Label)this.Page.FindControl("lblTituloPagina");
        if (lbl != null && lbl.Text != string.Empty)
        {
            DataTable dt = Utilitarios.Pesquisar("SELECT TOP 1 * FROM USR_ACESSO WHERE USR_LOGIN_ID=" +
                    UtilsLogin.DadosUsuarioLogado.USR_LOGIN_ID + " ORDER BY USR_ACESSO_ID DESC");

            if (dt.Rows.Count > 0)
            {
                DateTime Hora = DateTime.Now;
                DateTime HoraUltimo = Convert.ToDateTime(dt.Rows[0]["DATA_HORA"]);
                TimeSpan dif = Hora.Subtract(HoraUltimo);

                if (dif.TotalSeconds > 5 && dt.Rows[0]["DESCRICAO_MODULO"].ToString() != lbl.Text)
                {
                    UtilsLogin.GravaLogAcesso(lbl.Text, Sessoes.IP,
                        Utilitarios.Exec_StringSql_Return("SELECT SISTEMA + ' / BD: ' + BD FROM dbo.getVersaoSistema(0)"),
                            UtilsLogin.DadosUsuarioLogado.LOGIN, (int)UtilsLogin.DadosUsuarioLogado.USR_LOGIN_ID);
                }
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        ViewStateCompression = Deflater.BEST_COMPRESSION;
        base.OnInit(e);
    }

    //protected override void SavePageStateToPersistenceMedium(Object state)
    //{
    //    if (ViewStateCompression == Deflater.NO_COMPRESSION)
    //    {
    //        base.SavePageStateToPersistenceMedium(state);
    //        return;
    //    }

    //    Object viewState = state;
    //    if (state is Pair)
    //    {
    //        Pair statePair = (Pair)state;
    //        PageStatePersister.ControlState = statePair.First;
    //        viewState = statePair.Second;
    //    }

    //    using (StringWriter writer = new StringWriter())
    //    {
    //        new LosFormatter().Serialize(writer, viewState);
    //        string base64 = writer.ToString();
    //        byte[] compressed = Compress(Convert.FromBase64String((base64)));
    //        PageStatePersister.ViewState = Convert.ToBase64String(compressed);
    //    }
    //    PageStatePersister.Save();
    //}

    //protected override Object LoadPageStateFromPersistenceMedium()
    //{
    //    if (viewStateCompression == Deflater.NO_COMPRESSION)
    //        return base.LoadPageStateFromPersistenceMedium();

    //    PageStatePersister.Load();
    //    String base64 = PageStatePersister.ViewState.ToString();
    //    byte[] state = Decompress(Convert.FromBase64String(base64));
    //    string serializedState = Convert.ToBase64String(state);

    //    object viewState = new LosFormatter().Deserialize(serializedState);
    //    return new Pair(PageStatePersister.ControlState, viewState);
    //}

    private const int BUFFER_SIZE = 65536;
    private int viewStateCompression = Deflater.NO_COMPRESSION;

    private int ViewStateCompression
    {
        get { return viewStateCompression; }
        set { viewStateCompression = value; }
    }

    //private byte[] Compress(byte[] bytes)
    //{
    //    using (MemoryStream memoryStream = new MemoryStream(BUFFER_SIZE))
    //    {
    //        Deflater deflater = new Deflater(ViewStateCompression);
    //        using (Stream stream = new DeflaterOutputStream(memoryStream, deflater, BUFFER_SIZE))
    //        {
    //            stream.Write(bytes, 0, bytes.Length);
    //        }
    //        return memoryStream.ToArray();
    //    }
    //}

    //private byte[] Decompress(byte[] bytes)
    //{
    //    using (MemoryStream byteStream = new MemoryStream(bytes))
    //    {
    //        using (Stream stream = new InflaterInputStream(byteStream))
    //        {
    //            using (MemoryStream memory = new MemoryStream(BUFFER_SIZE))
    //            {
    //                byte[] buffer = new byte[BUFFER_SIZE];
    //                while (true)
    //                {
    //                    int size = stream.Read(buffer, 0, BUFFER_SIZE);
    //                    if (size <= 0)
    //                        break;

    //                    memory.Write(buffer, 0, size);
    //                }
    //                return memory.ToArray();
    //            }
    //        }
    //    }
    //}
}