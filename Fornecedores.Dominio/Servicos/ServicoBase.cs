using Fornecedores.Dominio.Interfaces.Repositorio;
using Fornecedores.Dominio.Interfaces.Servico;
using System.Collections.Generic;

namespace Fornecedores.Dominio.Servicos
{
    public class ServicoBase<TEntity> : IServicoBase<TEntity> where TEntity : class
    {
        private readonly IRepositorioBase<TEntity> _repositorioBase;

        public ServicoBase(IRepositorioBase<TEntity> repositorioBase)
        {
            _repositorioBase = repositorioBase;
        }

        public void Atualizar(TEntity entidade)
        {
            _repositorioBase.Atualizar(entidade);
        }

        public void Excluir(TEntity entidade)
        {
            _repositorioBase.Excluir(entidade);
        }

        public void Excluir(long id)
        {
            _repositorioBase.Excluir(id);
        }

        public void Incluir(TEntity entidade)
        {
            _repositorioBase.Incluir(entidade);
        }

        public TEntity ObterPorId(long id)
        {
            return _repositorioBase.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _repositorioBase.ObterTodos();
        }
    }
}
