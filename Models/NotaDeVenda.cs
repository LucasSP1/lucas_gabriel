using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace lucas_gabriel.Models
{
    public class NotaDeVenda
    {
        public int Id { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public NotaStatus Status {get; set;}
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public int VendedorId { get; set; }
        public Vendedor? Vendedor { get; set; }
        public int TransportadoraId { get; set; }
        public Transportadora? Transportadora { get; set; }
        public int TipoDePagamentoId { get; set; }
        public TipoDePagamento? TipoDePagamento { get; set; }
    }
}