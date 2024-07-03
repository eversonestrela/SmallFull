<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />
    <style>
        body {
            background-color: #f8f9fa;
        }

        .container {
            margin-top: 100px;
            width: 300px;
        }

        .card {
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .btn-login {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="formLogin" runat="server">
        <div class="container">
            <div class="card">
                <h2 class="text-center">Realizar Login</h2>
                <hr />
                <div class="form-group">
                    <asp:Label ID="lblUsuario" runat="server" AssociatedControlID="txtUsuario">Usuário:</asp:Label>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" />
                </div>
                <div class="form-group">
                    <asp:Label ID="lblSenha" runat="server" AssociatedControlID="txtSenha">Senha:</asp:Label>
                    <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" CssClass="form-control" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnLogin" runat="server" Text="Entrar" CssClass="btn btn-primary btn-login" OnClick="btnLogin_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
