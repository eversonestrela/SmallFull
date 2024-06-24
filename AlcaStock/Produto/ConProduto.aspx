﻿<%@ Page Language="C#" MasterPageFile="~/MasterPages/Consulta.master" AutoEventWireup="true" CodeFile="ConProduto.aspx.cs" Inherits="Paginas_Pessoa_ConProduto" Title="Consulta de Produtos" %>

<%@ Register Assembly="AGENDA.Controles" Namespace="AGENDA.Controles.UI" TagPrefix="cc1" %>
<%@ Register Assembly="AGENDA.Controles" Namespace="AGENDA.Controles.UI.ButtonToolBar" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentFiltros" runat="server">

    <asp:UpdatePanel ID="pnlFiltro" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td valign="bottom">
                        <cc1:FieldDropDown ID="ddlPSQ" runat="server" CssClass="btn btn-sm btn-secondary btn-pesquisar" ValueField="Pesquisar por">
                            <asp:ListItem Value="0">Nome</asp:ListItem>
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
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:DataGrid ID="gvProdutos" runat="server" AutoGenerateColumns="False" CssClass="table table-borderless custom-gridview"
                OnItemCreated="gvProdutos_ItemCreated" OnItemDataBound="gvProdutos_ItemDataBound" OnItemCommand="gvProdutos_ItemCommand">
                <Columns>
                    <asp:TemplateColumn HeaderText="Excluir">
                        <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
                        <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbtnExcluir" CausesValidation="false" ImageUrl="~/Library/Images/icones/close.png"
                                runat="server" CommandName="excluir" ToolTip="Clique aqui para Excluir este registro">
                            </asp:ImageButton>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Editar">
                        <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
                        <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbtnEditar" CausesValidation="false" ImageUrl="~/Library/Images/icones/edit.PNG"
                                runat="server" CommandName="editar" ToolTip="Clique aqui para Editar este registro">
                            </asp:ImageButton>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="PRODUTO_ID" HeaderText="ID" Visible="false" />
                    <asp:BoundColumn DataField="CODIGO" HeaderText="Código" />
                    <asp:BoundColumn DataField="TIPO" HeaderText="Tipo" />
                    <asp:BoundColumn DataField="NOME" HeaderText="Descrição" />
                    <asp:BoundColumn DataField="MARCA" HeaderText="Marca" />
                    <asp:BoundColumn DataField="ESTOQUE_ATUAL" HeaderText="Estoque atual" />
                    <asp:BoundColumn DataField="STATUS" HeaderText="Status" />
                    <asp:BoundColumn DataField="SIS_DATA_INSERT" HeaderText="Data Cadastro" DataFormatString="{0:dd/MM/yyyy}" />
                </Columns>
            </asp:DataGrid>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
