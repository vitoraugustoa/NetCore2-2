using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_EntityFrame.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
    
        [Required]
        [StringLength(50)]
        public string Sexo { get; set; }

        [Required]
        [StringLength(150)]
        public string Email { get; set; }

        public DateTime Nascimento { get; set; }    

        [Required]
        [StringLength(150)]
        public string Foto { get; set; }

        [Required]
        [StringLength(150)]
        public string Texto { get; set; }

        public TipoSocio TipoSocio { get; set; } // Relacionamento indicando que a tabela aluno possui um tipo Socio
    }
}