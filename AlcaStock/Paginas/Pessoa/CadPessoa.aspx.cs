using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Alcastock.Controllers;
using System.Globalization;
using Alcastock.Repositorios;
using AlcaStock.Attributes;

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
        string erro = ValidaCampos();

        if (string.IsNullOrWhiteSpace(erro))
        {
            string cpf = txt_PESSOAS_CPF_CNPJ.Text;

            PessoaRepositorio pessoaRepositorio = new PessoaRepositorio();
            if (pessoaRepositorio.CpfUnique(cpf))
            {
                divErros.Visible = true;
                lblErros.Text = "Este CPF já está cadastrado.";
                return;
            }

            PessoaModel pessoaModel = new PessoaModel
            {
                NOME = txt_PESSOAS_NOME.Text,
                CPF = txt_PESSOAS_CPF_CNPJ.Text,
                SEXO = ddl_PESSOAS_SEXO.SelectedValue,
                DATA_NASC = Convert.ToDateTime(txt_PESSOAS_DATA_NASC.Text),
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

            PessoaController p = new PessoaController();
            p.SalvarPessoa(pessoaModel);

            // Após o salvamento bem-sucedido, define um cookie para indicar que o modal deve ser exibido
            Response.Cookies["Sucesso"].Value = "true";
            Response.Cookies["MsgSucesso"].Value = "Pessoa adicionada com sucesso!";
            Response.Cookies["Sucesso"].Expires = DateTime.Now.AddSeconds(1); // Define o tempo de expiração do cookie
            Response.Cookies["MsgSucesso"].Expires = DateTime.Now.AddSeconds(1); // Define o tempo de expiração do cookie

            // Redireciona para a página de destino
            Response.Redirect("/Pessoa/ConPessoa");
        }
        else
        {
            divErros.Visible = true;
            lblErros.Text = erro;
        }
    }

    private string ValidaCampos()
    {
        string er = string.Empty;

        if (!CpfAttribute.IsValid(txt_PESSOAS_CPF_CNPJ.Text))
            er += "CPF inválido! </br>";
        if (string.IsNullOrWhiteSpace(txt_PESSOAS_NOME.Text))
            er += "Nome é de preenchimento obrigatório! </br>";
        if (string.IsNullOrWhiteSpace(txt_PESSOAS_DATA_NASC.Text))
            er += "Data de Nascimento não pode ser vazia! </br>";
        else if (!Utilitarios.VerificaDataValida(txt_PESSOAS_DATA_NASC.Text))
            er += "Data de Nascimento inválido! </br>";
        if (string.IsNullOrWhiteSpace(txt_PESSOAS_NOME_MAE.Text))
            er += "Nome da mãe é de preenchimento obrigatório! </br>";
        if (string.IsNullOrWhiteSpace(txt_PESSOAS_CPF_MAE.Text))
            er += "CPF da mãe inválido! </br>";
        if (!EmailAttribute.IsValidEmail(txt_PESSOAS_EMAIL.Text))
            er += "E-mail inválido! </br>";

        return er;
    }
}