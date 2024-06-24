using System;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Net;
using System.Collections.Generic;

public partial class PageIndex : System.Web.UI.Page
{
   
        protected void Page_Load(object sender, EventArgs e)
        {

        BindServices();
     

    }


    private void BindServices()
    {
        var services = new List<object>
    {
        new { Nome = "Apenas Corte", Preco = "R$69,99", Descricao = "Corte ilimitado ao mês\nElegante e brilhante" },
        new { Nome = "Corte e Barba", Preco = "R$169,99", Descricao = "Corte e secador de cabelo\nElegante e brilhante\nShampoo e conjunto com corte de cabelo\nTratamento capilar\nMarca facial\nCor dimensional com corte de cabelo." },
        new { Nome = "OURO", Preco = "R$99,99", Descricao = "Corte e secador de cabelo\nElegante e brilhante\nShampoo e conjunto com corte de cabelo\nTratamento capilar" }
    };

        RepeaterServices.DataSource = services;
        RepeaterServices.DataBind();
    }
    protected void btnInicio_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/Index/Inicial.aspx"));
    }

    protected void btnAgendar_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/Agendamento/Agendar.aspx"));
    }
    protected void btnAssinar_Click(object sender, EventArgs e)
    {
        RepeaterServices.Visible = true;
       
    }

    protected void btnParametro_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/Cadastros/Pesquisa.aspx"));
    }


}
