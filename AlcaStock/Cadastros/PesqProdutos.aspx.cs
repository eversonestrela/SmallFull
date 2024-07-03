using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class PesqClientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregarProdutos();
          
        }
    }

    private void CarregarProdutos()
    {
        string query = @"SELECT TOP 10 ROW_NUMBER() OVER(ORDER BY NOME) AS N , * FROM PRODUTOS ";
        DataTable dt = Utilitarios.Pesquisar(query);
        gvVendasRealizadas.DataSource = dt;
        gvVendasRealizadas.DataBind();
    }

    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        string termoConsulta = txtConsulta.Text.Trim();
        string query = @"
        SELECT TOP 10 ROW_NUMBER() OVER(ORDER BY NOME) AS N , * FROM PRODUTOS";


        DataTable dt = Utilitarios.Pesquisar(query);
        gvVendasRealizadas.DataSource = dt;
        gvVendasRealizadas.DataBind();

    }
    protected void ExportarExcel_Click(object sender, EventArgs e)
    {
        string query = @"
        SELECT * FROM PRODUTOS";


        DataTable dt = Utilitarios.Pesquisar(query);

        if (gvVendasRealizadas.Rows.Count > 0)
        {
            DataTable Excel = dt;
            Utilitarios.geraExcel(Excel, "Vendas", "##RETORNO");
        }
    }
    protected void RegistrarProdutos_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Cadastros/Produtos.aspx");
    }

    private void CarregarVendedores()
    {
        //DataTable dtPessoas = Utilitarios.Pesquisar("SELECT * FROM PRODUTOS");
        //ddlVendedores.DataSource = dtPessoas;
        //ddlVendedores.DataTextField = "Descricao";
        //ddlVendedores.DataValueField = "Codigo";
        //ddlVendedores.DataBind();
    }

}


