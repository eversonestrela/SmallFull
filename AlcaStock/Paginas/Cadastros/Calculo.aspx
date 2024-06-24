<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Calculo.aspx.cs" Inherits="Funcionarios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc3" %>

<!DOCTYPE html>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js"></script>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro de Funcion�rios</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="menu" style="text-align: center;">

            <asp:Button ID="Inicio" runat="server" Text="P�gina Inicial" Style="background-color: black; color: #fff; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;" OnClick="btnInicio_Click" />
            <asp:Button ID="Agendar" runat="server" Text="Agende AQUI!" Style="background-color: black; color: #fff; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;" OnClick="btnAgendar_Click" />
            <asp:Button ID="Contato" runat="server" Text="Fale Conosco" Style="background-color: black; color: #fff; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;" />
            <asp:Button ID="Cadastro" runat="server" Text="Cadastros" Style="background-color: black; color: #fff; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;" OnClick="btnParametro_Click" />

        </div>

        <br />
        <div id="TabelaPrecos" class="tabcontent">
            <fieldset>
                <legend class="rotulo"><b>Calcular Sal�rio Liquido:</b></legend>
                <br />
                <table>
                    <tr>
                        <td>
                            <label for="txtSalarioBruto">Sal�rio Bruto</label>
                        </td>
                        <td>
                            <label for="txtQTDE">Quantidade de Dependentes:</label></td>
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
                            <label for="txtValor">Outros descontos (Sem incid�ncias de IRRF ou INSS)</label>
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
                                <label for="lblSalarioBruto"><b>Sal�rio Bruto:</b></label>
                                <asp:Label ID="lblSalarioBruto" runat="server"></asp:Label><br />
                            </td>
                            <td></td>
                            <td style="padding-left: 60px;">
                                <label for="lblLiquido"><b>Sal�rio L�quido:</b></label>
                                <asp:Label ID="lblLiquido" runat="server"></asp:Label><br />
                            </td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td> <b>Descontos:</b></td>
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
                      <div> <br /> <br /></div>                   
                      <tr>
                            <td>
                                <label for="lblBaseCalculoINSS"><b>Base de C�lculo INSS:</b></label>
                                <asp:Label ID="lblBaseCalculoINSS" runat="server"></asp:Label><br />
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <label for="lblBaseCalculoIRRF"><b>Base de C�lculo IRRF:</b></label>
                                <asp:Label ID="lblBaseCalculoIRRF" runat="server"></asp:Label><br />
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
            <asp:Repeater runat="server">
            </asp:Repeater>
        </div>

    </form>
</body>
</html>