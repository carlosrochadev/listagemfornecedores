using Fornecedores.Dominio.Entidades;
using Fornecedores.Dominio.Interfaces.Repositorio;
using Fornecedores.Infra.Repositorio.ConfiguracaoContexto;

namespace Fornecedores.Infra.Repositorio.Repositorios
{
    public class RepositorioFornecedor : RepositorioBase<Fornecedor>, IRepositorioFornecedor
    {
        private readonly Contexto _contexto;

        public RepositorioFornecedor(Contexto contexto):base(contexto)
        {
            _contexto = contexto;
        }
    }
}
