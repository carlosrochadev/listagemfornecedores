using Fornecedores.Dominio.Entidades;
using Fornecedores.Dominio.Interfaces.Repositorio;
using Fornecedores.Dominio.Interfaces.Servico;

namespace Fornecedores.Dominio.Servicos
{
    public class ServicoFornecedor : ServicoBase<Fornecedor>, IServicoFornecedor
    {
        private readonly IRepositorioFornecedor _repositorioFornecedor;

        public ServicoFornecedor(IRepositorioFornecedor repositorioFornecedor):base(repositorioFornecedor)
        {
            _repositorioFornecedor = repositorioFornecedor;
        }
    }
}
