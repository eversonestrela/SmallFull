using System;


    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Aqui pode ser colocado código adicional de inicialização da página
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Aqui você colocaria a lógica para autenticar o usuário
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            // Exemplo simples de autenticação: comparando usuário e senha
            if (usuario == "admin" && senha == "12345")
            {
                Response.Redirect("~/Index/PaginaInicial.aspx"); // Redireciona para a página de dashboard após login
            }
            else
            {
                // Exemplo simples de exibição de mensagem de erro
                Response.Write("<script>alert('Usuário ou senha inválidos');</script>");
            }
        }
    }

