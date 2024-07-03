using System;
using System.IO;
using System.Web.UI.WebControls;
using System.Xml;

    public partial class NotaFiscal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Aqui voc� pode adicionar l�gica para o Page_Load, se necess�rio
        }

        protected void btnImportarXML_Click(object sender, EventArgs e)
        {
            if (fileUploadNotaFiscal.HasFile && Path.GetExtension(fileUploadNotaFiscal.FileName).Equals(".xml", StringComparison.InvariantCultureIgnoreCase))
            {
                try
                {
                    // Caminho do arquivo tempor�rio
                    string filePath = Server.MapPath("~/Temp/") + fileUploadNotaFiscal.FileName;

                    // Salvar o arquivo no servidor
                    fileUploadNotaFiscal.SaveAs(filePath);

                    // Aqui voc� pode implementar a l�gica para ler e processar o XML
                    // Exemplo de leitura b�sica do XML
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(filePath);

                    // Exemplo de acesso aos elementos do XML
                    XmlNodeList nodeList = xmlDoc.GetElementsByTagName("elemento");

                    // Processar os dados conforme necess�rio
                    // Exemplo: exibir os dados na p�gina
                    foreach (XmlNode node in nodeList)
                    {
                        string valor = node["campo"].InnerText;
                        // Processar ou armazenar os dados conforme necess�rio
                    }

                    // Ap�s processar, voc� pode deletar o arquivo tempor�rio se necess�rio
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
                lblStatus.Text = "Por favor, selecione um arquivo XML v�lido.";
            }
        }
    }

