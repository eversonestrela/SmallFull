<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Vendas.aspx.cs" Inherits="Vendas" MasterPageFile="/MasterPages/Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form2" runat="server">
<style>
    body {
        background-color: #f8f9fa;
    }

    .container {
        margin-top: 50px;
    }

    .header {
        margin-bottom: 20px;
    }

    .grid th, .grid td {
        text-align: center;
    }

    .totals {
        text-align: right;
        font-size: 18px;
    }

    .total {
        font-weight: bold;
        color: red;
    }

    .quantity {
        font-weight: bold;
        color: red;
        text-align: center;
    }
</style>
<script type="text/javascript">
    function PermiteSomenteNumeros(event) {
        var charCode = (event.which) ? event.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;
        return true;
    }
</script>
<script>
    $(document).ready(function () {
        $("#btnAdicionar").click(function (e) {
            var codigo = $("#<%= txtCodigo.ClientID %>").val();
                var quantidade = $("#<%= txtQuantidade.ClientID %>").val();
            });

            $("#txtCpfCnpj").on("change", function () {
                // Simulando uma chamada Ajax para atualizar a lista de clientes
                var cpfCnpj = $(this).val();
                if (cpfCnpj) {
                    $("#ddlClientes").html('<option>Cliente Encontrado</option>');
                } else {
                    $("#ddlClientes").html('<option>Cliente não encontrado</option>');
                }
            });
        });
</script>
        <div class="container">
            <h2 class="header text-center">Venda de Produtos</h2>
            <table style="text-align: left">
                <tr>
                    <td colspan="2" style="text-align-last: center;"><strong>Códigos:</strong></td>
                    <td>Gás: 4  - </td>
                    <td>Água: 5  </td>
                </tr>
            </table>
            <div class="form-group row">
                <div class="col-md-4">
                    <label>Cliente:</label>
                    <asp:TextBox ID="txtCpfCnpj" runat="server" CssClass="form-control" Placeholder="Digite o CPF/CNPJ" AutoPostBack="True" OnTextChanged="txtCpfCnpj_TextChanged"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label>Cliente Encontrado:</label>
                    <asp:DropDownList ID="ddlClientes" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Selecione um Cliente" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <label>Vendedores:</label>
                    <asp:DropDownList ID="ddlVendedores" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Selecione um Vendedor" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-md-4">
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" Placeholder="Código ou nome do produto:"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtQuantidade" runat="server" CssClass="form-control" Placeholder="Quantidade" onkeypress="return PermiteSomenteNumeros(event)"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Button ID="btnAdicionar" runat="server" CssClass="btn btn-success btn-block" Text="Adicionar Produto" OnClick="btnAdicionar_Click" />
                </div>
            </div>
            <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered grid" OnRowCommand="gvProducts_RowCommand" OnRowDeleting="gvProducts_RowDeleting">
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
                    <asp:BoundField DataField="QueroLucrar" HeaderText="Preço Unit." />
                    <asp:BoundField DataField="Total" HeaderText="Total" />
                </Columns>
            </asp:GridView>
            <div class="totals">
                <asp:Label ID="lblTotalBruto" runat="server" Text="Total Bruto: "></asp:Label><br />
                <asp:Label ID="lblDesconto" runat="server" Text="Desconto: "></asp:Label><br />
                <asp:Label ID="lblTotal" runat="server" Text="TOTAL: " CssClass="total"></asp:Label><br />
                <asp:Label ID="lblQuantidadeItens" runat="server" Text="Quantidade Itens: "></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Placeholder="Aplicar Desconto" onkeypress="return PermiteSomenteNumeros(event)"></asp:TextBox>
            </div>
        </div>
        <table style="width: 100%; text-align: center;">
            <tr>
                <td style="text-align: center;">
                    <asp:Button ID="btnConsultarVendas" runat="server" CssClass="btn btn-primary" Text="Consultar Vendas Realizadas" OnClick="btnConsultarVendas_Click" />
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Registrar Venda" OnClick="RegistrarVenda_Click" Style="margin: auto;" />
                </td>
            </tr>
        </table>
    </form>
    </asp:Content>

<%--<td align="center" background="../Library/Images/meio_580.gif">--%>

