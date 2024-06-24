<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inicial.aspx.cs" Inherits="PageIndex" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc3" %>

<!DOCTYPE html>

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


        <div id="Topo" style="text-align: center;">
            <h1>Os melhores barbeiros você encontra aqui!</h1>
        </div>


        <div style="text-align: center;">
            <asp:Button ID="btnAssinar" runat="server" Text="ASSINE AGORA!" CssClass="shadow-pulse"
                Style="background-color: black; color: #ffd800; padding: 20px 40px; border: none; border-radius: 5px; cursor: pointer; text-decoration: none;"
                OnClick="btnAssinar_Click" />
        </div>



        <asp:Repeater ID="RepeaterServices" runat="server" Visible="false">
            <HeaderTemplate>
                <div class="services-container">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="service">
                    <h2><%# Eval("Nome") %></h2>
                    <div class="price"><%# Eval("Preco") %></div>
                    <ul>
                        <li><%# Eval("Descricao") %></li>
                    </ul>
                </div>

            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>

        
<img src="../Library/Images/fundo_barber.gif" style="width: 100%; height: 100%; margin: auto;"/>




        <asp:LinkButton ID="logo" runat="server" CausesValidation="false" Style="display: block; text-align: center;">
  
        </asp:LinkButton>

    </form>
</body>
</html>
