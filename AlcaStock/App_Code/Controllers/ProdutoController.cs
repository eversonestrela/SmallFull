using Alcastock.Repositorios;

namespace Alcastock.Controllers
{
    public class ProdutoController
    {
        private readonly ProdutoRepositorio _repositorio;
        public ProdutoController()
        {
            _repositorio = new ProdutoRepositorio();
        }
    }
}