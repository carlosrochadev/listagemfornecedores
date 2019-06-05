using Fornecedores.Aplicacao.Inerfaces;
using Fornecedores.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Aplicacao
{
    public class AplicacaoServicoBase<TEntity> : IAplicacaoServicoBase<TEntity> where TEntity : class
    {
        private readonly IServicoBase<TEntity> _servicoBase;

        public AplicacaoServicoBase(IServicoBase<TEntity> servicoBase)
        {
            _servicoBase = servicoBase;
        }

        public void Atualizar(TEntity entidade)
        {
            _servicoBase.Atualizar(entidade);
        }

        public void Excluir(TEntity entidade)
        {
            _servicoBase.Excluir(entidade);
        }

        public void Excluir(long id)
        {
            _servicoBase.Excluir(id);
        }

        public void Incluir(TEntity entidade)
        {
            _servicoBase.Incluir(entidade);
        }

        public TEntity ObterPorId(long id)
        {
            return _servicoBase.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _servicoBase.ObterTodos();
        }
    }
}
