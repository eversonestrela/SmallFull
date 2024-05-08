<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="MasterPages_Menu" EnableViewState="false" %>

<asp:Label ID="lblMenu" runat="server"></asp:Label>
<div style="position: absolute; right: 5px; top: 4px; font-size: 10px;">
    <asp:LinkButton runat="server" OnClick="lnkAssLote_Click" ID="lnkAssLote" Style="text-decoration: none" CausesValidation="false">
        <asp:Image ID="Image2" runat="server" BorderWidth="0px" ImageAlign="AbsMiddle" ImageUrl="~/Library/Images/icones/icon_converte_datas_peq.gif" ToolTip="Clique aqui para assinar lote de documentos" />
    </asp:LinkButton>

    <asp:LinkButton runat="server" OnClick="lnkCorreio_Click" ID="lnkCorreio" Style="text-decoration: none" CausesValidation="false">
        <asp:Image ID="Image1" runat="server" BorderWidth="0px" ImageAlign="AbsMiddle" ImageUrl="~/Library/Images/icones/icon_email_novo.gif" /> CORREIO INTERNO, voc&ecirc; tem <b>
            <asp:Label ID="NMSG" runat="server" /> mensagem(ns)</b> n&atilde;o lida(s).
    </asp:LinkButton>
</div>
