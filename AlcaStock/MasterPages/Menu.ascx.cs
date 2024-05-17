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

        string filhos = string.Empty;
        string menu = string.Empty;

        /* nesse momento será criado os menus pai */
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["URL"].ToString() == string.Empty)
                menu = "<a class=\"nav-link collapsed\" data-toggle=\"collapse\" data-target=\"#menu" + dt.Rows[i]["TEXTO"].ToString().Replace("&nbsp;", "") + "\" aria-expanded=\"true\" aria-controls=\"menu" + dt.Rows[i]["TEXTO"].ToString().Replace("&nbsp;", "") + "\"" +
                    " href=\"javascript:;\">";
            else
                menu = "<a class=\"nav-link\" href=\"" + ResolveUrl(dt.Rows[i]["URL"].ToString()) + "\">";
            
            str.Append("<li class=\"nav-item\">");
            str.Append(menu);
            str.Append("<span>" + dt.Rows[i]["TEXTO"].ToString().Replace("&nbsp;", "") + "</span></a>");

            filhos = SubMenu(dt.Rows[i]["ID"].ToString(), dt.Rows[i]["TEXTO"].ToString().Replace("&nbsp;", ""));

            str.Append(filhos);

            if (filhos == string.Empty)
                str.Append("</li>");
        }

        Session["MENU"] = str.ToString();

        lblMenu.Text = str.ToString();
    }

    private string SubMenu(string id, string parent)
    {
        string TECNICO = Utilitarios.Exec_StringSql_Return("SELECT UPPER(COALESCE(TECNICO, 'N')) FROM USR_LOGIN WHERE USR_LOGIN_ID = 1"); //UtilsLogin.DadosUsuarioLogado.USR_LOGIN_ID.ToString());
        string GrupoTecnico = Utilitarios.Exec_StringSql_Return("SELECT MIN(USR_GRUPO_ID) FROM USR_LOGIN WHERE COALESCE(TECNICO, 'N') = 'S'");

        if (UtilsLogin.DadosUsuarioLogado.USR_GRUPO_ID.ToString() == GrupoTecnico)
            TECNICO = "S";

        StringBuilder str = new StringBuilder();

        string where = string.Empty;
        string filhos = string.Empty;
        string menu = string.Empty;
        int temFilhos = 0;

        if (id != string.Empty)
        {
            where = " AND PARENT_ID = " + id;

            DataTable dt = Utilitarios.Pesquisar("SELECT ID, PARENT_ID, URL, JSCRIPT_INI, JSCRIPT_FIM, TEXTO, BREAK_NEXT FROM VW_MENU_GRUPO " +
                "WHERE USR_GRUPO_ID = 1 " /*UtilsLogin.DadosUsuarioLogado.USR_GRUPO_ID.ToString() */ + where + " AND INICIAR IS NULL ORDER BY ORDEM, ID");

            if (dt.Rows.Count > 0)
            {
                str.Append("<div id=\"menu" + parent + "\" class=\"collapse\" data-parent=\"#menuLateral\">");
                str.Append("<div class=\"bg-white py-2 collapse-inner rounded\">");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //temFilhos = Utilitarios.Exec_IntSql_Return(string.Format("SELECT COUNT(*) FROM VW_MENU_GRUPO WHERE USR_GRUPO_ID = 1 AND PARENT_ID = {0} AND INICIAR IS NULL", dt.Rows[i]["ID"].ToString()));

                    //if (temFilhos > 0)
                    //{
                    //    str.Append("<a class=\"collapse-item\" data-toggle=\"collapse\" data-target=\"#menu" + dt.Rows[i]["TEXTO"].ToString() + 
                    //        "\" aria-expanded=\"true\" aria-controls=\"menu" + dt.Rows[i]["TEXTO"].ToString() + "\" href=\"javascript:;\" style=\"display: flex; justify-content: space-between; align-items: center;\">");
                    //    str.Append("<span>" + dt.Rows[i]["TEXTO"].ToString() + "</span>");
                    //    str.Append("<i class=\"fas fa-angle-down coll\"></i>");
                    //    str.Append("</a>");
                    //    str.Append("<div id=\"menu" + dt.Rows[i]["TEXTO"].ToString() + "\" class=\"collapse\" data-parent=\"#menu" + parent + "\">");

                    //    filhos = SubMenu(dt.Rows[i]["ID"].ToString(), dt.Rows[i]["TEXTO"].ToString());

                    //    str.Append(filhos);
                    //    str.Append("</div></div>");
                    //}
                    //else
                    //{
                    //    menu += "<a class=\"collapse-item\" href=\"" + ResolveUrl(dt.Rows[i]["URL"].ToString()) + "\"> " + dt.Rows[i]["TEXTO"].ToString().Replace("&nbsp;", "") + "</a>";
                    //}

                    menu += "<a class=\"collapse-item\" href=\"" + ResolveUrl(dt.Rows[i]["URL"].ToString()) + "\"> " + dt.Rows[i]["TEXTO"].ToString().Replace("&nbsp;", "") + "</a>";
                }

                str.Append(menu);
                str.Append("</div>");
                str.Append("</div>");

                str.Append("</li>");
            }
        }

        return str.ToString();
    }

    #endregion Metodos

}