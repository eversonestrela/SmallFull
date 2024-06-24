<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Clientes.aspx.cs" Inherits="Funcionarios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc3" %>

<!DOCTYPE html>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js"></script>

<script>
    $(document).ready(function () {
        $('#<%= txtCelular.ClientID %>').mask('(00) 00000-0000');
});
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro de Funcionários</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="menu" style="text-align: center;">

            <asp:Button ID="Inicio" runat="server" Text="Página Inicial" Style="background-color: black; color: #fff; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;" OnClick="btnInicio_Click" />
            <asp:Button ID="Agendar" runat="server" Text="Agende AQUI!" Style="background-color: black; color: #fff; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;" OnClick="btnAgendar_Click" />
            <asp:Button ID="Contato" runat="server" Text="Fale Conosco" Style="background-color: black; color: #fff; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;" />
            <asp:Button ID="Cadastro" runat="server" Text="Cadastros" Style="background-color: black; color: #fff; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;" OnClick="btnParametro_Click" />

        </div>

        <br />
        <br />
        <br />
        <br />
        <br />
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
                        <asp:TextBox ID="txtNome" runat="server" ></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCPF" runat="server" ></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCelular" runat="server" ></asp:TextBox>
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
                        <asp:TextBox ID="txtCidade" runat="server" ></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelefone" runat="server" ></asp:TextBox>
                    </td>

                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>

            </table>

            <table style="float: right">

                <tr>
                    <td>
                        <label  for="fuFoto">Foto:  </label>
                        <asp:FileUpload ID="fuFoto" runat="server" style="cursor:pointer;" />                
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                <tr>
                    <td>
                    <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" style="cursor:pointer;" OnClick="btnCadastrar_Click" />
        </tr>
                    </tr>
                </table>
                </fieldset>

    </form>
</body>
</html>
