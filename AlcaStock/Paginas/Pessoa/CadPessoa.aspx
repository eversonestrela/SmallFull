<%@ Page Language="C#" MasterPageFile="~/MasterPages/Cadastro.master" AutoEventWireup="true" CodeFile="CadPessoa.aspx.cs" Inherits="Paginas_Pessoa_CadPessoa" Title="Cadastro de Pessoas" %>

<%@ Register Assembly="AGENDA.Controles" Namespace="AGENDA.Controles.UI.ButtonToolBar" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AGENDA.Controles" Namespace="AGENDA.Controles.UI" TagPrefix="cc3" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentCampos" runat="Server">
    <link href="../Library/JQuery/fontawesome/css/font-awesome.css" rel="stylesheet" />
    <link href="../Library/JQuery/3d-bold-navigation/css/style.css" rel="stylesheet" />
    <script src="../Library/JQuery/3d-bold-navigation/js/modernizr.js"></script>
    <link href="../Library/JQuery/css/ui-lightness/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
    <script src="../Library/JQuery/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../Library/JQuery/gridgallery/css/component.css" rel="stylesheet" />
    <link href="../Library/JQuery/jstree/themes/default/style.min.css" rel="stylesheet" />
    <script src="../Library/JQuery/jstree/jstree.min.js"></script>
    <script src="../Library/JQuery/gridgallery/js/imagesloaded.pkgd.min.js"></script>
    <script src="../Library/JQuery/gridgallery/js/masonry.pkgd.min.js"></script>
    <script src="../Library/JQuery/gridgallery/js/classie.js"></script>
    <script src="../Library/JQuery/gridgallery/js/cbpgridgallery.js"></script>
    <script src="../Library/Images/biometria/jquery.maphilight.min.js"></script>
    <script src="../Library/Scripts/jquery.meiomask.js" type="text/javascript"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.10/jquery.mask.js"></script>

    <style type="text/css">
        .grdAnexos .ui-sortable tr {
            cursor: move;
        }

        .grdAnexos .ui-sortable .disabled {
            cursor: default;
        }

        .grdAnexos .ui-sortable-placeholder {
            border: 1px dashed #CCC;
            background: #f6f2dd;
            height: 34px;
        }

        input[type=text] {
            text-transform: uppercase;
        }

        .borda {
            border: solid 1px #000;
        }

        .altura {
            padding-top: 5px;
            font-size: 10px;
        }

        .row_selected {
            background-color: #ffffcc !important;
        }

        .modal_marcadores2 {
            background-color: #fff;
        }

        .modal-dialog {
        }

        .modal-content {
            -webkit-box-shadow: 0 5px 5px -5px rgba(0,0,0,.1);
            -moz-box-shadow: 0 5px 5px -5px rgba(0,0,0,.1);
            box-shadow: 0 5px 5px -5px rgba(0,0,0,.1);
            border: 0;
            border-radius: 0;
        }

        .modal-header {
            padding: 15px;
            overflow: hidden;
            border-top-left-radius: 0;
            border-top-right-radius: 0;
            border: 0 !important;
            height: 30px;
            font-size: 14px;
        }

        .modal-body {
            padding: 0 20px 20px;
        }

        #dragTree a {
            font-size: 11px;
        }

        .botao_button {
            font-family: Tahoma;
            font-size: 11px;
            border-radius: 5px;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            cursor: pointer;
            cursor: hand;
            color: rgba(0,0,0,0.9);
            text-shadow: 1px 1px 0px rgba(255,255,255,0.8);
            border: 1px solid rgba(0,0,0,0.5);
            background: -webkit-gradient(linear,0% 0%,0% 100%,from(rgba(255,255,255,1)),to(rgba(185,185,185,1)));
            background: -moz-linear-gradient(top,rgba(255,255,255,1),rgba(185,185,185,1));
            padding: 2px 5px 2px 5px;
            border: 1px solid #999999;
        }

        .botao_button:hover {
            background: #EEEEEE;
            box-shadow: 0px 0px 2px rgba(0,0,0,0.4);
            -moz-box-shadow: 0px 0px 2px rgba(0,0,0,0.4);
            -webkit-box-shadow: 0px 0px 2px rgba(0,0,0,0.4);
        }

        .icon-md {
            font-size: 16px;
        }

        .text-xl {
            font-size: 52px;
        }

        .text-center {
            text-align: center;
        }

        .checkbox {
            position: relative;
            display: block;
            margin-top: 10px;
            margin-bottom: 10px;
        }

        .vakata-context {
            z-index: 9999;
        }

        .grid figcaption {
            padding: 5px;
            height: 50px;
        }

        .ui-sortable-placeholder {
            border: 1px dashed #CCC;
            background: #f6f2dd;
            height: 489px;
        }

        .table-responsive {
            display: block;
            clear: both;
        }

        .dataTables_wrapper {
            position: relative;
            clear: both;
        }

        .dataTables_wrapper .dataTables_info {
            clear: both;
            float: left;
            padding-top: 0.755em;
        }

        .pagination {
            display: inline-block;
            padding-left: 0;
            margin: 20px 0;
            border-radius: 4px;
        }

        .pagination > li {
            display: inline;
        }

        .pagination > li > a, .pagination > li > span {
            position: relative;
            float: left;
            padding: 6px 12px;
            margin-left: -1px;
            line-height: 1.42857143;
            color: #000;
            text-decoration: none;
            background-color: #fff;
            border: 1px solid #ddd;
        }

        .pagination > li:first-child > a, .pagination > li:first-child > span {
            margin-left: 0;
            border-top-left-radius: 4px;
            border-bottom-left-radius: 4px;
        }

        .pagination > li:last-child > a, .pagination > li:last-child > span {
            border-top-right-radius: 4px;
            border-bottom-right-radius: 4px;
        }

        .pagination > li > a:focus, .pagination > li > a:hover, .pagination > li > span:focus, .pagination > li > span:hover {
            z-index: 3;
            color: rgba(0,0,0,0.9);
            background-color: #eee;
            border-color: #ddd;
        }

        .pagination > .active > a, .pagination > .active > a:focus, .pagination > .active > a:hover, .pagination > .active > span, .pagination > .active > span:focus, .pagination > .active > span:hover {
            z-index: 2;
            color: #fff;
            cursor: default;
            background-color: rgba(0,0,0,0.7);
            border-color: #ddd;
        }

        .pagination > .disabled > a, .pagination > .disabled > a:focus, .pagination > .disabled > a:hover, .pagination > .disabled > span, .pagination > .disabled > span:focus, .pagination > .disabled > span:hover {
            color: rgba(0,0,0,0.9);
            cursor: not-allowed;
            background-color: #fff;
            border-color: #ddd;
        }

        .pagination-lg > li > a, .pagination-lg > li > span {
            padding: 10px 16px;
            font-size: 18px;
            line-height: 1.3333333;
        }

        .pagination-lg > li:first-child > a, .pagination-lg > li:first-child > span {
            border-top-left-radius: 6px;
            border-bottom-left-radius: 6px;
        }

        .pagination-lg > li:last-child > a, .pagination-lg > li:last-child > span {
            border-top-right-radius: 6px;
            border-bottom-right-radius: 6px;
        }

        .pagination-sm > li > a, .pagination-sm > li > span {
            padding: 5px 10px;
            font-size: 12px;
            line-height: 1.5;
        }

        .pagination-sm > li:first-child > a, .pagination-sm > li:first-child > span {
            border-top-left-radius: 3px;
            border-bottom-left-radius: 3px;
        }

        .pagination-sm > li:last-child > a, .pagination-sm > li:last-child > span {
            border-top-right-radius: 3px;
            border-bottom-right-radius: 3px;
        }

        .table.rotulo {
            width: 100%;
            border-collapse: collapse;
        }

        .table.rotulo thead tr {
            color: Black;
            background-color: #E0DFE3;
            border-color: #CCCCCC;
            font-weight: bold;
        }

        .table.rotulo tbody tr {
            color: black;
            background-color: white;
            border-color: rgb(204, 204, 204);
        }

        .table.rotulo tbody tr:hover {
            background-color: #E0DFE3;
        }

        .mb-5 {
            margin-bottom: 5px;
        }

        .mb-10 {
            margin-bottom: 10px;
        }
    </style>

    <asp:HiddenField ID="txtPESSOA_ID" runat="server" />
    <cc2:TabContainer ID="TabContainer1" runat="server" ScrollBars="Auto">
        <cc2:TabPanel ID="tabInformacoes" runat="server" HeaderText="Pessoa">
            <HeaderTemplate>
                Pessoa
            </HeaderTemplate>
            <ContentTemplate>
                <div align="left">
                    <table width="680px">
                        <tr>
                            <td colspan="2">
                                <cc3:FieldDropDown ID="ddlPessoaTipo"
                                    runat="server" ValueField="Tipo Pessoa" Obrigatorio="True">
                                    <asp:ListItem Value="F" Selected="True">Física</asp:ListItem>
                                    <asp:ListItem Value="J">Jurídica</asp:ListItem>
                                </cc3:FieldDropDown>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTipo" runat="server" ErrorMessage="Informe a Pessoa!"
                                    Display="None" ControlToValidate="ddlPessoaTipo" SetFocusOnError="True" />
                            </td>
                            <td rowspan="5" valign="top" align="right">
                                <asp:Image ID="imageFoto1" runat="server" Visible="False" Width="150px" BorderColor="#CCCCCC"
                                    BorderWidth="1px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <cc3:FieldTextBox ID="txtPessoaNome" Width="250px" runat="server" ValueField="Nome" onBLur="SuperTrim(this);"
                                    CssClass="UPPER" Obrigatorio="True" ToolTip="Informe nome e sobrenome" onkeypress="return somente_txt(event);" />
                                <asp:RequiredFieldValidator ID="rvlPesquisa" runat="server" ErrorMessage="Informe o Nome!"
                                    Display="None" ControlToValidate="txtPessoaNome" SetFocusOnError="True" />
                            </td>
                            <td>
                                <cc3:FieldTextBox ID="txtPessoaCPF" runat="server" ValueField="CPF" Obrigatorio="True"
                                    Width="90px" MaxLength="14" ToolTip="Informe os números do CPF (Ex:00000000000)" />
                                <asp:RequiredFieldValidator ID="rqfCPF" runat="server" ErrorMessage="Informe o CPF!"
                                    Display="None" ControlToValidate="txtPessoaCPF" SetFocusOnError="True" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <cc3:FieldTextBox ID="txtPessoaRazao" Width="250px" runat="server" ValueField="Razão Social" onBLur="SuperTrim(this);"
                                    CssClass="UPPER" Obrigatorio="True" ToolTip="Informe a Razão Social" Visible="False" />
                                <asp:RequiredFieldValidator ID="rqfPessoaRazao" runat="server" ErrorMessage="Informe a Razão!"
                                    Display="None" ControlToValidate="txtPessoaRazao" SetFocusOnError="True" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <cc3:FieldDropDown ID="ddlPessoaSexo" runat="server" Obrigatorio="True" ValueField="Sexo">
                                    <asp:ListItem Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="M">Masculino</asp:ListItem>
                                    <asp:ListItem Value="F">Feminino</asp:ListItem>
                                </cc3:FieldDropDown>
                                <asp:RequiredFieldValidator ID="rqfSexo" runat="server" ErrorMessage="Informe o Sexo!"
                                    Display="None" ControlToValidate="ddlPessoaSexo" SetFocusOnError="True" />
                            </td>
                            <td>
                                <cc3:FieldTextBox ID="clpPessoaDataNasc" runat="server" MaxLength="8" Obrigatorio="True" type="search" autocomplete="off"
                                    Style="width: 90px;" ToolTip="Informe a data de nascimento (Ex:DD/MM/AAAA)" ValueField="Data de Nascimento" />

                                <asp:RequiredFieldValidator ID="rfvclpPessoaDataNasc" runat="server" ControlToValidate="clpPessoaDataNasc"
                                    Display="None" ErrorMessage="Informe a Data de Nascimento!" SetFocusOnError="True" />
                                <%--<asp:CompareValidator ID="cvPessoaDataNasc" runat="server" ControlToValidate="clpPessoaDataNasc"
                                    Operator="GreaterThan" ValueToCompare="01/01/1890" Type="Date" ErrorMessage="Data Inválida."
                                    Display="None" />
                                <asp:CompareValidator ID="cvPessoaDataNasc2" runat="server" ControlToValidate="clpPessoaDataNasc"
                                    Operator="LessThan" ValueToCompare="01/01/2100" Type="Date" ErrorMessage="Data Inválida."
                                    Display="None" />--%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <cc3:FieldTextBox ID="txtPessoaNomeMae" runat="server" CssClass="UPPER" Obrigatorio="True" onBLur="SuperTrim(this);"
                                    onFocus="nextfieldmae ='done';" ToolTip="Informe nome e sobrenome da Mãe" ValueField="Nome da Mãe"
                                    Width="250px" onkeypress="return somente_txt(event);" />
                                <asp:RequiredFieldValidator ID="rqfNomeMae" runat="server" ErrorMessage="Informe o Nome da Mãe!"
                                    Display="None" ControlToValidate="txtPessoaNomeMae" SetFocusOnError="True" type="text" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </cc2:TabPanel>
        <!-- inicio da aba pessoa fisica -->
        <cc2:TabPanel ID="tabComplementar" runat="server" HeaderText="Dados Pessoais">
            <ContentTemplate>
                <table width="680px">
                    <tr>
                        <td>
                            <cc3:FieldLabel ID="lblPessoaNome" runat="server" ValueField="Nome" />
                        </td>
                        <td>
                            <cc3:FieldLabel ID="lblPessoaCPF" runat="server" ValueField="CPF" />
                        </td>
                        <td rowspan="10" valign="top" align="right">
                            <center>
                                <asp:Image ID="imageFoto" Width="150px" runat="server" Visible="false" BorderColor="#CCCCCC"
                                    BorderWidth="1px" />
                                <div style="width: 100%;" id="div_possui_biometria" runat="server" visible="false">Há biometria cadastrada para este(a) segurado(a).</div>
                            </center>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 40px">
                            <cc3:FieldLabel ID="lblPessoaDataNasc" runat="server" ValueField="Data de Nascimento" />
                        </td>
                        <td style="height: 40px">
                            <cc3:FieldLabel ID="lblPessoaSexo" runat="server" ValueField="Sexo" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc3:FieldLabel ID="lblPessoaNomeMae" runat="server" ValueField="Nome da Mãe" />
                        </td>
                        <td>
                            <cc3:FieldTextBox ID="txtPessoaNomePAI" runat="server" ValueField="Nome do Pai" Width="250px"
                                CssClass="UPPER" ToolTip="Informe nome e sobrenome do Pai" onkeypress="return somente_txt(event);" />
                            <asp:RequiredFieldValidator ID="rqfPai" runat="server" ErrorMessage="Informe o Nome do Pai!"
                                Display="None" ControlToValidate="txtPessoaNomePAI" SetFocusOnError="True" Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc3:FieldTextBox ID="txtPessoaCPFMae" runat="server" ValueField="CPF da Mãe" Width="100px"
                                CssClass="UPPER" ToolTip="Informe o CPF da Mãe" />
                            <asp:RequiredFieldValidator ID="rqfCPFMae" runat="server" ErrorMessage="Informe o CPF da Mãe!"
                                Display="None" ControlToValidate="txtPessoaCPFMae" SetFocusOnError="True" Enabled="false" />
                        </td>
                        <td>
                            <cc3:FieldTextBox ID="txtPessoaCPFPai" runat="server" ValueField="CPF do Pai" Width="100px"
                                CssClass="UPPER" ToolTip="Informe o CPF do Pai" />
                            <asp:RequiredFieldValidator ID="rqfCPFPai" runat="server" ErrorMessage="Informe o CPF do Pai!"
                                Display="None" ControlToValidate="txtPessoaCPFPai" SetFocusOnError="True" Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc3:FieldDropDown ID="ddlPessoaUFCidadeNat" runat="server"
                                ValueField="UF de Nascimento" ToolTip="Estado de Nascimento">
                            </cc3:FieldDropDown>
                        </td>
                        <td>
                            <cc3:FieldDropDown ID="ddlPessoaCidadeNat" runat="server" ValueField="Naturalidade"
                                Width="250px" ToolTip="Cidade de Nascimento">
                            </cc3:FieldDropDown>
                            <asp:RequiredFieldValidator ID="rqfNaturalidade" runat="server" ErrorMessage="Informe a Naturalidade!"
                                Enabled="false" Display="None" ControlToValidate="ddlPessoaCidadeNat" SetFocusOnError="True" />
                            <cc2:ListSearchExtender ID="lseCidadeNaturalidade" PromptPosition="Bottom" runat="server"
                                TargetControlID="ddlPessoaCidadeNat" PromptText=" " />
                            <cc3:FieldTextBox ID="txtPessoaNaturalidadeExterior" runat="server" ValueField="Naturalidade"
                                ToolTip="Informe a Naturalidade" Visible="false" MaxLength="30" Width="250px" />
                            <asp:RequiredFieldValidator ID="rqfNaturalidadeForaPais" runat="server" ErrorMessage="Informe a Naturalidade!"
                                Display="None" ControlToValidate="txtPessoaNaturalidadeExterior" SetFocusOnError="True"
                                Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc3:FieldDropDown ID="ddlPessoaEstadoCivil" runat="server" ValueField="Estado Civil"
                                ToolTip="Informe o estado civil">
                                <asp:ListItem Value="1">SOLTEIRO(A)</asp:ListItem>
                                <asp:ListItem Value="2">CASADO(A)</asp:ListItem>
                                <asp:ListItem Value="3">VIÚVO(A)</asp:ListItem>
                                <asp:ListItem Value="10">SEPARADO(A) DE FATO</asp:ListItem>
                                <asp:ListItem Value="4">SEPARADO(A) JUDICIALMENTE</asp:ListItem>
                                <asp:ListItem Value="5">DIVORCIADO(A)</asp:ListItem>
                                <asp:ListItem Value="6">UNIÃO ESTÁVEL</asp:ListItem>
                                <asp:ListItem Value="9">OUTROS</asp:ListItem>
                            </cc3:FieldDropDown>
                            <asp:RequiredFieldValidator ID="rqfEstadoCivil" runat="server" ErrorMessage="Informe o Estado Civil!"
                                Display="None" ControlToValidate="ddlPessoaEstadoCivil" SetFocusOnError="True"
                                Enabled="false" />
                        </td>
                        <td class="rotulo">
                            <table>
                                <tr>
                                    <td>
                                        <cc3:FieldDropDown ID="ddlRegimeCasamento" runat="server" ValueField="Regime de Casamento"
                                            ToolTip="Informe o Regime de Casamento" Visible="false" Width="250px">
                                            <asp:ListItem Text="Selecione" Value="" />
                                            <asp:ListItem Value="1">Comunhão Parcial de Bens</asp:ListItem>
                                            <asp:ListItem Value="2">Comunhão Universal</asp:ListItem>
                                            <asp:ListItem Value="3">Separação Total de Bens</asp:ListItem>
                                            <asp:ListItem Value="4">Participação Final nos Aquestos</asp:ListItem>
                                            <asp:ListItem Value="5">Comunhão Bens</asp:ListItem>
                                        </cc3:FieldDropDown>
                                        <asp:RequiredFieldValidator ID="rqvRegimeCasamento" runat="server" ErrorMessage="Informe o Regime de Casamento!"
                                            Display="None" ControlToValidate="ddlRegimeCasamento" SetFocusOnError="True" Enabled="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <cc3:FieldDropDown ID="ddlPessoaNacionalidade" runat="server" ValueField="Nacionalidade:"
                                            Width="250px" ToolTip="Pais de Nascimento" CausesValidation="false" />
                                        <asp:RequiredFieldValidator ID="rqfNacionalidade" runat="server" ErrorMessage="Informe a Nacionalidade!"
                                            Display="None" ControlToValidate="ddlPessoaNacionalidade" SetFocusOnError="True"
                                            Enabled="false" />
                                    </td>
                                    <td style="padding-left: 15px;" id="td_naturalizado" runat="server">
                                        <fieldset>
                                            <legend style="color: brown"><b>Naturalizado</b></legend>
                                            <cc3:FieldRadioButtonList runat="server" ID="rblNaturalizado" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Sim" Value="S" />
                                                <asp:ListItem Text="Não" Value="N" />
                                            </cc3:FieldRadioButtonList>
                                            <asp:RequiredFieldValidator ID="rqfNaturalizado" runat="server" ErrorMessage="Informe a Naturalidade."
                                                Display="None" ControlToValidate="rblNaturalizado" SetFocusOnError="True" />
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc3:FieldDropDown ID="ddlPessoaPrtMolestia" Enabled="false" runat="server" ValueField="Portador de moléstia grave">
                                <asp:ListItem Value="N">N&#227;o</asp:ListItem>
                                <asp:ListItem Value="S">Sim</asp:ListItem>
                            </cc3:FieldDropDown>
                        </td>
                        <td>
                            <cc3:FieldDropDown ID="ddlPessoaIsencaoContrib" Enabled="false" runat="server" ValueField="Portador de doença incapacitante">
                                <asp:ListItem Value="N">N&#227;o</asp:ListItem>
                                <asp:ListItem Value="S">Sim</asp:ListItem>
                            </cc3:FieldDropDown>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc3:FieldDropDown ID="dllPessoaPortadorNecEspeciais" runat="server" ValueField="Portador de necessidades especiais">
                                <asp:ListItem Value="N">N&#227;o</asp:ListItem>
                                <asp:ListItem Value="S">Sim</asp:ListItem>
                            </cc3:FieldDropDown>
                        </td>
                        <td>
                            <cc3:FieldDropDown ID="ddlEscolaridade" runat="server" ValueField="Escolaridade"
                                Width="200px" ToolTip="Informe a Escolaridade">
                            </cc3:FieldDropDown>
                            <asp:RequiredFieldValidator ID="rqfEscolaridade" runat="server" ErrorMessage="Informe a Escolaridade!"
                                Display="None" ControlToValidate="ddlEscolaridade" SetFocusOnError="True" Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc3:FieldDropDown ID="ddlPessoaRaca" runat="server" ValueField="Raça" Width="100px"
                                ToolTip="Informe sua Raça" />
                        </td>
                        <td class="rotulo">
                            <div style="float: left;">
                                <b>Selecione o arquivo da Foto:</b><br />
                                <asp:FileUpload ID="fuFoto" Width="195px" runat="server" onchange="HabilitaBotao();" />
                            </div>
                            <div style="float: left; padding-left: 47px; padding-top: 13px;">
                                <asp:Button ID="btnInserirFoto" runat="server" Text="Inserir Foto" Enabled="false"
                                    />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc3:FieldDropDown ID="ddlTPSanguineo" runat="server" ValueField="Tipo Sanguíneo" ToolTip="Informe o Tipo Sanguíneo">
                                <asp:ListItem Text="" Value="0" Selected="True" />
                                <asp:ListItem Text="A+" Value="1" />
                                <asp:ListItem Text="A-" Value="2" />
                                <asp:ListItem Text="B+" Value="3" />
                                <asp:ListItem Text="B-" Value="4" />
                                <asp:ListItem Text="O+" Value="5" />
                                <asp:ListItem Text="O-" Value="6" />
                                <asp:ListItem Text="AB+" Value="7" />
                                <asp:ListItem Text="AB-" Value="8" />
                            </cc3:FieldDropDown>
                        </td>
                        <td>
                            <fieldset style="width: 105px;">
                                <legend class="rotulo"><b>Doador de Órgãos</b></legend>
                                <asp:RadioButtonList CssClass="rotulo" ID="rdlDoador" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Sim" Value="S" />
                                    <asp:ListItem Text="Não" Value="N" Selected="True" />
                                </asp:RadioButtonList>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="rotulo" style="padding-top: 10px;">
                            <div>
                                <b>Documentos</b><br />
                            </div>
                            <div>
                                <img src="../Library/Images/DotBlack.jpg" alt="" width="100%" height="1" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding-left: 15px; padding-bottom: 10px">
                                        <cc3:FieldTextBox ID="txtPessoaRGNumero" runat="server" ValueField="Número do RG"
                                            ToolTip="Informe o Número do Registro Geral" />
                                        <asp:RequiredFieldValidator ID="rqfRG" runat="server" ErrorMessage="Informe o Número do RG!"
                                            Display="None" ControlToValidate="txtPessoaRGNumero" SetFocusOnError="True" Enabled="false" />
                                    </td>
                                    <td style="padding-left: 15px; padding-bottom: 10px">
                                        <cc3:FieldTextBox ID="txtPessoaRGOrgEmissor" runat="server" ValueField="Órgão" MaxLength="10"
                                            ToolTip="Informe o órgão do Registro Geral" />
                                        <asp:RequiredFieldValidator ID="rqfRGOrgao" runat="server" ErrorMessage="Informe o Órgão do RG!"
                                            Display="None" ControlToValidate="txtPessoaRGOrgEmissor" SetFocusOnError="True"
                                            Enabled="false" />
                                    </td>
                                    <td>
                                        <table width="220">
                                            <tr>
                                                <td style="padding-left: 15px; padding-bottom: 10px">
                                                    <cc3:FieldDropDown ID="ddlPessoaRGUF" runat="server" ValueField="UF" ToolTip="Informe o Estado da Expedição do RG" />
                                                </td>
                                                <td style="padding-left: 15px; padding-bottom: 10px">
                                                    <cc3:FieldTextBox ID="clpPessoaRGDtaEms" ValueField="Data de Expedição" runat="server"
                                                        Style="width: 90px;" type="search" autocomplete="off" ToolTip="Informe a data de Expedição no formato DD/MM/AAAA" />


                                                    <asp:CompareValidator ID="CompareValidatorDataEmRg" ErrorMessage="Data de expedição do RG está inválida" ControlToValidate="clpPessoaRGDtaEms" runat="server" Type="Date"
                                                        Operator="DataTypeCheck" SetFocusOnError="true" Display="None" Enabled="false" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="padding-left: 15px; padding-bottom: 10px" rowspan="3" valign="top">
                                        <fieldset>
                                            <legend class="rotulo"><b>Certidão de Nascimento/Casamento</b></legend>
                                            <table>
                                                <tr>
                                                    <td colspan="3" id="tdCartorio" runat="server">
                                                        <cc3:FieldTextBox ID="txtCartorio" runat="server" ValueField="Cartório" MaxLength="100" Width="435px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <cc3:FieldTextBox ID="txtNTermo" runat="server" ValueField="Nº do Termo" MaxLength="15" />
                                                    </td>
                                                    <td>
                                                        <cc3:FieldTextBox ID="txtNFolha" runat="server" ValueField="Nº da Folha" MaxLength="5" />
                                                    </td>
                                                    <td>
                                                        <cc3:FieldTextBox ID="txtNLivro" runat="server" ValueField="Nº do Livro" MaxLength="10" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <cc3:FieldTextBox ID="txtNMat" runat="server" ValueField="Nº Matrícula" MaxLength="35" Width="435px" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 15px; padding-bottom: 10px">
                                        <cc3:FieldTextBox ID="txtPessoaTituloNum" runat="server" ValueField="Título de Eleitor"
                                            MaxLength="12" ToolTip="Informe o Número do Título de Eleitor" />
                                        <cc2:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtPessoaTituloNum"
                                            FilterType="Custom, Numbers" ValidChars="-." />
                                        <asp:RequiredFieldValidator ID="rqfTitulo" runat="server" ErrorMessage="Informe o Título de Eleitor!"
                                            Display="None" ControlToValidate="txtPessoaTituloNum" SetFocusOnError="True"
                                            Enabled="false" />
                                    </td>
                                    <td style="padding-left: 15px; padding-bottom: 10px">
                                        <cc3:FieldTextBox ID="txtPessoaTituloZona" runat="server" ValueField="Zona Eleitoral"
                                            MaxLength="3" ToolTip="Informe o número da Zona Eleitoral do Título de Eleitor" />
                                        <cc2:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txtPessoaTituloZona"
                                            FilterType="Custom, Numbers" ValidChars="-." />
                                        <asp:RequiredFieldValidator ID="rqfTituloZona" runat="server" ErrorMessage="Informe a Zona do Título de Eleitor!"
                                            Display="None" ControlToValidate="txtPessoaTituloZona" SetFocusOnError="True"
                                            Enabled="false" />
                                    </td>
                                    <td style="padding-left: 15px; padding-bottom: 10px">
                                        <cc3:FieldTextBox ID="txtPessoaTituloSecao" runat="server" ValueField="Seção" MaxLength="4"
                                            ToolTip="Informe o Número da Seção do Título de Eleitor" />
                                        <cc2:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txtPessoaTituloSecao"
                                            FilterType="Custom, Numbers" ValidChars="-." />
                                        <asp:RequiredFieldValidator ID="rqfTituloSecao" runat="server" ErrorMessage="Informe a Seção do Título de Eleitor!"
                                            Display="None" ControlToValidate="txtPessoaTituloSecao" SetFocusOnError="True"
                                            Enabled="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 15px; padding-bottom: 10px">
                                        <cc3:FieldTextBox ID="txtPessoaPIS" runat="server" ValueField="PIS/PASEP" MaxLength="14"
                                            OnBlur="VerificaPIS();" ToolTip="Informe o Número do PIS ou PASEP" />
                                        <asp:Button ID="btnValidaPISPasep" runat="server"
                                            Style="display: none;" />
                                        <asp:RequiredFieldValidator ID="rqfPIS" runat="server" ErrorMessage="Informe o PIS!"
                                            Display="None" ControlToValidate="txtPessoaPIS" SetFocusOnError="True" Enabled="false" />
                                    </td>
                                    <td style="padding-left: 15px; padding-bottom: 10px">
                                        <cc3:FieldTextBox ID="txtPessoaRESERVISTA" runat="server" ValueField="Reservista"
                                            MaxLength="30" ToolTip="Informe o Número da Reservista!" />
                                    </td>
                                    <td style="padding-left: 15px; padding-bottom: 10px">
                                        <cc3:FieldTextBox ID="txtPessoaCNH" runat="server" ValueField="CNH" MaxLength="30"
                                            ToolTip="Informe o Número da CNH!" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="rotulo" style="padding-top: 10px;">
                            <div>
                                <b>Carteira de Trabalho</b><br />
                            </div>
                            <div>
                                <img src="../Library/Images/DotBlack.jpg" alt="" width="100%" height="1" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <cc3:FieldTextBox ID="txtPessoaCTPSNum" runat="server" ValueField="Número CTPS" ToolTip="Informe o Número da Carteira de Trabalho" />
                                        <cc2:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" TargetControlID="txtPessoaCTPSNum"
                                            FilterType="Custom, Numbers" ValidChars="-." />
                                        <asp:RequiredFieldValidator ID="rqfCTPS" runat="server" ErrorMessage="Informe o Número da CTPS!"
                                            Display="None" ControlToValidate="txtPessoaCTPSNum" SetFocusOnError="True" Enabled="false" />
                                    </td>
                                    <td>
                                        <cc3:FieldTextBox ID="txtPessoaCTPSSerie" runat="server" ValueField="Série CTPS"
                                            ToolTip="Informe o Número da Série da Carteira de Trabalho" MaxLength="15" />
                                        <asp:RequiredFieldValidator ID="rqfCTPSSerie" runat="server" ErrorMessage="Informe o Número de Série da CTPS!"
                                            Display="None" ControlToValidate="txtPessoaCTPSSerie" SetFocusOnError="True"
                                            Enabled="false" />
                                    </td>
                                    <td>
                                        <cc3:FieldTextBox ID="clpPessoaCTPSDtaEms" ValueField="Data de Emissão" runat="server" type="search" autocomplete="off"
                                            Style="width: 90px;" ToolTip="Informe a Data de Emissão da Carteira de trabalho em formato DD/MM/AAAA" />
                                        <asp:CompareValidator ID="CompareValidator1" ErrorMessage="Data de emissão da Carteira de trabalho está inválida" ControlToValidate="clpPessoaCTPSDtaEms" runat="server" Type="Date"
                                            Operator="DataTypeCheck" SetFocusOnError="true" Display="None" Enabled="false" />
                                        <asp:RequiredFieldValidator ID="rqfCTPSDataEms" runat="server" ErrorMessage="Informe a Data de Emissão da CTPS!"
                                            Display="None" ControlToValidate="clpPessoaCTPSDtaEms" SetFocusOnError="True"
                                            Enabled="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <cc3:FieldDropDown ID="ddlPessoaCTPSUF" runat="server" ValueField="UF CTPS" ToolTip="Informe o Estado da Expedição da Carteira de Trabalho">
                                        </cc3:FieldDropDown>
                                        <asp:RequiredFieldValidator ID="rqfCTPSUF" runat="server" ErrorMessage="Informe a UF da CTPS!"
                                            Display="None" ControlToValidate="ddlPessoaCTPSUF" SetFocusOnError="True" Enabled="false" />
                                    </td>
                                    <td colspan="2">
                                        <cc3:FieldTextBox ID="txtPessoaLocalExpCTPS" runat="server" ValueField="Local de Expedição CTPS"
                                            ToolTip="Informe a Cidade de Expedição da Carteira de Trabalho" onFocus="nextfieldctps ='done';" />
                                        <asp:RequiredFieldValidator ID="rqfCTPSLocal" runat="server" ErrorMessage="Informe o Local de Expedição da CTPS!"
                                            Display="None" ControlToValidate="txtPessoaLocalExpCTPS" SetFocusOnError="True"
                                            Enabled="false" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="rotulo" style="padding-top: 10px;">
                            <div>
                                <b>Carteira Profissional</b><br />
                            </div>
                            <div>
                                <img src="../Library/Images/DotBlack.jpg" alt="" width="100%" height="1" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <cc3:FieldTextBox ID="txtPessoaCONSELHO_CART_PROF" runat="server" ValueField="Conselho"
                                            ToolTip="Informe o Conselho da Carteira do Profissional" MaxLength="30" />
                                    </td>
                                    <td>
                                        <cc3:FieldTextBox ID="txtPessoaNUMERO_CART_PROF" runat="server" ValueField="Número"
                                            ToolTip="Informe o Número da Carteira do Profissional" MaxLength="30" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc2:TabPanel>
        <!-- fim pessoa fisica -->
        <!-- inicio da aba pessoa juridica -->
        <cc2:TabPanel ID="TabPessoaJuridica" runat="server" HeaderText="Pessoa Jurídica">
            <ContentTemplate>
                <div id="Div1" style="position: absolute; margin-left: 480px; margin-top: 10px; display: none">
                    <asp:Image ID="image1" runat="server" Width="100px" Height="100px" Visible="false"
                        BorderColor="#CCCCCC" BorderWidth="1px" />
                </div>
                <table width="680">
                    <tr>
                        <td>
                            <cc3:FieldLabel ID="lblPessoaTipo" runat="server" ValueField="Tipo Pessoa" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc3:FieldLabel ID="lblPessoaFantasia" runat="server" ValueField="Nome Fantasia" />
                        </td>
                        <td>
                            <cc3:FieldLabel ID="lblPessoaRazao" runat="server" ValueField="Razao Social" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 40px">
                            <cc3:FieldLabel ID="lblPessoaCnpj" runat="server" ValueField="CNPJ" />
                        </td>
                        <td style="height: 40px">
                            <cc3:FieldTextBox ID="txtPessoaInscricaoEstadual" runat="server" ValueField="Inscricao Estadual"
                                Width="100px" CssClass="UPPER" ToolTip="Informe a inscrição estadual" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc3:FieldTextBox ID="txtPessoaInscricaoMunicipal" runat="server" ValueField="Inscricao Municipal"
                                Width="100px" CssClass="UPPER" ToolTip="Informe a Inscricao Municipal" />
                        </td>
                        <td>
                            <cc3:FieldTextBox ID="txtPessoaContato" runat="server" ValueField="Contato" Width="100px"
                                CssClass="UPPER" ToolTip="Informe o contato da empresa" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc2:TabPanel>
        <!-- fim pessoa Juridica -->
        <!-- inicio complemento -->
        <cc2:TabPanel ID="tabComplemento" runat="server" HeaderText="Complemento">
            <ContentTemplate>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td colspan="2">
                                    <cc3:FieldDropDown ID="ddlTipoContrato" runat="server" Width="600" ValueField="Tipo de Contrato">
                                        <asp:ListItem Text="<-Selecione->" Value="" Selected="True" />
                                        <asp:ListItem Text="Contrato de trabalho por prazo indeterminado" Value="1" />
                                        <asp:ListItem Text="Contrato de trabalho por prazo determinado com cláusula assecuratória de direito recíproco de rescisão antecipada" Value="2" />
                                        <asp:ListItem Text="Contrato de trabalho por prazo determinado sem cláusula assecuratória de direito recíproco de rescisão antecipada" Value="3" />
                                    </cc3:FieldDropDown>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table>
                                        <tr>
                                            <td colspan="3">
                                                <cc3:FieldTextBox ID="txtPessoaEnderecoCEP" runat="server" ValueField="CEP"
                                                    data-input-mask="99.999-999" data-plugin-masked-input placeholder="__.___-___"
                                                    MaxLength="10" CssClass="custom-margin" ToolTip="Informe os Números do CEP (Ex:78.043-305)"
                                                    />
                                                <asp:RequiredFieldValidator ID="rqfCEP" runat="server" ErrorMessage="Informe o CEP!"
                                                    Display="None" ControlToValidate="txtPessoaEnderecoCEP" SetFocusOnError="True"
                                                    Enabled="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <cc3:FieldDropDown ID="ddlPessoaTipoLogradouro" runat="server" Width="100px" ValueField="Tipo Logradouro">
                                                    <asp:ListItem Text="<-Selecione->" Value="" Selected="True" />
                                                    <asp:ListItem Text="Avenida" Value="8" />
                                                    <asp:ListItem Text="Rua" Value="81" />
                                                    <asp:ListItem Text="Travessa" Value="100" />
                                                    <asp:ListItem Text="Quadra" Value="77" />
                                                    <asp:ListItem Text="Praça" Value="65" />
                                                    <asp:ListItem Text="Vila" Value="104" />
                                                    <asp:ListItem Text="Alameda" Value="4" />
                                                    <asp:ListItem Text="Estrada" Value="31" />
                                                    <asp:ListItem Text="Rodovia" Value="90" />
                                                </cc3:FieldDropDown>
                                                <asp:RequiredFieldValidator ID="rqfTipoLogradouro" runat="server" ErrorMessage="Informe o Tipo Logradouro!"
                                                    Display="None" ControlToValidate="ddlPessoaTipoLogradouro" SetFocusOnError="True"
                                                    Enabled="false" />

                                            </td>
                                            <td>
                                                <cc3:FieldTextBox ID="txtPessoaEnderecoRua" runat="server" ValueField="Descrição"
                                                    CssClass="UPPER" Width="300px" ToolTip="Informe a Descrição do Tipo Logradouro" />
                                                <asp:RequiredFieldValidator ID="rqfEndereco" runat="server" ErrorMessage="Informe a Descrição do Tipo Logradouro!"
                                                    Display="None" ControlToValidate="txtPessoaEnderecoRua" SetFocusOnError="True"
                                                    Enabled="false" />
                                            </td>
                                            <td>
                                                <cc3:FieldTextBox ID="txtPessoaEnderecoNumero" runat="server" ValueField="Número"
                                                    ToolTip="Informe o Número da Residência" Width="100" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table>
                                        <tr>
                                            <td>
                                                <cc3:FieldTextBox ID="txtPessoaEnderecoBairro" runat="server" ValueField="Bairro"
                                                    CssClass="UPPER" Width="250px" ToolTip="Informe o Bairro" />
                                                <asp:RequiredFieldValidator ID="rqfBairro" runat="server" ErrorMessage="Informe o Bairro!"
                                                    Display="None" ControlToValidate="txtPessoaEnderecoBairro" SetFocusOnError="True"
                                                    Enabled="false" />
                                            </td>
                                            <td>
                                                <table id="fBrasil" runat="server">
                                                    <tr>
                                                        <td>
                                                            <cc3:FieldDropDown ID="ddlPessoaEnderecoUF" runat="server" Width="100" ValueField="UF de Residência"
                                                                ToolTip="Informe o Estado da Residência">
                                                            </cc3:FieldDropDown>
                                                            <asp:HiddenField ID="hddCidadeEnde" runat="server" />
                                                        </td>
                                                        <td>
                                                            <cc3:FieldDropDown ID="ddlPessoaCidadeEnde" runat="server" ValueField="Cidade de Residência"
                                                                Width="250px" ToolTip="Informe a Cidade da Residência" />
                                                            <cc2:ListSearchExtender ID="lseCidadeEnd" PromptPosition="Bottom" runat="server"
                                                                TargetControlID="ddlPessoaCidadeEnde" PromptText=" " />
                                                            <asp:RequiredFieldValidator ID="rqfCidadeEnd" runat="server" ErrorMessage="Informe a Cidade de Residência!"
                                                                Display="None" ControlToValidate="ddlPessoaCidadeEnde" SetFocusOnError="True"
                                                                Enabled="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table>
                                        <tr>
                                            <td class="rotulo">
                                                <cc3:FieldDropDown ID="ddlPessoaPais" runat="server" ValueField="País" Width="250px"
                                                    ToolTip="País em que se encontra" />
                                                <asp:RequiredFieldValidator ID="rqfPais" runat="server" ErrorMessage="Informe o País!"
                                                    Display="None" ControlToValidate="ddlPessoaPais" SetFocusOnError="True" Enabled="false" />
                                            </td>
                                            <td>
                                                <cc3:FieldTextBox ID="txtPessoaEnderecoComplemento" runat="server" ValueField="Complemento"
                                                    Width="300" CssClass="UPPER" ToolTip="Informe a Quadra,Apto,Lote" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="fExterior" runat="server" visible="false">
                                <td colspan="2">
                                    <fieldset class="rotulo">
                                        <table class="rotulo" width="100%">
                                            <tr>
                                                <td>
                                                    <cc3:FieldTextBox ID="txtPessoaCidadeExterior" CssClass="UPPER" runat="server" ValueField="Cidade"
                                                        MaxLength="30" ToolTip="Informe a Cidade no Exterior" />
                                                </td>
                                                <td>
                                                    <cc3:FieldTextBox ID="txtPessoaEstadoExterior" CssClass="UPPER" runat="server" ValueField="Estado"
                                                        MaxLength="30" ToolTip="Informe o Estado no Exterior" />
                                                </td>
                                                <td>
                                                    <cc3:FieldTextBox ID="txtPessoaCodigoPostalExterior" CssClass="UPPER" runat="server"
                                                        ValueField="Código Postal" MaxLength="30" ToolTip="Informe o Código Postal no Exterior" />
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <cc3:FieldTextBox ID="txtPessoaFoneRes" runat="server" ValueField="Fone Residencial"
                                        MaxLength="15" ToolTip="Informe o Número do Telefone com o DDD (Ex: 6533223400)" />
                                    <asp:RequiredFieldValidator ID="rqfTelefoneRes" runat="server" ErrorMessage="Informe a Fone Residencial!"
                                        Display="None" ControlToValidate="txtPessoaFoneRes" SetFocusOnError="True" Enabled="false" />
                                </td>
                                <td>
                                    <cc3:FieldTextBox ID="txtPessoaFoneCel" runat="server" ValueField="Fone Celular"
                                        MaxLength="15" ToolTip="Informe o Número ro Telefone com o DDD (Ex: 65998886132)" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <cc3:FieldTextBox ID="txtPessoaEmail1" runat="server" ValueField="Email 1" Width="250px"
                                        ToolTip="Infome o email" />
                                </td>
                                <td>
                                    <cc3:FieldTextBox ID="txtPessoaEmail2" runat="server" ValueField="Email 2" Width="250px"
                                        ToolTip="Informe o email" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <cc3:FieldTextBox ID="txtPessoaObs" runat="server" ValueField="Observações" TextMode="MultiLine"
                                        Width="550px" Height="50px" CssClass="UPPER" ToolTip="Caso haja alguma informação descreva neste campo"
                                        onFocus="nextfieldobs ='done';" /><br />
                                    <span id="lb_contador" style="font-size: xx-small; display: none;">Ainda restam <span
                                        id="contador">800</span> caracteres a serem digitados.</span>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <cc3:FieldTextBox ID="txtPessoaMatriculaBanestes"
                                        runat="server" ValueField="Matricula Banestes" CssClass="UPPER" Width="100px"
                                        MaxLength="9" ToolTip="Informe a matricula do banco banestes." />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </cc2:TabPanel>
        <cc2:TabPanel Visible="false" Enabled="true" ID="tabAssDigital" runat="server" HeaderText="Assinatura Eletrônica">
            <ContentTemplate>
                <table class="rotulo" width="98%">
                    <tr>
                        <td>
                            <fieldset class="rotulo">
                                <legend><b>Assinatura Eletrônica</b><asp:ImageButton runat="server" ID="ImageButton70" ImageUrl="~/Library/Images/icones/about.png"
                                    ToolTip="A assinatura eletrônica deverá ter no mínimo 06 caracteres, devendo ser preenchido por letras/números. Essa assinatura será solicita para confirmação de sua identidade. " /></legend>
                                <table class="rotulo">
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chk_Ativa_Ass" runat="server" Text="Utilizar Assinatura (RSA-Rivest-Shamir-Adleman)" Font-Bold="true" AutoPostBack="true"/>
                                        </td>
                                    </tr>

                                </table>
                                <table>
                                    <tr>
                                        <td>
                                            <cc3:FieldTextBox ID="txtSenhaAss" TextMode="Password" runat="server" Obrigatorio="true" Enabled="false" ValueField="Senha"></cc3:FieldTextBox>
                                            <asp:RequiredFieldValidator ID="requiredSenhaAss" runat="server" ErrorMessage="Informe a senha!"
                                                Display="None" ControlToValidate="txtSenhaAss" SetFocusOnError="True"
                                                Enabled="false" />
                                            <asp:HiddenField ID="hhdHashSenhaAss" Visible="false" runat="server" />
                                        </td>
                                        <td>
                                            <cc3:FieldTextBox ID="txtConfirmaSenhaAss" TextMode="Password" Enabled="false" Obrigatorio="true" runat="server" ValueField="Confirmar Senha"></cc3:FieldTextBox>
                                            <asp:RequiredFieldValidator ID="requiredConfSenhaAss" runat="server" ErrorMessage="O campo confirmar senha é obrigatorio!"
                                                Display="None" ControlToValidate="txtSenhaAss" SetFocusOnError="True"
                                                Enabled="false" />
                                            <asp:CompareValidator ID="cv_USR_LOGIN_CONFIRMA" runat="server" ControlToValidate="txtConfirmaSenhaAss"
                                                ControlToCompare="txtSenhaAss" Display="None" ErrorMessage="A senha confirmada não é a mesma digitada no campo Senha!"
                                                SetFocusOnError="true" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc2:TabPanel>
        <cc2:TabPanel Visible="false" Enabled="false" ID="tabAnexos" runat="server">
            <ContentTemplate>
                <%--<asp:UpdatePanel ID="updAnexo" runat="server">
                    <ContentTemplate>--%>
                <table class="rotulo" width="98%">
                    <tr>
                        <td>
                            <asp:Button ID="btnVisualizarImagens" runat="server" Text="Visualizar Imagens em Carrossel"
                                CausesValidation="false" Style="margin-top: 5px; margin-bottom: 8px;" />
                            <fieldset class="rotulo">
                                <legend><b class="rotulo">Lista de documentos anexados a esta pessoa:</b></legend>
                                <div style="padding-bottom: 2px;">
                                    <asp:Button ID="Button3" runat="server" Style="display: none;"
                                        CausesValidation="false" />
                                    <div style="display: block; padding-bottom: 5px;" id="div_total_imagens" runat="server" visible="false">
                                        <div class="col-md-12">
                                            <div class="pull-right">
                                                Total de Documentos Digitalizados:
                                                    <asp:Label ID="lb_total_digitalizacao" runat="server" Font-Bold="true" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div id="div_grid_imagens" runat="server">
                                    <asp:DataGrid CssClass="rotulo grdAnexos" ID="grdAnexos" runat="server" AutoGenerateColumns="False"
                                        CellPadding="5"
                                       >
                                        <HeaderStyle Font-Bold="True" ForeColor="Black" BackColor="#E0DFE3" BorderColor="#CCCCCC" />
                                        <ItemStyle ForeColor="Black" BorderColor="#CCCCCC" BackColor="White" />
                                        <AlternatingItemStyle BackColor="WhiteSmoke"></AlternatingItemStyle>
                                        <Columns>
                                            <asp:TemplateColumn HeaderText="Excluir" Visible="true">
                                                <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:ImageButton CausesValidation="false" ID="imgbtnExcluirAnexo" ImageUrl="~/Library/Images/icones/delete.gif"
                                                        runat="server" CommandName="excluir" ToolTip="Clique aqui excluir este documento"></asp:ImageButton>
                                                    <cc2:ConfirmButtonExtender ID="ConfirmRGPSDelete" runat="server" TargetControlID="imgbtnExcluirAnexo"
                                                        ConfirmText="Deseja realmente Excluir este arquivo?">
                                                    </cc2:ConfirmButtonExtender>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:EditCommandColumn ButtonType="LinkButton" HeaderText="Editar" ValidationGroup="EditContribuicaoPrivada"
                                                UpdateText="&lt;img src='../Library/images/icones/atualizar.gif' border='0' alt='Alterar'&gt;"
                                                CancelText="&lt;img src='../Library/images/icones/cancelarGrid.gif' border='0' alt='Cancelar'&gt;"
                                                EditText="&lt;img src='../Library/Images/icones/edit.gif' border='0' alt='Editar'&gt;">
                                                <HeaderStyle HorizontalAlign="Center" Width="18px"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                <FooterStyle HorizontalAlign="Center" BorderColor="White"></FooterStyle>
                                            </asp:EditCommandColumn>
                                            <asp:TemplateColumn HeaderText="Ordem">
                                                <HeaderStyle HorizontalAlign="Center" Width="10px"></HeaderStyle>
                                                <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:ImageButton CausesValidation="false" ID="imbSubirDoc" ImageUrl="~/Library/Images/Botoes/NumericUp.gif"
                                                            runat="server" CommandName="subir" ToolTip="Clique aqui subir o documento" />
                                                    </div>
                                                    <div>
                                                        <asp:ImageButton CausesValidation="false" ID="imbDescerDoc" ImageUrl="~/Library/Images/Botoes/NumericDown.gif"
                                                            runat="server" CommandName="descer" ToolTip="Clique aqui descer o documento" />
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:BoundColumn DataField="ARQUIVOS_PESSOAS_DOCUMENTOS_ID" Visible="False"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="PESSOA_ID" HeaderText="PESSOA_ID" Visible="False"></asp:BoundColumn>
                                            <asp:TemplateColumn Visible="True" HeaderText="Nome do documento">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Titulo" runat="server"><%# DataBinder.Eval(Container.DataItem, "TITULO")%></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtTitulo" runat="server" Width="150"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Arquivo">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkANEXO" Text='<%# DataBinder.Eval(Container, "DataItem.NAME")%>' CssClass="grdAnexoslnkANEXO1" data-id='<%# DataBinder.Eval(Container, "DataItem.ARQUIVOS_PESSOAS_DOCUMENTOS_ID")%>'
                                                        ToolTip="Clique para baixar o anexo" CommandName="baixar" CausesValidation="false"></asp:LinkButton>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtNomeArquivo" runat="server" Width="150"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn Visible="True" HeaderText="Usuário">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Usuario" runat="server"><%# DataBinder.Eval(Container.DataItem, "USUARIO")%></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:BoundColumn DataField="NAME" Visible="false"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="TIPO" Visible="false"></asp:BoundColumn>
                                            <%--<asp:BoundColumn DataField="DATA" HeaderText="Inserido em"></asp:BoundColumn>--%>
                                            <asp:TemplateColumn Visible="True" HeaderText="Inserido em">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Data" runat="server"><%# DataBinder.Eval(Container.DataItem, "DATA")%></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                        </Columns>
                                        <PagerStyle Mode="NumericPages" Visible="False" />
                                    </asp:DataGrid>
                                </div>
                                <div id="div_carrossel" runat="server" visible="false">
                                    <div id="div_flutuante" style="position: fixed; bottom: 65px; width: 100%; z-index: 9999; display: none;">
                                        <div style="margin: 0 auto; width: 520px; background-color: #f6f2dd; box-shadow: 0 0 10px 0 rgba(0, 0, 0, 0.75); padding: 10px; border-radius: 5px 5px 0px 0px;">
                                            <div class="text-center">
                                                <button id="btn_selecionar" runat="server" type="button" class="botao_button">Selecionar Todos</button>
                                                <button id="btn_marcadores" runat="server" type="button" class="botao_button" disabled="disabled">Criar Marcador</button>
                                                <button id="btn_desvincular" runat="server" type="button" style="display: none;" class="botao_button" disabled="disabled" causesvalidation="false">Desvincular</button>
                                                <button id="btn_anexar_identificador" type="button" style="display: none;" disabled="disabled" class="botao_button">Anexar ao Marcador/Identificador</button>
                                                <asp:Button ID="btn_excluir" runat="server" disabled="disabled" Text="Excluir Documento(s)" CausesValidation="false" />
                                                <cc2:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btn_excluir" ConfirmText="Deseja realmente excluir o(s) registro(s) selecionado(s)?" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal_marcadores2" style="position: fixed; top: 250px; left: 15px; z-index: 999;">
                                        <div class="modal-dialog" style="width: 408px; box-shadow: 0 0 5px 0 rgba(0, 0, 0, 0.75);">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button id="btn_marcador_fechar" type="button" title="Ocultar Marcador(es)" style="float: right; cursor: pointer;"><span aria-hidden="true">&times;</span></button>
                                                    <h3 class="panel-title">Marcador(es)</h3>
                                                </div>
                                                <div class="modal-body">
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <button id="btn_marcador_novo" runat="server" type="button" class="botao_button">Novo Marcador</button>
                                                            <asp:Button ID="btn_marcador_sem" runat="server" CssClass="btn btn-info btn-xs" Text="Sem Marcador(es)" CausesValidation="false" />
                                                            <asp:Button ID="btn_mostrar_imagens" runat="server" CssClass="btn btn-info btn-xs" Text="Todos Documentos" CausesValidation="false" />
                                                        </div>
                                                    </div>
                                                    <div class="row" style="margin-top: 10px;">
                                                        <div id="dragTree" runat="server" class="jstree jstree-3 jstree-default" role="tree" aria-multiselectable="true" tabindex="0" aria-activedescendant="j3_1" aria-busy="false" style="overflow-x: auto;">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal_marcadores3" style="position: fixed; top: 250px; left: 15px; z-index: 999; display: none;">
                                        <button id="btn_mostrar_marcadores" type="button" style="background: rgba(0, 0, 0, 0) none repeat scroll 0 0; border: 0 none; cursor: pointer; padding: 0;" title="Mostrar Marcador(es)"><span class="text-xl fa fa-tags" aria-hidden="true"></button>
                                    </div>
                                    <div id="grid-gallery" class="grid-gallery">
                                        <section class="grid-wrap">
                                            <ul class="grid">
                                                <asp:Repeater ID="rp_documentos" runat="server">
                                                    <ItemTemplate>
                                                        <li data-id='<%#DataBinder.Eval(Container.DataItem, "ARQUIVOS_PESSOAS_DOCUMENTOS_ID")%>' data-tipo='<%#DataBinder.Eval(Container.DataItem, "TIPO")%>'>
                                                            <div id="div_chk" runat="server" style="text-align: center;" class="checkbox opcoes_ggg">
                                                                <label style="cursor: pointer;">
                                                                    <input id='checkbox<%#DataBinder.Eval(Container.DataItem, "ARQUIVOS_PESSOAS_DOCUMENTOS_ID")%>' type="checkbox" value='<%#DataBinder.Eval(Container.DataItem, "ARQUIVOS_PESSOAS_DOCUMENTOS_ID")%>' name="chk">
                                                                    Selecionar
                                                                </label>
                                                                &nbsp;
                                                            </div>
                                                            <figure>
                                                                <div style="height: 345px; background: #f1f1f1;">
                                                                    <img id="imgDocumentos" runat="server" border="0" data-id='<%#Eval("ARQUIVOS_PESSOAS_DOCUMENTOS_ID")%>' style="cursor: move;" />
                                                                    <embed id="iframe_pdf" runat="server" type="application/pdf" width="100%" height="350" />
                                                                </div>
                                                                <figcaption>
                                                                    <h5>
                                                                        <asp:Label ID="lbTitulo" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "TITULO")%>' /></h5>
                                                                </figcaption>
                                                            </figure>
                                                            <div class="opcoes_ggg" style="text-align: center; padding-bottom: 15px;">
                                                                <button id="btnAlterarDocumento" runat="server" type="button" class="botao_button" visible="false" title="Alterar Nome" data-id='<%#Eval("ARQUIVOS_PESSOAS_DOCUMENTOS_ID")%>' data-documento='<%#DataBinder.Eval(Container.DataItem, "TITULO")%>' style="margin-bottom: 2px;">Renomear</button>
                                                                <button id="btn_download" runat="server" type="button" class="botao_button">Download</button>
                                                                <asp:Button ID="btn_girar_anti_horario" runat="server" CommandArgument='<%#Eval("ARQUIVOS_PESSOAS_DOCUMENTOS_ID") + "," + Eval("TIPO")%>' CommandName="girar_anti" Text="Girar anti-horário" />
                                                                <asp:Button ID="btn_girar_horario" runat="server" CommandArgument='<%#Eval("ARQUIVOS_PESSOAS_DOCUMENTOS_ID") + "," + Eval("TIPO")%>' CommandName="girar_horario" Text="Girar horário" />
                                                            </div>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                        </section>
                                        <section class="slideshow">
                                            <ul>
                                                <asp:Repeater ID="rp_documentos2" runat="server">
                                                    <ItemTemplate>
                                                        <li>
                                                            <div style="position: absolute; bottom: 0; margin-bottom: 5px; width: 100%;">
                                                                <div style="width: 450px; margin: 0 auto;">
                                                                    <select id="ddl_renomear_documento" runat="server" style="width: 400px;" data-tipo='<%#DataBinder.Eval(Container.DataItem, "TIPO")%>' data-id='<%#DataBinder.Eval(Container.DataItem, "ARQUIVOS_PESSOAS_DOCUMENTOS_ID")%>'>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                            <figure>
                                                                <img id="imgDocumentos2" runat="server" border="0" />
                                                                <embed id="iframe_pdf2" runat="server" type="application/pdf" style="width: 100%; height: 100%;" />
                                                            </figure>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                            <nav>
                                                <span class="fa fa-angle-left nav-prev"></span>
                                                <span class="fa fa-angle-right nav-next"></span>
                                                <span class="fa fa-times nav-close"></span>
                                            </nav>
                                        </section>
                                    </div>
                                    <div id="div_paginacao" runat="server">
                                        <div class="table-responsive">
                                            <div class="dataTables_wrapper" style="margin-top: 15px;">
                                                <div class="dataTables_info">
                                                    <asp:DropDownList ID="ddlIndex" runat="server"
                                                        CssClass="form-control">
                                                        <asp:ListItem Text="8" Value="8" />
                                                        <asp:ListItem Text="20" Value="20" Selected="True" />
                                                        <asp:ListItem Text="40" Value="40" />
                                                        <asp:ListItem Text="80" Value="80" />
                                                        <asp:ListItem Text="120" Value="120" />
                                                    </asp:DropDownList>
                                                    <asp:Label ID="lblpage" runat="server" CssClass="minimo"></asp:Label>
                                                </div>
                                                <div class="text-center">
                                                    <ul class="pagination">
                                                        <li>
                                                            <asp:LinkButton ID="lnkFirst" runat="server" CausesValidation="false">Primeira Página</asp:LinkButton></li>
                                                        <li>
                                                            <asp:LinkButton ID="lnkPrevious" runat="server" CausesValidation="false"><i class="fa fa-chevron-left" style="padding:2px;"></i></asp:LinkButton></li>
                                                        <asp:Repeater ID="RepeaterPaging" runat="server">
                                                            <ItemTemplate>
                                                                <li id="li" runat="server">
                                                                    <asp:LinkButton ID="Pagingbtn" runat="server" CommandArgument='<%# Eval("PageIndex") %>'
                                                                        CommandName="newpage" Text='<%# Eval("PageText") %>' CausesValidation="false"></asp:LinkButton>
                                                                </li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        <li>
                                                            <asp:LinkButton ID="lnkNext" runat="server" CausesValidation="false"><i class="fa fa-chevron-right" style="padding:2px;"></i></asp:LinkButton></li>
                                                        <li>
                                                            <asp:LinkButton ID="lnkLast" runat="server" CausesValidation="false">Última Página</asp:LinkButton></li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="div_sem_resultado" runat="server" visible="false">
                                        <div class="text-center">
                                            <h3>Todos documento(s) está(ão) vinculado(s) a um marcador!</h3>
                                        </div>
                                    </div>
                                </div>
                                <asp:HiddenField runat="server" ID="hddProcessoVirtualAux" />
                                <asp:HiddenField runat="server" ID="hddArrastarDocumento" />
                                <asp:Button runat="server" ID="btnProcessoVirtualAux" Style="display: none;"
                                    CausesValidation="false" />
                            </fieldset>

                            <div runat="server" id="divDocumentosProvaVida" visible="false" style="margin-top: 10px;">
                                <fieldset class="rotulo">
                                    <legend class="mb-5"><b class="rotulo">Lista de documentos anexados via Prova de Vida:</b></legend>
                                    <table class="table rotulo mb-10" cellspacing="0" cellpadding="2" rules="all" border="1">
                                        <thead>
                                            <tr>
                                                <td>Nome do Documento</td>
                                                <td>Arquivo</td>
                                                <td>Inserido Em</td>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater runat="server" ID="rptAnexosProvaVida">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:HiddenField runat="server" ID="hddId" Value='<%# Eval("ARQUIVOS_PESSOAS_DOCUMENTOS_PROVA_VIDA_ID") %>' />
                                                            <asp:HiddenField runat="server" ID="hddName" Value='<%# Eval("NAME") %>' />
                                                            <%# Eval("TITULO") %>
                                                        </td>
                                                        <td>
                                                            <asp:LinkButton runat="server" ID="lnkANEXO" Text='<%# DataBinder.Eval(Container, "DataItem.NAME")%>'
                                                                ToolTip="Clique para baixar o documento" CommandName="baixar" CausesValidation="false"></asp:LinkButton>
                                                        </td>
                                                        <td style="white-space: nowrap"><%# Eval("DATA") %></td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>

                                    <table class="table rotulo mb-5" cellspacing="0" cellpadding="2" rules="all" border="1">
                                        <thead>
                                            <tr>
                                                <td>Nome do Documento</td>
                                                <td>Arquivo</td>
                                                <!--<td>Percentual</td>-->
                                                <td>Inserido Em</td>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater runat="server" ID="rptSelfieProvaVida">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:HiddenField runat="server" ID="hddId" Value='<%# Eval("ARQUIVOS_PESSOAS_DOCUMENTOS_PROVA_VIDA_ID") %>' />
                                                            <asp:HiddenField runat="server" ID="hddName" Value='<%# Eval("NAME") %>' />
                                                            <%# Eval("TITULO") %>
                                                        </td>
                                                        <td>
                                                            <asp:LinkButton runat="server" ID="lnkANEXO" Text='<%# DataBinder.Eval(Container, "DataItem.NAME")%>'
                                                                ToolTip="Clique para baixar o documento" CommandName="baixar" CausesValidation="false"></asp:LinkButton>
                                                        </td>
                                                        <!--<td><%# Eval("PERCENTUAL") %></td>-->
                                                        <td style="white-space: nowrap"><%# Eval("DATA") %></td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </fieldset>
                                <!-- /#divDocumentosProvaVida -->
                            </div>
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hdd_USR_LOGIN_ID" runat="server" />
                <asp:HiddenField ID="hdd_modal_marcadores" runat="server" />
                <asp:HiddenField ID="hdd_CONTROLE" runat="server" />
                <asp:HiddenField ID="hdd_FLUTUANTE" runat="server" />
                <asp:HiddenField ID="hdd_PESSOA_LABEL_ID" runat="server" />
                <asp:HiddenField ID="hdd_PESSOA_MARCADOR_ID" runat="server" />
                <input type="hidden" id="hdd_carrocel_post" />
                <asp:Button ID="btn_label" runat="server" Style="display: none;" CausesValidation="false" />
                <asp:Button ID="btn_marcador" runat="server" Style="display: none;" CausesValidation="false" />
                <asp:Button ID="btn_carregar_marcadores" runat="server" Style="display: none;" CausesValidation="false" />
                <asp:Button ID="btn_carregar_marcadores2" runat="server" Style="display: none;" CausesValidation="false" />
                <cc2:ModalPopupExtender ID="modal_marcadores" runat="server" TargetControlID="Button8"
                    PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="ImageButton2" />
                <asp:Button ID="Button8" runat="server" Style="display: none;" />
                <asp:Panel ID="Panel1" Style="display: none; margin: 0px; position: absolute; z-index: 1000"
                    runat="server">
                    <div>
                        <table border="0" cellspacing="0" cellpadding="0" class="rotulo">
                            <tr>
                                <td style="height: 34px; width: 34px; background: url(../Library/Images/TE.gif) no-repeat" />
                                <td style="height: 34px; width: 34px; background: url(../Library/Images/TC.gif) repeat-x; color: #FFFFFF;">Marcador(es)
                                </td>
                                <td style="height: 34px; width: 34px; background: url(../Library/Images/TD.gif) no-repeat">
                                    <asp:ImageButton Style="cursor: hand" ID="ImageButton2" runat="server" ImageUrl="~/Library/Images/delete.png"
                                        Height="18px" BorderStyle="None" CausesValidation="false" Visible="true" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 34px; background: url(../Library/Images/ME.gif) repeat-y" />
                                <td style="width: 34px; background: url(../Library/Images/MC.gif); padding: 5px;" align="center">
                                    <table cellpadding="2" cellspacing="2" style="margin-left: -15px;">
                                        <tr>
                                            <td>
                                                <cc3:FieldDropDown ID="ddl_marcadores" runat="server" Width="400" ValueField="Marcador" DataTextField="NOME" DataValueField="MARCADOR_ID" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <cc3:FieldTextBox ID="txt_marcador_label" runat="server" Width="200" ValueField="Identificador" CssClass="form-control" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <button id="btn_cadastro_marcador" type="button" class="botao_button">Confirmar</button>
                                                <button id="btn_modal_novo_marcador" type="button" class="botao_button">Novo Marcador</button>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 34px; background: url(../Library/Images/MD.gif) repeat-y" />
                            </tr>
                            <tr>
                                <td style="height: 18px; width: 18px; background: url(../Library/Images/BE.gif) no-repeat" />
                                <td style="height: 18px; width: 18px; background: url(../Library/Images/BC.gif) repeat-x" />
                                <td style="height: 18px; width: 18px; background: url(../Library/Images/BD.gif) no-repeat" />
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                <cc2:ModalPopupExtender ID="modal_anexar_identificador" runat="server" TargetControlID="Button9"
                    PopupControlID="Panel2" BackgroundCssClass="modalBackground" CancelControlID="ImageButton3" />
                <asp:Button ID="Button9" runat="server" Style="display: none;" />
                <asp:Panel ID="Panel2" Style="display: none; margin: 0px; position: absolute; z-index: 1000"
                    runat="server">
                    <div>
                        <table border="0" cellspacing="0" cellpadding="0" class="rotulo">
                            <tr>
                                <td style="height: 34px; width: 34px; background: url(../Library/Images/TE.gif) no-repeat" />
                                <td style="height: 34px; width: 34px; background: url(../Library/Images/TC.gif) repeat-x; color: #FFFFFF;">Identificador
                                </td>
                                <td style="height: 34px; width: 34px; background: url(../Library/Images/TD.gif) no-repeat">
                                    <asp:ImageButton Style="cursor: hand" ID="ImageButton3" runat="server" ImageUrl="~/Library/Images/delete.png"
                                        Height="18px" BorderStyle="None" CausesValidation="false" Visible="true" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 34px; background: url(../Library/Images/ME.gif) repeat-y" />
                                <td style="width: 34px; background: url(../Library/Images/MC.gif); padding: 5px;" align="center">
                                    <table cellpadding="2" cellspacing="2" style="margin-left: -15px;">
                                        <tr>
                                            <td>
                                                <cc3:FieldDropDown ID="ddl_identificador" runat="server" Width="400" ValueField="Identificador" CssClass="form-control" DataValueField="ID" DataTextField="NOME" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btn_anexar_identificador_confirmar" runat="server" CssClass="btn btn-success" Text="Confirmar" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 34px; background: url(../Library/Images/MD.gif) repeat-y" />
                            </tr>
                            <tr>
                                <td style="height: 18px; width: 18px; background: url(../Library/Images/BE.gif) no-repeat" />
                                <td style="height: 18px; width: 18px; background: url(../Library/Images/BC.gif) repeat-x" />
                                <td style="height: 18px; width: 18px; background: url(../Library/Images/BD.gif) no-repeat" />
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                <cc2:ModalPopupExtender ID="modal_novo_marcadores" runat="server" TargetControlID="Button10"
                    PopupControlID="Panel3" BackgroundCssClass="modalBackground" CancelControlID="ImageButton4" />
                <asp:Button ID="Button10" runat="server" Style="display: none;" />
                <asp:Panel ID="Panel3" Style="display: none; margin: 0px; position: absolute; z-index: 1000"
                    runat="server">
                    <div>
                        <table border="0" cellspacing="0" cellpadding="0" class="rotulo">
                            <tr>
                                <td style="height: 34px; width: 34px; background: url(../Library/Images/TE.gif) no-repeat" />
                                <td style="height: 34px; width: 34px; background: url(../Library/Images/TC.gif) repeat-x; color: #FFFFFF;">Novo Marcador
                                </td>
                                <td style="height: 34px; width: 34px; background: url(../Library/Images/TD.gif) no-repeat">
                                    <asp:ImageButton Style="cursor: hand" ID="ImageButton4" runat="server" ImageUrl="~/Library/Images/delete.png"
                                        Height="18px" BorderStyle="None" CausesValidation="false" Visible="true" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 34px; background: url(../Library/Images/ME.gif) repeat-y" />
                                <td style="width: 34px; background: url(../Library/Images/MC.gif); padding: 5px;" align="center">
                                    <table cellpadding="2" cellspacing="2" style="margin-left: -15px;">
                                        <tr>
                                            <td>
                                                <cc3:FieldTextBox ID="txt_nome_marcador" runat="server" Width="400" ValueField="Nome" CssClass="form-control" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <button id="btn_novo_marcador" type="button" class="botao_button">Confirmar</button>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 34px; background: url(../Library/Images/MD.gif) repeat-y" />
                            </tr>
                            <tr>
                                <td style="height: 18px; width: 18px; background: url(../Library/Images/BE.gif) no-repeat" />
                                <td style="height: 18px; width: 18px; background: url(../Library/Images/BC.gif) repeat-x" />
                                <td style="height: 18px; width: 18px; background: url(../Library/Images/BD.gif) no-repeat" />
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
            </ContentTemplate>
            <%-- </asp:UpdatePanel>
            </ContentTemplate>--%>
        </cc2:TabPanel>
        <cc2:TabPanel Enabled="true" Visible="false" ID="tabInfGeral" runat="server" HeaderText="Informações Gerais">
            <ContentTemplate>
                <table class="rotulo" width="680">
                    <tr>
                        <td>
                            <fieldset class="rotulo">
                                <legend><b class="rotulo">Optante de Plano de Saúde:</b></legend>
                                <asp:RadioButtonList CellSpacing="0" CellPadding="0" Enabled="true" RepeatDirection="Horizontal"
                                    ID="rdbSaude" runat="server">
                                    <asp:ListItem Text="Sim" Value="S"></asp:ListItem>
                                    <asp:ListItem Text="Não" Value="N"></asp:ListItem>
                                </asp:RadioButtonList>
                            </fieldset>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc2:TabPanel>
        <cc2:TabPanel ID="tabSocioEconomico" runat="server" HeaderText="Dados Sócio-Econômicos"
            Visible="false">
            <ContentTemplate>
                <table width="680" cellpadding="2" cellspacing="2" class="rotulo">
                    <tr>
                        <td>
                            <fieldset class="rotulo">
                                <legend><b class="rotulo">Imóvel:</b></legend>
                                <table>
                                    <tr>
                                        <td>
                                            <cc3:FieldRadioButtonList ID="rbRecadastramentoImovel" runat="server">
                                                <asp:ListItem Text="Próprio" Value="P" />
                                                <asp:ListItem Text="Alugado" Value="A" />
                                            </cc3:FieldRadioButtonList>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <fieldset class="rotulo">
                                <legend><b class="rotulo">Outros Bens:</b></legend>
                                <table>
                                    <tr>
                                        <td>
                                            <cc3:FieldCheckBox ID="cbCarro" runat="server" Text="Carro" /><br />
                                            <cc3:FieldCheckBox ID="cbMoto" runat="server" Text="Moto" /><br />
                                            <cc3:FieldCheckBox ID="cbMicro" runat="server" Text="Microcomputador" /><br />
                                            <cc3:FieldCheckBox ID="cbInternet" runat="server" Text="Acesso a Internet" /><br />
                                            <cc3:FieldCheckBox ID="cbArCondicionado" runat="server" Text="Ar-Condicionado" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <fieldset class="rotulo">
                                <legend><b class="rotulo">Outras Informações:</b></legend>
                                <table>
                                    <tr>
                                        <td>
                                            <cc3:FieldCheckBox ID="cbPlanoSaude" runat="server" Text="Plano de Saúde" /><br />
                                            <cc3:FieldCheckBox ID="cbPrevidencia" runat="server" Text="Previdência Privada" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc2:TabPanel>
        <cc2:TabPanel ID="tabHist" runat="server" HeaderText="Histórico Cadastral" Visible="false">
            <ContentTemplate>
                <asp:UpdatePanel runat="server">
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnHIncluir" />
                        <asp:PostBackTrigger ControlID="btnHSalvar" />
                        <asp:PostBackTrigger ControlID="btnHCancelar" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:DataGrid CssClass="rotulo" ID="grdHistorico" runat="server" AutoGenerateColumns="False"
                            CellPadding="5" Width="680">
                            <HeaderStyle Font-Bold="True" ForeColor="Black" BackColor="#E0DFE3" BorderColor="#CCCCCC"
                                HorizontalAlign="Center" />
                            <ItemStyle ForeColor="Black" BorderColor="#CCCCCC" BackColor="White" HorizontalAlign="Center" />
                            <AlternatingItemStyle BackColor="WhiteSmoke"></AlternatingItemStyle>
                            <Columns>
                                <asp:TemplateColumn HeaderText="Excluir" Visible="true">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnExcluirHist" runat="server" CommandName="excluir" ImageUrl="~/Library/Images/icones/delete.gif"
                                            CausesValidation="false" OnClientClick="javascript:return pergunta('Deseja excluir esse registro?');" />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Editar" Visible="false">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnAlterarHist" CausesValidation="false" runat="server" ImageUrl="~/Library/Images/icones/edit.gif"
                                            CommandName="editar" />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="HIST_CADASTRAL_ID" Visible="false" />
                                <asp:BoundColumn DataField="OBS" Visible="false" />
                                <asp:BoundColumn DataField="SEGURADO_ID" Visible="false" />
                                <asp:BoundColumn DataField="USER_INSERT" HeaderText="Usuário Cadastrou" Visible="false" />
                                <asp:TemplateColumn HeaderText="Usuário Cadastrou">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lkUSER_INSERT" runat="server" CommandName="Selecionar" CausesValidation="false" />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="TIME_INSERT" HeaderText="Data/Hora do Cadastro"></asp:BoundColumn>
                                <asp:BoundColumn DataField="USER_UPDATE" HeaderText="Usuário Alterou" Visible="false" />
                                <asp:TemplateColumn HeaderText="Usuário Alterou">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lkUSER_UPDATE" runat="server" CommandName="Selecionar" CausesValidation="false" />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="TIME_UPDATE" HeaderText="Data/Hora da Alteração"></asp:BoundColumn>
                            </Columns>
                        </asp:DataGrid>
                        <p>
                            <asp:HiddenField ID="HDD_HIST_CADASTRAL_ID" runat="server" />
                            <cc3:FieldTextBox ID="txt_HIST_CADASTRAL_OBS" runat="server" Visible="false" TextMode="MultiLine"
                                Height="70" Width="595" ValueField="Observações:" />
                        </p>
                        <p>
                            <asp:Button ID="btnHIncluir" runat="server" Text="Novo" 
                                CausesValidation="false" />
                            <asp:Button ID="btnHCancelar" runat="server" Text="Cancelar"
                                CausesValidation="false" />
                            <asp:Button ID="btnHSalvar" runat="server" Text="Salvar"
                                CausesValidation="false" />
                        </p>
                        <p>
                            <cc3:FieldCheckBox ID="chk_JUDICIAL" runat="server" Text="RESTABELECIMENTO JUDICIAL" Visible="false" />
                            <cc3:FieldCheckBox ID="chk_PCCS" runat="server" Text="ENQUADRAMENTO PCCS" Visible="false" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </cc2:TabPanel>
        <cc2:TabPanel Visible="False" Enabled="true" ID="Comentario" runat="server" HeaderText="Comentários">
            <ContentTemplate>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <fieldset style="width: 520px">
                            <legend><b class="rotulo">Descrição:</b></legend>
                            <asp:TextBox runat="server" ID="txt_comentario" MaxLength="800" TextMode="MultiLine"
                                Width="500px" Height="80px"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Button runat="server" ID="btncomentario" Text="Salvar" />
                        </fieldset>
                        <br />
                        <br />
                        <asp:DataGrid CssClass="rotulo" ID="grdComentarios" runat="server" Width="540px"
                            AutoGenerateColumns="False">
                            <HeaderStyle Font-Bold="True" ForeColor="Black" BackColor="#E0DFE3" BorderColor="#CCCCCC"
                                HorizontalAlign="Center" />
                            <ItemStyle ForeColor="Black" BorderColor="#CCCCCC" BackColor="White" HorizontalAlign="Center" />
                            <AlternatingItemStyle BackColor="WhiteSmoke"></AlternatingItemStyle>
                            <Columns>
                                <asp:TemplateColumn HeaderText="Excluir">
                                    <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
                                    <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnexcluir" ImageUrl="~/Library/Images/icones/cancelar.gif"
                                            runat="server" CommandName="Excluir" ToolTip="Clique aqui para Excluir registro"
                                            CausesValidation="false"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="COMENTARIO_ID" Visible="false"></asp:BoundColumn>
                                <asp:BoundColumn DataField="DATA" HeaderText="Data"></asp:BoundColumn>
                                <asp:BoundColumn DataField="USUARIO" HeaderText="Usuario"></asp:BoundColumn>
                                <asp:BoundColumn DataField="COMENTARIO" HeaderText="Comentario"></asp:BoundColumn>
                            </Columns>
                        </asp:DataGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </cc2:TabPanel>
        <cc2:TabPanel ID="tabDadosBancarios" runat="server" HeaderText="Dados Bancários">
            <ContentTemplate>
                <table width="680px">
                    <tr>
                        <td>
                            <cc3:FieldLabel ID="lblPessoaNomeBanco" runat="server" ValueField="Nome" />
                        </td>
                        <td>
                            <cc3:FieldLabel ID="lblPessoaCPFBanco" runat="server" ValueField="CPF" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 40px">
                            <cc3:FieldLabel ID="lblPessoaDataNascBanco" runat="server" ValueField="Data de Nascimento" />
                        </td>
                        <td style="height: 40px">
                            <cc3:FieldLabel ID="lblPessoaSexoBanco" runat="server" ValueField="Sexo" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc3:FieldLabel ID="lblPessoaNomeMaeBanco" runat="server" ValueField="Nome da Mãe" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:CheckBox ID="chkPortador" CssClass="rotulo" runat="server" Enabled="false" Text="Portador de moléstia grave" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkIsentoContrib" CssClass="rotulo" runat="server" Enabled="false"
                                Text="Portador de doença incapacitante" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkBloqueioCreditoConta" CssClass="rotulo" runat="server" Enabled="false"
                                Text="Bloquear no Crédito em Conta" />
                        </td>
                    </tr>
                </table>
                <div runat="server" id="dvDadosPessoa">
                    <fieldset style="width: 95%;">
                        <legend id="lgd" class="rotulo">Dados Bancários</legend>
                        <asp:UpdatePanel ID="updDados" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <cc3:FieldDropDown Style="width: 210px;" ID="ddlBanco" AutoPostBack="true" runat="server"
                                                Obrigatorio="false" CssClass="dropDown" ValueField="Banco:">
                                            </cc3:FieldDropDown>
                                        </td>
                                        <td>
                                            <cc3:FieldTextBox Width="90px" ID="txtAgencia" ValueField="Agência" runat="server"></cc3:FieldTextBox>
                                        </td>
                                        <td>
                                            <cc3:FieldTextBox Width="30px" ID="txtDV" ValueField="DV" runat="server" MaxLength="2" />
                                        </td>
                                        <td>
                                            <cc3:FieldTextBox Width="90px" ID="txtConta" ValueField="Conta" runat="server"></cc3:FieldTextBox>
                                        </td>
                                        <td>
                                            <cc3:FieldTextBox Width="30px" ID="txtDV2" ValueField="DV" runat="server" MaxLength="2" />
                                        </td>
                                        <td>
                                            <cc3:FieldTextBox Width="40px" ID="txtOP" ValueField="Op" MaxLength="4" runat="server"></cc3:FieldTextBox>
                                            <cc2:FilteredTextBoxExtender runat="server" ID="ftOP" TargetControlID="txtOP"
                                                InvalidChars="+-*" FilterType="Custom, Numbers" ValidChars="" />
                                        </td>
                                        <td>
                                            <cc3:FieldDropDown Style="width: 130px;" ID="ddlFormaPag" AutoPostBack="true" runat="server"
                                                Obrigatorio="false" CssClass="dropDown" ValueField="Forma de Pagamento:">
                                            </cc3:FieldDropDown>
                                        </td>
                                        <td>
                                            <cc3:FieldLabel ID="lblSituacao" runat="server"></cc3:FieldLabel>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </fieldset>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnSalvarDadosBancario" runat="server" CausesValidation="false" Text="Salvar"
                                    ToolTip="Salvar Informações" CssClass="btnProc" />
                                <asp:Image ID="Image3" runat="server" ImageUrl="../Library/Images/Separador.gif"
                                    CssClass="SeparadorBtn" />
                                <asp:Button ID="btnExcluirDadosBancario" runat="server" CausesValidation="true" Text="Excluir"
                                    ToolTip="Excluir informações" CssClass="btnProc" OnClientClick="return ConfirmarExclusao();" />
                                <asp:Image ID="Image2" runat="server" ImageUrl="../Library/Images/Separador.gif"
                                    CssClass="SeparadorBtn" />
                                <asp:Button ID="btnBloquearDadosBancario" runat="server" CausesValidation="false"
                                    Text="Bloquear/Desbloquear" ToolTip="Bloquear/Desbloquear" CssClass="btnProc"
                                    Enabled="false" />
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- Inicio do Pop-up do Senha -->
                <asp:HiddenField ID="hddOperacao" runat="server" />
                <asp:Button ID="BtnModalSenha" runat="server" Style="display: none;" />
                <cc2:ModalPopupExtender ID="mpeSenha" runat="server" TargetControlID="BtnModalSenha"
                    PopupControlID="Panel4" BackgroundCssClass="modalBackground" OkControlID="OkButton"
                    CancelControlID="CancelButton" DropShadow="false" />
                <asp:Panel ID="Panel4" runat="server" Style="display: none; margin: 0px; position: absolute">
                    <div style="background: url(../Library/Images/topo_login.gif) no-repeat; width: 232px; height: 36px;">
                    </div>
                    <div>
                        <table align="center" border="0" cellpadding="0" cellspacing="0" class="texto_login"
                            width="232">
                            <tr>
                                <td align="center" background="../Library/Images/meio_login.gif">
                                    <table border="0" cellpadding="2" cellspacing="0" class="texto_menu" width="90%">
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">Senha:
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtSenha" runat="server" CssClass="campos" TextMode="Password">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td align="left">
                                                <asp:Button ID="OkButton" runat="server" Text="OK" Width="60px" Style="display: none" />
                                                <asp:Button ID="Button7" runat="server" Text="OK"
                                                    Width="60px" />
                                                <asp:Button ID="CancelButton" runat="server" Text="Cancelar" Width="60px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td align="left">&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td background="../Library/Images/baixo_login.gif" height="18"></td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                <!-- Inicio do Modal Pop-up do Bloqueio  -->
                <cc2:ModalPopupExtender ID="MPEErro" BehaviorID="BehaviorMPEErro" runat="server"
                    TargetControlID="btnBloqueioAux" PopupControlID="pnlErro" BackgroundCssClass="modalBackground"
                    CancelControlID="btnCancelErro" DropShadow="false" />
                <asp:Button ID="btnBloqueioAux" runat="server" Style="display: none" />
                <asp:Panel ID="pnlErro" Style="display: none; margin: 0; position: absolute" runat="server"
                    DefaultButton="btnConcluiBloqueio">
                    <asp:Panel ID="Panel6" runat="server">
                        <div>
                            <table width="232" border="0" align="center" cellpadding="0" cellspacing="0" class="rotulo">
                                <tr>
                                    <td colspan="2" height="36" background="../Library/Images/topo_modal.gif">&nbsp;&nbsp;&nbsp;&nbsp;<font color="#FFFFFF" face="tahoma"> Deseja Bloquear?</font>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                    <div>
                        <table width="232" border="0" align="center" cellpadding="0" cellspacing="0" class="texto_login">
                            <tr>
                                <td align="center" background="../Library/Images/meio_login.gif">
                                    <table width="85%" border="0" cellpadding="2" cellspacing="0" class="rotulo">
                                        <tr>
                                            <td>
                                                <cc3:FieldTextBox ID="txtDataBloqueio" runat="server" ValueField="Data:" Width="120px"></cc3:FieldTextBox>
                                                <cc2:MaskedEditExtender ID="mexTxtData" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                    Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtDataBloqueio" />
                                                <asp:RequiredFieldValidator ID="rfvclpData" runat="server" ControlToValidate="txtDataBloqueio"
                                                    ErrorMessage="Informe a Data para bloqueio!" SetFocusOnError="true" runat="server"
                                                    ValidationGroup="MpErro" Display="None"></asp:RequiredFieldValidator>
                                            </td>
                                            <tr>
                                                <td align="left">
                                                    <cc3:FieldTextBox ID="txtDataBloqueioFolha" runat="server" onKeyUp="formatValueNumber(this,'##/####', event);"
                                                        ValueField="Comp. Folha:"></cc3:FieldTextBox>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="rfvclpDataBloqueioFolha" runat="server" ControlToValidate="txtDataBloqueioFolha"
                                                        ErrorMessage="Informe a competência" SetFocusOnError="true" ValidationGroup="MpErro"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <cc3:FieldDropDown ID="ddlTipoBloqueio" runat="server" CssClass="dropDown" Style="width: 180px;" ValueField="Tipo de Bloqueio:">
                                                        <asp:ListItem Value="B" Text="Bloqueio em Folha" />
                                                        <asp:ListItem Value="C" Text="Credito em Conta" />
                                                    </cc3:FieldDropDown>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <cc3:FieldDropDown ID="ddlMotivoBloqueio" runat="server" CssClass="dropDown" Obrigatorio="true"
                                                        Style="width: 180px;" ValueField="Motivo do Bloqueio:">
                                                    </cc3:FieldDropDown>
                                                </td>
                                                <tr>
                                                    <td align="left">
                                                        <cc3:FieldTextBox ID="txtMotivoBloqueio" runat="server" Height="60px" TextMode="MultiLine"
                                                            ValueField="Descrição:" Width="180px"></cc3:FieldTextBox>
                                                        <asp:RequiredFieldValidator ID="rfvclpMotivo" runat="server" ControlToValidate="txtMotivoBloqueio"
                                                            ErrorMessage="Informe a descrição" SetFocusOnError="true" ValidationGroup="MpErro"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <br />
                                                        <asp:Button ID="btnConcluiBloqueio" runat="server"
                                                            Text="Bloquear" ValidationGroup="MpErro" />
                                                        <asp:Button ID="btnCancelErro" runat="server" CausesValidation="false" Text="Cancelar" />
                                                    </td>
                                                </tr>
                                            </tr>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="18" background="../Library/Images/baixo_login.gif"></td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                <!-- Inicio do Pop-up do Senha -->
            </ContentTemplate>
        </cc2:TabPanel>
    </cc2:TabContainer>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentToolBar" runat="Server">
    <asp:Button ID="btnnextmae" runat="server" Style="display: none" />
    <asp:Button ID="btnAtualizaAnexos" runat="server" 
        CausesValidation="false" Style="display: none" />
    <%--POPUP_CARTEIRA--%>
    <asp:Panel ID="pnlCarteira" runat="server">
        <cc2:ModalPopupExtender ID="MPSeleciona" runat="server" TargetControlID="Button2"
            PopupControlID="pnlEventos" BackgroundCssClass="modalBackground" />
        <asp:Button ID="Button2" runat="server" Style="display: none;" />
        <asp:Panel ID="pnlEventos" Style="display: none; margin: 0px; position: absolute; z-index: 1000"
            runat="server">
            <div>
                <table border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="height: 34px; width: 34px; background: url(../Library/Images/TE.gif) no-repeat" />
                        <td style="height: 34px; width: 34px; background: url(../Library/Images/TC.gif) repeat-x; color: #FFFFFF;">
                            <asp:Label ID="lblTituloMP" runat="server" Text="Formulário de Carteiras Emitidas" />
                        </td>
                        <td style="height: 34px; width: 34px; background: url(../Library/Images/TD.gif) no-repeat">
                            <asp:ImageButton Style="cursor: hand" ID="btnfecha" runat="server" ImageUrl="~/Library/Images/delete.png"
                                Height="18px" BorderStyle="None" CausesValidation="false" Visible="true" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 34px; background: url(../Library/Images/ME.gif) repeat-y" />
                        <td style="width: 34px; background: url(../Library/Images/MC.gif); padding: 5px;"
                            align="center">
                            <div id="MPconteudo" style="border: solid 1px #ccc; width: 270px; height: 175px; padding: 5px;">
                                <%--CONTEUDO--%>
                                <table width="100%" border="0" cellspacing="3" cellpadding="3">
                                    <tr>
                                        <td>
                                            <div style="overflow-x: auto; height: 170px;">
                                                <asp:DataGrid CssClass="rotulo" ID="grd_Carteira" runat="server" Width="100%" AutoGenerateColumns="False">
                                                    <HeaderStyle Font-Bold="True" ForeColor="Black" BackColor="#E0DFE3" BorderColor="#CCCCCC"
                                                        HorizontalAlign="Center" />
                                                    <ItemStyle ForeColor="Black" BorderColor="#CCCCCC" BackColor="White" HorizontalAlign="Center" />
                                                    <AlternatingItemStyle BackColor="WhiteSmoke" />
                                                    <Columns>
                                                        <asp:TemplateColumn HeaderText="Excluir">
                                                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                                            <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnexcluir" ImageUrl="~/Library/Images/icones/delete2.gif" runat="server"
                                                                    CommandName="deleta" ToolTip="Clique aqui para Excluir registro" CausesValidation="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:BoundColumn DataField="CARTEIRA_EMISSAO_ID" Visible="false" />
                                                        <asp:BoundColumn DataField="LOGIN" HeaderText="Usuário" />
                                                        <asp:BoundColumn DataField="USR_LOGIN_ID" Visible="false" />
                                                        <asp:BoundColumn DataField="DATA_EMISSAO" HeaderText="Data" />
                                                    </Columns>
                                                    <PagerStyle Mode="NumericPages" Visible="False" />
                                                </asp:DataGrid>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <%--CONTEUDO--%>
                            </div>
                            <br />
                            <asp:Button ID="Button1" runat="server" Text="Visualizar carteira" Width="120PX"
                                />
                            <asp:Button ID="btnFechaPopup" runat="server" Text="Fechar" Width="120px" />
                        </td>
                        <td style="width: 34px; background: url(../Library/Images/MD.gif) repeat-y" />
                    </tr>
                    <tr>
                        <td style="height: 18px; width: 18px; background: url(../Library/Images/BE.gif) no-repeat" />
                        <td style="height: 18px; width: 18px; background: url(../Library/Images/BC.gif) repeat-x" />
                        <td style="height: 18px; width: 18px; background: url(../Library/Images/BD.gif) no-repeat" />
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </asp:Panel>
    <%--POPUP_CARTEIRA--%>
    <%--POPUP_CARTEIRA_FORM--%>
    <asp:Panel ID="pnlForm" runat="server">
        <cc2:ModalPopupExtender ID="MPCarteira" runat="server" TargetControlID="Button4"
            PopupControlID="pnlCarteiraForm" BackgroundCssClass="modalBackground" />
        <asp:Button ID="Button4" runat="server" Style="display: none;" />
        <asp:Panel ID="pnlCarteiraForm" Style="display: none; margin: 0px; position: absolute; z-index: 1000"
            runat="server">
            <div>
                <table border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="height: 34px; width: 34px; background: url(../Library/Images/TE.gif) no-repeat" />
                        <td style="height: 34px; width: 34px; background: url(../Library/Images/TC.gif) repeat-x; color: #FFFFFF;">
                            <asp:Label ID="lblTitulo_Form" runat="server" Text="Formulário de Carteiras Emitidas" />
                        </td>
                        <td style="height: 34px; width: 34px; background: url(../Library/Images/TD.gif) no-repeat">
                            <asp:ImageButton Style="cursor: hand" ID="ImageButton1" runat="server" ImageUrl="~/Library/Images/delete.png"
                                Height="18px" BorderStyle="None" CausesValidation="false" Visible="true" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 34px; background: url(../Library/Images/ME.gif) repeat-y" />
                        <td style="width: 34px; background: url(../Library/Images/MC.gif); padding: 5px;"
                            align="center">
                            <div id="Div2" style="border: solid 1px #ccc; width: 350px; padding: 5px;">
                                <%--CONTEUDO--%>
                                <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                    <tr class="altura">
                                        <td>Órgão Expedidor
                                        </td>
                                        <td>Data da Expedição
                                        </td>
                                        <td>Via
                                        </td>
                                        <td>Matrícula
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="rotulo borda">
                                            <b>
                                                <asp:Label ID="lblOrgaoExp" runat="server" /></b>
                                        </td>
                                        <td class="rotulo borda">
                                            <b>
                                                <asp:Label ID="lblDataExp" runat="server" /></b>
                                        </td>
                                        <td class="rotulo borda">
                                            <b>
                                                <asp:Label ID="lblVia" runat="server" /></b>
                                        </td>
                                        <td class="rotulo borda">
                                            <b>
                                                <asp:Label ID="lblMat" runat="server" /></b>
                                        </td>
                                    </tr>
                                    <tr class="altura">
                                        <td colspan="4">Nome
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="rotulo borda" colspan="4">
                                            <b>
                                                <asp:Label ID="lblNome" runat="server" /></b>
                                        </td>
                                    </tr>
                                    <tr class="altura">
                                        <td>Nacionalidade
                                        </td>
                                        <td>Naturalidade
                                        </td>
                                        <td colspan="2">Data Nasc.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="rotulo borda">
                                            <b>
                                                <asp:Label ID="lblNac" runat="server" /></b>
                                        </td>
                                        <td class="rotulo borda">
                                            <b>
                                                <asp:Label ID="lblNat" runat="server" /></b>
                                        </td>
                                        <td class="rotulo borda" colspan="2">
                                            <b>
                                                <asp:Label ID="lblDat" runat="server" /></b>
                                        </td>
                                    </tr>
                                    <tr class="altura">
                                        <td>R.G.
                                        </td>
                                        <td>Órgão
                                        </td>
                                        <td colspan="2">CPF
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="rotulo borda">
                                            <b>
                                                <asp:Label ID="lblRG" runat="server" /></b>
                                        </td>
                                        <td class="rotulo borda">
                                            <b>
                                                <asp:Label ID="lblOrg" runat="server" /></b>
                                        </td>
                                        <td class="rotulo borda" colspan="2">
                                            <b>
                                                <asp:Label ID="lblCpf" runat="server" /></b>
                                        </td>
                                    </tr>
                                    <tr class="altura">
                                        <td>Data Aposent.
                                        </td>
                                        <td colspan="2">Nº Diário Oficial
                                        </td>
                                        <td>Tipo Sangue
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="rotulo borda">
                                            <b>
                                                <asp:Label ID="lblApos" runat="server" /></b>
                                        </td>
                                        <td class="rotulo borda" colspan="2">
                                            <b>
                                                <asp:Label ID="lblDiar" runat="server" /></b>
                                        </td>
                                        <td class="rotulo borda">
                                            <b>
                                                <asp:Label ID="lblTps" runat="server" /></b>
                                        </td>
                                    </tr>
                                </table>
                                <%--CONTEUDO--%>
                            </div>
                            <br />
                            <asp:Button ID="Button5" runat="server" Text="Emitir carteira" Width="120PX" />
                            <asp:Button ID="Button6" runat="server" Text="Fechar" Width="120px" />
                        </td>
                        <td style="width: 34px; background: url(../Library/Images/MD.gif) repeat-y" />
                    </tr>
                    <tr>
                        <td style="height: 18px; width: 18px; background: url(../Library/Images/BE.gif) no-repeat" />
                        <td style="height: 18px; width: 18px; background: url(../Library/Images/BC.gif) repeat-x" />
                        <td style="height: 18px; width: 18px; background: url(../Library/Images/BD.gif) no-repeat" />
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </asp:Panel>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:Button ID="Button11" runat="server" Style="display: none;" />
    
    <%--POPUP_CARTEIRA_FORM--%>
    <cc1:ImageButtonHover ID="btnCancelar" Imagem="../Library/Images/icones/voltar.gif"
        CausesValidation="false" Texto="Voltar" ToolTip="Clique aqui para Voltar" runat="server"
        Visible="true"></cc1:ImageButtonHover>
    <cc1:SeparadorToolBar ID="SeparadorToolBar7" Imagem="../Library/Images/Separador.gif"
        runat="server"></cc1:SeparadorToolBar>
    <cc1:ImageButtonHover ID="btnAvanca" Imagem="../Library/Images/icones/avancar.gif"
        CausesValidation="true" Texto="Avançar" ToolTip="Clique aqui para preencher as demais informações"
        runat="server"></cc1:ImageButtonHover>
</asp:Content>