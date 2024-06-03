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
using System.Xml.Linq;
using System.IO;

public partial class Paginas_Pessoa_CadPessoa : AppBasePage
{
    #region Propiedades

    private string _ACAO = string.Empty;
    private string _ID = string.Empty;

    #endregion Propiedades

    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPages_Cadastro)Master).Titulo = "Cadastro de Pessoas";

        if (Request.QueryString["acao"] != null)
            _ACAO = Request.QueryString["acao"].ToString();
        if (Request.QueryString["id"] != null)
            _ID = Request.QueryString["id"].ToString();

        if (!IsPostBack)
        {
            ConfiguraTela();
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

    protected void btnInsereFoto_Click(object sender, EventArgs e)
    {
        if (_ACAO == "Editar")
        {
            if (fuFoto.HasFile)
            {
                if (fuFoto.FileName != string.Empty)
                {
                    // Obtem a extenção do arquivo
                    string extensao = Path.GetExtension(fuFoto.PostedFile.FileName).ToLower();

                    string tipoArquivo = null;
                    // Efetua a validação do arquivo
                    switch (extensao)
                    {
                        case ".gif":
                            tipoArquivo = "image/gif";
                            break;

                        case ".jpg":
                        case ".jpeg":
                            tipoArquivo = "image/jpeg";
                            break;

                        default:
                            ScriptManager.RegisterClientScriptBlock(this, GetType(), "msg", "<script>alert('Erro - tipo de arquivo inválido!');</script>", false);
                            return;
                    }

                    byte[] dados = new byte[fuFoto.PostedFile.InputStream.Length + 1];
                    fuFoto.PostedFile.InputStream.Read(dados, 0, dados.Length);

                    ArquivoPessoaModel arquivoPessoa = new ArquivoPessoaModel
                    {
                        PESSOA_ID = int.Parse(_ID),
                        NAME = fuFoto.PostedFile.FileName,
                        DATA = DateTime.Now,
                        MIME = fuFoto.PostedFile.ContentType,
                        DADOS = dados
                    };

                    SalvaFoto(arquivoPessoa);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "MSG", "<script>alert('Favor informar a imagem que será anexada.');</script>", false);
            }
        }
    }

    #region Metodos
    private void ConfiguraTela()
    {
        if (_ACAO == "Editar")
        {
            trImagem.Visible = true;
            tdImagem.Visible = true;
            arquivosTab.Visible = true;
            arquivos.Visible = true;
            PreencheCampos();
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

    private void PreencheCampos()
    {
        PessoaController pessoaController = new PessoaController();
        PessoaModel pessoa = ConsultaPessoa();

        if (pessoa != null)
        {
            txt_PESSOAS_CPF_CNPJ.Text = pessoa.CPF;
            txt_PESSOAS_NOME.Text = pessoa.NOME;
            ddl_PESSOAS_SEXO.SelectedValue = pessoa.SEXO;
            txt_PESSOAS_DATA_NASC.Text = Convert.ToDateTime(pessoa.DATA_NASC.ToString()).ToString("dd/MM/yyyy");
            txt_PESSOAS_NOME_MAE.Text = pessoa.NOME_MAE;
            txt_PESSOAS_CPF_MAE.Text = pessoa.CPF_MAE;
            txt_PESSOAS_NOME_PAI.Text = pessoa.NOME_PAI;
            txt_PESSOAS_CPF_PAI.Text = pessoa.CPF_PAI;
            txt_PESSOAS_TELEFONE_RESIDENCIAL.Text = pessoa.TELEFONE_RESIDENCIAL;
            txt_PESSOAS_TELEFONE_CELULAR.Text = pessoa.TELEFONE_CELULAR;
            txt_PESSOAS_EMAIL.Text = pessoa.EMAIL;

            ConsultaFoto();
        }
    }

    private PessoaModel ConsultaPessoa()
    {
        PessoaController pessoaController = new PessoaController();
        List<PessoaModel> pessoas = pessoaController.ConsultarPessoaPorId(_ID);

        PessoaModel pessoa = pessoas[0];
        return pessoa;
    }

    private void ConsultaFoto()
    {
        PessoaController pessoaController = new PessoaController();
        PessoaModel pessoa = ConsultaPessoa();
        List<ArquivoPessoaModel> arquivoPessoa = pessoaController.ConsultarArquivoPessoasPorId(pessoa.PESSOA_ID);

        if (arquivoPessoa.Count > 0)
        {
            imageFoto.Visible = true;
            imageFoto.ImageUrl = "MostraImagem.aspx?id=" + pessoa.PESSOA_ID;
            btnDeletaFoto.Visible = true;
        }
        else
        {
            imageFoto.Visible = false;
            btnDeletaFoto.Visible = false;
        }
    }
    
    /// <summary>
    /// Método responsável para upload da foto da pessoa
    /// </summary>
    /// <param name="PESSOA_ID">PESSOA_ID, chave primaria da pessoa cadastrada</param>
    private void SalvaFoto(ArquivoPessoaModel arquivoPessoa)
    {
        PessoaController pessoaController = new PessoaController();
        pessoaController.DeletarImagem(arquivoPessoa.PESSOA_ID);
        pessoaController.SalvarImagem(arquivoPessoa);

        ConsultaFoto();
    }

    #endregion Metodos

    protected void btnDeletaFoto_Click(object sender, EventArgs e)
    {
        PessoaController pessoaController = new PessoaController();
        PessoaModel pessoa = ConsultaPessoa();
        pessoaController.DeletarImagem(pessoa.PESSOA_ID);

        ConsultaFoto();
    }
}