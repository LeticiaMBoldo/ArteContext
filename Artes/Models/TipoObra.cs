using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artes.Models
{
    [Table("TipoObra")]
    public class TipoObra
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome do Tipo de Obra")]
        [Required(ErrorMessage = "Informe o Nome do Tipo de Obra")]
        [StringLength(50, ErrorMessage = "O Nome do Tipo de Obra deve possuir no máximo 50 caracteres")]
        public string Nome { get; set; }
    }
}
