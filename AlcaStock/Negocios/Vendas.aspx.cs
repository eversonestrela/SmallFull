using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Linq;
using System.Web.UI;
using Microsoft.Ajax.Utilities;
using System.Collections.Generic;

public partial class Vendas : System.Web.UI.Page
{
    private DataTable produtosVendidos;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            produtosVendidos = new DataTable();
            produtosVendidos.Columns.Add("Codigo");
            produtosVendidos.Columns.Add("Descricao");
            produtosVendidos.Columns.Add("Grade");
            produtosVendidos.Columns.Add("Quantidade");
            produtosVendidos.Columns.Add("Unidade");
            produtosVendidos.Columns.Add("PrecoUnitario");
            produtosVendidos.Columns.Add("Total");
            ViewState["ProdutosVendidos"] = produtosVendidos;

            CarregarVendedores();
        }
        else
        {
            produtosVendidos = (DataTable)ViewState["ProdutosVendidos"];
        }
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> GetProductSuggestions(string prefixText, int count)
    {
        List<string> suggestions = new List<string>();
        string query = "SELECT TOP " + count + " Descricao FROM PRODUTOS WHERE CODIGO LIKE '%" + prefixText + "%' OR DESCRICAO LIKE '%" + prefixText + "%'";

        DataTable dt = Utilitarios.Pesquisar(query);

        foreach (DataRow row in dt.Rows)
        {
            suggestions.Add(row["Descricao"].ToString());
        }

        return suggestions;
    }


    protected void btnAdicionar_Click(object sender, EventArgs e)
    {
        string codigo = txtCodigo.Text;
        int quantidade;
        bool sucesso = int.TryParse(txtQuantidade.Text, out quantidade);

        if (codigo.IsNullOrWhiteSpace())
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "RPT", "<script>alert('Informe o produto!');</script>", false);

        }
        else
        {
            if (sucesso)
            {
                AdicionarProduto(codigo, quantidade);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "RPT", "<script>alert('Informe a quantidade do produto');</script>", false);
            }
        }
    }

    private void AdicionarProduto(string codigo, int quantidade)
    {
        DataTable dt = Utilitarios.Pesquisar("SELECT * FROM PRODUTOS WHERE CODIGO LIKE '%" + codigo + "%' OR DESCRICAO LIKE '%" + codigo + "%'");

        if (dt.Rows.Count > 0)
        {
            string descricao = dt.Rows[0]["Descricao"].ToString();
            decimal precoUnitario = Convert.ToDecimal(dt.Rows[0]["PrecoUnitario"]);

            DataRow existingRow = produtosVendidos.Select("Codigo = '" + codigo + "'").FirstOrDefault();

            if (existingRow != null)
            {
                int novaQuantidade = Convert.ToInt32(existingRow["Quantidade"]) + quantidade;
                decimal novoTotal = novaQuantidade * precoUnitario;

                existingRow["Quantidade"] = novaQuantidade;
                existingRow["Total"] = novoTotal;
            }
            else
            {
                decimal total = quantidade * precoUnitario;

                DataRow row = produtosVendidos.NewRow();
                row["Codigo"] = codigo;
                row["Descricao"] = descricao;
                row["Grade"] = ""; // Adicione a lógica para obter o valor correto
                row["Quantidade"] = quantidade;
                row["Unidade"] = "UN"; // Altere conforme necessário
                row["PrecoUnitario"] = precoUnitario;
                row["Total"] = total;

                produtosVendidos.Rows.Add(row);
            }

            ViewState["ProdutosVendidos"] = produtosVendidos;
            gvProducts.DataSource = produtosVendidos;
            gvProducts.DataBind();

            CalcularTotais();
        }
    }

    private void CalcularTotais()
    {
        decimal totalBruto = 0;
        foreach (DataRow row in produtosVendidos.Rows)
        {
            totalBruto += Convert.ToDecimal(row["Total"]);
        }

        lblTotalBruto.Text = "Total Bruto: " + totalBruto.ToString("F2");
        lblDesconto.Text = "Desconto: 0,00%";
        lblTotal.Text = "TOTAL: " + totalBruto.ToString("F2");
        lblQuantidadeItens.Text = "Quantidade Itens: " + produtosVendidos.Rows.Count;
    }

    protected void gvProducts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            produtosVendidos.Rows[index].Delete();
            ViewState["ProdutosVendidos"] = produtosVendidos;

            gvProducts.DataSource = produtosVendidos;
            gvProducts.DataBind();

            CalcularTotais();
        }
    }


    protected void RegistrarVenda_Click(object sender, EventArgs e)
    {
        string Vendedor = ddlVendedores.SelectedValue;
        string Cliente = txtCpfCnpj.Text.Trim();
        DataTable dtClientes = Utilitarios.Pesquisar("SELECT Id, Nome FROM CLIENTES WHERE CPF_CNPJ = '" + Cliente + "'");
        string idCliente = dtClientes.Rows.Count > 0 ? dtClientes.Rows[0]["Id"].ToString() : "0";

        if (produtosVendidos.Rows.Count > 0)
        {
            foreach (DataRow row in produtosVendidos.Rows)
            {
                string CodigoProduto = row["Codigo"].ToString();
                string Quantidade = row["Quantidade"].ToString();
                string SQL = @"
            INSERT INTO HISTORICO_VENDAS(ID_VENDEDOR, ID_CLIENTE, ID_PRODUTO, QUANTIDADE, DATA_VENDA)
            VALUES(" + Vendedor + ", " + idCliente + "," + CodigoProduto + ", " + Quantidade + ", '" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "')";

                Utilitarios.Exec_StringSql(SQL);
            }

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "RPT", "<script>alert('Venda realizada com sucesso!');</script>", false);
            LimparCampos();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "RPT", "<script>alert('Nenhum produto adicionado à venda!');</script>", false);
        }
    }


    protected void gvProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Este método está presente apenas para evitar o erro "evento não tratado".
        // O código real de exclusão está no método gvProducts_RowCommand.
    }

    protected void txtCpfCnpj_TextChanged(object sender, EventArgs e)
    {
        string cpfCnpj = txtCpfCnpj.Text.Trim();
        DataTable dtClientes = Utilitarios.Pesquisar("SELECT Id, Nome FROM CLIENTES WHERE CPF_CNPJ = '" + cpfCnpj + "'");

        if (dtClientes.Rows.Count > 0)
        {
            ddlClientes.Items.Clear();
            ddlClientes.Items.Add(new ListItem(dtClientes.Rows[0]["Nome"].ToString(), dtClientes.Rows[0]["Id"].ToString()));
        }
        else
        {
            ddlClientes.Items.Clear();
            ddlClientes.Items.Add(new ListItem("Cliente não encontrado", ""));
        }
    }

    private void CarregarVendedores()
    {
        DataTable dtVendedores = Utilitarios.Pesquisar("SELECT Id, Nome FROM VENDEDORES");
        ddlVendedores.DataSource = dtVendedores;
        ddlVendedores.DataTextField = "Nome";
        ddlVendedores.DataValueField = "Id";
        ddlVendedores.DataBind();
    }

    private void LimparCampos()
    {
        txtCodigo.Text = string.Empty;
        txtQuantidade.Text = string.Empty;
        txtCpfCnpj.Text = string.Empty;
        ddlClientes.Items.Clear();
        gvProducts.DataSource = null;
        gvProducts.DataBind();

        // Reiniciar a variável de estado para uma nova DataTable
        produtosVendidos = new DataTable();
        produtosVendidos.Columns.Add("Codigo");
        produtosVendidos.Columns.Add("Descricao");
        produtosVendidos.Columns.Add("Grade");
        produtosVendidos.Columns.Add("Quantidade");
        produtosVendidos.Columns.Add("Unidade");
        produtosVendidos.Columns.Add("PrecoUnitario");
        produtosVendidos.Columns.Add("Total");
        ViewState["ProdutosVendidos"] = produtosVendidos;

        // Atualizar os totais para refletir os campos limpos
        CalcularTotais();
    }
    protected void btnConsultarVendas_Click(object sender, EventArgs e)
    {
        Response.Redirect("VendasRealizadas.aspx");
    }


}
