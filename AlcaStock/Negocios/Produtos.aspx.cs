using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class CadastroProduto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Carregar opções de dropdowns, se necessário
        }
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        string codigo = txtCodigo.Text;
        string referencia = txtReferencia.Text;
        string descricao = txtDescricao.Text;
        string grupo = ddlGrupo.SelectedValue;
        string subGrupo = ddlSubGrupo.SelectedValue;
        string setor = ddlSetor.SelectedValue;
        string marca = txtMarca.Text;
        decimal valorCompra = Convert.ToDecimal(txtValorCompra.Text);
        decimal ipi = Convert.ToDecimal(txtIPI.Text);
        decimal icms = Convert.ToDecimal(txtICMS.Text);
        decimal frete = Convert.ToDecimal(txtFrete.Text);
        decimal seguro = Convert.ToDecimal(txtSeguro.Text);
        decimal desconto = Convert.ToDecimal(txtDesconto.Text);
        decimal margem = Convert.ToDecimal(txtMargem.Text);
        decimal precoVenda = Convert.ToDecimal(txtPrecoVenda.Text);
        int saldoEstoque = Convert.ToInt32(txtSaldoEstoque.Text);
        DateTime dataUltimaCompra = Convert.ToDateTime(txtDataUltimaCompra.Text);
        string fornecedor = txtFornecedor.Text;
        string unidadeMedida = txtUnidadeMedida.Text;
        string ncm = txtNCM.Text;
        string origemProduto = txtOrigemProduto.Text;

        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO PRODUTOS (Codigo, Referencia, Descricao, Grupo, SubGrupo, Setor, Marca, ValorCompra, IPI, ICMS, Frete, Seguro, Desconto, Margem, PrecoVenda, SaldoEstoque, DataUltimaCompra, Fornecedor, UnidadeMedida, NCM, OrigemProduto) " +
                           "VALUES (@Codigo, @Referencia, @Descricao, @Grupo, @SubGrupo, @Setor, @Marca, @ValorCompra, @IPI, @ICMS, @Frete, @Seguro, @Desconto, @Margem, @PrecoVenda, @SaldoEstoque, @DataUltimaCompra, @Fornecedor, @UnidadeMedida, @NCM, @OrigemProduto)";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Codigo", codigo);
            cmd.Parameters.AddWithValue("@Referencia", referencia);
            cmd.Parameters.AddWithValue("@Descricao", descricao);
            cmd.Parameters.AddWithValue("@Grupo", grupo);
            cmd.Parameters.AddWithValue("@SubGrupo", subGrupo);
            cmd.Parameters.AddWithValue("@Setor", setor);
            cmd.Parameters.AddWithValue("@Marca", marca);
            cmd.Parameters.AddWithValue("@ValorCompra", valorCompra);
            cmd.Parameters.AddWithValue("@IPI", ipi);
            cmd.Parameters.AddWithValue("@ICMS", icms);
            cmd.Parameters.AddWithValue("@Frete", frete);
            cmd.Parameters.AddWithValue("@Seguro", seguro);
            cmd.Parameters.AddWithValue("@Desconto", desconto);
            cmd.Parameters.AddWithValue("@Margem", margem);
            cmd.Parameters.AddWithValue("@PrecoVenda", precoVenda);
            cmd.Parameters.AddWithValue("@SaldoEstoque", saldoEstoque);
            cmd.Parameters.AddWithValue("@DataUltimaCompra", dataUltimaCompra);
            cmd.Parameters.AddWithValue("@Fornecedor", fornecedor);
            cmd.Parameters.AddWithValue("@UnidadeMedida", unidadeMedida);
            cmd.Parameters.AddWithValue("@NCM", ncm);
            cmd.Parameters.AddWithValue("@OrigemProduto", origemProduto);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
