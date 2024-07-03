<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Calculo.aspx.cs" Inherits="Funcionarios" MasterPageFile="~/Masterpages/Site.master" %>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc3" %>
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Cadastro de Funcionários</title>
        <style>
            .container {
                    display: flex;
                justify-content: center;
                align-items: center;
                flex-direction: column;
                min-height: 70vh; /* Ajustado para 90vh */
                text-align: center;
                margin-top: -100px; 
            }
            fieldset {
                width: 100%;
                max-width: 800px;
                margin: auto;
            }
        </style>
    </head>
    <body>
        <form id="form1" runat="server">
            <div class="container">
                <div id="TabelaPrecos" class="tabcontent">
                    <fieldset>
                        <legend class="rotulo"><b>Calcular Salário Liquido:</b></legend>
                        <br />
                        <table>
                            <tr>
                                <td>
                                    <label for="txtSalarioBruto">Salário Bruto</label>
                                </td>
                                <td>
                                    <label for="txtQTDE">Quantidade de Dependentes:</label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="CalculoSimplificado" runat="server" Text="Calculo Simplificado de IRRF?" Checked="true" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtSalarioBruto" runat="server" MaxLength="200" onkeyup="formatValueNumber(this,'###.###.###.##0,0000', event);nextFocus(this,18,event);"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQTDE" runat="server" Width="90%" onkeypress="return isNumberKey(event)" nfocus="this.select();"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <label for="txtValor">Outros descontos (Sem incidências de IRRF ou INSS)</label>
                                </td>
                            </tr>
                            <td>
                                <asp:TextBox ID="txtValor" runat="server" Width="100%" onkeyup="formatValueNumber(this,'###.###.###.##0,0000', event);nextFocus(this,18,event);"></asp:TextBox>
                            </td>
                            <tr>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="Button1" runat="server" Text="Calcular" Style="cursor: pointer;" OnClick="btnCalcular_Click" />
                                </td>
                            </tr>
                        </table>
                        <div id="RetornoValores">
                            <table>
                                <tr>
                                    <td style="padding-right: 1px;">
                                        <label for="lblSalarioBruto"><b>Salário Bruto:</b></label>
                                        <asp:Label ID="lblSalarioBruto" runat="server"></asp:Label><br />
                                    </td>
                                    <td></td>
                                    <td style="padding-left: 60px;">
                                        <label for="lblLiquido"><b>Salário Líquido:</b></label>
                                        <asp:Label ID="lblLiquido" runat="server"></asp:Label><br />
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td><b>Descontos:</b></td>
                                </tr>
                                <tr>
                                    <td>
                                        <label for="lblINSS">INSS:</label>
                                        <asp:Label ID="lblINSS" runat="server"></asp:Label><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label for="lblIRRF">IRRF:</label>
                                        <asp:Label ID="lblIRRF" runat="server"></asp:Label><br />
                                    </td>
                                </tr>
                                <div>
                                    <br />
                                    <br />
                                </div>
                                <tr>
                                    <td>
                                        <label for="lblBaseCalculoINSS"><b>Base de Cálculo INSS:</b></label>
                                        <asp:Label ID="lblBaseCalculoINSS" runat="server"></asp:Label><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label for="lblBaseCalculoIRRF"><b>Base de Cálculo IRRF:</b></label>
                                        <asp:Label ID="lblBaseCalculoIRRF" runat="server"></asp:Label><br />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </fieldset>
                    <asp:Repeater runat="server">
                    </asp:Repeater>
                </div>
            </div>
        </form>
    </body>
    </html>
</asp:Content>
