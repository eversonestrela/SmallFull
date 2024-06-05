<%@ Page Language="C#" MasterPageFile="~/MasterPages/Cadastro.master" AutoEventWireup="true" CodeFile="CadProduto.aspx.cs" Inherits="Paginas_Pessoa_CadProduto" Title="Cadastro de Produto" %>

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
                    <button class="nav-link active" id="produtoServicoTab" data-toggle="tab" data-target="#produtoServico" type="button" role="tab" aria-controls="produtoServico" aria-selected="true">Produto ou Serviço</button>
                </li>
                <li class="nav-item" role="presentation">
                    <button class="nav-link" id="enderecoTab" data-toggle="tab" data-target="#endereco" type="button" role="tab" aria-controls="endereco" aria-selected="false">Endereço</button>
                </li>
                <li class="nav-item" role="presentation">
                    <button class="nav-link" id="arquivosTab" data-toggle="tab" data-target="#arquivos" type="button" role="tab" aria-controls="arquivos" aria-selected="false" runat="server" visible="false">Documentos Anexados</button>
                </li>
            </ul>
            <div class="tab-content">
                <div class="tab-pane fade show active" id="produtoServico" role="tabpanel" aria-labelledby="produtoServicoTab">
                    <br />
                    <table width="100%">
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td class="pdr-10">
                                            <cc3:FieldTextBox ID="txtCodigo" runat="server" ValueField="Código" Width="150px" Style="padding: 5px;" />
                                        </td>
                                        <td class="pdr-10">
                                            <cc3:FieldDropDown ID="ddlTipo" runat="server" ValueField="Tipo" style="padding: 4px;" Width="150px" CssClass="input-cadastro">
                                                <asp:ListItem Text="Produto" Value="1" Selected="True" />
                                                <asp:ListItem Text="Serviço" Value="2" />
                                            </cc3:FieldDropDown>
                                        </td>
                                        <td class="pdr-10">
                                            <cc3:FieldTextBox ID="txtNome" runat="server" onkeyup="convertToUppercase(event);" ValueField="Nome" Width="600px" Style="padding: 5px;" />                         
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
                                            <cc3:FieldDropDown ID="ddlGrupo" runat="server" ValueField="Grupo*" style="padding: 4px;" Width="310px" CssClass="input-cadastro">
                                                <asp:ListItem Text="Selecione" Value="0" Selected="True" />
                                            </cc3:FieldDropDown>
                                        </td>
                                        <td class="pdr-10">
                                            <cc3:FieldDropDown ID="ddlMarca" runat="server" ValueField="Marca" style="padding: 4px;" Width="295px" CssClass="input-cadastro">
                                                <asp:ListItem Text="Marca..." Value="0" Selected="True" />
                                            </cc3:FieldDropDown>
                                        </td>
                                        <td class="pdr-10">
                                            <cc3:FieldTextBox ID="txtUnidadeMedida" runat="server" ValueField="Unid. medida" Width="295px" Style="padding: 5px;" />
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
                                            <cc3:FieldTextBox ID="txtCusto" runat="server" ValueField="Custo (R$)" Width="150px" CssClass="input-cadastro" />
                                        </td>
                                        <td class="pdr-10">
                                            <cc3:FieldTextBox ID="txtLucroEsperado" runat="server" ValueField="Lucro Esperado (R$)" Width="150px" CssClass="input-cadastro" />
                                        </td>
                                        <td class="pdr-10">
                                            <cc3:FieldTextBox ID="txtPercLucro" runat="server" ValueField="Perc. Lucro (%)" Width="150px" CssClass="input-cadastro" />
                                        </td>
                                        <td class="pdr-10">
                                            <cc3:FieldTextBox ID="txtPrecoVenda" runat="server" ValueField="Preço Venda (R$)" Width="150px" CssClass="input-cadastro" />
                                        </td>
                                        <td class="pdr-10">
                                            <cc3:FieldTextBox ID="txtLiquido" runat="server" ValueField="Líquido (R$)" Width="150px" CssClass="input-cadastro" Enabled="false" />
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
                                            <label class="rotulo">Controla Estoque</label><br />
                                            <div class="btn-group" role="group">
                                                <button type="button" class="btn btn-sm btn-light">Sim</button>
                                                <button type="button" class="btn btn-sm btn-danger">Não</button>
                                            </div>
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