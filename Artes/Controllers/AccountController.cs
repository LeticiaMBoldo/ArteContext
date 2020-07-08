using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Artes.Controllers
{
    public class AccountController : Controller
    {
        //criar as variais 
        private readonly UserManager<Usuario> userManager;
        private readonly SignInManager<Usuario> signInManager;

        //criar o controller 
        public AccountController(UserManager<Usuario> user, SignInManager<Usuario> sign)
        {
            userManager = user;
            signInManager = sign;
        }

        public IActionResult Login()
        {
            return View();
        }

        //quando o usuario pede para enviar infromação pro controller
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel user)
        {
            //cria as mensagens de erro
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            //variavel que vai receber 
            var result = await signInManager.PasswordSignInAsync(user.Email, user.Password, true, lockoutOnFailure: true);
            //lockoutOnFailure significa que o usuário errar a senha 3 vezes ele vai ficar travado e vai ter de esperar alguns minutos
            //para tentar de novo
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Admin");
            }

            if(result.IsLockedOut)
            {
                ModelState.AddModelError("", "Usuário bloqueado, aguarde alguns minutos e tente novamente");
                return View();
            }
            else
            {
                ModelState.AddModelError("", "E-mail de Acesso e/ou Senha Inválidos!!!");
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}