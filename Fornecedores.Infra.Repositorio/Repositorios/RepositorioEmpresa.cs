using Fornecedores.Dominio.Entidades;
using Fornecedores.Dominio.Interfaces.Repositorio;
using Fornecedores.Infra.Repositorio.ConfiguracaoContexto;

namespace Fornecedores.Infra.Repositorio.Repositorios
{
    public class RepositorioEmpresa : RepositorioBase<Empresa>, IRepositorioEmpresa
    {
        private readonly Contexto _contexto;

        public RepositorioEmpresa(Contexto contexto):base(contexto)
        {
            _contexto = contexto;
        }
    }
}
