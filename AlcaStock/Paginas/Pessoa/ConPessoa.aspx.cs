using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Pessoa_ConPessoa : AppBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPages_Consulta)Master).Titulo = "Consulta de Pessoas";
        txtPesquisa.Focus();

        if (!IsPostBack)
        {

        }
    }

    protected void ddlPSQ_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtPesquisa.Text = string.Empty;

        switch (ddlPSQ.SelectedValue)
        {
            case "1":
                txtPeriodoInicial.Visible = txtPeriodoFinal.Visible = false;
                txtPesquisa.Visible = true;
                mskCPF.Enabled = false;
                txtPesquisa.CssClass = "CPF";
                Utilitarios.AtribuirFuncoesJava(this);
                break;

            case "4":
                txtPeriodoInicial.Visible = txtPeriodoFinal.Visible = true;
                txtPesquisa.Visible = false;
                mskCPF.Enabled = false;
                break;

            default:
                txtPeriodoInicial.Visible = txtPeriodoFinal.Visible = false;
                txtPesquisa.Visible = true;
                mskCPF.Enabled = false;


                txtPesquisa.CssClass = "caixaTexto";
                Utilitarios.RemoverAtributo(txtPesquisa, "onkeydown");
                Utilitarios.RemoverAtributo(txtPesquisa, "onblur");
                Utilitarios.RemoverAtributo(txtPesquisa, "MaxLength");
                break;
        }
    }

    protected void btnNovo_Click(object sender, EventArgs e)
    {
        Response.Redirect("CadPessoa?ACAO=Novo");
    }
}