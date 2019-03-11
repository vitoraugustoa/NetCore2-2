using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcClaimsDemo.Models;
using Microsoft.AspNetCore.Authorization;

namespace MvcClaimsDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.Claims = User.Claims;
                
            return View();
        }

        [Authorize(Policy = "CEO")]
        public IActionResult Diretor()
        {

            return View();
        }

        [Authorize(Policy = "ADMIN")]
        public IActionResult Funcionario()
        {

            return View();
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
