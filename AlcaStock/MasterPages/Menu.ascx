<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="MasterPages_Menu" EnableViewState="false" %>

<%--<div style="position: absolute; right: 5px; top: 4px; font-size: 10px;">
    <asp:LinkButton runat="server" OnClick="lnkCorreio_Click" ID="lnkCorreio" Style="text-decoration: none" CausesValidation="false">
        <asp:Image ID="Image1" runat="server" BorderWidth="0px" ImageAlign="AbsMiddle" ImageUrl="~/Library/Images/icones/icon_email_novo.gif" /> CORREIO INTERNO, voc&ecirc; tem <b>
            <asp:Label ID="NMSG" runat="server" /> mensagem(ns)</b> n&atilde;o lida(s).
    </asp:LinkButton>
</div>--%>

<%--<asp:Label ID="lblMenu" runat="server"></asp:Label>--%>

<ul class="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="menuLateral" style="font-family:Nunito,-apple-system,BlinkMacSystemFont,Segoe UI,Roboto,Helvetica Neue,Arial,sans-serif,Apple Color Emoji,Segoe UI Emoji,Segoe UI Symbol,Noto Color Emoji">
    
    <a class="sidebar-brand d-flex align-items-center justify-content-center">
        <div class="sidebar-brand-icon rotate-n-15">
            <i class="fas fa-truck-loading"></i>
        </div>
        <div class="sidebar-brand-text mx-3">alcastock <sup>1</sup></div>
    </a>

    <hr class="sidebar-divider my-0">

    <asp:Label ID="lblMenu" runat="server"></asp:Label>

    <%--<li class="nav-item">
		<a class="nav-link" href="/Inicial.aspx">
			<span>Início</span>
		</a>
	</li>
	<li class="nav-item">
		<a class="nav-link collapsed" data-toggle="collapse" data-target="#menuCadastros" aria-expanded="true" aria-controls="menuCadastros" href="javascript:;">
			<span>Cadastros</span>
		</a>
		<div id="menuCadastros" class="collapse" data-parent="#menuLateral">
			<div class="bg-white py-2 collapse-inner rounded">
				<a class="collapse-item" href="/Pessoa/ConPessoa.aspx"> Pessoas</a>
				<a class="collapse-item" data-toggle="collapse" data-target="#menuFornecedores" aria-expanded="true" aria-controls="menuFornecedores" href="javascript:;" style="display: flex; justify-content: space-between; align-items: center;">
					<span>Fornecedores</span>
					<i class="fas fa-angle-down coll"></i>
				</a>
				<div id="menuFornecedores" class="collapse" data-parent="#menuCadastros">
					<div class="bg-white py-2 collapse-inner rounded">
						<a class="collapse-item" href="#"> Público</a>
					</div>
				</div>
			</div>
		</div>
	</li>--%>

    <hr class="sidebar-divider d-none d-md-block">

    <div class="text-center d-none d-md-inline">
        <button class="rounded-circle border-0" id="sidebarToggle" title="Esconder o menu"></button>
    </div>
</ul>