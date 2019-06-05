using Fornecedores.Dominio.Entidades;
using Fornecedores.Dominio.Interfaces.Repositorio;
using Fornecedores.Dominio.Interfaces.Servico;

namespace Fornecedores.Dominio.Servicos
{
    public class ServicoEmpresa : ServicoBase<Empresa>, IServicoEmpresa
    {
        private readonly IRepositorioEmpresa _repositorioEmpresa;
        public ServicoEmpresa(IRepositorioEmpresa repositorioEmpresa):base(repositorioEmpresa)
        {
            _repositorioEmpresa = repositorioEmpresa;
        }

    }
}
