using System;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Net;
using System.Data;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Funcionarios : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
   

        if (!IsPostBack)
        {
            CarregaDados();

        }

    

    }


    protected void btnAgendar_Click(object sender, EventArgs e)
    {


    }

    protected void GetPesquisaNome(object sender, EventArgs e)
    {
        if (txtValorDigitado.Text != "")
        {

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "MSG", "<script type=\"text/javascript\">alert('Digite um valor para pesquisa';</script>", false);
        }

    }

    protected void SetBuscaNome(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/Agendamento/Agendar.aspx"));
    }


    protected void btnParametro_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/Cadastros/Pesquisa.aspx"));
    }


    protected void GetNovoCadastro_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/Cadastros/Clientes.aspx"));
    }

    protected void CarregaDados()
    {

        DataTable dt =  Utilitarios.Pesquisar("SELECT * FROM PRECOS");
   
    }

    protected void btnInicio_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/Index/Inicial.aspx"));
    }
    protected void GetPesquisaNome_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/Index/Inicial.aspx"));
    }


    protected void rptValores_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {

            SetEditMode(e.Item, true);
        
        }
        else if (e.CommandName == "Cancel")
        {
            SetEditMode(e.Item, false);
        }
        else if (e.CommandName == "Update")
        {
            int itemId = Convert.ToInt32(e.CommandArgument);
            string nomeProduto = ((TextBox)e.Item.FindControl("txtNomeProduto")).Text;
            string descricaoProduto = ((TextBox)e.Item.FindControl("txtDescricaoProduto")).Text;
            string valorProduto = ((TextBox)e.Item.FindControl("txtValorProduto")).Text;

            Utilitarios.Exec_ProcSql("UPDATE PRECOS SET NOME_PRODUTO =" + nomeProduto + ", DESCRICAO_PRODUTO =" + descricaoProduto + ", VALOR_PRODUTO =" + valorProduto + " WHERE ITEM_ID = "+ itemId);
            
        }
        
    }

    private void SetEditMode(RepeaterItem item, bool isEdit)
    {
        ((TextBox)item.FindControl("txtNomeProduto")).Enabled = isEdit;
        ((TextBox)item.FindControl("txtDescricaoProduto")).Enabled = isEdit;
        ((TextBox)item.FindControl("txtValorProduto")).Enabled = isEdit;
        item.FindControl("imgbtnDelete").Visible = !isEdit;
        item.FindControl("btnUpdate").Visible = isEdit;
        item.FindControl("btnCancel").Visible = isEdit;
  
    }

protected void btnCadastrar_Click(object sender, EventArgs e)
    {
   
        

        // Coletar dados do formulário
    
   


    }


}
