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

    protected void ddlPSQ_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPSQ.SelectedValue == "1")
        {
            txtPesquisa.Attributes.Add("oninput", "formatarCPF(this)");
            txtPesquisa.MaxLength = 11;
        }
        else
        {
            txtPesquisa.Attributes.Remove("oninput");
            txtPesquisa.MaxLength = int.MaxValue;
        }
    }
    #endregion Events

    #region Metodos
    private void Consultar(string tipoConsulta, string descricao)
    {
        PessoaController pessoaController = new PessoaController();
        List<PessoaModel> pessoas = pessoaController.ConsultarPessoas(tipoConsulta, descricao);

        if (pessoas == null || pessoas.Count == 0)
        {
            gvProdutos.Columns[0].Visible = false;
            gvProdutos.Columns[1].Visible = false;
            pessoas = new List<PessoaModel>
            {
                new PessoaModel { NOME = "Nenhum registro encontrado" }
            };
        }
        else
        {
            gvProdutos.Columns[0].Visible = true;
            gvProdutos.Columns[1].Visible = true;
        }

        gvProdutos.DataSource = pessoas;
        gvProdutos.DataBind();
    }
    #endregion Metodos

}