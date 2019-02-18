using System;
using System.Collections.Generic;

namespace EfCore_DbFirst.Models
{
    public partial class Tiposocios
    {
        public Tiposocios()
        {
            Alunos = new HashSet<Alunos>();
        }

        public int Id { get; set; }
        public int DuracaoEmMeses { get; set; }
        public int TaxaDesconto { get; set; }

        public virtual ICollection<Alunos> Alunos { get; set; }
    }
}
