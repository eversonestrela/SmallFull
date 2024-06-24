using System;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Net;

public partial class Funcionarios : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {



    }


    protected void btnAgendar_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/Agendamento/Agendar.aspx"));
    }

    protected void btnParametro_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/Cadastros/Pesquisa.aspx"));
    }


    protected void btnInicio_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/Index/Inicial.aspx"));
    }



    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        string caminhoArquivo = null;
        if (fuFoto.HasFile)
        {
            try
            {
                // Obtém o nome do arquivo e salva-o no servidor
                string nomeArquivo = Path.GetFileName(fuFoto.FileName);
                 caminhoArquivo = Server.MapPath("~/Imagens/") + nomeArquivo;
                fuFoto.SaveAs(caminhoArquivo);

                // Aqui você pode inserir os dados do funcionário no banco de dados, incluindo o caminho da foto
                // Exemplo: Utilitarios.InserirFuncionario(nome, cpf, cidade, telefone, celular, email, caminhoArquivo);

                // Exibe uma mensagem de sucesso
                Response.Write("Funcionário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                // Em caso de erro ao salvar a foto, exibe uma mensagem de erro
                Response.Write("Erro ao salvar a foto: " + ex.Message);
            }
        }

        // Coletar dados do formulário
        string nome = txtNome.Text;
        string cpf = txtCPF.Text;
        string celular = txtCelular.Text;
        string cidade = txtCidade.Text;
        string telefone = txtTelefone.Text;
        string email = txtEmail.Text;
        string SQL = string.Empty;
        // Inserir no banco de dados
        try
        {
     
        }
        catch (Exception ex)
        {
            Response.Write("Erro ao inserir os dados do cliente: " + ex.Message);
        }


    }


}
