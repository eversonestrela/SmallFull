<%@ Page Language="C#" MasterPageFile="~/MasterPages/Consulta.master" AutoEventWireup="true" CodeFile="ConPessoa.aspx.cs" Inherits="Paginas_Pessoa_ConPessoa" Title="Consulta de Pessoas" %>

<%@ Register Assembly="AGENDA.Controles" Namespace="AGENDA.Controles.UI" TagPrefix="cc1" %>
<%@ Register Assembly="AGENDA.Controles" Namespace="AGENDA.Controles.UI.ButtonToolBar" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentFiltros" runat="server">
    <link href="../Library/JQuery/css/ui-lightness/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />

    <script src="../Library/JQuery/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../Library/Scripts/jquery.meiomask.js" type="text/javascript"></script>

    <asp:UpdatePanel ID="pnlFiltro" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td valign="bottom">
                        <cc1:FieldDropDown ID="ddlPSQ" runat="server" CssClass="btn btn-sm btn-secondary btn-pesquisar" ValueField="Pesquisar por"
                            OnSelectedIndexChanged="ddlPSQ_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0">Nome</asp:ListItem>
                            <asp:ListItem Value="1">CPF</asp:ListItem>
                        </cc1:FieldDropDown>
                    </td>
                    <td valign="bottom">
                        <label class="rotuloCaixaPesquisar">Descrição</label>
                        <div class="input-group input-group-sm">
                            <cc1:FieldTextBox ID="txtPesquisa" runat="server" CssClass="form-control form-control-pesquisar" Width="250px" onkeyup="convertToUppercase(event);" />
                        </div>
                        
                    </td>
                    <td valign="bottom">
                        <asp:Button ID="btnConsultar" Text="Consultar" runat="server" CssClass="btn btn-sm btn-outline-dark" CausesValidation="true"
                            OnClick="btnConsultar_Click" />
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
    <asp:DataGrid ID="gvPessoas" runat="server" AutoGenerateColumns="False" CssClass="table table-borderless custom-gridview"
        OnItemCreated="gvPessoas_ItemCreated" OnItemDataBound="gvPessoas_ItemDataBound">
        <Columns>
            <asp:BoundColumn DataField="NOME" HeaderText="Nome" />
            <asp:BoundColumn DataField="CPF" HeaderText="CPF" />
            <asp:BoundColumn DataField="DATA_NASC" HeaderText="Data de Nascimento" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundColumn DataField="SEXO" HeaderText="Sexo" />
            <asp:BoundColumn DataField="NOME_MAE" HeaderText="Nome da Mãe" />
            <asp:BoundColumn DataField="CPF_MAE" HeaderText="CPF da Mãe" />
            <asp:BoundColumn DataField="NOME_PAI" HeaderText="Nome do Pai" />
            <asp:BoundColumn DataField="CPF_PAI" HeaderText="CPF do Pai" />
            <asp:BoundColumn DataField="TELEFONE_RESIDENCIAL" HeaderText="Telefone Residencial" />
            <asp:BoundColumn DataField="TELEFONE_CELULAR" HeaderText="Telefone Celular" />
            <asp:BoundColumn DataField="EMAIL" HeaderText="E-mail" />
        </Columns>
    </asp:DataGrid>
</asp:Content>