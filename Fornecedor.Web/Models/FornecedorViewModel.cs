using Fornecedores.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fornecedor.Web.Models
{
    public class FornecedorViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required()]
        [StringLength(200)]
        public string Nome { get; set; }
        [Required()]
        [MaxLength(18)]
        [MinLength(11)]
        [Display(Name = "CPF/CNPJ")]
        public string CPFCNPJ { get; set; }
        [Display(Name ="Data/hora de cadastro")]
        public string DataHoraCadastro { get; set; }
        [Required(ErrorMessage = "Selecione uma empresa")]
        [Display(Name ="Empresa")]
        public int EmpresaId { get; set; }
        [Display(Name = "Empresa")]
        public string NomeEmpresa { get; set; }
        public SelectList Empresa { get; set; }
        public string Telefone { get; set; }
        public List<string> Telefones { get; set; }
        public string RG { get; set; }
        [Display(Name ="Data de nascimento")]
        public string DataNascimento { get; set; }

        public FornecedorViewModel()
        {
            Telefones = new List<string>();
        }
    }
}