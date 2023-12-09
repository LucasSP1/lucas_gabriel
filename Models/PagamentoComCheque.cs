using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lucas_gabriel.Models
{
    public class PagamentoComCheque : TipoDePagamento
    {
        public string? NomeDoBanco { get; set; }
    }
}