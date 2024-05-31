using Alcastock.Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class Paginas_Pessoa_ConPessoa : AppBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPages_Consulta)Master).Titulo = "Consulta de Pessoas";
        txtPesquisa.Focus();

        if (!IsPostBack)
        {
            //Consultar("", "");
        }
    }

    protected void btnNovo_Click(object sender, EventArgs e)
    {
        Response.Redirect("CadPessoa?ACAO=Novo");
    }

    private void Consultar(string tipoConsulta, string descricao)
    {
        PessoaController pessoaController = new PessoaController();
        List<PessoaModel> pessoas = pessoaController.ConsultarPessoas(tipoConsulta, descricao);

        if (pessoas.Count == 0)
            pessoas = null;

        gvPessoas.DataSource = pessoas;
        gvPessoas.DataBind();
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
}