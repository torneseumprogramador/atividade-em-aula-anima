using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace Charles_WebApplication.Models
{
    public partial class Cliente
    {

        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["PostgresConexao"].ConnectionString;

        public static void Salvar(Cliente cliente)
        {
            try
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
                var mensagem = "Cadastro feito com sucesso!!!";
                System.Windows.Forms.MessageBox.Show(mensagem, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                var mensagem = "Erro!!! : ";
                System.Windows.Forms.MessageBox.Show(mensagem+ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static List<Cliente> GetClientes()
        {
            var clientes = new List<Cliente>();

            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT clienteid, nome, telefone, cpf FROM cliente order by nome", connection))
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

        public static void Atualizar(Cliente cliente)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;


                    command.CommandText = $"UPDATE cliente SET nome ='{cliente.Nome}', telefone ='{cliente.Telefone}', cpf ='{cliente.Cpf}' WHERE clienteid = {cliente.Clienteid};";
                    command.ExecuteNonQuery();

                }
            }
        }

        public static void Excluir(int clienteid)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;

                        command.CommandText = $"DELETE FROM cliente WHERE clienteid = '{clienteid}'";
                        command.ExecuteNonQuery();
                        var mensagem = "Exclusao feito com sucesso!!!";
                        System.Windows.Forms.MessageBox.Show(mensagem, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Npgsql.PostgresException e)
                    {
                        // Trate a exceção aqui
                        var mensagem = "Erro ao excluir Cliente: " + e.Message;
                        System.Windows.Forms.MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


    }
}