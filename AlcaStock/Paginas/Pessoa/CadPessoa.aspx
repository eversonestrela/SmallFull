<%@ Page Language="C#" MasterPageFile="~/MasterPages/Cadastro.master" AutoEventWireup="true" CodeFile="CadPessoa.aspx.cs" Inherits="Paginas_Pessoa_CadPessoa" Title="Cadastro de Pessoas" %>

<%@ Register Assembly="AGENDA.Controles" Namespace="AGENDA.Controles.UI.ButtonToolBar" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AGENDA.Controles" Namespace="AGENDA.Controles.UI" TagPrefix="cc3" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentCampos" runat="server">
    <link href="../Library/JQuery/css/ui-lightness/jquery-ui-1.8.16.custom.css" rel="stylesheet"
    type="text/css" />
    <script src="../Library/JQuery/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../Library/Scripts/jquery.meiomask.js" type="text/javascript"></script>

    <style type="text/css">
        .espaco-table {
            color: #000;
        }

        .espaco-table td {
            padding-right: 10px;
        }

        #btnClose {
            float:right;
            width: 25px;
            height: 25px;
            border: none;
            position: relative;
            z-index: 100;
            margin-right: -23px;
            margin-top: -23px;
            border-radius: 25em;
            font-weight: bolder;
        }

        #divErros {
            overflow: hidden; /* Para evitar que o conteúdo "escape" do container */
        }
    </style>

    <asp:HiddenField ID="txtPESSOA_ID" runat="server" />


    <div class="d-flex justify-content-center">
        <div class="p-3 mb-2 bg-danger text-white w-50" runat="server" id="divErros" visible="false">
            <button type="button" id="btnClose" data-element="<%= divErros.ClientID %>">
                <span aria-hidden="true">&times;</span>
            </button>
            <asp:Label runat="server" ID="lblErros" />
        </div>
    </div>

    <div style="display: flex; align-content: center;justify-content: center; margin: 0;">
        <div style="height: 500px;">
            <table width="100%">
                
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td class="pdr-10">
                                    <cc3:FieldTextBox ID="txt_PESSOAS_CPF_CNPJ" runat="server" ValueField="CPF" Width="300px" Style="padding: 5px;" CssClass="CPF" Obrigatorio="true" />
                                </td>
                                <td class="pdr-10">
                                    <cc3:FieldTextBox ID="txt_PESSOAS_NOME" runat="server" ValueField="Nome Completo" Width="300px" onkeyup="convertToUppercase(event);" 
                                        CssClass="input-cadastro" Obrigatorio="true" MaxLength="400" />
                                </td>
                                <td class="pdr-10">
                                    <cc3:FieldDropDown ID="ddl_PESSOAS_SEXO" runat="server" ValueField="Sexo" style="padding: 4px;" Width="150px" CssClass="input-cadastro">
                                        <asp:ListItem Text="Masculino" Value="M" Selected="True" />
                                        <asp:ListItem Text="Feminino" Value="F" />
                                    </cc3:FieldDropDown>                                
                                </td>
                                <td class="pdr-10">
                                    <cc3:FieldTextBox ID="txt_PESSOAS_DATA_NASC" runat="server" ValueField="Data de Nasc."
                                        Style="width: 100px;" CssClass="date input-cadastro" MaxLength="10" Obrigatorio="true" />
                                    <asp:ImageButton runat="Server" ID="ImageButton1" ImageUrl="~/Library/Images/icones/Calendario.gif"
                                        AlternateText="Visualizar Calendário" CausesValidation="false" /><br />
                                    <cc2:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_PESSOAS_DATA_NASC"
                                        PopupButtonID="ImageButton1" Animated="true" Format="dd/MM/yyyy" />
                                </td>
                            </tr>
                        </table>
        
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td class="pdr-10">
                                    <cc3:FieldTextBox ID="txt_PESSOAS_NOME_MAE" runat="server" ValueField="Nome Mãe" Width="300px" onkeyup="convertToUppercase(event);" 
                                        CssClass="input-cadastro" Obrigatorio="true" MaxLength="400" />
                                </td>
                                <td class="pdr-10">
                                    <cc3:FieldTextBox ID="txt_PESSOAS_CPF_MAE" runat="server" ValueField="CPF Mãe" Width="300px" Style="padding: 5px;" CssClass="CPF" Obrigatorio="true" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td class="pdr-10">
                                    <cc3:FieldTextBox ID="txt_PESSOAS_NOME_PAI" runat="server" ValueField="Nome Pai" Width="300px" onkeyup="convertToUppercase(event);" CssClass="input-cadastro" MaxLength="400" />
                                </td>
                                <td class="pdr-10">
                                    <cc3:FieldTextBox ID="txt_PESSOAS_CPF_PAI" runat="server" ValueField="CPF Pai" Width="300px" Style="padding: 5px;" CssClass="CPF" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td class="pdr-10">
                                    <cc3:FieldTextBox ID="txt_PESSOAS_TELEFONE_RESIDENCIAL" runat="server" ValueField="Telefone Residencial" Width="300px" CssClass="   input-cadastro"
                                        oninput="maskPhone(event)" maxlength="16" />
                                </td>
                                <td class="pdr-10">
                                    <cc3:FieldTextBox ID="txt_PESSOAS_TELEFONE_CELULAR" runat="server" ValueField="Telefone Celular" Width="300px" CssClass="input-cadastro" 
                                        oninput="maskPhone(event)" maxlength="16" Obrigatorio="true" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td class="pdr-10">
                                    <cc3:FieldTextBox ID="txt_PESSOAS_EMAIL" runat="server" ValueField="E-mail" Width="300px" CssClass="input-cadastro" MaxLength="400" />
                                </td>                            
                            </tr>
                        </table>
                    </td>
                </tr>
             </table>
        </div>
    </div>
    
    
    <%--<cc2:TabContainer ID="TabContainer1" runat="server" ScrollBars="Auto">
        <cc2:TabPanel ID="tabInformacoes" runat="server" HeaderText="Pessoa">
            <HeaderTemplate>
                Pessoa
            </HeaderTemplate>
            <ContentTemplate>
                <label>CPF</label>
                <cc3:FieldTextBox ID="txt_PESSOAS_CPF_CNPJ" runat="server" ValueField="CPF/CPNJ" Width="100px" />
            </ContentTemplate>
        </cc2:TabPanel>
        
        <!-- inicio da aba pessoa fisica -->
        <cc2:TabPanel ID="tabComplementar" runat="server" HeaderText="Dados Pessoais">
            <ContentTemplate>
                
            </ContentTemplate>
        </cc2:TabPanel>
        <!-- fim pessoa fisica -->
        
        <!-- inicio da aba pessoa juridica -->
        <cc2:TabPanel ID="TabPessoaJuridica" runat="server" HeaderText="Pessoa Jurídica">
            <ContentTemplate>
                
            </ContentTemplate>
        </cc2:TabPanel>
        <!-- fim pessoa Juridica -->
        
        <!-- inicio complemento -->
        <cc2:TabPanel ID="tabComplemento" runat="server" HeaderText="Complemento">
            <ContentTemplate>

            </ContentTemplate>
        </cc2:TabPanel>
    </cc2:TabContainer>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentToolBar" runat="Server">
    <cc1:ImageButtonHover ID="btnVoltar" runat="server" Imagem="../Library/Images/icones/voltar.gif"
        CausesValidation="false" Texto="Voltar" ToolTip="Clique aqui para Voltar" OnClick="btnVoltar_Click"></cc1:ImageButtonHover>
    <cc1:SeparadorToolBar ID="SeparadorToolBar7" Imagem="../Library/Images/Separador.gif"
        runat="server"></cc1:SeparadorToolBar>
    <cc1:ImageButtonHover ID="btnSalvar" runat="server" Imagem="../Library/Images/icones/Salvar.gif"
        CausesValidation="true" Texto="Salvar" ToolTip="Clique aqui para salvar" OnClick="btnSalvar_Click"></cc1:ImageButtonHover>
</asp:Content>