using Models;
using Alcastock.Repositorios;

namespace Alcastock.Controllers
{
    public class PessoaController
    {
        private readonly PessoaRepositorio _repositorio;

        public PessoaController()
        {
            _repositorio = new PessoaRepositorio();
        }

        public void SalvarPessoa(PessoaModel pessoa)
        {
            _repositorio.Salvar(pessoa);
        }
    }
}