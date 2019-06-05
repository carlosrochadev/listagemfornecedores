using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fornecedores.Dominio.Entidades
{
    [Table("Fornecedores")]
    public class Fornecedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required()]
        [StringLength(200)]
        public string Nome { get; set; }
        [Required()]
        [StringLength(18)]
        public string CPFCNPJ { get; set; }
        [StringLength(14)]
        public string RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public int EmpresaId { get; set; }
        [ForeignKey("EmpresaId")]
        public virtual Empresa Empresa { get; set; }
        public string Telefone { get; set; }

    }
}
