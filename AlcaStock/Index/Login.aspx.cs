using System;


    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Aqui pode ser colocado c�digo adicional de inicializa��o da p�gina
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Aqui voc� colocaria a l�gica para autenticar o usu�rio
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            // Exemplo simples de autentica��o: comparando usu�rio e senha
            if (usuario == "admin" && senha == "12345")
            {
                Response.Redirect("~/Index/PaginaInicial.aspx"); // Redireciona para a p�gina de dashboard ap�s login
            }
            else
            {
                // Exemplo simples de exibi��o de mensagem de erro
                Response.Write("<script>alert('Usu�rio ou senha inv�lidos');</script>");
            }
        }
    }

