using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NET_Framework_MVC.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public string Autor { get;set;}
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["MinhaConexao"].ConnectionString;

        public Livro(int id, string titulo, string categoria, string autor)
        {
            Id = id;
            Titulo = titulo;
            Categoria = categoria;
            Autor = autor;
        }

        public Livro()
        {
        }

        public static List<Livro> Todos()
        {
            List<Livro> livros = new List<Livro>{
            new Livro(1,"Narnia", "fantasia", "c.s. lewis" ),
            new Livro(2, "A arma escalate", "Renata Ventura", "fantasia"),
            new Livro(3, "Rainha Vermelha", "Victoria A.", "distopia"),
            new Livro(4, "Orgulho e preconceito", "Jane Austen", "Romance")
        };
            return livros;
        }

        public static List<Livro> TodosComSQL()
        {
            List<Livro> livros = new List<Livro>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "SELECT id, titulo, autor, categoria FROM livros";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Livro livro = new Livro();
                            livro.Id = reader.GetInt32(0);
                            livro.Titulo = reader.GetString(1);
                            livro.Autor = reader.GetString(2);
                            livro.Categoria = reader.GetString(3);
                            



                            livros.Add(livro);
                        }
                    }
                }
            }

            return livros;

        }

    }
}