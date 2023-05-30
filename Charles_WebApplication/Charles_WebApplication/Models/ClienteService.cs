using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Charles_WebApplication.Models
{
    public partial class Cliente
    {

        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["PostgresConexao"].ConnectionString;

        public static void Salvar(Cliente cliente)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;


                    command.CommandText = $"INSERT INTO Cliente (nome, telefone, cpf) VALUES ('{cliente.Nome}', '{cliente.Telefone}', '{cliente.Cpf}')";
                    command.ExecuteNonQuery();

                }
            }
        }

        public static List<Cliente> GetClientes()
        {
            var clientes = new List<Cliente>();

            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT clienteid, nome, telefone, cpf FROM cliente", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cliente = new Cliente
                            {
                                Clienteid = reader.GetInt32(0),
                                Nome = reader.GetString(1),
                                Telefone = reader.GetString(2),
                                Cpf = reader.GetString(3)
                            };
                            clientes.Add(cliente);
                        }
                    }
                }
            }

            return clientes;
        }


    }
}