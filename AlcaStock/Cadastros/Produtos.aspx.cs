using Microsoft.Ajax.Utilities;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;

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
        string nulo = "null";
        string datetime = DateTime.Now.ToString("dd-MM-yyyy");
        string codigo = txtCodigo.Text;
        string nome = txtNome.Text;
        string descricao = txtDescricao.Text;
        decimal valorcompra = string.IsNullOrWhiteSpace(txtValorCompra.Text) ? Convert.ToDecimal(nulo) : Convert.ToDecimal(txtValorCompra.Text, new CultureInfo("pt-BR"));
        decimal margemlucro = string.IsNullOrEmpty(txtMargem.Text) ? Convert.ToDecimal(nulo) : Convert.ToDecimal(txtMargem.Text, new CultureInfo("pt-BR"));
        decimal precovenda = Convert.ToDecimal(txtPrecoVenda.Text, new CultureInfo("pt-BR"));
        string dataCadastro = string.IsNullOrEmpty(txtDataAtualizacao.Text) ? Convert.ToString(datetime) : Convert.ToString(txtDataAtualizacao.Text);
        string dataAtualizacao = string.IsNullOrEmpty(txtDataAtualizacao.Text) ? Convert.ToString(datetime) : Convert.ToString(txtDataAtualizacao.Text);
        string status = string.IsNullOrEmpty(ddlStatus.Text) ? Convert.ToString(nulo) : Convert.ToString(ddlStatus.Text);

        DataTable existe = Utilitarios.Pesquisar("SELECT COUNT(*) AS QTDE FROM PRODUTOS WHERE CODIGO =" + codigo);

        if (existe.Rows.Count >= 0)
        {
            if (existe.Rows[0]["QTDE"].ToString() != "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "RPT", "<script>alert('Codigo já utilizado por outro produto!');</script>", false);
            }

            else
            {
                string query = @"INSERT INTO PRODUTOS      (Codigo,
                                                    Nome,
                                                    Descricao,
                                                    PrecoUnitario,
                                                    QueroLucrar,
                                                    DataCadastro,
                                                    DataAtualizacao,
                                                    Status) " +
                               "VALUES ('" + codigo + "', '" + nome + "','" + descricao + "' ,'" + valorcompra.ToString(CultureInfo.InvariantCulture) + "' , '" + precovenda.ToString(CultureInfo.InvariantCulture) + "', " + dataCadastro + " , " + dataAtualizacao + ", '" + status + "')";

                Utilitarios.Exec_StringSql(query);

                //SqlConnection conn = Utilitarios.GetOpenConnection();
                //SqlCommand cmd = new SqlCommand(query, conn);
                //cmd.Parameters.AddWithValue("@codigo", codigo);
                //cmd.Parameters.AddWithValue("@nome", nome);
                //cmd.Parameters.AddWithValue("@tipo", tipo);
                //cmd.Parameters.AddWithValue("@valorcompra", valorcompra);
                //cmd.Parameters.AddWithValue("@margemlucro", margemlucro);
                //cmd.Parameters.AddWithValue("@precovenda", precovenda);
                //cmd.Parameters.AddWithValue("@dataCadastro", dataCadastro);
                //cmd.Parameters.AddWithValue("@dataAtualizacao", dataAtualizacao);
                //cmd.Parameters.AddWithValue("@status", status);

                //int rowsAffected = cmd.ExecuteNonQuery();

                //if (rowsAffected > 0)
                //{
                //    // Inserção bem-sucedida
                //    ScriptManager.RegisterClientScriptBlock(this, GetType(), "RPT", "<script>alert('Produto cadastrado com sucesso!');</script>", false);

                //    // Limpar campos após inserção

                //}
                //else
                //{
                //    
                //    ScriptManager.RegisterClientScriptBlock(this, GetType(), "RPT", "<script>alert('Falha ao cadastrar produto.');</script>", false);
                //}


                //cmd.ExecuteNonQuery();
                //Utilitarios.CloseConnection(conn);
                //cmd.Dispose();

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "RPT", "<script>alert('Produto Cadastrado!');</script>", false);
            }
        }
    }
}
