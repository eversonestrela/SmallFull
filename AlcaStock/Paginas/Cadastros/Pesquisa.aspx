<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pesquisa.aspx.cs" Inherits="Funcionarios" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc3" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro de Funcionários</title>
    <style>
        .tab {
            overflow: hidden;
            border: 1px solid #ccc;
            background-color: #f1f1f1;
        }

            .tab button {
                background-color: inherit;
                float: left;
                border: none;
                outline: none;
                cursor: pointer;
                padding: 14px 16px;
                transition: 0.3s;
            }

                .tab button:hover {
                    background-color: #ddd;
                }

                .tab button.active {
                    background-color: #ccc;
                }

        .tabcontent {
            display: none;
            padding: 6px 12px;
            border: 1px solid #ccc;
            border-top: none;
        }

            .tabcontent.show {
                display: block;
            }
    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
    <script>
        function openTab(evt, tabName) {
            var i, tabcontent, tablinks;

            tabcontent = document.getElementsByClassName("tabcontent");
            for (i = 0; i < tabcontent.length; i++) {
                tabcontent[i].style.display = "none";
            }

            tablinks = document.getElementsByClassName("tablinks");
            for (i = 0; i < tablinks.length; i++) {
                tablinks[i].className = tablinks[i].className.replace(" active", "");
            }

            document.getElementById(tabName).style.display = "block";
            evt.currentTarget.className += " active";
        }

        $(document).ready(function () {
            document.getElementById("defaultOpen").click();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div id="menu" style="text-align: center;">
            <asp:Button ID="Inicio" runat="server" Text="Página Inicial" Style="background-color: black; color: #fff; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;" OnClick="btnInicio_Click" />
            <asp:Button ID="Agendar" runat="server" Text="Agende AQUI!" Style="background-color: black; color: #fff; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;" OnClick="btnAgendar_Click" />
            <asp:Button ID="Contato" runat="server" Text="Fale Conosco" Style="background-color: black; color: #fff; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;" />
            <asp:Button ID="Cadastro" runat="server" Text="Cadastros" Style="background-color: black; color: #fff; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;" OnClick="btnParametro_Click" />
        </div>

        <div class="tab">
            <button class="tablinks" onclick="openTab(event, 'NovoCadastro')" id="defaultOpen" type="button">Cadastro Clientes</button>
            <button class="tablinks" onclick="openTab(event, 'TabelaPrecos')" type="button">Tabela de Preços</button>
            <button class="tablinks" onclick="openTab(event, 'PesquisaNome')" type="button">Definir</button>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="NovoCadastro" class="tabcontent">

                    <fieldset>
                        <legend class="rotulo"><b>Cadastro de Clientes:</b></legend>
                        <br />
                        <table>
                            <tr>

                                <tr>
                                    <td>
                                        <label for="txtNome">Nome</label></td>
                                    <td>
                                        <label for="txtCPF">CPF</label></td>
                                    <td>
                                        <label for="txtCPF">Celular </label>
                                    </td>
                                </tr>
                                <td>
                                    <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCPF" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCelular" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <tr>
                                    <td>
                                        <label for="txtCidade">Telefone </label>
                                    </td>
                                    <td>
                                        <label for="txtTelefone">E-mail</label>
                                    </td>
                                    <td>
                                        <label for="txtEmail">Cidade </label>
                                    </td>
                                </tr>
                                <td>
                                    <asp:TextBox ID="txtCidade" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTelefone" runat="server"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table style="float: right">
                            <tr>
                                <td>
                                    <label for="fuFoto">Foto:  </label>
                                    <asp:FileUpload ID="fuFoto" runat="server" Style="cursor: pointer;" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" Style="cursor: pointer;" OnClick="btnCadastrar_Click" />
                                </tr>
                            </tr>
                        </table>
                    </fieldset>
                </div>
                <div id="TabelaPrecos" class="tabcontent">
                    <fieldset>
                        <legend class="rotulo"><b>Tabela de preços - Valores Cadastrados:</b></legend>
                        <br />
                        <table>
                            <tr>

                                <tr>
                                    <td>
                                        <label for="txtNomeProduto">Nome do Produto</label></td>
                                    <td>
                                         <label for="txtValor">Valor do Produto</label>                                     
                                    <td>
                                       <label for="txtQTDE">Quantidade</label></td>
                                    </td>
                                </tr>
                                <td>
                                    <asp:TextBox ID="txtNomeProduto" runat="server" MaxLength="200"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtValor" runat="server" onkeyup="formatValueNumber(this,'###.###.###.##0,0000', event);nextFocus(this,18,event);" ></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQTDE" runat="server" Width="50%" onkeypress="return isNumberKey(event)" nfocus="this.select();" ></asp:TextBox>
                                </td>
                            </tr>                         
                        </table>                  
                        <table>
                            <tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" Text="Alterar" Style="cursor: pointer;" OnClick="btnCadastrar_Click" />
                                </tr>
                            </tr>
                        </table>
                    </fieldset>


                    <asp:Repeater runat="server">
                     

                    </asp:Repeater>
                </div>
                <div id="PesquisaNome" class="tabcontent">
                    <h3>Definire</h3>
                    <asp:TextBox ID="txtValorDigitado" runat="server" placeholder="Digite o nome desejado"></asp:TextBox>
                    <asp:Button runat="server" CssClass="btn btn-outline-success" Text="Pesquisar" OnClick="GetPesquisaNome_Click" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
