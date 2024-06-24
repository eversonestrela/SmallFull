<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Produtos.aspx.cs" Inherits="Vendas" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Venda de Produtos</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f9;
        }
        .container {
            max-width: 1200px;
            margin: 50px auto;
            padding: 20px;
            background-color: #fff;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
        }
        .header {
            font-weight: bold;
            font-size: 24px;
            margin-bottom: 20px;
            text-align: center;
            color: #333;
        }
        .form-group {
            display: flex;
            justify-content: space-between;
            margin-bottom: 20px;
        }
        .form-group input {
            width: 45%;
            padding: 10px;
            font-size: 16px;
            border: 1px solid #ddd;
            border-radius: 5px;
        }
        .form-group button {
            width: 10%;
            padding: 10px;
            background-color: #28a745;
            color: #fff;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
        }
        .form-group button:hover {
            background-color: #218838;
        }
        .grid {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }
        .grid th, .grid td {
            padding: 10px;
            border: 1px solid #ddd;
            text-align: center;
        }
        .grid th {
            background-color: #f8f9fa;
        }
        .totals {
            text-align: right;
            font-size: 20px;
            margin-bottom: 20px;
        }
        .totals .total {
            font-weight: bold;
            color: red;
        }
        .quantity {
            font-weight: bold;
            color: red;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2 class="header">Venda de Produtos</h2>
            <div class="form-group">
                <asp:TextBox ID="txtCpfCnpj" runat="server" Placeholder="Digite o CPF/CNPJ" AutoPostBack="True" OnTextChanged="txtCpfCnpj_TextChanged"></asp:TextBox>
                <asp:DropDownList ID="ddlClientes" runat="server" Width="45%">
                    <asp:ListItem Text="Selecione um Cliente" Value=""></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlVendedores" runat="server" Width="45%">
                    <asp:ListItem Text="Selecione um Vendedor" Value=""></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtCodigo" runat="server" Placeholder="Código ou nome do produto:"></asp:TextBox>
                <asp:TextBox ID="txtQuantidade" runat="server" Placeholder="Quantidade"></asp:TextBox>
                <asp:Button ID="btnAdicionar" runat="server" Cursor="point" Text="Adicionar Produto" OnClick="btnAdicionar_Click" />
            </div>

            <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" CssClass="grid" OnRowCommand="gvProducts_RowCommand" OnRowDeleting="gvProducts_RowDeleting">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/Library/Images/icones/delete.gif" CommandName="Delete" CommandArgument='<%# Container.DataItemIndex %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Codigo" HeaderText="Código" />
                    <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                    <asp:BoundField DataField="Grade" HeaderText="Grade" />
                    <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" />
                    <asp:BoundField DataField="Unidade" HeaderText="UN" />
                    <asp:BoundField DataField="PrecoUnitario" HeaderText="Preço Unit." />
                    <asp:BoundField DataField="Total" HeaderText="Total" />
                </Columns>
            </asp:GridView>

            <div class="totals">
                <asp:Label ID="lblTotalBruto" runat="server" Text="Total Bruto: "></asp:Label>
                <asp:Label ID="lblDesconto" runat="server" Text="Desconto: "></asp:Label>
                <asp:Label ID="lblTotal" runat="server" Text="TOTAL: " CssClass="total"></asp:Label>
            </div>

            <div class="quantity">
                <asp:Label ID="lblQuantidadeItens" runat="server" Text="Quantidade Itens: "></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>