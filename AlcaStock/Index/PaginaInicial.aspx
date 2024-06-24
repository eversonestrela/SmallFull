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
                <h1 class="display-4">Bem-vindo à nossa Distribuidora</h1>
                <p class="lead">Fornecendo Gás e Água com Qualidade e Segurança</p>
            </div>
        </header>

        <!-- Seção de Produtos -->
        <div class="container">
            <div class="row">
                <!-- Produto 1 -->
                <div class="col-lg-4 col-md-6 product-card">
                    <div class="card h-100">
                        <img class="card-img-top" src="gas_image_url" alt="Gás">
                        <div class="card-body">
                            <h4 class="card-title">Gás</h4>
                            <p class="card-text">Descrição do produto de gás.</p>
                        </div>
                    </div>
                </div>
                <!-- Produto 2 -->
                <div class="col-lg-4 col-md-6 product-card">
                    <div class="card h-100">
                        <img class="card-img-top" src="agua_image_url" alt="Água">
                        <div class="card-body">
                            <h4 class="card-title">Água</h4>
                            <p class="card-text">Descrição do produto de água.</p>
                        </div>
                    </div>
                </div>
                <!-- Produto 3 -->
                <div class="col-lg-4 col-md-6 product-card">
                    <div class="card h-100">
                        <img class="card-img-top" src="outro_produto_image_url" alt="Outro Produto">
                        <div class="card-body">
                            <h4 class="card-title">Outro Produto</h4>
                            <p class="card-text">Descrição de outro produto.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Rodapé -->
        <footer class="text-center">
            <div class="container">
                <p>&copy; 2024 Distribuidora de Gás e Água. Todos os direitos reservados.</p>
                <p>Telefone: (11) 1234-5678 | Endereço: Rua Exemplo, 123 - Cidade, Estado</p>
            </div>
        </footer>
    </div>
</asp:Content>
