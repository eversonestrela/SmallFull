using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

public partial class MasterPages_Menu : System.Web.UI.UserControl
{
    #region Propriedades

    StringBuilder str = new StringBuilder();

    #endregion Propriedades

    #region Eventos

    protected void Page_Load(object sender, EventArgs e)
    {
        CriaMenu();
    }

    protected void lnkCorreio_Click(object sender, EventArgs e)
    {
        //
    }

    #endregion Eventos

    #region Metodos

    private void CriaMenu()
    {
        DataTable dt = new DataTable();
        //string query = "SELECT ID, PARENT_ID, URL, JSCRIPT_INI, JSCRIPT_FIM, TEXTO FROM VW_MENU_GRUPO WHERE USR_GRUPO_ID = @USR_GRUPO_ID AND PARENT_ID IS NULL AND INICIAR IS NULL ORDER BY ID, PARENT_ID";
        string query = "SELECT ID, PARENT_ID, URL, JSCRIPT_INI, JSCRIPT_FIM, TEXTO FROM VW_MENU_GRUPO WHERE USR_GRUPO_ID = 1 AND PARENT_ID IS NULL AND INICIAR IS NULL ORDER BY ID, PARENT_ID";

        // Cria o objeto de conexão
        SqlConnection conn = Utilitarios.GetOpenConnection();
        // Cria o objeto SqlDataAdapter
        SqlDataAdapter exec = new SqlDataAdapter();
        // Cria o SqlCommand
        SqlCommand cmd = new SqlCommand(query, conn);
        //cmd.Parameters.AddWithValue("@USR_GRUPO_ID", UtilsLogin.DadosUsuarioLogado.USR_GRUPO_ID.ToString());
        exec.SelectCommand = cmd;
        exec.SelectCommand.CommandTimeout = 1020;

        try
        {
            // Realiza a Consulta
            exec.Fill(dt);
        }
        catch (SqlException ex)
        {
            //
        }
        finally
        {
            Utilitarios.CloseConnection(conn);
            exec.Dispose();
            cmd.Dispose();
        }

        str.Append("<link href=\"" + ResolveUrl("~/Library/Estilos/Menu.css") + "\" rel=\"stylesheet\" type=\"text/css\"/>");
        str.Append("<div id=\"navegacaoSecao\">");
        str.Append("<ul class=\"maxWidth\">");

        string filhos = string.Empty;
        string menu = string.Empty;

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["JSCRIPT_INI"] != DBNull.Value)
            {
                menu = "<a href=\"javascript:;\" onclick=\"" + dt.Rows[i]["JSCRIPT_INI"].ToString() +
                           ResolveUrl(dt.Rows[i]["URL"].ToString()) + dt.Rows[i]["JSCRIPT_FIM"].ToString() + "\">";
            }
            else
            {
                if (dt.Rows[i]["URL"].ToString() != string.Empty)
                    menu = "<a href=\"" + ResolveUrl(dt.Rows[i]["URL"].ToString()) + "\">";
                else
                    menu = "<a href=\"javascript:;\">";
            }

            str.Append("<li class=\"\">" + menu + dt.Rows[i]["TEXTO"].ToString().Replace("&nbsp;", "") + "</a>");

            filhos = SubMenu(dt.Rows[i]["ID"].ToString());

            if (filhos == string.Empty)
                str.Append("</li>");
            else
                str.Append("<ul class=\"\">" + filhos + "</ul></li>");
        }

        str.Append("</ul></div>");

        Session["MENU"] = str.ToString();

        lblMenu.Text = str.ToString();
    }

    private string SubMenu(string ID)
    {
        string TECNICO = Utilitarios.Exec_StringSql_Return("SELECT UPPER(COALESCE(TECNICO, 'N')) FROM USR_LOGIN WHERE USR_LOGIN_ID = " + 1);//UtilsLogin.DadosUsuarioLogado.USR_LOGIN_ID.ToString());

        string GrupoTecnico = Utilitarios.Exec_StringSql_Return("SELECT MIN(USR_GRUPO_ID) FROM USR_LOGIN WHERE COALESCE(TECNICO, 'N') = 'S'");

        if (UtilsLogin.DadosUsuarioLogado.USR_GRUPO_ID.ToString() == GrupoTecnico)
            TECNICO = "S";

        StringBuilder str = new StringBuilder();

        string where = string.Empty;
        string filhos = string.Empty;
        string menu = string.Empty;

        if (ID != string.Empty)
        {
            where = " AND PARENT_ID = " + ID;

            DataTable dt = Utilitarios.Pesquisar("SELECT ID, PARENT_ID, URL, JSCRIPT_INI, JSCRIPT_FIM, TEXTO, BREAK_NEXT FROM VW_MENU_GRUPO " +
                            "WHERE USR_GRUPO_ID = " + 1/*UtilsLogin.DadosUsuarioLogado.USR_GRUPO_ID.ToString() */ + " " + where + " AND INICIAR IS NULL ORDER BY ORDEM,ID");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (TECNICO != "S" && (dt.Rows[i]["ID"].ToString() == "6042" || dt.Rows[i]["ID"].ToString() == "606"))
                {
                    dt.Rows[i]["URL"] = "";
                    str.Append("<li class=\"\"><a href=\"javascript:;\"><font color='#CCCCCC'>" + dt.Rows[i]["TEXTO"].ToString().Replace("&nbsp;", "") + "</font></a></li>");
                }
                else
                {
                    if (dt.Rows[i]["JSCRIPT_INI"] != DBNull.Value)
                    {
                        menu = "<a href=\"javascript:;\" onclick=\"" + dt.Rows[i]["JSCRIPT_INI"].ToString() +
                                   ResolveUrl(dt.Rows[i]["URL"].ToString()) + dt.Rows[i]["JSCRIPT_FIM"].ToString() + "\">";
                    }
                    else
                    {
                        if (dt.Rows[i]["URL"].ToString() != string.Empty)
                            menu = "<a href=\"" + ResolveUrl(dt.Rows[i]["URL"].ToString()) + "\">";
                        else
                            menu = "<a class=\"Submenu\" href=\"javascript:;\">";
                    }

                    str.Append("<li class=\"\">" + menu + dt.Rows[i]["TEXTO"].ToString().Replace("&nbsp;", "") + "</a>");

                    filhos = SubMenu(dt.Rows[i]["ID"].ToString());

                    if (filhos == string.Empty)
                    {
                        str.Append("</li>");
                    }
                    else
                    {
                        str.Append("<ul class=\"\">" + filhos + "</ul></li>");
                    }
                }
            }
        }

        return str.ToString();
    }

    #endregion Metodos

}