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

/// <summary>
/// UserControl que realiza a paginação da Grid
/// Obrigatório nas telas:
///     No evento Page_Load da tela passar o DataGrid para o UserControl. Ex: Paginacao1.GRIDRESULTADO = grdResultados;
///     No evento ItemDataBound do DataGrid chamar o método do UserControl "TotalizarPaginas". Ex: Paginacao1.TotalizarPaginas();
/// </summary>
public partial class Library_MasterPages_paginacao : System.Web.UI.UserControl
{
    #region Propriedades

    public DataTable RESULTADOCONSULTA
    {
        get
        {
            DataTable dt = null;

            if (Session["CONSULTA"] != null)
                dt = (DataTable)Session["CONSULTA"];

            return dt;
        }
        set
        {
            Session["CONSULTA"] = value;
        }
    }

    public DataGrid GRIDRESULTADO
    {
        get
        {
            DataGrid grid = new DataGrid();

            if (Session["GRIDRESULTADOS"] != null)
                grid = (DataGrid)Session["GRIDRESULTADOS"];

            return grid;
        }
        set
        {
            Session["GRIDRESULTADOS"] = value;
        }
    }

    public DropDownList DROPPAGE
    {
        get
        {
            return dropPage;
        }
        set
        {
            dropPage = value;
        }
    }

    private int INDEXGRID
    {
        get
        {
            int index = 0;
            if (Session["INDEXGRID"] != null)
                index = Convert.ToInt32(Session["INDEXGRID"]);

            return index;
        }
        set
        {
            Session["INDEXGRID"] = value;
        }

    }

    #endregion Propriedades

    #region Eventos

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((!IsPostBack) && (RESULTADOCONSULTA == null || RESULTADOCONSULTA.Rows.Count == 0))
        {
            RESULTADOCONSULTA = null;
            GRIDRESULTADO = null;
            INDEXGRID = 0;
            ControlarEstadoBotoes(false, false, false, false, false);
        }
    }

    protected void ImageButtonNav(object sender, EventArgs e)
    {
        string arg = ((LinkButton)sender).CommandArgument;
        int currentPage = GRIDRESULTADO.CurrentPageIndex;
        switch (arg)
        {
            case "proximo":
                if (GRIDRESULTADO.CurrentPageIndex < (GRIDRESULTADO.PageCount - 1))
                {
                    currentPage += 1;
                    INDEXGRID = currentPage;
                }
                break;
            case "anterior":
                if (GRIDRESULTADO.CurrentPageIndex > 0)
                {
                    currentPage -= 1;
                    INDEXGRID = currentPage;
                }
                break;
            case "ultimo":
                {
                    currentPage = (GRIDRESULTADO.PageCount - 1);
                    INDEXGRID = currentPage;
                }
                break;

            case "primeiro":
                {
                    currentPage = 0;
                    INDEXGRID = currentPage;
                }
                break;
        }
        dropPage.SelectedIndex = currentPage;
        AlimentarGrid(currentPage);
    }

    protected void dropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GRIDRESULTADO.CurrentPageIndex = dropPage.SelectedIndex;
        AlimentarGrid(GRIDRESULTADO.CurrentPageIndex);
    }

    #endregion Eventos

    #region Metodos

    /// <summary>
    /// Alimenta a grid e seta a página que ela deverá estar
    /// </summary>
    /// <param name="currentPage">Número da Página que a grid deverá estar</param>
    public void AlimentarGrid(int currentPage)
    {

        if (currentPage > GRIDRESULTADO.PageCount)
        {
            GRIDRESULTADO.CurrentPageIndex = currentPage - 1;
        }
        else
        {
            GRIDRESULTADO.CurrentPageIndex = currentPage;
        }

        GRIDRESULTADO.DataSource = RESULTADOCONSULTA;
        GRIDRESULTADO.DataBind();
        dropPage.SelectedIndex = currentPage;

        AtualizarImageButtons();
    }

    /// <summary>
    /// Metodo para Totalizar as Paginas atribuindo no DropDownList.
    /// </summary>
    public void TotalizarPaginas()
    {
        dropPage.Items.Clear();
        if (dropPage.Items.Count <= 0)
        {
            for (int i = 1; i <= GRIDRESULTADO.PageCount; i++)
            {
                dropPage.Items.Add(i.ToString());
            }
        }
        AtualizarImageButtons();
    }

    /// <summary>
    /// Metodo para atualizar as Imagens da Barra de Navegação.
    /// </summary>
    public void AtualizarImageButtons()
    {
        int pgAtual = GRIDRESULTADO.CurrentPageIndex + 1;
        int pgTotal = GRIDRESULTADO.PageCount;

        if (GRIDRESULTADO.CurrentPageIndex == 0)
        {
            // CHAMADO: 32661 - Alterado para qdo a variavel pgTotal vier zerada, não habilitar os botões.
            if (pgTotal <= 1)
            {
                ControlarEstadoBotoes(false, false, false, false, false);
            }
            else
            {
                ControlarEstadoBotoes(false, false, true, true, true);
            }
        }
        else if (GRIDRESULTADO.CurrentPageIndex == (GRIDRESULTADO.PageCount - 1))
        {
            ControlarEstadoBotoes(true, true, false, false, true);
        }
        else if (GRIDRESULTADO.PageCount == 0)
        {
            ControlarEstadoBotoes(false, false, false, false, false);
        }
        else
        {
            ControlarEstadoBotoes(true, true, true, true, true);
        }

        if (RESULTADOCONSULTA != null)
        {
            if (RESULTADOCONSULTA.Rows.Count <= 0)
            {
                ControlarEstadoBotoes(false, false, false, false, false);
            }


            lblTotal.Text = pgTotal.ToString();
            lblTotalRegistros.Text = "Total de Registros: " + RESULTADOCONSULTA.Rows.Count;
        }
    }

    /// <summary>
    /// Controla o estado dos botões (Imagem e Enable)
    /// </summary>
    /// <param name="primeiro">Botão para primeira página</param>
    /// <param name="anterior">Botão para página anterior</param>
    /// <param name="proximo">Botão para próxima página</param>
    /// <param name="ultimo">Botão para última página</param>
    /// <param name="drop">DropDownList da numeração das Páginas</param>
    public void ControlarEstadoBotoes(bool primeiro, bool anterior, bool proximo, bool ultimo, bool drop)
    {
        #region primeiro

        if (!primeiro)
        {
            // btnPrimeiro.ImageUrl = "~/Library/Images/Botoes/pagenav_primeiro_desabilitado.gif";
            btnPrimeiro.Enabled = false;
        }
        else
        {
            // btnPrimeiro.ImageUrl = "~/Library/Images/Botoes/pagenav_primeiro.gif";
            btnPrimeiro.Enabled = true;
            btnPrimeiro.CausesValidation = false;
        }

        #endregion primeiro

        #region anterior

        if (!anterior)
        {
            //btnAnterior.ImageUrl = "~/Library/Images/Botoes/pagenav_anterior_desabilitado.gif";
            btnAnterior.Enabled = false;
        }
        else
        {
            //btnAnterior.ImageUrl = "~/Library/Images/Botoes/pagenav_anterior.gif";
            btnAnterior.Enabled = true;
            btnAnterior.CausesValidation = false;
        }

        #endregion anterior

        #region proximo

        if (!proximo)
        {
            //btnProximo.ImageUrl = "~/Library/Images/Botoes/pagenav_proximo_desabilitado.gif";
            btnProximo.Enabled = false;
        }
        else
        {
            //btnProximo.ImageUrl = "~/Library/Images/Botoes/pagenav_proximo.gif";
            btnProximo.Enabled = true;
            btnProximo.CausesValidation = false;
        }

        #endregion proximo

        #region ultimo

        if (!ultimo)
        {
            //btnUltimo.ImageUrl = "~/Library/Images/Botoes/pagenav_ultimo_desabilitado.gif";
            btnUltimo.Enabled = false;
        }
        else
        {
            //btnUltimo.ImageUrl = "~/Library/Images/Botoes/pagenav_ultimo.gif";
            btnUltimo.Enabled = true;
            btnUltimo.CausesValidation = false;
        }

        #endregion ultimo

        #region drop

        if (!drop)
        {
            dropPage.Enabled = false;
        }
        else
        {
            dropPage.Enabled = true;
            dropPage.CausesValidation = false;
        }

        #endregion drop
    }

    #endregion Metodos

}
