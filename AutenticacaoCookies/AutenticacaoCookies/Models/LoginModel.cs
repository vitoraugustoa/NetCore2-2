using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutenticacaoCookies.Models
{
    public class LoginModel
    {
        [Required]
        public string Usuario { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public String RequestPath { get; set; }


    }
}
