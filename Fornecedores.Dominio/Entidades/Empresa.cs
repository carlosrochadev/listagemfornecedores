using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fornecedores.Dominio.Entidades
{
    [Table("Empresas")]
    public class Empresa
    {
        public Empresa()
        {
            Fornecedores = new HashSet<Fornecedor>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="O campo deve ser preenchido")]
        [MaxLength(2, ErrorMessage ="O campo deve ter 2 caracteres. Ex: SC")]
        [StringLength(2)]
        public string UF { get; set; }

        [Display(Name ="Nome fantasia")]
        [Required(ErrorMessage = "O campo deve ser preenchido")]
        [MaxLength(100, ErrorMessage = "O campo deve conter menos de 100 caracteres")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "O campo deve ser preenchido")]
        [MaxLength(18, ErrorMessage = "O campo está no formato incorreto")]
        [StringLength(18)]
        public string CNPJ { get; set; }

        public virtual ICollection<Fornecedor> Fornecedores { get; set; }
    }
}
