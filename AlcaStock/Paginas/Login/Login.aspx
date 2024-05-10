<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>ALCASTOCK - Sistema de Estoque</title>
        <link href="../../Library/Estilos/estilo_padrao.css" rel="stylesheet" type="text/css" />
        <style type="text/css">
            .topo1 {
                background-image: url(../../Library/Images/monitor.gif);
            }

            .topo2 {
                background-image: url(../../Library/Images/cadeado.gif);
            }

            #divLogin {
                background-color: lightblue;
            }
        </style>
        <script src="../../Library/JQuery/jquery-1.6.2.min.js" type="text/javascript"></script>
        <script src="https://www.google.com/recaptcha/api.js?render=6LdpEHsoAAAAADJOQ1NtaHj-9GK0y0vzfW3qpgb2" type="text/javascript"></script>
        <script type="text/javascript">

            grecaptcha.ready(function () {
                grecaptcha.execute('6LdpEHsoAAAAADJOQ1NtaHj-9GK0y0vzfW3qpgb2', { action: 'submit' }).then(function (token) {
                    document.getElementById('<%= recaptchaResponse.ClientID %>').value = token;
                });
            });

            function AutenticarTecnico() {
                var id = $("#<%=txtUSER.ClientID%>").val();
                var id_oculto = $("#<%=LabelLogin.ClientID%>").text();

                if (id === undefined)
                    id = id_oculto.substring(0, id_oculto.length - 2);

                if (id % 1 === 0) {

                    var protocolo = 'http';
                    if (location.protocol.indexOf("https") > -1)
                        protocolo = 'https';

                    $.ajax({
                        type: "GET",
                        contentType: "application/json; charset=utf-8",
                        url: protocolo + "://www.agendaextranet.com.br/novaextranet_ws/WebService.asmx/getPermiteTrabalhoClienteHash?id=" + id,
                        data: {},
                        dataType: "json",
                        success: function (data) {
                            if (data.d != '')
                                $("#<%=btnLogin.ClientID%>").click();
                            else {
                                alert("Horário não permitido. Favor entre em contato com seu coordenador para habilitar o seu acesso!");
                                return false;
                            }
                        },
                        error: function (result) {
                            alert("Erro ao logar no sistema, tente novamente!");
                            return false;
                        }
                    });
                }
                else {
                    $("#<%=btnLogin.ClientID%>").click();
                }

        </script>
    </head>
    <body>
        <form id="form1" runat="server" defaultbutton="btnLogin">
            <asp:ScriptManager ID="scripmanager" runat="server" EnablePartialRendering="true" EnableScriptGlobalization="true"></asp:ScriptManager>
            <div id="loginNew" runat="server">
                <asp:TextBox Style="display: none" ID="hddResolucao" runat="server" />
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; vertical-align: middle; text-align: center;">
                    <tr>
                        <td>
                            <table align="center" border="0">
                                <tr>
                                    <td colspan="3">
                                        <div id="divLogin" style="width: 300px; height: 200px">
                                            <table border="0" cellpadding="2" cellspacing="2" align="center" style="font-family: Tahoma; font-size: 14px;">
                                                <tr>
                                                    <td align="left">
                                                        <label>Login:</label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:TextBox Style="font-family: Tahoma; font-size: 15px; border: 1px solid #D6D6D6; color: #999999"
                                                            ID="txtUSER" runat="server" TabIndex="1" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUSER"
                                                            Display="None" ErrorMessage="Informe o usu&aacute;rio!" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                        <asp:Label ID="LabelLogin" runat="server" Visible="False" Font-Bold="True" Font-Size="Large"
                                                            ForeColor="#000066"></asp:Label>
                                                        <asp:LinkButton ID="LimparCookieLogin" Font-Size="Large" runat="server" Visible="False"
                                                            CausesValidation="false" OnClick="LimparCookieLogin_Click" TabIndex="5" Text=" trocar login!"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <label>Senha:</label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:TextBox Style="font-family: Tahoma; font-size: 15px; border: 1px solid #D6D6D6; color: #999999"
                                                            ID="txtPassWord" runat="server" TextMode="Password" TabIndex="2" /> 
                                                        <asp:HiddenField runat="server" ID="hddDigital" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassWord"
                                                            Display="None" ErrorMessage="Informe a senha!" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <img src="../../Library/Images/btnAcessar.png" onclick="return AutenticarTecnico();" style="cursor: pointer;" alt="" />
                                                        <asp:ImageButton ID="btnLogin" runat="server" OnClick="btnLogin_Click" ImageUrl="~/Library/Images/btnAcessar.png"
                                                            Style="display: none;" TabIndex="3" />
                                                        <asp:Button ID="btnLoginDigital" runat="server" OnClick="btnLogin_Click" Style="display: none"
                                                            CausesValidation="false" />
                                                        <asp:HiddenField ID="recaptchaResponse" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            &nbsp;&nbsp;
            <div style="position: fixed; bottom: 0px; width: 100%; height: 25px; z-index: -50" id="sisrodape">
                <table width="100%" height="100%" style="border-top: 1px solid #CCCCCC; padding-left: 10px;" border="0"
                    align="center" cellpadding="0" cellspacing="0" class="texto_login">
                    <tr>
                        <td valign="middle">Sistema desenvolvido por Alcatech. Todos os Direitos Reservados. 2024
                        </td>
                        <%--<td align="right">
                            <a href="http://www.agendaassessoria.com.br" target="_blank">
                                <img src="../Library/Images/logo_agenda.gif" width="89" height="24" border="0" alt="" /></a>
                        </td>--%>
                    </tr>
                </table>
            </div>
        </form>
    </body>
</html>