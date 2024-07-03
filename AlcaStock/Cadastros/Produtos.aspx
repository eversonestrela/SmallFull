<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Produtos.aspx.cs" Inherits="CadastroProduto" MasterPageFile="~/MasterPages/Site.master" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <title>Cadastro de Produto</title>
    <style>
        body {
            background-color: #f8f9fa;
        }

        .container {
            margin-top: 50px;
        }

        .form-group {
            margin-bottom: 1rem;
        }
    </style>

    <body>

        <form id="form1" runat="server">
            <div class="container">
                <h2 class="header text-center">Cadastro de Produto</h2>
                <br />
                <br />
                <br />
                <div class="form-row">
                    <div class="form-group col-md-4">
                        <label for="txtCodigo">Código</label>
                        <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="txtNome">Nome</label>
                        <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="txtDescricao">Descrição</label>
                        <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <%--           <div class="form-row">
                <div class="form-group col-md-4">
                    <label for="ddlGrupo">Grupo</label>
                    <asp:DropDownList ID="ddlGrupo" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Grupo 1" Value="Grupo1"></asp:ListItem>
                        <asp:ListItem Text="Grupo 2" Value="Grupo2"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group col-md-4">
                    <label for="txtMarca">Marca</label>
                    <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-4">
                    <label for="txtUnidadeMedida">Unid. Medida</label>
                    <asp:TextBox ID="txtUnidadeMedida" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>--%>
                <div class="form-row">
                    <div class="form-group col-md-4">
                        <label for="txtValorCompra">Custo (R$)</label>
                        <asp:TextBox ID="txtValorCompra" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="txtMargem">Quero Lucrar (R$)</label>
                        <asp:TextBox ID="txtMargem" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="txtPrecoVenda">Preço Venda (R$)</label>
                        <asp:TextBox ID="txtPrecoVenda" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-4">
                        <label for="txtDataCadastro">Data Cadastro</label>
                        <asp:TextBox ID="txtDataCadastro" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="txtDataAtualizacao">Data Atualização</label>
                        <asp:TextBox ID="txtDataAtualizacao" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="ddlStatus">Status</label>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                            <asp:ListItem Text="ATIVO" Value="ATIVO"></asp:ListItem>
                            <asp:ListItem Text="INATIVO" Value="INATIVO"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group text-right">
                    <asp:Button ID="btnSalvar" runat="server" CssClass="btn btn-primary" Text="Salvar" OnClick="btnSalvar_Click" />
                </div>
            </div>
        </form>
    </body>
    </html>
</asp:Content>
