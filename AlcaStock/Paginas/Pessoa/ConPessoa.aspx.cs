using Alcastock.Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class Paginas_Pessoa_ConPessoa : AppBasePage
{
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPages_Consulta)Master).Titulo = "Consulta de Pessoas";
        txtPesquisa.Focus();

        if (!IsPostBack)
        {
            Consultar("", "");
        }
    }

    protected void btnNovo_Click(object sender, EventArgs e)
    {
        Response.Redirect("CadPessoa?ACAO=Novo");
    }

    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        string tipoConsulta = ddlPSQ.SelectedValue;
        string descricao = txtPesquisa.Text.Trim();
        Consultar(tipoConsulta, descricao);
    }

    protected void gvPessoas_ItemCreated(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            e.Item.CssClass = "gridview-header";
        }
    }

    protected void gvPessoas_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            e.Item.CssClass = "data-row";
        }
    }

    protected void gvPessoas_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "editar")
        {
            Response.Redirect("CadPessoa?acao=Editar&id=" + e.Item.Cells[2].Text);
        }
        else if (e.CommandName == "excluir")
        {
            Response.Redirect("CadPessoa?acao=Excluir&id=" + e.Item.Cells[2].Text);
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
            gvPessoas.Columns[0].Visible = false;
            gvPessoas.Columns[1].Visible = false;
            pessoas = new List<PessoaModel>
            {
                new PessoaModel { NOME = "Nenhum registro encontrado" }
            };
        }
        else
        {
            gvPessoas.Columns[0].Visible = true;
            gvPessoas.Columns[1].Visible = true;
        }

        gvPessoas.DataSource = pessoas;
        gvPessoas.DataBind();
    }
    #endregion Metodos
}