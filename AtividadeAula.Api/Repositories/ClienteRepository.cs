using AtividadeAula.Api.Data;
using AtividadeAula.Api.Models;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;

namespace AtividadeAula.Api.Repositories
{
    public class ClienteRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["GamaApp"].ConnectionString;
        ClienteDbContext _context = new ClienteDbContext();

        public Cliente BuscaClientePorId(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var sql = "SELECT * FROM clientes WHERE Id = @Id";
                return connection.QueryFirstOrDefault<Cliente>(sql, new { Id = id });
            }
        }

        public Cliente GetByCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ListaClientes()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var sql = "SELECT * FROM clientes";

                return connection.Query<Cliente>(sql).ToList();

            }
        }

        public List<Cliente> ListClientesEntity()
        {
            List<Cliente> clientes;
            using (var context = new ClienteDbContext()) // Substitua "SeuContexto" pelo nome do seu contexto de banco de dados
            {
                clientes = context.Clientes.ToList();
            }

            return clientes;

        }

        public void InserirCliente(Cliente cliente)
        {
            var sql = @"insert into clientes(nome, cpf)
            values(@nome, @cpf);";

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("Nome", cliente.Nome, DbType.String);
            parametros.Add("Cpf", cliente.CPF, DbType.String);

            var connection = new NpgsqlConnection(connectionString);  
            connection.Execute(sql, parametros);

        }

        public void AtualizarCliente(string cpf, string nome)
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            var sql = @"update clientes 
                set nome = @nome where cpf = @cpf"
            ;
            var parameters = new { Nome = nome, CPF = cpf };

            var lineUpdated = connection.Execute(sql, new { nome, cpf });

        }
    }
}