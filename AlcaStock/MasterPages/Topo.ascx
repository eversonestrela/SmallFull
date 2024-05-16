<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Topo.ascx.cs" Inherits="MasterPages_Topo" %>

<%--<asp:Label ID="ico_cliente" runat="server"></asp:Label>
<table width="100%" height="94%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="width: 300px;">
            
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
</table>--%>

<div id="content">
    <!-- Topbar master -->
    <nav class="navbar navbar-expand navbar-light bg-white topbar static-top shadow">
        <!-- Toggle do menu lateral (responsivo) -->
        <button id="sidebarToggleTop" class="btn btn-link d-md-none rounded-circle mr-3">
            <i class="fa fa-bars"></i>
        </button>
        <!-- Topbar - Navegação -->
        <ul class="navbar-nav ml-auto">
            <!-- Notificações -->
            <li class="nav-item dropdown no-arrow mx-1" title="Notificações">
                <a class="nav-link dropdown-toggle" href="#" id="dropdownNotificacoes" role="button"
                   data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    <i class="fas fa-bell fa-fw"></i>
                    <!-- Contador - Notificações -->
                    <span class="badge badge-danger badge-counter">3+</span>
                </a>
                <!-- Dropdown - Notificações -->
                <div class="dropdown-list dropdown-menu dropdown-menu-right shadow animated--grow-in"
                     aria-labelledby="dropdownNotificacoes">
                    <h6 class="dropdown-header">
                        Central de Notificações
                    </h6>
                    <a class="dropdown-item d-flex align-items-center" href="#">
                        <div class="mr-3">
                            <div class="icon-circle bg-primary">
                                <i class="fas fa-file-alt text-white"></i>
                            </div>
                        </div>
                        <div>
                            <div class="small text-gray-500">December 12, 2019</div>
                            <span class="font-weight-bold">A new monthly report is ready to download!</span>
                        </div>
                    </a>
                    <a class="dropdown-item text-center small text-gray-500" href="#">Mostrar Todos</a>
                </div>
            </li>

            <div class="topbar-divider d-none d-sm-block"></div>

            <!-- Informações do Usuário -->
            <li class="nav-item dropdown no-arrow">
                <a class="nav-link dropdown-toggle" href="#" id="dropdownUsuario" role="button"
                   data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    <span class="mr-2 d-none d-lg-inline text-gray-600 small">Pedro Alcantara</span>
                    <%--<img class="img-profile rounded-circle" alt=">--%>
                </a>
                <!-- Dropdown - Informações do Usuário -->
                <div class="dropdown-menu dropdown-menu-right shadow animated--grow-in"
                     aria-labelledby="dropdownUsuario">
                    <a class="dropdown-item" href="#">
                        <i class="fas fa-user fa-sm fa-fw mr-2 text-gray-400"></i>
                        Meus Dados
                    </a>
                    <a class="dropdown-item" href="#">
                        <i class="fas fa-cogs fa-sm fa-fw mr-2 text-gray-400"></i>
                        Configurações
                    </a>
                    <a class="dropdown-item" href="#">
                        <i class="fas fa-list fa-sm fa-fw mr-2 text-gray-400"></i>
                        Registro de Logs
                    </a>
                    <div class="dropdown-divider"></div>
                    <a class="dropdown-item" href="#" data-toggle="modal" data-target="#modalLogout" title="Clique aqui para sair">
                        <i class="fas fa-sign-out-alt fa-sm fa-fw mr-2 text-gray-400"></i>
                        Sair
                    </a>
                </div>
            </li>

        </ul>

    </nav>
    <!-- Fim Topbar -->
</div>

<!-- Modal Logout -->
<div class="modal fade" id="modalLogout" tabindex="-1" role="dialog" aria-labelledby="modalDoLogout"
     aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title rotulo" id="modalDoLogout">Deseja Realmente Sair?</h5>
                <button class="btn-close" type="button" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">×</span>
                </button>
            </div>
            <div class="modal-body rotulo"><h6>Clique em Sim para encerrar a sessão.</h6></div>
            <div class="modal-footer">
                <button class="btn btn-sm btn-secondary" type="button" data-dismiss="modal">Não</button>
                <a class="btn btn-sm btn-danger" href="#">Sim</a>
            </div>
        </div>
    </div>
</div>