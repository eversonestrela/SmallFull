<%@ Page Language="C#" MasterPageFile="~/MasterPages/Consulta.master" AutoEventWireup="true" CodeFile="ConPessoa.aspx.cs" Inherits="Paginas_Pessoa_ConPessoa" Title="Consulta de Pessoas" %>

<%@ Register Assembly="AGENDA.Controles" Namespace="AGENDA.Controles.UI" TagPrefix="cc1" %>
<%@ Register Assembly="AGENDA.Controles" Namespace="AGENDA.Controles.UI.ButtonToolBar" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentFiltros" runat="server">
    <link href="../Library/JQuery/css/ui-lightness/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />

    <script src="../Library/JQuery/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../Library/Scripts/jquery.meiomask.js" type="text/javascript"></script>

    <script type="text/javascript">

        function Mascara(campo, tipo) {
            var aplicamask = campo.value;
            var tam_campo;
            switch (tipo) {
                case 1:  // Aplica máscara de CPF
                    tam_campo = 14
                    aplicamask = aplicamask.replace(/\D/g, "");
                    aplicamask = aplicamask.replace(/(\d{3})/, "$1.");
                    aplicamask = aplicamask.replace(/([.]\d{3})/, "$1.");
                    aplicamask = aplicamask.replace(/(\d{3}[.]\d{3}[.]\d{3})/, "$1-");
                    aplicamask = aplicamask.length > tam_campo ? aplicamask.substring(0, tam_campo) : aplicamask;
                    break;
            }
            campo.value = aplicamask;
        }

        var tipo = document.getElementById("<%=ddlPSQ.ClientID%>").value;
        $(document).ready(function () {
            if (tipo == 1) {
                $("#<%=txtPesquisa.ClientID%>").mask("999.999.999-99");
            }
        });

    </script>
    <asp:UpdatePanel ID="pnlFiltro" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td valign="bottom">
                        <cc1:FieldDropDown ID="ddlPSQ" runat="server" CssClass="dropDown" ValueField="Pesquisar por" Obrigatorio="false" 
                            OnSelectedIndexChanged="ddlPSQ_SelectedIndexChanged" AutoPostBack="true" Width="100px" style="padding: 4px;">
                            <asp:ListItem Value="0">Nome</asp:ListItem>
                            <asp:ListItem Value="1">CPF</asp:ListItem>
                        </cc1:FieldDropDown>
                    </td>
                    <td valign="bottom">
                        <cc1:FieldTextBox ID="txtPesquisa" runat="server" CssClass="caixaTexto" ValueField="Descrição"
                            Obrigatorio="True" Width="250px"></cc1:FieldTextBox>
                        <cc3:MaskedEditExtender ID="mskCPF" runat="server" TargetControlID="txtPesquisa"
                            Mask="999\.999\.999-99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                            OnInvalidCssClass="MaskedEditError" Enabled="false" ClearMaskOnLostFocus="false" />
                        <asp:RequiredFieldValidator ID="rvlPesquisa" runat="server" ErrorMessage="Informe um texto para pesquisa!"
                            Display="None" ControlToValidate="txtPesquisa" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                        <div style="float: left;">
                            <cc1:FieldTextBox ID="txtPeriodoInicial" ValueField="Nascidos em:" runat="server"
                                Style="width: 70px;" Visible="false" />
                        </div>
                        <div style="float: left; padding-left: 5px;">
                            <cc1:FieldTextBox ID="txtPeriodoFinal" runat="server" Style="width: 70px;" Visible="false" />
                        </div>
                    </td>
                    <td valign="bottom">
                        <asp:Button ID="btnConsultar" Text="Consultar" runat="server" CssClass="button" CausesValidation="true" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentToolBar" runat="server">
    <asp:LinkButton ID="btnNovo" runat="server" CausesValidation="false" CssClass="btnProc"
        Text="<img src='../Library/Images/icones/Novo.gif'> Novo"
        ToolTip="Novo Registro" OnClick="btnNovo_Click" />
    <asp:Image CssClass="SeparadorBtn" ImageUrl="~/Library/Images/Separador.gif"
        runat="server" />
    <asp:LinkButton ID="lnkExportaExcel" runat="server" CausesValidation="false" CssClass="btnProc"
        Text="<img src='../Library/Images/icones/excel.gif' height='14'> Exportar Lista para Excel"
        ToolTip="Exportar Lista para Excel" />
    <asp:Image CssClass="SeparadorBtn" ImageUrl="~/Library/Images/Separador.gif"
        runat="server" />
    <asp:LinkButton ID="btnVoltar" runat="server" CausesValidation="false" CssClass="btnProc"
        Text="<img src='../Library/Images/icones/voltar.gif'> Voltar"
        ToolTip="Cancelar" OnClick="btnVoltar_Click" />
</asp:Content>