using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace lucas_gabriel.Models
{
    public class Item
    {
        public int Id { get; set; }
        public double Preco { get; set; }
        public int Percentual { get; set; }
        public int Qtd { get; set; }

        [ForeignKey("Produto")]
        public int ProdutoId {get; set;}
        public Produto? Produto { get; set; }
        
        [ForeignKey("NotaDeVenda")]
        public int NotaDeVendaId { get; set; }
        public NotaDeVenda? NotaDeVenda { get; set; }
    }
}