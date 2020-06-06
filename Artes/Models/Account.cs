using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Artes.Models
{
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
}
