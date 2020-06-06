using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artes.Models
{
    [Table("Cidade")]
    public class Cidade
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o Nome da Cidade")]
        [StringLength(50, ErrorMessage = "O Nome da Cidade deve possuir no máximo 50 caracteres")]
        public string Nome { get; set; }
        
        [Display(Name = "UF")]
        [Required(ErrorMessage = "Informe o Estado da Cidade")]
        [StringLength(2, ErrorMessage = "O Estado deve possuir no máximo 2 caracteres")]
        public string Estado { get; set; }

        [NotMapped]
        public string NomeCompleto { get => Nome + " (" + Estado + ")"; }
    }
}
