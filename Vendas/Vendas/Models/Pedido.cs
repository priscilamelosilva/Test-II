using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vendas.Models
{
    public class Pedido
    {
        [Display(Name = "Pedido")]
        public int Id{ get; set; }

        [Required(ErrorMessage = "Preencha o Número do Pedido.", AllowEmptyStrings = false)]
        [Display(Name = "Número")]
        public int Numero { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido.")]
        public DateTime Data { get; set; }

        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public virtual Cliente Cliente { get; set; }
    }
}