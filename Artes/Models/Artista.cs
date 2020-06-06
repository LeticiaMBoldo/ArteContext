using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Artes.Models
{
    [Table("Artista")]
    public class Artista
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Artista")]
        [StringLength(60, ErrorMessage = "O Nome do Artista deve possuir no máximo 60 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Endereço")]
        [StringLength(60, ErrorMessage = "O Endereço deve possuir no máximo 60 caracteres")]
        public string Endereco { get; set; }

        [StringLength(50, ErrorMessage = "O Bairro deve possuir no máximo 50 caracteres")]
        public string Bairro { get; set; }

        [Display(Name = "Telefone/Celular")]
        [StringLength(20, ErrorMessage = "O Telefone/Celular deve possuir no máximo 20 caracteres")]
        public string Fone { get; set; }

        [Display(Name = "RG")]
        [StringLength(20, ErrorMessage = "O RG deve possuir no máximo 20 caracteres")]
        public string Rg { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Informe o E-mail do Artista")]
        [StringLength(100, ErrorMessage = "O E-mail deve possuir no máximo 20 caracteres")]
        public string Email { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Informe a Cidade do Artista")]
        public int CidadeId { get; set; }

        [Display(Name = "Cidade")]
        public Cidade Cidade { get; set; }

        [Display(Name = "Foto")]
        [StringLength(500)]
        public string Foto { get; set; }
    }
}
