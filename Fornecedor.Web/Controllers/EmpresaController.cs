using Fornecedores.Aplicacao.Inerfaces;
using Fornecedores.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fornecedor.Web.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly IAplicacaoServicoEmpresa _aplicacaoServicoEmpresa;

        public EmpresaController(IAplicacaoServicoEmpresa aplicacaoServicoEmpresa)
        {
            _aplicacaoServicoEmpresa = aplicacaoServicoEmpresa;
        }

        public ActionResult Index()
        {
            IEnumerable<Empresa> model = _aplicacaoServicoEmpresa.ObterTodos();

            return View(model);
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(Empresa model)
        {
            try
            {
                IList<string> UFs = new List<string>() { "AC","AL","AM","AP","BA","CE","DF","ES","GO","MA","MG","MS","MT","PA","PB","PE","PI","PR","RJ","RN","RO",
                                                        "RR","RS","SC","SE","SP","TO"};

                if (!UFs.Contains(model.UF))
                {
                    ModelState.AddModelError("UF", "Informe um UF válido");
                }

                if (ModelState.IsValid)
                {  
                    _aplicacaoServicoEmpresa.Incluir(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                if (id > 0)
                {
                    Empresa model = _aplicacaoServicoEmpresa.ObterPorId(id);

                    return View(model);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Empresa model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _aplicacaoServicoEmpresa.Atualizar(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}