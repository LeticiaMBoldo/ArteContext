using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Artes.Models
{
    //ViewModel
   public class UserLoginModel
    {
        //o que eu vou ter no meu login
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail de Acesso")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
    
        /*
        [Display(Name = "Remember me? ")]
        public bool RememberMe { get; set; }*/
    }

   public class UserRegistrationModel
    {
        [Required(ErrorMessage = "Informe o Nome do Usuário")]
        public string Nome { get; set; }

        [Display(Name = "E-Mail de Acesso")]
        [Required(ErrorMessage = "Informe o E-mail de Acesso")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Comfirmação de Senha")]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "Senha e Confirmação de Senha não conferem")]
        public string confirmacaoSenha { get; set; }
    }
}
