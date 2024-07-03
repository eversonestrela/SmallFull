using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class PesqClientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregarPessoas();
            CarregarVendedores();
        }
    }

    private void CarregarPessoas()
    {
        string query = @"SELECT TOP 10 ROW_NUMBER() OVER(ORDER BY NOME)  AS N, * FROM PESSOAS ";
        DataTable dt = Utilitarios.Pesquisar(query);
        gvVendasRealizadas.DataSource = dt;
        gvVendasRealizadas.DataBind();
    }

    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        string termoConsulta = txtConsulta.Text.Trim();
        string query = @"
        SELECT TOP 10 ROW_NUMBER() OVER(ORDER BY NOME)  AS N, * FROM PESSOAS";


        DataTable dt = Utilitarios.Pesquisar(query);
        gvVendasRealizadas.DataSource = dt;
        gvVendasRealizadas.DataBind();

    }
    protected void ExportarExcel_Click(object sender, EventArgs e)
    {
        string query = @"
        SELECT * FROM PESSOAS";


        DataTable dt = Utilitarios.Pesquisar(query);

        if (gvVendasRealizadas.Rows.Count > 0)
        {
            DataTable Excel = dt;
            Utilitarios.geraExcel(Excel, "Vendas", "##RETORNO");
        }
    }
    protected void RegistrarPessoas_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Cadastros/Clientes.aspx");
    }

    private void CarregarVendedores()
    {
        //DataTable dtPessoas = Utilitarios.Pesquisar("SELECT TOP 10 * FROM PESSOAS");
        //ddlVendedores.DataSource = dtPessoas;
        //ddlVendedores.DataTextField = "NOME";
        //ddlVendedores.DataValueField = "PESSOA_ID";
        //ddlVendedores.DataBind();
    }

}


