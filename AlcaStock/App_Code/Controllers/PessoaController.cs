using Models;
using Alcastock.Repositorios;
using System.Collections.Generic;

namespace Alcastock.Controllers
{
    public class PessoaController
    {
        private readonly PessoaRepositorio _repositorio;

        public PessoaController()
        {
            _repositorio = new PessoaRepositorio();
        }

        public List<PessoaModel> ConsultarPessoas(string tipoConsulta, string descricao)
        {
            List<PessoaModel> pessoas = _repositorio.ConsultarPessoas(tipoConsulta, descricao);
            return pessoas;
        }

        public void SalvarPessoa(PessoaModel pessoa)
        {
            _repositorio.Salvar(pessoa);
        }
    }
}