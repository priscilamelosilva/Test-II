using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vendas.Models
{
    public class PedidoItem
    {
        public int Id { get; set; }
        public string Material { get; set; }
        public decimal Quantidade { get; set; }

        [Display(Name = "Valor Unitário")]
        public decimal ValorUnitario { get; set; }

        [Display(Name = "Valor Total")]
        public decimal ValorTotal { get; set; }

        public int IdPedido{ get; set; }
        [ForeignKey("IdPedido")]
        public virtual Pedido Pedido { get; set; }
    }
}