using Fornecedores.Dominio.Interfaces.Repositorio;
using Fornecedores.Infra.Repositorio.ConfiguracaoContexto;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Fornecedores.Infra.Repositorio
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class
    {
        private Contexto _contexto;

        public RepositorioBase(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void Atualizar(TEntity entidade)
        {
            _contexto.Entry(entidade).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Excluir(TEntity entidade)
        {
            _contexto.Set<TEntity>().Remove(entidade);
            _contexto.SaveChanges();
        }

        public void Excluir(long id)
        {
            var entidade = ObterPorId(id);
            Excluir(entidade);
        }

        public void Incluir(TEntity entidade)
        {
            _contexto.Set<TEntity>().Add(entidade);
            _contexto.SaveChanges();
        }

        public TEntity ObterPorId(long id)
        {
            return _contexto.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _contexto.Set<TEntity>().ToList();
        }
    }
}
