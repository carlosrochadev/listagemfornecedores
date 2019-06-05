using Fornecedores.Aplicacao.Inerfaces;
using Fornecedores.Dominio.Entidades;
using Fornecedores.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Aplicacao
{
    public class AplicacaoServicoEmpresa : AplicacaoServicoBase<Empresa>, IAplicacaoServicoEmpresa
    {
        private readonly IServicoEmpresa _servicoEmpresa;

        public AplicacaoServicoEmpresa(IServicoEmpresa servicoEmpresa) : base(servicoEmpresa)
        {
            _servicoEmpresa = servicoEmpresa;
        }
    }
}
