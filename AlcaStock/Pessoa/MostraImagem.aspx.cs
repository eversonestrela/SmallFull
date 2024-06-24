using Alcastock.Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Alcastock.Controllers;

public partial class Paginas_Pessoa_MostraImagem : AppBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
            ExibeImagemBD(Convert.ToInt32(Request.QueryString["id"]));
    }

    protected void ExibeImagemBD(int id)
    {
        Response.ContentType = "image/jpeg";
        Stream strm = ShowEmpImage(id);

        // Verifica se nao existe stream do arquivo cadastrado no banco
        if (strm != null)
        {
            byte[] buffer = new byte[4096];
            int byteSeq = strm.Read(buffer, 0, 4096);

            while (byteSeq > 0)
            {
                Response.OutputStream.Write(buffer, 0, byteSeq);
                byteSeq = strm.Read(buffer, 0, 4096);
            }
        }
    }

    public Stream ShowEmpImage(int id)
    {
        PessoaController pessoaController = new PessoaController();
        List<ArquivoPessoaModel> arquivoPessoas = pessoaController.ConsultarArquivoPessoasPorId(id);

        if (arquivoPessoas.Count > 0)
        {
            ArquivoPessoaModel arquivoPessoa = arquivoPessoas[0];
            return new MemoryStream((byte[])arquivoPessoa.DADOS);
        }
        else
        {
            return null;
        }
    }
}