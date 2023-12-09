using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace lucas_gabriel.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Desc { get; set; }
        public int Qtd { get; set; }
        public double Preco { get; set; }

        [ForeignKey("Marca")]
        public int MarcaId { get; set; }
        public Marca? Marca { get; set; }
    }
}