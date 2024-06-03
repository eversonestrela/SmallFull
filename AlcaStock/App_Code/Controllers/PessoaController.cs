using Models;
using Alcastock.Repositorios;
using System.Collections.Generic;

namespace Alcastock.Controllers
{
    public class PessoaController
    {
        private readonly PessoaRepositorio _repositorio;
        private readonly ArquivoPessoaRepositorio _repositorioArquivoPessoa;

        public PessoaController()
        {
            _repositorio = new PessoaRepositorio();
            _repositorioArquivoPessoa = new ArquivoPessoaRepositorio();
        }

        public List<PessoaModel> ConsultarPessoas(string tipoConsulta, string descricao)
        {
            List<PessoaModel> pessoas = _repositorio.ConsultarPessoas(tipoConsulta, descricao);
            return pessoas;
        }

        public List<PessoaModel> ConsultarPessoaPorId(string pessoaId)
        {
            List<PessoaModel> pessoas = _repositorio.ConsultarPessoaPorId(pessoaId);
            return pessoas;
        }

        public void SalvarPessoa(PessoaModel pessoa)
        {
            _repositorio.Salvar(pessoa);
        }

        public void AtualizarPessoa(int pessoaId, PessoaModel pessoa)
        {
            _repositorio.AtualizarPessoa(pessoaId, pessoa);
        }

        public void ExcluirPessoa(int pessoaId)
        {
            _repositorio.ExcluirPessoa(pessoaId);
        }

        /* ARQUIVO PESSOAS */
        public void SalvarImagem(ArquivoPessoaModel arquivoPessoa)
        {
            _repositorioArquivoPessoa.SalvarImagem(arquivoPessoa);
        }

        public List<ArquivoPessoaModel> ConsultarArquivoPessoasPorId(int? pessoaId)
        {
            List<ArquivoPessoaModel> arquivoPessoa = _repositorioArquivoPessoa.ConsultarArquivoPessoasPorId(pessoaId);
            return arquivoPessoa;
        }

        public void DeletarImagem(int? pessoaId)
        {
            _repositorioArquivoPessoa.DeletarImagem(pessoaId);
        }
    }
}