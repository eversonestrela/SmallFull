<%@ Page Language="C#" MasterPageFile="~/MasterPages/DefaultPage.master"
    EnableSessionState="ReadOnly" AutoEventWireup="true"
    CodeFile="Inicial.aspx.cs" Inherits="Inicial" Title="ALCASHOCK - Sistema de Estoque" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc3" %>
<%@ Register Assembly="AGENDA.Controles" Namespace="AGENDA.Controles.UI" TagPrefix="cc2" %>
<%@ Register Assembly="AGENDA.Controles" Namespace="AGENDA.Controles.UI.ButtonToolBar" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style type="text/css">
        .flyOutDiv {
            display: none;
            position: absolute;
            width: 400px;
            z-index: 3;
            opacity: 0;
            filter: (progid:DXImageTransform.Microsoft.Alpha(opacity=0));
            font-size: 14px;
            border: solid 1px #CCCCCC;
            background-color: #FFFFFF;
            padding: 5px;
        }

        .flyOutDivCloseX {
            background-color: #666666;
            color: #FFFFFF;
            text-align: center;
            font-weight: bold;
            text-decoration: none;
            border: outset thin #FFFFFF;
            padding: 5px;
        }

        .relatorio1 {
            list-style: none;
            margin: 0;
            padding: 0;
            padding-left: 0px;
            text-align: center;
        }

        #relatorio1 ul {
            list-style: none;
            margin: 0;
            padding: 0px;
            padding-left: 0px;
            text-align: center;
        }

        #relatorio1 li {
            text-align: center;
            display: inline;
            float: inherit;
            padding-bottom: 3px;
        }

            #relatorio1 li input {
                margin-bottom: 5px;
            }

        .Acordion {
            vertical-align: top;
            border: 1px solid #999999;
            border-bottom: none;
            color: Black;
            font-weight: bold;
            font-family: Tahoma;
            font-size: 11px;
            padding: 5px;
            text-align: left;
            height: 15px;
            background-color: #F0F0F0;
            cursor: pointer;
            cursor: hand;
        }

        .AcordionHover {
            vertical-align: top;
            border: 1px solid #999999;
            border-bottom: none;
            color: Black;
            font-weight: bold;
            font-family: Tahoma;
            font-size: 11px;
            padding: 5px;
            text-align: left;
            height: 15px;
            background-color: #DDDDDD;
            cursor: pointer;
            cursor: hand;
        }

        .ContentAcordion {
            padding: 0px;
            border: 1px solid #DDDDDD;
            border-right: 1px solid #CCCCCC;
        }

        .Caixa {
            padding: 12px;
            background: #FFFFFF;
            border: 1px solid #CCCCCC;
            border-radius: 10px 10px 10px 10px; /* Implementação W3C */
            box-shadow: 0px 0px 10px rgba(0,0,0,0.4);
            -moz-box-shadow: 0px 0px 10px rgba(0,0,0,0.4);
            -webkit-box-shadow: 0px 0px 10px rgba(0,0,0,0.4);
        }

        .divAzul {
            padding: 0px;
            background: #006666;
            border-radius: 10px 10px 0px 0px; /* Implementação W3C */
            background: linear-gradient(#0099CC, #006666 100%); /* Implementação W3C */
            background: -moz-linear-gradient(#0099CC, #006666 100%); /* Implementação Mozilla */
            background: -webkit-gradient(linear, 0 0, 0 100%, from(#0099CC), to(#006666)); /* Implementação para browsers que renderizam via webkit */
            -pie-background: linear-gradient(#0099CC, #006666 100%);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorStr='#0099CC', EndColorStr='#006666'); /* IE6,IE7 */
            -ms-filter: "progid:DXImageTransform.Microsoft.gradient(startColorStr='#0099CC', EndColorStr='#006666')"; /* IE8 */
        }
    </style>

    <script type="text/javascript">

        function convertedatas() {
            window.open('ConverteDatas/ConverteDatas.aspx', 'ConverteDatas', 'height=600,width=575,left=' + ((screen.width - 575) / 2) + 'status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=false');
            return false;
        }
        function AlterarSenha() {
            window.open('Login/PopUpAlteraSenha.aspx', 'AlterarSenha', 'height=250,width=500,left=' + ((screen.width - 500) / 2) + 'status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=false');
            return false;
        }

        $(function () {

            $("#divTitProcRec")
                .click(function () {
                    if (document.getElementById('divProcRec').style.display == 'none')
                        $("#divProcRec").slideDown();
                    else
                        $("#divProcRec").slideUp();
                });
        });

        function AlturaDiv() {

            var altura = document.getElementById('divMenus').offsetHeight;
            altura = altura - (document.getElementById('divEndereco').offsetHeight +
                document.getElementById('divParametro').offsetHeight + 85);

            var dif = 0;
            /*if (self.innerHeight) { dif = self.innerHeight }
            else if (document.documentElement && document.documentElement.clientHeight) { dif = document.documentElement.clientHeight; }
            else if (document.body) { dif = document.body.clientHeight; }
            */

            if (document.getElementById('divProcRec') != null) {
                document.getElementById('divProcRec').style.height = String(altura + dif) + 'px';
                //alert(document.getElementById('divProcRec').style.height);
            }
        }

        function ExEnderecoMac() {
            var event = document.createEvent('CustomEvent');

            event.initCustomEvent("EnviarDadosString", true, true, { 'metodo': 'ExEnderecoMac', 'ws': $("#hdnURL").val(), 'usuarioId': $("#hdnUserId").val() });

            document.documentElement.dispatchEvent(event);


            document.getElementById('imgCarregando').style.display = 'none';
            document.getElementById('divCarregando').style.display = 'none';

        }

        function ExRetornoEnderecoMac(retorno) {

        }

        </script>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:HiddenField ClientIDMode="Static" ID="hdnURL" runat="server" />
            <asp:HiddenField ClientIDMode="Static" ID="hdnUserId" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <div style="position: static; bottom: 0px; width: 100%" id="sisrodape">
        <table width="100%" style="border-top: 1px solid #CCCCCC; padding-left: 10px;" border="0"
            align="center" cellpadding="0" cellspacing="0" class="texto_login">
            <tr>
                <td valign="middle">Sistema desenvolvido por Agenda Assessoria. Todos os Direitos Reservados. 2009
                </td>
                <td align="right">
                    <a href="http://www.agendaassessoria.com.br" target="_blank">
                        <img src="Library/Images/logo_agenda.gif" width="89" height="24" border="0" alt="" />
                    </a>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>