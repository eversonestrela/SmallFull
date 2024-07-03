using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web.UI;

public partial class Clientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Cidades();
        }
    }

    protected void Cidades()
    {
        DataTable dt = Utilitarios.Pesquisar("SELECT * FROM UF");
        DataTable dt2 = Utilitarios.Pesquisar("SELECT * FROM CIDADES");
        Utilitarios.AtualizaDropDown(ddlUF, dt, "Sigla", "Sigla");
        Utilitarios.AtualizaDropDown(ddlCidade, dt2, "Nome", "UFID");
    }
    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        string CPF = txtCPF.Text;
        string Nome = txtNome.Text;
        string DataNasc = txtDataNasc.Text;
        string Rua = txtEndRua.Text;
        string NumeroCasa = txtEndNumero.Text;
        string Bairro = txtEndBairro.Text;
        string UF = ddlUF.SelectedValue;
        string Cidade = ddlCidade.SelectedValue;
        string Status = ddlStatus.SelectedValue;

        string query = @" SET DATEFORMAT DMY INSERT INTO PESSOAS
            (
            NOME,
            DATA_NASC,
            CPF,
            EndRua,
            EndNumero,
            EndBairro,
            UF,
            Cidade,
            Status
            )
            VALUES
            ('" + Nome + "', '" + DataNasc + "', '" + CPF + "', '" + Rua + "',  '" + NumeroCasa + "', '" + Bairro + "', '" + UF + "', '" + Cidade + "', '" + Status + "')";

        Utilitarios.Exec_StringSql(query);
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "RPT", "<script>alert('Pessoa Cadastrada com Sucesso!');</script>", false);
        LimpaCampos();
    }


    protected void LimpaCampos()
    {
        txtCPF.Text = string.Empty;
        txtNome.Text = string.Empty;
        txtDataNasc.Text = string.Empty;
        txtEndRua.Text = string.Empty;
        txtEndNumero.Text = string.Empty;
        txtEndBairro.Text = string.Empty;
        ddlUF.SelectedIndex = 0; 
        ddlCidade.SelectedIndex = 0; 
        ddlStatus.SelectedIndex = 0; 
    }

}
