<%@ Page Language="C#" MasterPageFile="~/MasterPages/Cadastro.master" AutoEventWireup="true" CodeFile="CadPessoa.aspx.cs" Inherits="Paginas_Pessoa_CadPessoa" Title="Cadastro de Pessoas" %>

<%@ Register Assembly="AGENDA.Controles" Namespace="AGENDA.Controles.UI.ButtonToolBar" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AGENDA.Controles" Namespace="AGENDA.Controles.UI" TagPrefix="cc3" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentCampos" runat="server">
    
    <asp:HiddenField ID="txtPESSOA_ID" runat="server" />

    <div class="d-flex justify-content-center">
        <div class="p-3 mb-2 bg-danger text-white w-50" runat="server" id="divErros" visible="false">
            <button type="button" id="btnClose" data-element="<%= divErros.ClientID %>">
                <span aria-hidden="true">&times;</span>
            </button>
            <asp:Label runat="server" ID="lblErros" />
        </div>
    </div>

    <div style="display: flex; align-content: center; justify-content: left; margin: 0;">
        <div style="height: 500px;">
            <ul class="nav nav-tabs" role="tablist">
                <li class="nav-item" role="presentation">
                    <button class="nav-link active" id="dadosPessoaisTab" data-toggle="tab" data-target="#dadosPessoais" type="button" role="tab" aria-controls="dadosPessoais" aria-selected="true">Dados Pessoais</button>
                </li>
                <li class="nav-item" role="presentation">
                    <button class="nav-link" id="enderecoTab" data-toggle="tab" data-target="#endereco" type="button" role="tab" aria-controls="endereco" aria-selected="false">Endereço</button>
                </li>
                <li class="nav-item" role="presentation">
                    <button class="nav-link" id="arquivosTab" data-toggle="tab" data-target="#arquivos" type="button" role="tab" aria-controls="arquivos" aria-selected="false" runat="server" visible="false">Documentos Anexados</button>
                </li>
            </ul>
            <div class="tab-content">
                <div class="tab-pane fade show active" id="dadosPessoais" role="tabpanel" aria-labelledby="dadosPessoaisTab">
                    <br />
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
                                            <asp:Label runat="server" Font-Bold="true" CssClass="rotuloObrigatorio">Data Nasc.</asp:Label>
                                            <div class="input-group">
                                                <cc3:FieldTextBox ID="txt_PESSOAS_DATA_NASC" runat="server"
                                                    Style="width: 100px;" CssClass="date input-cadastro" MaxLength="10" />
                                                <cc2:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_PESSOAS_DATA_NASC"
                                                    PopupButtonID="ImageButton1" Animated="true" Format="dd/MM/yyyy" />
                                                <div class="input-group-append">
                                                    <button type="button" class="iconeDate" style="border: none; background: none;" >
                                                        <i class="fas fa-calendar-alt fa-lg"></i>
                                                    </button>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top" rowspan="9" runat="server" id="tdImagem" visible="false">
                                <asp:Image ID="imageFoto" Height="200px" Width="150px" runat="server" Visible="false" BorderColor="#CCCCCC"
                                    BorderWidth="1px" />
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
                        <tr runat="server" id="trImagem" visible="false">
                            <td>
                                <table>
                                    <tr>
                                        <td class="pdr-10">
                                            <b class="rotulo">Selecione o arquivo da Foto:</b><br />
                                            <asp:FileUpload ID="fuFoto" Width="300px" runat="server" />
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="btnInsereFoto" Text="Inserir foto" runat="server" CssClass="btn btn-sm btn-outline-primary btn-pequeno"
                                                OnClick="btnInsereFoto_Click"/>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="btnDeletaFoto" Text="Excluir foto" runat="server" CssClass="btn btn-sm btn-outline-danger btn-pequeno"
                                                OnClick="btnDeletaFoto_Click"/>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="tab-pane fade" id="endereco" role="tabpanel" aria-labelledby="enderecoTab">teste2</div>
                <div class="tab-pane fade" id="arquivos" role="tabpanel" aria-labelledby="arquivosTab" runat="server" visible="false">
                    <br />
                    <table width="100%">
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="btnVisualizaDocs" Text="<i class='fas fa-file-image'></i> Visualizar Documentos" runat="server" CssClass="btn btn-sm btn-secondary btn-pequeno"/>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentToolBar" runat="Server">
    <asp:LinkButton ID="btnVoltar" Text="<i class='fas fa-arrow-alt-circle-left'></i> Voltar" runat="server" CssClass="btn btn-sm btn-secondary" CausesValidation="true"
        OnClick="btnVoltar_Click"/>
    <asp:LinkButton ID="btnSalvar" Text="<i class='fas fa-save'></i> Salvar" runat="server" CssClass="btn btn-sm btn-primary" CausesValidation="true"
        ToolTip="Clique aqui para salvar" OnClick="btnSalvar_Click" />
</asp:Content>