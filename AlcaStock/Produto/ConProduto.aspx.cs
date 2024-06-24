using Alcastock.Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class Paginas_Pessoa_ConProduto : AppBasePage
{
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPages_Consulta)Master).Titulo = "Consulta de Produtos";
        txtPesquisa.Focus();

        if (!IsPostBack)
        {
            Consultar("", "");
        }
    }

    protected void btnNovo_Click(object sender, EventArgs e)
    {
        Response.Redirect("CadProduto?ACAO=Novo");
    }

    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        string tipoConsulta = ddlPSQ.SelectedValue;
        string descricao = txtPesquisa.Text.Trim();
        Consultar(tipoConsulta, descricao);
    }

    protected void gvProdutos_ItemCreated(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            e.Item.CssClass = "gridview-header";
        }
    }

    protected void gvProdutos_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            e.Item.CssClass = "data-row";
        }
    }

    protected void gvProdutos_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "editar")
        {
            Response.Redirect("CadProduto?acao=Editar&id=" + e.Item.Cells[2].Text);
        }
        else if (e.CommandName == "excluir")
        {
            Response.Redirect("CadProduto?acao=Excluir&id=" + e.Item.Cells[2].Text);
        }
    }

    #endregion Events

    #region Metodos
    private void Consultar(string tipoConsulta, string descricao)
    {
        ProdutoController produtoController = new ProdutoController();
        List<ProdutoModel> produtos = produtoController.ConsultarProdutos(tipoConsulta, descricao);

        if (produtos == null || produtos.Count == 0)
        {
            gvProdutos.Columns[0].Visible = false;
            gvProdutos.Columns[1].Visible = false;
            produtos = new List<ProdutoModel>
            {
                new ProdutoModel { CODIGO = "Nenhum registro encontrado" }
            };
        }
        else
        {
            gvProdutos.Columns[0].Visible = true;
            gvProdutos.Columns[1].Visible = true;
        }

        gvProdutos.DataSource = produtos;
        gvProdutos.DataBind();
    }
    #endregion Metodos

}