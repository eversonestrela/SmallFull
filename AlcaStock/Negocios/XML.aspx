<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XML.aspx.cs" Inherits="NotaFiscal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Importar Nota Fiscal</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Importar Nota Fiscal</h2>
            <asp:FileUpload ID="fileUploadNotaFiscal" runat="server" />
            <br />
            <asp:Button ID="btnImportarXML" runat="server" Text="Importar XML" OnClick="btnImportarXML_Click" />
            <br />
            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
