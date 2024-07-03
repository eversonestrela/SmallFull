<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Clientes.aspx.cs" Inherits="Clientes" MasterPageFile="~/MasterPages/Site.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">

    <title>Cadastro de Produto</title>
    <style>
        body {
            background-color: #f8f9fa;
        }

        .container {
            margin-top: 50px;
        }

        .form-group {
            margin-bottom: 1rem;
        }
    </style>

    <body>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <div class="container">
                <h2 class="header text-center">Cadastro de Pessoas</h2>
                <br />
                <br />
                <br />
                <div class="form-row">
                    <div class="form-group col-md-4">
                        <label for="txtCPF">CPF:</label>
                        <asp:TextBox ID="txtCPF" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="txtNome">Nome:</label>
                        <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="txtDataNasc">Data de Nascimento:</label>
                        <asp:TextBox ID="txtDataNasc" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:MaskedEditExtender
                            ID="txtDataNasc_MaskedEditExtender"
                            runat="server"
                            TargetControlID="txtDataNasc"
                            Mask="99/99/9999"
                            MaskType="Date"
                            InputDirection="RightToLeft"
                            DisplayMoney="None"
                            AutoComplete="true"></asp:MaskedEditExtender>
                        <asp:CalendarExtender
                            ID="txtDataNasc_CalendarExtender"
                            runat="server"
                            TargetControlID="txtDataNasc"
                            Format="dd/MM/yyyy"></asp:CalendarExtender>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-4">
                        <label for="txtEndRua">Rua:</label>
                        <asp:TextBox ID="txtEndRua" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="txtEndNumero">Numero Residência:</label>
                        <asp:TextBox ID="txtEndNumero" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="txtEndBairro">Bairro:</label>
                        <asp:TextBox ID="txtEndBairro" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-2">
                        <label for="ddlUF">UF:</label>
                        <asp:DropDownList ID="ddlUF" runat="server" CssClass="form-control" Width="100px">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="ddlCidade">Cidade:</label>
                        <asp:DropDownList ID="ddlCidade" runat="server" CssClass="form-control" Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="ddlStatus">Status</label>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" Width="100%">
                            <asp:ListItem Text="ATIVO" Value="ATIVO"></asp:ListItem>
                            <asp:ListItem Text="INATIVO" Value="INATIVO"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group text-right">
                    <asp:Button ID="btnSalvar" runat="server" CssClass="btn btn-primary" Text="Salvar" OnClick="btnSalvar_Click" />
                </div>
            </div>
        </form>
    </body>
    </html>
</asp:Content>
