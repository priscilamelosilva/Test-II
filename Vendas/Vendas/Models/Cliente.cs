using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vendas.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome{ get; set; }

        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido.")]
        public DateTime DataNascimento{ get; set; }

        public int Idade{ get; set; }

        [Display(Name = "CPF")]
        public string Cpf{ get; set; }

        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}