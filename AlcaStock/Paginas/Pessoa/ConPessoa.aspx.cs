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
            PessoaController pessoaController = new PessoaController();
            List<PessoaModel> pessoas = pessoaController.ConsultarPessoas();

            gvPessoas.DataSource = pessoas;
            gvPessoas.DataBind();
        }
    }

    protected void btnNovo_Click(object sender, EventArgs e)
    {
        Response.Redirect("CadPessoa?ACAO=Novo");
    }

    protected void gvPessoas_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.CssClass = "gridview-header";
        }
    }

    protected void gvPessoas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.CssClass = "data-row";
        }
    }
}