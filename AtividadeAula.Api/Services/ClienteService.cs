using AtividadeAula.Api.Models;
using AtividadeAula.Api.Repositories;
using System.Collections.Generic;

namespace AtividadeAula.Api.Services
{
    public class ClienteService 
    {
        ClienteRepository clienteRepository = new ClienteRepository();

        public ClienteService()
        {
        }
        public Cliente BuscaClientePorId(int id)
        {
            return clienteRepository.BuscaClientePorId(id);
        }

        public Cliente GetByCpf(string cpf)
        {
            return clienteRepository.GetByCpf(cpf);
        }

        public void InserirCliente(Cliente cliente)
        {
            clienteRepository.InserirCliente(cliente);
        }

        public List<Cliente> ListaClientes()
        {
            //var clientes = clienteRepository.ListClientesEntity();
            return clienteRepository.ListaClientes();
        }

        public void AtualizaCliente(Cliente cliente)
        {
            clienteRepository.AtualizarCliente(cliente.CPF, cliente.Nome);      
        }
    }
}