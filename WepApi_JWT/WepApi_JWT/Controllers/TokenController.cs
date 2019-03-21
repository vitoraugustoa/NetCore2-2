using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WepApi_JWT.ViewModels;


namespace WepApi_JWT.Controllers
{
    public class TokenController : Controller
    {
        [HttpPost]
        [Route("api/token/create")]
        public IActionResult Create([FromBody]LoginViewModel model)
        {
            if (model.Email == "vitor.lopes@bhs.com.br" && model.Password == "123")
            {
                return new ObjectResult(GenerateToken(model.Email));
            }
            return BadRequest();
        }

        private string GenerateToken(string email)
        {
            var claims = new Claim[]
            {
                //  Define as claims
                new Claim(ClaimTypes.Name, email),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString())
            };

            //  Gera o token
            SymmetricSecurityKey symmetricSecurity = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("senhasupersecretaparaauth"));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurity , SecurityAlgorithms.HmacSha256);
            JwtHeader jwtHeader = new JwtHeader(signingCredentials);
            JwtPayload jwtPayload = new JwtPayload(claims);
            JwtSecurityToken token = new JwtSecurityToken(jwtHeader , jwtPayload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}