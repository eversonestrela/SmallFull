using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Pessoa_CadPessoa : AppBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPages_Cadastro)Master).Titulo = "Cadastro de Pessoas";

        if (!IsPostBack)
        {
            txt_PESSOAS_CPF_CNPJ.CssClass = "CPF";
            Utilitarios.AtribuirFuncoesJava(this);
        }
    }

    protected void rdbl_TIPO_CPF_CNPJ_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbl_TIPO_CPF_CNPJ.SelectedIndex == 0)
        {
            txt_PESSOAS_CPF_CNPJ.CssClass = "CPF";
            txt_PESSOAS_CPF_CNPJ.ValueField = "CPF";
        }
        else
        {
            txt_PESSOAS_CPF_CNPJ.CssClass = "CNPJ";
            txt_PESSOAS_CPF_CNPJ.ValueField = "CNPJ";
        }

        Utilitarios.AtribuirFuncoesJava(this);
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Pessoa/ConPessoa");
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {

    }
}