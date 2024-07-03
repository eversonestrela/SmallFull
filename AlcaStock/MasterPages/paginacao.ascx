<%@ Control Language="C#" AutoEventWireup="true" CodeFile="paginacao.ascx.cs" Inherits="Library_MasterPages_paginacao" %>

<div>
    <table>
        <tr>
            <td>
                <asp:LinkButton CssClass="btn btn-default btn-sm" ID="btnPrimeiro" runat="server" ToolTip="Primeira Página" CommandArgument="primeiro"
                    OnClick="ImageButtonNav"><span class="fa fa-step-backward"></span></asp:LinkButton></td>
            <td>
                <asp:LinkButton CssClass="btn btn-default btn-sm" ID="btnAnterior" runat="server" ToolTip="Página Anterior" CommandArgument="anterior"
                    OnClick="ImageButtonNav"><span class="fa fa-chevron-left"></span></asp:LinkButton></td>
            <td style="vertical-align:bottom !important">
                <asp:DropDownList ID="dropPage" runat="server" ToolTip="Selecione a página desejada" AutoPostBack="true" style="margin-bottom:0px !important"
                    OnSelectedIndexChanged="dropPage_SelectedIndexChanged" CssClass="form-control input-sm mb-md">
                </asp:DropDownList></td>
            <td>
                <asp:LinkButton ID="btnProximo" runat="server" ToolTip="Próxima Página" CommandArgument="proximo" OnClick="ImageButtonNav"
                    CssClass="btn btn-default btn-sm"><span class="fa fa-chevron-right"></span></asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="btnUltimo" runat="server" ToolTip="Útilma Página" CommandArgument="ultimo" OnClick="ImageButtonNav"
                    CssClass="btn btn-default btn-sm"><span class="fa fa-step-forward"></span></asp:LinkButton></td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblTotal" Visible="false" runat="server" CssClass="label" Text="0"></asp:Label>

                <asp:Label ID="lblTotalRegistros" runat="server" CssClass="panel-subtitle" Text="Total de Registros:"></asp:Label>
            </td>
        </tr>
    </table>
</div>
