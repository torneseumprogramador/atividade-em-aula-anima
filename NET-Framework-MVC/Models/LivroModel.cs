using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NET_Framework_MVC.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public string Autor { get;set;}
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["MinhaConexao"].ConnectionString;

        public LivroModel(int id, string titulo, string categoria, string autor)
        {
            Id = id;
            Titulo = titulo;
            Categoria = categoria;
            Autor = autor;
        }

        public LivroModel()
        {
        }

        public void add()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();


                string sql = "INSERT INTO livros (titulo, autor, categoria) VALUES (@titulo, @autor, @categoria)";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@titulo", this.Titulo);
                    command.Parameters.AddWithValue("@autor", this.Autor);
                    command.Parameters.AddWithValue("@categoria", this.Categoria);

                    int rowsAffected = command.ExecuteNonQuery();

                    Console.WriteLine("Número de linhas afetadas: " + rowsAffected);
                }

               
            }
        }

        public static List<LivroModel> Todos()
        {
            List<LivroModel> livros = new List<LivroModel>();

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "SELECT id, titulo, autor, categoria FROM livros";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LivroModel livro = new LivroModel();
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