using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContatoWebApi.Models
{
    [Table("Contatos")]
    public class Contato
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Informe o nome do contato")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o email do contato")]
        [StringLength(200)]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o telefone do contato")]
        [StringLength(50)]
        public string Telefone { get; set; }
    }
}
