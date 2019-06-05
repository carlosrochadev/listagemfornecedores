using Fornecedores.Aplicacao.Inerfaces;
using Fornecedores.Dominio.Entidades;
using Fornecedores.Dominio.Interfaces.Servico;
using System;

namespace Fornecedores.Aplicacao
{
    public class AplicacaoServicoFornecedor : AplicacaoServicoBase<Fornecedor>, IAplicacaoServicoFornecedor
    {
        private readonly IServicoFornecedor _servicoFornecedor;

        public AplicacaoServicoFornecedor(IServicoFornecedor servicoFornecedor):base(servicoFornecedor)
        {
            _servicoFornecedor = servicoFornecedor;
        }
    }
}
