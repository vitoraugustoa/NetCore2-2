using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_EntityFrame.Models
{
    [Table("TipoSocios")]
    public class TipoSocio
    {
        [Key]
        public int Id { get; set; } // Para funcionar como uma chave primaria na tabela

        [Required]
        public int DuracaoEmMeses { get; set; }
        // Mensal -> sem desconto
        // 3 meses -> 10%
        // 6 meses -> 20%
        // 12 meses -> 30%
        
        [Required]
        public int TaxaDesconto { get; set; }
    }
}