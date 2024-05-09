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
        </style>
        <script src="../../Library/JQuery/jquery-1.6.2.min.js" type="text/javascript"></script>
        <script src="https://www.google.com/recaptcha/api.js?render=6LdpEHsoAAAAADJOQ1NtaHj-9GK0y0vzfW3qpgb2" type="text/javascript"></script>
        <script type="text/javascript">

            //function isHttps() {
            //    if ((document.location.protocol == 'https:') == false) {
            //        document.write('<div id="divSSL" style="top: 0px; position: fixed;padding:10px;background-color:#FEFF99;width:100%"><img src="cadeado.png" height=16 align="absmiddle">' +
            //            'A navegação está ocorrendo sem o uso de certificado SSL, não podendo ser garantida a confidencialidade dos dados ' +
            //            'trafegados entre o navegador e o servidor.</div>');
            //    }
            //}

            //isHttps();

            function Resolucao() {
                if (document.getElementById('pnlLogin') != null) {
                    if (screen.width < 1024) {
                        document.getElementById('pnlLogin').style.display = 'none';
                        document.getElementById('pnlErro').style.display = 'block';
                        document.getElementById('backcadeado').className = 'topo1';
                    }
                    else {
                        document.getElementById('pnlLogin').style.display = 'block';
                        document.getElementById('pnlErro').style.display = 'none';
                        document.getElementById('backcadeado').className = 'topo2';
                    }
                }
            }

            function checar_caps_lock(ev) {
                var e = ev || window.event;
                codigo_tecla = e.keyCode ? e.keyCode : e.which;
                tecla_shift = e.shiftKey ? e.shiftKey : ((codigo_tecla == 16) ? true : false);
                if (((codigo_tecla >= 65 && codigo_tecla <= 90) && !tecla_shift) || ((codigo_tecla >= 97 && codigo_tecla <= 122) && tecla_shift)) {
                    document.getElementById('aviso_caps_lock').style.visibility = 'visible';
                }
                else {
                    document.getElementById('aviso_caps_lock').style.visibility = 'hidden';
                }
            }

            <%--function ExtensaoNaoInstalada() {
                $("#div_aviso_extensao").html('<img src="../Library/Images/chrome_web_store.png"><br>Extensão <b>Agenda Assessoria - WebAPI</b> não foi instalada, favor clique no link para realizar o <a href="https://chrome.google.com/webstore/detail/locallinks/aopmnlckolhoiinpfckejfhpmkmkfagc" target="_blank">download.</a>');
                var modal = "<%=MPECertificadoDigital.ClientID %>";
                $find(modal).show();
            }--%>

            //function ExtensaoInstalada(tipo) {
            //    if (tipo == 1) {
            //        $.ajax({
            //            type: "POST",
            //            contentType: "application/json; charset=utf-8",
            //            url: "../WebService/WebServiceArquivos.asmx/ExLoginBiometria",
            //            data: "{}",
            //            dataType: "json",
            //            success: function (data) {
            //                if (data.d != "") {
            //                    var event = document.createEvent('CustomEvent');
            //                    event.initCustomEvent("EnviarDadosString", true, true, { 'metodo': 'ExLoginBiometria', 'hashs': data.d });
            //                    document.documentElement.dispatchEvent(event);
            //                }
            //                else {
            //                    alert("Atenção: Não foi detectado nenhuma biometria vinculada a uma conta de usuário!");
            //                }
            //            },
            //            error: function (result) {
            //            }
            //        });
            //    } else {
            //        $.ajax({
            //            type: "POST",
            //            contentType: "application/json; charset=utf-8",
            //            url: "../WebService/WebServiceArquivos.asmx/ExLoginDigital",
            //            data: "{}",
            //            dataType: "json",
            //            success: function (data) {
            //                if (data.d != "") {
            //                    var event = document.createEvent('CustomEvent');
            //                    event.initCustomEvent("EnviarDadosString", true, true, { 'metodo': 'ExLoginDigital', 'hashs': data.d });
            //                    document.documentElement.dispatchEvent(event);
            //                }
            //                else {
            //                    alert("Atenção: Não foi detectado nenhum certificado digital vinculado a uma conta de usuário!");
            //                }
            //            },
            //            error: function (result) {
            //            }
            //        });
            //    }
            //}

            //var DetectarExtensao = function (tipo) {
            //    var is_chrome = navigator.userAgent.toLowerCase().indexOf('chrome') > -1;

            //    if (is_chrome) {
            //        var s = document.createElement('script');
            //        s.onload = function () { ExtensaoInstalada(tipo); };
            //        s.onerror = function () { ExtensaoNaoInstalada(); };
            //        s.src = 'chrome-extension://aopmnlckolhoiinpfckejfhpmkmkfagc/icons/19x19.png';
            //        document.body.appendChild(s);
            //    }
            //    else {
            //        ExtensaoInstalada(tipo);
            //    }
            //}

            <%--function WebAPI() {
                $("#div_aviso_extensao").html('<img src="../Library/Images/box_sisprev.gif"><br>Pacote <b>AgendaAssessoria.WebAPI.exe</b> não foi instalada, favor clique no link para realizar o <a href="http://proxima.sisprevweb.com.br/AgendaAssessoria.WebAPI.exe" target="_blank">download.</a>');
                var modal = "<%=MPECertificadoDigital.ClientID %>";
                $find(modal).show();
            }

            function ExRetornoLoginUsuario(retorno) {
                console.log(retorno);
                var json = JSON.parse(retorno);
                if (json.dados != undefined) {
                    $("#<%=hddDigital.ClientID %>").val(json.dados);
                    $("#<%=btnLoginDigital.ClientID %>").click();
                }
            }--%>

            <%--function AutenticarTecnico() {
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
            --%>}

            grecaptcha.ready(function () {
                    grecaptcha.execute('6LdpEHsoAAAAADJOQ1NtaHj-9GK0y0vzfW3qpgb2', { action: 'submit' }).then(function (token) {
                        document.getElementById('<%= recaptchaResponse.ClientID %>').value = token;
                });
            });

        </script>
    </head>
    <body>
        <form id="form1" runat="server" defaultbutton="btnLogin">
            <asp:ScriptManager ID="scripmanager" runat="server" EnablePartialRendering="true" EnableScriptGlobalization="true"></asp:ScriptManager>
            <div id="loginNew" runat="server">
                <asp:TextBox Style="display: none" ID="hddResolucao" runat="server" />
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; vertical-align: middle; text-align: center;">
                    <tr>
                        <td style="vertical-align: middle;">
                            <table width="100%" height="75" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left">
                                        <asp:Image ID="Logo" runat="server" Style="margin-bottom: 5px" align="top" ImageUrl="~/Library/Images/logo_sisprev_web.gif" />
                                    </td>
                                    <td align="right">
                                        <asp:Image ID="LogoCliente" runat="server" ImageUrl="~/Library/Images_Cliente/logo.gif" />
                                    </td>
                                </tr>
                            </table>
                            <div style="height: 300px; width: 100%">
                                <div style="height: 65px">
                                </div>
                                <table width="600" align="center" border="0">
                                    <tr align="center">
                                        <td>
                                            <a href="javascript:;" id="btncomum" runat="server">
                                                <img src="../../Library/Images/btnLoginSenha.png" title="Autenticação por login e senha, digite abaixo os dados para acessar o sistema!"
                                                    onmouseover="this.src='../../Library/Images/btnLoginSenha2.png';" onmouseout="this.src='../../Library/Images/btnLoginSenha.png';" />
                                            </a>
                                        </td>
                                        <%--<td>
                                            <a href="javascript:;" id="btndig" runat="server">
                                                <img src="../Library/Images/btnDigital.png" border="0" title="Clique aqui para autenticar pela sua digital cadastrada!"
                                                    onmouseover="this.src='../Library/Images/btnDigital2.png';" onmouseout="this.src='../Library/Images/btnDigital.png'" onclick="return DetectarExtensao(1);" />
                                            </a>
                                            <img src="../Library/Images/btnDigital3.png" style="display: none;" id="btndig2"
                                                title="Autenticação por digital (Leitor não encontrado)" />
                                        </td>--%>
                                        <%--<td>
                                            <a href="javascript:;" id="btnecpf" runat="server">
                                                <img src="../Library/Images/btnEcpf.png" border="0" title="Clique aqui para autenticar por e-CPF ou e-CPNJ!"
                                                    onmouseover="this.src='../Library/Images/btnEcpf2.png';" onmouseout="this.src='../Library/Images/btnEcpf.png'" onclick="return DetectarExtensao(2);" />
                                            </a>
                                            <img src="../Library/Images/btnEcpf3.png" id="btnecpf2" runat="server" visible="false"
                                                title="Autenticação por e-CPF ou e-CPNJ não habilitado!" />
                                        </td>--%>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <div id="divLogin" style="background-image: url(../../Library/Images/caixaLogin.png); width: 654px; height: 117px">
                                                <div style="height: 55px">
                                                </div>
                                                <table border="0" cellpadding="2" cellspacing="2" align="center" style="font-family: Tahoma; font-size: 14px;">
                                                    <tr>
                                                        <td align="left">Login:
                                                        <asp:TextBox Style="font-family: Tahoma; font-size: 15px; border: 1px solid #D6D6D6; color: #999999"
                                                            ID="txtUSER" runat="server" TabIndex="1"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUSER"
                                                                Display="None" ErrorMessage="Informe o usu&aacute;rio!" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                            <asp:Label ID="LabelLogin" runat="server" Visible="False" Font-Bold="True" Font-Size="Large"
                                                                ForeColor="#000066"></asp:Label>
                                                            <asp:LinkButton ID="LimparCookieLogin" Font-Size="Large" runat="server" Visible="False"
                                                                CausesValidation="false" OnClick="LimparCookieLogin_Click" TabIndex="5" Text=" trocar login!"></asp:LinkButton>
                                                        </td>
                                                        <td align="left">
                                                            <div>
                                                                Senha:
                                                            <asp:TextBox Style="font-family: Tahoma; font-size: 15px; border: 1px solid #D6D6D6; color: #999999"
                                                                ID="txtPassWord" runat="server" TextMode="Password" TabIndex="2"
                                                                onKeyPress="checar_caps_lock(event)"></asp:TextBox>
                                                            </div>
                                                            <asp:HiddenField runat="server" ID="hddDigital" />
                                                            <div id="aviso_caps_lock" style="visibility: hidden; position: absolute; width: 310px; height: 180px; z-index: 1; padding: 2px">
                                                                <div>
                                                                    <img src="../Library/Images/top_ballon.gif" border="0" alt="" />
                                                                </div>
                                                                <div style='border: solid 1px #000000; border-bottom: 0px; padding-left: 10px; padding-right: 10px; width: 290px; font-size: 11px; font-family: tahoma; border-top: 0px; background-color: #FFFFD9'>
                                                                    <img src="../../Library/Images/warning.png" align="middle" alt="" />
                                                                    <b>Caps Lock está ativada</b>
                                                                    <br/>
                                                                    Se Caps Lock estiver ativado, isso pode fazer com que você digite a senha incorretamente.
                                                                    <br/>
                                                                    <br/>
                                                                    Você deve pressionar a tecla Caps Lock para desativá-las antes de digitar a senha.
                                                                </div>
                                                                <div>
                                                                    <img src="../Library/Images/bottom_ballon.gif" border="0" alt="" />
                                                                </div>
                                                            </div>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassWord"
                                                                Display="None" ErrorMessage="Informe a senha!" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td align="left">
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
                            </div>
                            <table width="100%" border="0" cellspacing="0" cellpadding="20">
                                <tr>
                                    <td align="center">
                                        <asp:Label runat="server" ID="lblbr" Text="<br /><br />"></asp:Label>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="2" class="login">
                                            <tr>
                                                <td class="rotulo" align="center">
                                                    <asp:Label ID="lbEndereco" runat="server"></asp:Label>,
                                                <asp:Label ID="lbNumero" runat="server"></asp:Label>
                                                    -
                                                <asp:Label ID="lbBairro" runat="server"></asp:Label>
                                                    -
                                                <asp:Label ID="lbCidade" runat="server"></asp:Label>
                                                    –
                                                <asp:Label ID="lbEstado" runat="server"></asp:Label>
                                                    - TEL.
                                                <asp:Label ID="lbTelefone" runat="server"></asp:Label>
                                                    - FAX
                                                <asp:Label ID="lbFax" runat="server"></asp:Label>
                                                    - CEP:
                                                <asp:Label ID="lbCEP" runat="server"></asp:Label>
                                                    <br />
                                                    <asp:LinkButton ID="lblSite" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" id="backcadeado" name="backcadeado" style="background-repeat: no-repeat; background-position: left; display: none">
                                        <div id="pnlLogin" style="display: none">
                                            <table width="232" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="36" background="../../Library/Images/topo_login.gif"></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" background="../../Library/Images/meio_login.gif"></td>
                                                </tr>
                                                <tr>
                                                    <td height="18" background="../../Library/Images/baixo_login.gif"></td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="pnlErro" style="display: none; width: 65%; text-align: center; height: 170px">
                                            <b style="font-family: Verdana; font-size: 12px; color: #FF0000;">
                                                <br />
                                                ATENÇÃO A RESOLUÇÃO DE VÍDEO DO SEU MONITOR É INFERIOR A RECOMENDADA <b style="color: #000000">"1024x768"</b>, PORTANTO PARA A UTILIZAÇÃO CORRETA DO SISTEMA É NECESSÁRIO ALTERÁ-LA!</b>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            &nbsp;&nbsp;
            <div runat="server" visible="false" id="divBloqueado" style="margin-left: -291px; left: 50%; top: 50%; margin-top: -122px; position: absolute; width: 583px; height: 244px">
                <img src="../../Library/Images/imgBloqueado.png" />
            </div>
            <div style="display: none; margin: 0%; position: absolute; width: 232px;" class="modalBackground">
                <table align="center" border="0" cellpadding="0" cellspacing="0" class="texto_login" width="232">
                    <tr>
                        <td background="../../Library/Images/topo_login.gif" height="36"></td>
                    </tr>
                    <tr>
                        <td align="center" background="../../Library/Images/meio_login.gif">
                            <table border="0" cellpadding="2" cellspacing="0" class="texto_menu" width="90%">
                                <tr>
                                    <td height="60">
                                        <img src="../../Library/Images/preload.gif" alt="" />
                                        Aguarde Carregando ...
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td background="../../Library/Images/baixo_login.gif" height="18"></td>
                    </tr>
                </table>
            </div>
            <div style="position: fixed; bottom: 0px; width: 100%; z-index: -50" id="sisrodape">
                <table width="100%" style="border-top: 1px solid #CCCCCC; padding-left: 10px;" border="0"
                    align="center" cellpadding="0" cellspacing="0" class="texto_login">
                    <tr>
                        <td valign="middle">Sistema desenvolvido por Agenda Assessoria. Todos os Direitos Reservados. 2009
                        </td>
                        <td align="right">
                            <a href="http://www.agendaassessoria.com.br" target="_blank">
                                <img src="../Library/Images/logo_agenda.gif" width="89" height="24" border="0" alt="" /></a>
                        </td>
                    </tr>
                </table>
            </div>
            <%--<cc3:ModalPopupExtender ID="MPECertificadoDigital" runat="server" TargetControlID="Button17"
                CancelControlID="ImageButton5" PopupControlID="pnlCertificadoDigital" BackgroundCssClass="modalBackground"
                DropShadow="false" />
            <asp:Button ID="Button17" runat="server" Style="display: none;" />
            <asp:Panel ID="pnlCertificadoDigital" Height="100" Style="display: none; margin: 0px; position: absolute; z-index: 1000"
                runat="server">
                <div>
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td style="height: 34px; width: 34px; background: url(../Library/Images/TE.gif) no-repeat" />
                            <td style="height: 34px; width: 34px; background: url(../Library/Images/TC.gif) repeat-x; color: #FFFFFF;">Agenda Assessoria - WebAPI
                            </td>
                            <td style="height: 34px; width: 34px; background: url(../Library/Images/TD.gif) no-repeat">
                                <asp:ImageButton Style="cursor: hand" ID="ImageButton5" runat="server" ImageUrl="~/Library/Images/delete.png"
                                    Height="18px" BorderStyle="None" CausesValidation="false" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 34px; background: url(../Library/Images/ME.gif) repeat-y" />
                            <td style="width: 34px; background: url(../Library/Images/MC.gif); padding: 5px;" align="center">
                                <div id="div_aviso_extensao" style="width: 250px;"></div>
                            </td>
                            <td style="width: 34px; background: url(../Library/Images/MD.gif) repeat-y" />
                        </tr>
                        <tr>
                            <td style="height: 18px; width: 18px; background: url(../Library/Images/BE.gif) no-repeat" />
                            <td style="height: 18px; width: 18px; background: url(../Library/Images/BC.gif) repeat-x" />
                            <td style="height: 18px; width: 18px; background: url(../Library/Images/BD.gif) no-repeat" />
                        </tr>
                    </table>
                </div>
            </asp:Panel>--%>
        </form>
    </body>
</html>