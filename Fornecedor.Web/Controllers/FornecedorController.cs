using Fornecedor.Web.Models;
using Fornecedores.Aplicacao.Inerfaces;
using Fornecedores.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fornecedor.Web.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IAplicacaoServicoFornecedor _aplicacaoServicoFornecedor;
        private readonly IAplicacaoServicoEmpresa _aplicacaoServicoEmpresa;

        public FornecedorController(IAplicacaoServicoFornecedor aplicacaoServicoFornecedor, IAplicacaoServicoEmpresa aplicacaoServicoEmpresa)
        {
            _aplicacaoServicoFornecedor = aplicacaoServicoFornecedor;
            _aplicacaoServicoEmpresa = aplicacaoServicoEmpresa;
        }

        // GET: Fornecedor
        public ActionResult Index()
        {
            var fornecedores = _aplicacaoServicoFornecedor.ObterTodos().ToList();
            var model = new List<FornecedorViewModel>();

            foreach (var item in fornecedores)
            {
                FornecedorViewModel viewModel = new FornecedorViewModel()
                {
                    Id = item.Id,
                    CPFCNPJ = item.CPFCNPJ,
                    NomeEmpresa = item.Empresa.NomeFantasia,
                    Nome = item.Nome,
                    Telefone = item.Telefone.Replace("|", ","),
                    DataHoraCadastro = item.DataHoraCadastro.ToLongDateString()
                };

                model.Add(viewModel);
            }

            return View(model);
        }

        public ActionResult Novo()
        {
            var empresas = _aplicacaoServicoEmpresa.ObterTodos();
            var model = new FornecedorViewModel();

            model.Empresa = new SelectList(empresas, "Id", "NomeFantasia");
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Novo(FornecedorViewModel model)
        {
            try
            {
                Empresa empresa = null;

                if(model.EmpresaId > 0)
                {
                    empresa = _aplicacaoServicoEmpresa.ObterPorId(model.EmpresaId);
                }

                if(!string.IsNullOrWhiteSpace(model.CPFCNPJ) && model.CPFCNPJ.Length == 14)
                {
                    if (string.IsNullOrWhiteSpace(model.RG))
                    {
                        ModelState.AddModelError("RG", "O campo RG deve ser preenchido");
                    }

                    if(string.IsNullOrWhiteSpace(model.DataNascimento))
                    {
                        ModelState.AddModelError("DataNascimento", "O campo é de preenchimento obrigatório");
                    }

                    if ((empresa != null && empresa.UF.ToUpper() == "PR") && (DateTime.Now.Year - Convert.ToDateTime(model.DataNascimento).Year) < 18)
                    {
                        ModelState.AddModelError("DataNascimento", "A idade deve ser maior de 18 anos");
                    }
                }

                if (ModelState.IsValid)
                {
                    var fornecedor = new Fornecedores.Dominio.Entidades.Fornecedor();
                    fornecedor.CPFCNPJ = model.CPFCNPJ;
                    fornecedor.DataHoraCadastro = DateTime.Now;
                    fornecedor.Nome = model.Nome;
                    fornecedor.EmpresaId = model.EmpresaId;
                    fornecedor.Telefone = Session["TELEFONES"] != null ? (string)Session["TELEFONES"] : string.Empty;
                    fornecedor.RG = model.RG;
                    fornecedor.DataNascimento = string.IsNullOrWhiteSpace(model.DataNascimento) ? new DateTime(1900, 01, 01) : Convert.ToDateTime(model.DataNascimento);

                    _aplicacaoServicoFornecedor.Incluir(fornecedor);
                    return RedirectToAction("Index");
                }
                else
                {
                    var empresas = _aplicacaoServicoEmpresa.ObterTodos();

                    model.Empresa = new SelectList(empresas, "Id", "NomeFantasia");

                    if (Session["TELEFONES"] != null)
                    {
                        model.Telefones = ((string)Session["TELEFONES"]).Split('|').ToList();
                    }
                    return View(model);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public JsonResult AdicionarTelefone(string telefone)
        {
            bool _adicionou = false;

            if (!string.IsNullOrWhiteSpace(telefone))
            {
                if (Session["TELEFONES"] == null)
                {
                    Session["TELEFONES"] = telefone;
                    _adicionou = true;
                }
                else
                {
                    string telefones = (string)Session["TELEFONES"];
                    telefones = string.Concat(telefones, "|", telefone);
                    Session["TELEFONES"] = telefones;
                    _adicionou = true;
                }
            }
            
            return Json(new { Adicionou = _adicionou }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoverTelefone(string telefone)
        {
            bool _removeu = false;

            if (!string.IsNullOrWhiteSpace(telefone))
            {
                if (Session["TELEFONES"] != null)
                {
                    string[] telefonesSession = ((string)Session["TELEFONES"]).Split('|');
                    string telefones = string.Empty;

                    foreach (var item in telefonesSession)
                    {
                        if(item != telefone)
                        {
                            telefones += string.IsNullOrWhiteSpace(telefones) ? item : "|" + item;
                        }
                    }

                    Session["TELEFONES"] = telefones;

                    _removeu = true;
                }
            }

            return Json(new { Removeu = _removeu }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PesquisarFornecedores(string nome, string cpfcnpj, string dataCadastro)
        {
            IQueryable<Fornecedores.Dominio.Entidades.Fornecedor> fornecedores = _aplicacaoServicoFornecedor.ObterTodos().AsQueryable();
            var listaFornecedores = new List<FornecedorViewModel>();

            if (!string.IsNullOrWhiteSpace(nome))
            {
                fornecedores = fornecedores.Where(f => f.Nome.Contains(nome));
            }

            if (!string.IsNullOrWhiteSpace(cpfcnpj))
            {
                fornecedores = fornecedores.Where(f => f.CPFCNPJ.Contains(nome));
            }

            if (!string.IsNullOrWhiteSpace(dataCadastro))
            {
                DateTime dataDeCadastro;
                DateTime.TryParse(dataCadastro, out dataDeCadastro);

                fornecedores = fornecedores.Where(f => f.DataHoraCadastro == dataDeCadastro);
            }

            if (fornecedores.Count() > 0) {
                foreach (var item in fornecedores)
                {
                    var fornecedor = new FornecedorViewModel();

                    fornecedor.CPFCNPJ = item.CPFCNPJ;
                    fornecedor.DataHoraCadastro = item.DataHoraCadastro.ToLongDateString();
                    fornecedor.NomeEmpresa = item.Empresa.NomeFantasia;
                    fornecedor.Nome = item.Nome;
                    fornecedor.Telefone = item.Telefone.Replace("|",",");

                    listaFornecedores.Add(fornecedor);
                }
            }

            return Json(new { Fornecedores = listaFornecedores }, JsonRequestBehavior.AllowGet);

        }
    }
}