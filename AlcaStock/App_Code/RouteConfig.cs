using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace AlcaStock
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);

            // Adicionar rotas personalizadas
            routes.MapPageRoute("Inicio", "Inicio", "~/Inicial.aspx");
            routes.MapPageRoute("ConPessoaRoute", "Pessoa/ConPessoa", "~/Paginas/Pessoa/ConPessoa.aspx");
            routes.MapPageRoute("CadPessoaRoute", "Pessoa/CadPessoa", "~/Paginas/Pessoa/CadPessoa.aspx");
            routes.MapPageRoute("ConProdutoRoute", "Produto/ConProduto", "~/Paginas/Produto/ConProduto.aspx");
            routes.MapPageRoute("CadProdutoRoute", "Produto/CadProduto", "~/Paginas/Produto/CadProduto.aspx");
        }
    }
}