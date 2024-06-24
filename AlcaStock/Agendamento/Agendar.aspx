<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Agendar.aspx.cs"  Inherits="PageIndex" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc3" %>

<!DOCTYPE html>
<link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>


<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.1/css/all.min.css">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Página Inicial de Cadastro</title>

    <style>
        /* Estilo para o menu */
     #menu {
         background-color: white;
         overflow: hidden;
     }

         #menu a {
             float: left;
             display: block;
             color: white;
             text-align: center;
             padding: 14px 16px;
             text-decoration: none;
         }

             #menu a:hover {
                 background-color: #ddd;
                 color: black;
             }

     .services-container {
         display: flex;
         justify-content: space-around;
         background-color: #f4f4f4;
         padding: 20px;
     }

     .service {
         width: 300px;
         background-color: #fff;
         padding: 15px;
         box-shadow: 0 2px 5px rgba(0,0,0,0.1);
         text-align: center;
     }

         .service h2 {
             color: #333;
         }
         .service .price {
             font-size: 24px;
             color: #666;
         }
     @keyframes shadow-pulse {
         0% {
             box-shadow: 0 0 0 0px rgba(0, 0, 0, 0.2);
         }

         100% {
             box-shadow: 0 0 0 15px rgba(0, 0, 0, 0);
         }
     }
     .shadow-pulse {
         animation: shadow-pulse 2s infinite;
     }

/*CALENDARIO */
.button-style {
    background-color: white; /* Azul */
    color: black; /* Letras brancas */
    border: 1px;
    padding: 7px 6px; /* Espaçamento interno */
    font-size: 16px; /* Tamanho do texto */
    border-radius: 5px; /* Bordas arredondadas */
    cursor: pointer; /* Cursor em forma de mão indicando que é clicável */
    transition: background-color 0.3s, transform 0.2s; /* Transição suave para cor e transformação */
    text-align: center;
}

.button-style:hover {
    /*background-color: #0056b3;*/ /* Azul mais escuro ao passar o mouse */
    transform: scale(1.05); /* Aumenta ligeiramente o botão */
}

/*CALENDARIO*/

     .textured-background {
        background: url('path_to_your_texture_image.png');
        text-align: center;
        display: block;
        width: 100px; /* Largura conforme necessário */
        height: auto; /* Altura conforme necessário */
    }



    </style>

</head>
<body>
    <form id="form1" runat="server">
        <!-- Menu -->
        <div id="menu" style="text-align: center;">

               <asp:Button ID="Inicio" runat="server" Text="Página Inicial" Style="background-color: black; color: #fff; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;" OnClick="btnInicio_Click" />
       <asp:Button ID="Agendar" runat="server" Text="Agende AQUI!" Style="background-color: black; color: #fff; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;" OnClick="btnAgendar_Click" />
       <asp:Button ID="Contato" runat="server" Text="Fale Conosco" Style="background-color: black; color: #fff; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;" />
       <asp:Button ID="Cadastro" runat="server" Text="Cadastros" Style="background-color: black; color: #fff; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;" OnClick="btnParametro_Click" />

     </div>


        <asp:Panel ID="Visagista" runat="server" CssClass="modalPanel" Style="display: none;">
            <h2>Faça sua consultoria em VISAGISMO</h2>
            <asp:Button ID="ConfirmButton" runat="server" Text="Confirmar" />
            <asp:Button ID="CancelButton" runat="server" Text="Cancelar" />
        </asp:Panel>



        <!-- Conteúdo da página -->
        <div class="Cadastro">
            <!-- Seu conteúdo de cadastro aqui -->
            <h2></h2>
            <!-- Exemplo de formulário de cadastro -->
            <asp:TextBox ID="txtNome" runat="server" placeholder="Nome"></asp:TextBox>
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
            <%--  <asp:Button ID="btnAgendar" runat="server" Text="Novo Agendamento" Style="background-color: black; color: #fff; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;" OnClick="btnAgendar_Click" />--%>


            <%--<asp:Button ID="btnAgendar" runat="server" Text="Novo Agendamento" OnClick="btnAgendar_Click" />--%>
        </div>

        <table>
            <tr>

                <td></td>
            </tr>
        </table>
        <table>
            <tr>
                <td>

                    <asp:Button ID="Salvar" runat="server" Text="Confirmar Agendamento" Style="background-color: chartreuse; color: black; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;" Visible="false" OnClick="ConfirmarAgenda_Click" />
                </td>

                <td></td>
            </tr>
        </table>
        <table style="margin: 0 auto;">
            <tr>
                <td>             
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" Style="display: block; text-align: center;" OnClick="LinkButton_Click" CommandArgument="2">
                  <img src="../Library/Images/Milene.gif" style="width: 100px; height: auto; margin: auto;"/>               
                    </asp:LinkButton>
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td>           
                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="false" Style="display: block; text-align: center;" OnClick="LinkButton_Click" CommandArgument="3">
                    <img src="../Library/Images/Isaque.gif" style="width: 100px; height: auto; margin: auto;"/>
                    </asp:LinkButton>
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td>                    
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" Style="display: block; text-align: center;" OnClick="LinkButton_Click" CommandArgument="4">
                      <img src="../Library/Images/matheus.gif" style="width: 100px; height: auto; margin: auto;"/>
                    </asp:LinkButton>
                </td>
            </tr>
        </table>
  
<div style="display: flex; justify-content: center; margin-top: 20px;">
    <style>
        #lblNomeProfissional:hover {
            background-color: #0056b3; /* Mais escuro ao passar o mouse */
            color: white;
            cursor: pointer; /* Muda o cursor para indicar interatividade */
        }
    </style>
    <asp:Label ID="lblNomeProfissional" runat="server" Text="" style="background-color: #007BFF; color: white; padding: 10px; border-radius: 5px; transition: background-color 0.3s;" Visible="false"></asp:Label>
</div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <asp:Panel ID="pnlDates" runat="server" style="text-align: center; margin-top: 20px;" CssClass="button-style" Text="15" Visible="false"></asp:Panel>
        <asp:Panel ID="pnlTimes" runat="server" style="text-align: center; margin-top: 20px;" CssClass="button-style" Text="15" Visible="false"></asp:Panel>

     <asp:Button ID="Button1" runat="server" Text="Corte"  Style="background-color: chartreuse; text-align: center; color: black; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;" Visible="true" OnClick="ConfirmarAgenda_Click" />
 <asp:Button ID="Button2" runat="server" Text="Corte e Barba" Style="background-color: chartreuse; text-align: center; color: black; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;" Visible="true" OnClick="ConfirmarAgenda_Click" />
            <asp:Button ID="Button3" runat="server" Text="Barba" Style="background-color: chartreuse;  text-align: center; color: black; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;" Visible="true" OnClick="ConfirmarAgenda_Click" />
    

        <footer>
        </footer>
    </form>
</body>
</html>
