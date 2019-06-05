using Fornecedores.Aplicacao;
using Fornecedores.Aplicacao.Inerfaces;
using Fornecedores.Dominio.Interfaces.Repositorio;
using Fornecedores.Dominio.Interfaces.Servico;
using Fornecedores.Dominio.Servicos;
using Fornecedores.Infra.Repositorio;
using Fornecedores.Infra.Repositorio.Repositorios;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fornecedor.Web.App_Start
{
    public class ModulosNinject : NinjectModule
    {
        public override void Load()
        {
            #region Configuração da Aplicação Serviço

            Bind(typeof(IAplicacaoServicoBase<>)).To(typeof(AplicacaoServicoBase<>));
            Bind(typeof(IAplicacaoServicoEmpresa)).To(typeof(AplicacaoServicoEmpresa));
            Bind(typeof(IAplicacaoServicoFornecedor)).To(typeof(AplicacaoServicoFornecedor));

            #endregion

            #region Configuração dos Serviços

           Bind(typeof(IServicoBase<>)).To(typeof(ServicoBase<>));
           Bind(typeof(IServicoEmpresa)).To(typeof(ServicoEmpresa));
           Bind(typeof(IServicoFornecedor)).To(typeof(ServicoFornecedor));

            #endregion

            #region Configuração dos Repositórios

            Bind(typeof(IRepositorioBase<>)).To(typeof(RepositorioBase<>));
            Bind(typeof(IRepositorioEmpresa)).To(typeof(RepositorioEmpresa));
            Bind(typeof(IRepositorioFornecedor)).To(typeof(RepositorioFornecedor));

            #endregion
        }
    }
}