using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artes.Models
{
    //informar que a classe criada é especial
    public class Usuario : IdentityUser
    {

        public string Nome { get; set; }
    }
}
