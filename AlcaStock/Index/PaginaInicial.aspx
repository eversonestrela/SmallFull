<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaginaInicial.aspx.cs" Inherits="PaginaInicial" MasterPageFile="~/MasterPages/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="logo">
            <i class="fas fa-gas-pump logo-icon"></i>
            <span class="logo-text">GIL GAS</span>
        </div>

        <!-- Jumbotron -->
        <header class="jumbotron">
            <div class="container text-center">
                <h1 class="display-4">Bem-vindo � nossa Distribuidora</h1>
                <p class="lead">Fornecendo G�s e �gua com Qualidade e Seguran�a</p>
            </div>
        </header>

        <!-- Se��o de Produtos -->
        <div class="container">
            <div class="row">
                <!-- Produto 1 -->
                <div class="col-lg-4 col-md-6 product-card">
                    <div class="card h-100">
                        <img class="card-img-top" src="gas_image_url" alt="G�s">
                        <div class="card-body">
                            <h4 class="card-title">G�s</h4>
                            <p class="card-text">Descri��o do produto de g�s.</p>
                        </div>
                    </div>
                </div>
                <!-- Produto 2 -->
                <div class="col-lg-4 col-md-6 product-card">
                    <div class="card h-100">
                        <img class="card-img-top" src="agua_image_url" alt="�gua">
                        <div class="card-body">
                            <h4 class="card-title">�gua</h4>
                            <p class="card-text">Descri��o do produto de �gua.</p>
                        </div>
                    </div>
                </div>
                <!-- Produto 3 -->
                <div class="col-lg-4 col-md-6 product-card">
                    <div class="card h-100">
                        <img class="card-img-top" src="outro_produto_image_url" alt="Outro Produto">
                        <div class="card-body">
                            <h4 class="card-title">Outro Produto</h4>
                            <p class="card-text">Descri��o de outro produto.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Rodap� -->
        <footer class="text-center">
            <div class="container">
                <p>&copy; 2024 Distribuidora de G�s e �gua. Todos os direitos reservados.</p>
                <p>Telefone: (11) 1234-5678 | Endere�o: Rua Exemplo, 123 - Cidade, Estado</p>
            </div>
        </footer>
    </div>
</asp:Content>
