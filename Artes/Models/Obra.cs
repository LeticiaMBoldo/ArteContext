using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Artes.Models
{
    [Table("Obra")]
    public class Obra
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome da Obra")]
        [Required(ErrorMessage = "Informe o Nome da Obra")]
        [StringLength(1000, ErrorMessage = "O Nome da Obra deve possuir no máximo 1000 caracteres")]
        public string Nome { get; set; }


        [Display(Name = "Tipo de Obra")]
        [Required(ErrorMessage = "Informe o Tipo de Obra")]
        public int TipoObraId { get; set; }
        [Display(Name = "Tipo de Obra")]
        public TipoObra TipoObra { get; set; }


        [Display(Name = "Artista")]
        [Required(ErrorMessage = "Informe o Artista")]
        public int ArtistaId { get; set; }
        [Display(Name = "Artista")]
        public Artista Artista { get; set; }


        [Display(Name = "Inspirada Em")]
        [Required(ErrorMessage = "Informe qual foi a inspiração para a Obra")]
        [StringLength(2000, ErrorMessage = "A inspiração deve possuir no máximo 2000 caracteres")]
        public string InspiradaEm { get; set; }

        
        [Display(Name = "O que Representa")]
        [Required(ErrorMessage = "Informe o que a Obra Representa")]
        [StringLength(2000, ErrorMessage = "O que representa deve possuir no máximo 2000 caracteres")]
        public string Representa { get; set; }

        
        [Display(Name = "Foto da Obra")]
        [Required(ErrorMessage = "Carregue uma Imagem da Obra")]
        [StringLength(500)]
        public string FotoArte { get; set; }


        [Required]
        [Display(Name = "Data de Inscrição")]
        [DataType(DataType.DateTime)]
        public DateTime DataInscricao { get; set; }
    }
}
