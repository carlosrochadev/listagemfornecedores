﻿using System.Collections.Generic;

namespace Fornecedores.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioBase<TEntity> where TEntity : class
    {
        void Incluir(TEntity entidade);
        void Excluir(TEntity entidade);
        void Excluir(long id);
        TEntity ObterPorId(long id);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity entidade);
    }
}