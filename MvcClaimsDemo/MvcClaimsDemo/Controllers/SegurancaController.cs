using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace MvcClaimsDemo.Controllers
{
    [Authorize(Policy = "FUNCI")]
    public class SegurancaController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        public SegurancaController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.Name != null)
            {
                if (User.Identity.Name == "diretor@email.com")
                {
                    var user = await _userManager.FindByNameAsync(User.Identity.Name);
                    //atribuir o valor da claim
                    await _userManager.AddClaimAsync(user, new Claim("CEO", "D001"));
                }
                else
                {
                    var user = await _userManager.FindByNameAsync(User.Identity.Name);
                    //atribuir o valor da claim
                    await _userManager.AddClaimAsync(user, new Claim("ADMIN", "A001"));
                }
                ViewBag.Claims = "Declaração atribuída a : " + User.Identity.Name.ToString();
            }
            else
            {
                ViewBag.Claims = "Não existe usuário logado";
            }
            return View();
        }
    }
}