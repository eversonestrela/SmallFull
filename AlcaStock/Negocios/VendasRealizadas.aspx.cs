using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class VendasRealizadas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           CarregarVendas();
           CarregarVendedores();
        }
    }

    private void CarregarVendas()
    {
        string query = @"SELECT HV.ID_VENDA, V.NOME, P.DESCRICAO, C.NOME, HV.QUANTIDADE, CONVERT(VARCHAR(10),HV.DATA_VENDA,103) AS DATA_VENDA
        FROM HISTORICO_VENDAS HV
        LEFT JOIN VENDEDORES V ON HV.ID_VENDEDOR = V.ID
        LEFT JOIN PRODUTOS P ON P.CODIGO = HV.ID_PRODUTO
        LEFT JOIN CLIENTES C ON C.ID = HV.ID_CLIENTE
        WHERE V.ID = 
        ";
        DataTable dt = Utilitarios.Pesquisar(query);
        gvVendasRealizadas.DataSource = dt;
        gvVendasRealizadas.DataBind();
    }

    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        string termoConsulta = txtConsulta.Text.Trim();
        string query = @"
        SELECT HV.ID_VENDA, V.NOME, P.DESCRICAO, C.NOME, HV.QUANTIDADE, CONVERT(VARCHAR(10),HV.DATA_VENDA,103) AS DATA_VENDA
        FROM HISTORICO_VENDAS HV
        LEFT JOIN VENDEDORES V ON HV.ID_VENDEDOR = V.ID
        LEFT JOIN PRODUTOS P ON P.CODIGO = HV.ID_PRODUTO
        LEFT JOIN CLIENTES C ON C.ID = HV.ID_CLIENTE";
         

        DataTable dt = Utilitarios.Pesquisar(query);
        gvVendasRealizadas.DataSource = dt;
        gvVendasRealizadas.DataBind();

    }
    protected void ExportarExcel_Click(object sender, EventArgs e)
    {
        string query = @"
        SELECT HV.ID_VENDA, V.NOME, P.DESCRICAO, C.NOME, HV.QUANTIDADE, CONVERT(VARCHAR(10),HV.DATA_VENDA,103) AS DATA_VENDA
        FROM HISTORICO_VENDAS HV
        LEFT JOIN VENDEDORES V ON HV.ID_VENDEDOR = V.ID
        LEFT JOIN PRODUTOS P ON P.CODIGO = HV.ID_PRODUTO
        LEFT JOIN CLIENTES C ON C.ID = HV.ID_CLIENTE";


        DataTable dt = Utilitarios.Pesquisar(query);

        if (gvVendasRealizadas.Rows.Count > 0)
        {
            DataTable Excel = dt;
            Utilitarios.geraExcel(Excel, "Vendas", "##RETORNO");
        }
    }
    protected void RegistrarVenda_Click(object sender, EventArgs e)
    {
        Response.Redirect("Vendas.aspx");
    }

    private void CarregarVendedores()
    {
        DataTable dtVendedores = Utilitarios.Pesquisar("SELECT Id, Nome FROM VENDEDORES");
        ddlVendedores.DataSource = dtVendedores;
        ddlVendedores.DataTextField = "Nome";
        ddlVendedores.DataValueField = "Id";
        ddlVendedores.DataBind();
    }

}


