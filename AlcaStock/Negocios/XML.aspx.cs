using System;
using System.IO;
using System.Web.UI.WebControls;
using System.Xml;

    public partial class NotaFiscal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Aqui você pode adicionar lógica para o Page_Load, se necessário
        }

        protected void btnImportarXML_Click(object sender, EventArgs e)
        {
            if (fileUploadNotaFiscal.HasFile && Path.GetExtension(fileUploadNotaFiscal.FileName).Equals(".xml", StringComparison.InvariantCultureIgnoreCase))
            {
                try
                {
                    // Caminho do arquivo temporário
                    string filePath = Server.MapPath("~/Temp/") + fileUploadNotaFiscal.FileName;

                    // Salvar o arquivo no servidor
                    fileUploadNotaFiscal.SaveAs(filePath);

                    // Aqui você pode implementar a lógica para ler e processar o XML
                    // Exemplo de leitura básica do XML
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(filePath);

                    // Exemplo de acesso aos elementos do XML
                    XmlNodeList nodeList = xmlDoc.GetElementsByTagName("elemento");

                    // Processar os dados conforme necessário
                    // Exemplo: exibir os dados na página
                    foreach (XmlNode node in nodeList)
                    {
                        string valor = node["campo"].InnerText;
                        // Processar ou armazenar os dados conforme necessário
                    }

                    // Após processar, você pode deletar o arquivo temporário se necessário
                    File.Delete(filePath);

                    // Exibir mensagem de sucesso ou atualizar interface
                    lblStatus.Text = "XML importado com sucesso!";
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Erro ao importar XML: " + ex.Message;
                }
            }
            else
            {
                lblStatus.Text = "Por favor, selecione um arquivo XML válido.";
            }
        }
    }

