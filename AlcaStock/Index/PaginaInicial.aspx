<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaginaInicial.aspx.cs" Inherits="PaginaInicial" MasterPageFile="/MasterPages/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="container">
            <div class="logo">
                <i class="fas fa-gas-pump logo-icon"></i>
                <span class="logo-text">GIL GAS</span>
            </div>

            <!-- Jumbotron -->
            <header class="jumbotron" style="background-color: #5bc24f;">
                <div class="container text-center" >
                    <h1 class="display-6">Distribuidora Gil Gás!</h1>
                    <p class="lead">Fornecendo Gás e Água com Qualidade e Segurança</p>
                </div>
            </header>
            <!-- Seção de Produtos -->
            <div class="container">
                <div class="row justify-content-center">
                    <!-- Adicionando justify-content-center para centralizar -->
                    <!-- Produto 1 -->
                    <div class="col-lg-4 col-md-6 product-card">
                        <div class="card h-100">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <!-- Container flexível para alinhar os elementos verticalmente -->
                                    <table>
                                        <tr>
                                            <td>
                                                <img src="../Library/Images/gas.gif" width="60px" />
                                                <!-- mr-2 para adicionar margem à direita -->
                                                <img src="../Library/Images/gasazul.gif" width="46px" />
                                                <!-- ml-2 para adicionar margem à esquerda -->
                                            </td>
                                        </tr>
                                    </table>

                                </div>
                                <h4 class="card-title">Gás</h4>
                                <p class="card-text">Copagaz e Ultragaz.</p>
                            </div>
                        </div>
                    </div>
                    <!-- Produto 2 -->
                    <div class="col-lg-4 col-md-6 product-card">
                        <div class="card h-100">
                            <img src="../Library/Images/agua2.gif" width="60px" align="middle" border="0" />
                            <div class="card-body">
                                <h4 class="card-title">Água</h4>
                                <p class="card-text">Águas Lebrinha, Puríssima, Jaciára e Canindé.</p>
                            </div>
                        </div>
                    </div>
                    <!-- Produto 3 -->
                    <!-- Se precisar adicionar o terceiro produto, descomente este bloco -->
                    <!--<div class="col-lg-4 col-md-6 product-card">
            <div class="card h-100">
                <img class="card-img-top" src="outro_produto_image_url" alt="Outro Produto">
                <div class="card-body">
                    <h4 class="card-title">Outro Produto</h4>
                    <p class="card-text">Descrição de outro produto.</p>
                </div>
            </div>
        </div>-->
                    <%--          </div>
                <div class="row justify-content-center">
                    <div class="col-lg-4 col-md-6">
                        <asp:Button ID="btnAdicionar" runat="server" Width="90px" CssClass="btn btn-success btn-block" Text="Peça" />
                    </div>
                </div>
            </div>--%>
                    <!-- Rodapé -->
            
                </div>
    </form>
</asp:Content>
