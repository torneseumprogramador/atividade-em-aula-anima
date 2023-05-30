using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Charles_WebApplication.Models
{
    public partial class Cliente
    {
        public int Clienteid { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public int Id_cidade { get; set; }
    }
}