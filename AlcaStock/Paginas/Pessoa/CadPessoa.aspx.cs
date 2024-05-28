using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Alcastock.Controllers;
using System.Globalization;

public partial class Paginas_Pessoa_CadPessoa : AppBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPages_Cadastro)Master).Titulo = "Cadastro de Pessoas";

        if (!IsPostBack)
        {
            Utilitarios.AtribuirFuncoesJava(this);
        }
    }

    /// <summary>
    /// Ação do click de voltar
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Pessoa/ConPessoa");
    }

    /// <summary>
    /// Ação do botão de salvar
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        DateTime dataNasc;
        if (!DateTime.TryParseExact(txt_PESSOAS_DATA_NASC.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataNasc))
        {
            // Handle the error: invalid date format
            return;
        }

        PessoaModel pessoaModel = new PessoaModel
        {
            NOME = txt_PESSOAS_NOME.Text,
            CPF = txt_PESSOAS_CPF_CNPJ.Text,
            SEXO = ddl_PESSOAS_SEXO.SelectedValue,
            DATA_NASC = dataNasc,
            NOME_MAE = txt_PESSOAS_NOME_MAE.Text,
            CPF_MAE = txt_PESSOAS_CPF_MAE.Text,
            NOME_PAI = txt_PESSOAS_NOME_PAI.Text,
            CPF_PAI = txt_PESSOAS_CPF_PAI.Text,
            TELEFONE_RESIDENCIAL = txt_PESSOAS_TELEFONE_RESIDENCIAL.Text,
            TELEFONE_CELULAR = txt_PESSOAS_TELEFONE_CELULAR.Text,
            EMAIL = txt_PESSOAS_EMAIL.Text,
            SIS_USUARIO_INSERT = "Pedro Wenner",
            SIS_DATA_INSERT = DateTime.Now
        };
        
        PessoaController controller = new PessoaController();
        controller.SalvarPessoa(pessoaModel);

        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModalScript", "showModal();", true);
    }
}