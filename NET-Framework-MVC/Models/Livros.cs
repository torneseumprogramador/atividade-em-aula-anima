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


        public static List<Livro> Todos()
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