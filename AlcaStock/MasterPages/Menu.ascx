<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="MasterPages_Menu" EnableViewState="false" %>

<%--<div style="position: absolute; right: 5px; top: 4px; font-size: 10px;">
    <asp:LinkButton runat="server" OnClick="lnkCorreio_Click" ID="lnkCorreio" Style="text-decoration: none" CausesValidation="false">
        <asp:Image ID="Image1" runat="server" BorderWidth="0px" ImageAlign="AbsMiddle" ImageUrl="~/Library/Images/icones/icon_email_novo.gif" /> CORREIO INTERNO, voc&ecirc; tem <b>
            <asp:Label ID="NMSG" runat="server" /> mensagem(ns)</b> n&atilde;o lida(s).
    </asp:LinkButton>
</div>--%>

<ul class="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="menuLateral">
    <!-- Logo - Menu -->
    <a class="sidebar-brand d-flex align-items-center justify-content-center">
        <div class="sidebar-brand-icon rotate-n-15">
            <i class="fas fa-truck-loading"></i>
        </div>
        <div class="sidebar-brand-text mx-3">alcastock <sup>1</sup></div>
    </a>

    <!-- Divisória -->
    <hr class="sidebar-divider my-0">

    <!-- Item Menu - Home -->
    <li class="nav-item active">
        <a class="nav-link" href="/">
            <i class="fas fa-home"></i>
            <span>Início</span>
        </a>
    </li>

    <!-- Divisória -->
    <hr class="sidebar-divider">

    <div class="sidebar-heading">
        Cadastros
    </div>

    <li class="nav-item">
        <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#menuPessoas"
           aria-expanded="true" aria-controls="menuPessoas">
            <i class="fas fa-fw fa-user-alt"></i>
            <span>Pessoas</span>
        </a>
        <div id="menuPessoas" class="collapse" data-parent="#menuLateral">
            <div class="bg-white py-2 collapse-inner rounded">
                <asp:Label ID="lblMenu" runat="server"></asp:Label>
                <%--<a class="collapse-item" asp-controller="Pessoa" asp-action="Index"> Pessoas</a>
                <a class="collapse-item" asp-controller="Cliente" asp-action="Index"> Clientes</a>
                <a class="collapse-item" href="#"> Distribuidores</a>--%>
            </div>
        </div>
    </li>

    <li class="nav-item">
        <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#menuProdutos"
           aria-expanded="true" aria-controls="menuProdutos">
            <i class="fas fa-fw fa-cog"></i>
            <span>Estoque</span>
        </a>
        <div id="menuProdutos" class="collapse" data-parent="#menuLateral">
            <div class="bg-white py-2 collapse-inner rounded">
                <a class="collapse-item" asp-controller="Produto" asp-action="Index"> Produtos</a>
            </div>
        </div>
    </li>

    <!-- Divisória final -->
    <hr class="sidebar-divider d-none d-md-block">

    <!-- Toggler para esconder o menu -->
    <div class="text-center d-none d-md-inline">
        <button class="rounded-circle border-0" id="sidebarToggle" title="Esconder o menu"></button>
    </div>
</ul>