<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Topo.ascx.cs" Inherits="MasterPages_Topo" %>

<asp:Label ID="ico_cliente" runat="server"></asp:Label>
<table width="100%" height="94%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="width: 300px;">
            <asp:Image ID="Logo" runat="server" ImageUrl="~/Library/Images/logo_sisprev_web.gif" />
        </td>
        <td align="right">
            <table>
                <tr>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="fundo_logado">
                                    <table cellpadding="0">
                                        <tr>
                                            <td style="padding-left: 5px;" class="texto_login">
                                                <asp:Label ID="lblNomeUsuario" runat="server"></asp:Label>
                                            </td>
                                            <td class="texto_login" align="center">
                                                <asp:Label ID="Label1" Visible="false" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 5px;" colspan="2" class="texto_login">
                                                <asp:Label ID="lbLotacao" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 5px;" colspan="2">
                                                <iframe id="iframesessao" frameborder="0" height="16px" marginheight="0" marginwidth="0"
                                                    style="background-color: Transparent" name="iframesessao" scrolling="no" src="<%=ResolveClientUrl("~/Library/MasterPages/Sessao.aspx")%>"
                                                    width="200"></iframe>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="direito_logado"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
        <td align="right">
            <asp:Image ID="LadoDireito" runat="server" ImageUrl="~/Library/Images_Cliente/lado_direito_logo.gif" />
        </td>
    </tr>
</table>