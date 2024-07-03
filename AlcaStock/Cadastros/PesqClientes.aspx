<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PesqClientes.aspx.cs" Inherits="PesqClientes" MasterPageFile="/MasterPages/Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <h2 class="header text-center">Cadastro e Consulta de Pessoas</h2>
            <br />
            <div class="form-group row">
                <table>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="IDConsulta" Text="Consulta:"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div class="col-md-4">
                    <asp:TextBox ID="txtConsulta" runat="server" CssClass="form-control" Placeholder="Consultar informa��es:"></asp:TextBox>
                </div>
                <div class="col-md-4">

                    <asp:Button ID="btnConsultar" runat="server" CssClass="btn btn-primary" Text="Consultar" OnClick="btnConsultar_Click" />
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Cadastrar Nova Pessoa" OnClick="RegistrarPessoas_Click" Style="margin: auto;" />
                </div>
                <table style="width: 100%; text-align: center;">
                    <tr>
                        <td style="text-align: ri;"></td>
                    </tr>
                </table>
            </div>
            <table style="width: 100%; text-align: center;">
                <tr>
                    <td>
                        <label>Filtre por Produto:</label>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Selecione um produto" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <label>Filtre por Cliente:</label>
                        <asp:DropDownList ID="ddlClientes" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Selecione um Cliente" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <label>Filtre por vendedor:</label>
                        <asp:DropDownList ID="ddlVendedores" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Selecione um Vendedor" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:LinkButton ID="ImageButtonHover1" runat="server" CausesValidation="false" OnClick="ExportarExcel_Click"
                            CssClass="rotulo btnProc" Text="<img src='../Library/Images/icones/excel.gif' width=14 height=14> Exportar Excel"
                            ToolTip="Exportar Excel" />
                    </td>
                </tr>

            </table>
            <table>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
            </table>
            <asp:GridView ID="gvVendasRealizadas" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                <Columns>
                    <asp:BoundField DataField="N" HeaderText="" />
                    <asp:BoundField DataField="NOME" HeaderText="Nome:" />
                    <asp:BoundField DataField="CPF" HeaderText="CPF" />
                    <asp:BoundField DataField="DATA_NASC" HeaderText="Data de Nascimento" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</asp:Content>
