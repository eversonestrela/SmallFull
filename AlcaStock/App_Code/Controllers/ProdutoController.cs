using Alcastock.Repositorios;
using Models;
using System.Collections.Generic;

namespace Alcastock.Controllers
{
    public class ProdutoController
    {
        private readonly ProdutoRepositorio _repositorio;
        public ProdutoController()
        {
            _repositorio = new ProdutoRepositorio();
        }

        public List<ProdutoModel> ConsultarProdutos(string tipoConsulta, string descricao)
        {
            List<ProdutoModel> produtos = _repositorio.Consultar(tipoConsulta, descricao);
            return produtos;
        }

        public void SalvarProduto(ProdutoModel produto)
        {
            _repositorio.Salvar(produto);
        }
    }
}