using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Pessoa
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        public string Nome;
        public string CPF;
        public string Telefone;

        public void Salvar()
        {
            pessoas.Add(this);
        }

        public static List<Pessoa> Todos()
        {
            return pessoas;
        }
    }
}