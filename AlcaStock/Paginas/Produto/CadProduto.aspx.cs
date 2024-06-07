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

public partial class Paginas_Pessoa_CadProduto : AppBasePage
{
    #region Propiedades

    private string _ACAO = string.Empty;
    private string _ID = string.Empty;

    #endregion Propiedades

    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPages_Cadastro)Master).Titulo = "Cadastro de Produto";
        divErros.Visible = false;

        if (Request.QueryString["acao"] != null)
            _ACAO = Request.QueryString["acao"].ToString();
        if (Request.QueryString["id"] != null)
            _ID = Request.QueryString["id"].ToString();

        if (_ACAO == "Excluir")
        {
            ExcluirProduto();
        }

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
        Response.Redirect("../Produto/ConProduto");
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
            if (_ACAO == "Novo")
            {
                ProdutoController produtoController = new ProdutoController();

                ProdutoModel produto = new ProdutoModel
                {
                    CODIGO = txtCodigo.Text,
                    TIPO = ddlTipo.SelectedValue,
                    NOME = txtNome.Text,
                    GRUPO = ddlGrupo.SelectedValue,
                    MARCA = ddlMarca.SelectedValue,
                    UNIDADE_MEDIDA = txtUnidadeMedida.Text,
                    CUSTO = Utilitarios.FormataValorDecimal(txtCusto.Text),
                    LUCRO_ESPERADO = Utilitarios.FormataValorDecimal(txtLucroEsperado.Text),
                    PERC_LUCRO = Utilitarios.FormataValorDecimal(txtPercLucro.Text),
                    PRECO_VENDA = Utilitarios.FormataValorDecimal(txtPrecoVenda.Text)
                };

                Response.Cookies["MsgSucesso"].Value = "Produto adicionada com sucesso!";
            }
            else if (_ACAO == "Editar")
            {
                
                Response.Cookies["MsgSucesso"].Value = "Produto atualizada com sucesso!";
            }

            // Após o salvamento bem-sucedido, define um cookie para indicar que o modal deve ser exibido
            Response.Cookies["Sucesso"].Value = "true";
            Response.Cookies["Sucesso"].Expires = DateTime.Now.AddSeconds(1); // Define o tempo de expiração do cookie
            Response.Cookies["MsgSucesso"].Expires = DateTime.Now.AddSeconds(1); // Define o tempo de expiração do cookie

            // Redireciona para a página de destino
            Response.Redirect("/Pessoa/ConProduto");
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
                divErros.Visible = true;
                lblErros.Text = "Favor informar a imagem que será anexada.";
            }
        }
    }

    protected void btnDeletaFoto_Click(object sender, EventArgs e)
    {
        PessoaController pessoaController = new PessoaController();
        PessoaModel pessoa = ConsultaProduto();
        pessoaController.DeletarImagem(pessoa.PESSOA_ID);

        ConsultaFoto();
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
            btnSalvar.Text = "<i class='fas fa-save'></i> Atualizar";
            PreencheCampos();
        }
    }

    private string ValidaCampos()
    {
        string er = string.Empty;

        if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            er += "<li>Campo código não pode ser vazio!</li>";
        if (string.IsNullOrWhiteSpace(txtNome.Text))
            er += "<li>Campo nome não pode ser vazio!</li>";
        if (ddlGrupo.SelectedIndex == 0)
            er += "<li>Grupo deve ser preenchido</li>";
        if (ddlMarca.SelectedIndex == 0)
            er += "<li>Grupo deve ser preenchido</li>";
        if (string.IsNullOrWhiteSpace(txtCusto.Text))
            er += "<li>Custo deve ser preenchido!</li>";
        if (string.IsNullOrWhiteSpace(txtLucroEsperado.Text))
            er += "<li>Lucro esperado deve ser preenchido!</li>";
        if (string.IsNullOrWhiteSpace(txtEstoqueMinimo.Text))
            er += "<li>Estoque mínimo deve ser preenchido!</li>";

        return er;
    }

    private void PreencheCampos()
    {
        PessoaController pessoaController = new PessoaController();
        PessoaModel pessoa = ConsultaProduto();

        if (pessoa != null)
        {

            ConsultaFoto();
        }
    }

    private PessoaModel ConsultaProduto()
    {
        PessoaController pessoaController = new PessoaController();
        List<PessoaModel> pessoas = pessoaController.ConsultarPessoaPorId(_ID);

        PessoaModel pessoa = pessoas[0];
        return pessoa;
    }

    private void ConsultaFoto()
    {
        PessoaController pessoaController = new PessoaController();
        PessoaModel pessoa = ConsultaProduto();
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

    private void ExcluirProduto()
    {
        PessoaController p = new PessoaController();

        p.ExcluirPessoa(int.Parse(_ID));
        Response.Cookies["Sucesso"].Value = "true";
        Response.Cookies["Sucesso"].Expires = DateTime.Now.AddSeconds(1); // Define o tempo de expiração do cookie
        Response.Cookies["MsgSucesso"].Value = "Pessoa deletada com sucesso!";
        Response.Cookies["MsgSucesso"].Expires = DateTime.Now.AddSeconds(1); // Define o tempo de expiração do cookie

        // Redireciona para a página de destino
        Response.Redirect("/Pessoa/ConPessoa");
    }

    #endregion Metodos

}