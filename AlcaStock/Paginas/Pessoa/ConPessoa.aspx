<%@ Page Language="C#" MasterPageFile="~/MasterPages/Consulta.master" AutoEventWireup="true" CodeFile="ConPessoa.aspx.cs" Inherits="Paginas_Pessoa_ConPessoa" Title="Consulta de Pessoas" %>

<%@ Register Assembly="AGENDA.Controles" Namespace="AGENDA.Controles.UI" TagPrefix="cc1" %>
<%@ Register Assembly="AGENDA.Controles" Namespace="AGENDA.Controles.UI.ButtonToolBar" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentFiltros" runat="server">
    <link href="../Library/JQuery/css/ui-lightness/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />

    <script src="../Library/JQuery/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../Library/Scripts/jquery.meiomask.js" type="text/javascript"></script>

    <script>
        document.addEventListener("DOMContentLoaded", function () {
            var dropdownButton = document.getElementById("dropdownButton");
            var dropdownItems = document.querySelectorAll(".dropdown-item");

            dropdownItems.forEach(function (item) {
                item.addEventListener("click", function () {
                    var value = this.getAttribute("data-value");
                    var text = this.textContent;

                    dropdownButton.textContent = text;
                    dropdownButton.setAttribute("data-selected-value", value);
                });
            });
        });
    </script>

    <asp:UpdatePanel ID="pnlFiltro" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td valign="bottom">
                        <cc1:FieldDropDown ID="ddlPSQ" runat="server" CssClass="btn btn-sm btn-secondary btn-pesquisar" ValueField="Pesquisar por">
                            <asp:ListItem Value="0">Nome</asp:ListItem>
                            <asp:ListItem Value="1">CPF</asp:ListItem>
                        </cc1:FieldDropDown>
                    </td>
                    <td valign="bottom">
                        <label class="rotuloCaixaPesquisar">Descrição</label>
                        <div class="input-group input-group-sm">
                            <cc1:FieldTextBox ID="txtPesquisa" runat="server" CssClass="form-control form-control-pesquisar" Width="250px" />
                        </div>
                        
                    </td>
                    <td valign="bottom">
                        <asp:Button ID="btnConsultar" Text="Consultar" runat="server" CssClass="btn btn-sm btn-outline-dark" CausesValidation="true" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentToolBar" runat="server">
    <asp:LinkButton ID="btnNovo" runat="server" CausesValidation="false" CssClass="btn btn-sm btn-primary btn-novo"
        Text="<i class='fas fa-plus'></i> Novo Cadastro"
        ToolTip="Novo Registro" OnClick="btnNovo_Click" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentGrid" runat="server">
    <asp:GridView ID="gvPessoas" runat="server" AutoGenerateColumns="False" CssClass="table table-borderless custom-gridview"
        OnRowCreated="gvPessoas_RowCreated" OnRowDataBound="gvPessoas_RowDataBound">
        <Columns>
            <asp:BoundField DataField="NOME" HeaderText="Nome" />
            <asp:BoundField DataField="CPF" HeaderText="CPF" />
            <asp:BoundField DataField="DATA_NASC" HeaderText="Data de Nascimento" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="SEXO" HeaderText="Sexo" />
            <asp:BoundField DataField="NOME_MAE" HeaderText="Nome da Mãe" />
            <asp:BoundField DataField="CPF_MAE" HeaderText="CPF da Mãe" />
            <asp:BoundField DataField="NOME_PAI" HeaderText="Nome do Pai" />
            <asp:BoundField DataField="CPF_PAI" HeaderText="CPF do Pai" />
            <asp:BoundField DataField="TELEFONE_RESIDENCIAL" HeaderText="Telefone Residencial" />
            <asp:BoundField DataField="TELEFONE_CELULAR" HeaderText="Telefone Celular" />
            <asp:BoundField DataField="EMAIL" HeaderText="E-mail" />
        </Columns>
    </asp:GridView>
</asp:Content>