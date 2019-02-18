using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Mvc_BO.Models
{
    public class Aluno
    {
        //Para que a propriedade aluno nunca seja vinculado à uma action
        // [BindNever] 
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome deve ser informado!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O nome deve ter no minimo 5 caracteres")]
        [Display(Name = "Informe o nome do cliente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Sexo deve ser informado!")]
        [Display(Name = "Informe o Sexo do cliente")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "O Email deve ser informado!")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Data de nascimento deve ser informada!")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Nascimento { get; set; }

        public string Foto {get; set;}

        public string Texto {get; set;}
    }
}