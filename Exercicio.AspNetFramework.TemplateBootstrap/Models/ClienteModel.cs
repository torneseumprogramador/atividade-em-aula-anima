using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio.AspNetFramework.TemplateBootstrap.Models
{
    public class ClienteModel
    {
        // Propriedades
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string NomeCompleto => $"{Nome} {Sobrenome}";

        public string Email { get; set; }

        public string Profissao { get; set; }

        public string DataCadastro => DateTime.Now.ToString("dd/MM/yyyy");

        private static List<ClienteModel> listagem = new List<ClienteModel>();

        public static IQueryable<ClienteModel> Listagem { get { return listagem.AsQueryable(); } }

        // Construtor
        static ClienteModel()
        {
            // Memory database
            ClienteModel.listagem.Add(
                new ClienteModel { Id = 1, Nome = "Fulano", Sobrenome = "Silva", Email = "FulanoSilva@teste.com", Profissao = "Arquiteto de Sistemas II" });
            ClienteModel.listagem.Add(
                new ClienteModel { Id = 2, Nome = "Beltrano", Sobrenome = "Oliveira", Email = "BeltranoOliveira@teste.com", Profissao = "DBA" });
            ClienteModel.listagem.Add(
                new ClienteModel { Id = 3, Nome = "Sicrano", Sobrenome = "Santos", Email = "SicranoSantos@teste.com", Profissao = "Arquiteto de Sistemas I" });
            ClienteModel.listagem.Add(
                new ClienteModel { Id = 4, Nome = "Jorge", Sobrenome = "Pinto", Email = "JorgePinto@teste.com", Profissao = "Desenvolvedor Front-End" });
            ClienteModel.listagem.Add(
                new ClienteModel { Id = 5, Nome = "Paulo", Sobrenome = "Silva", Email = "PauloSilvateste.com", Profissao = "Desenvolvedor Back-End" });
            ClienteModel.listagem.Add(
                new ClienteModel { Id = 6, Nome = "Maria", Sobrenome = "Penha", Email = "MariaPenha@teste.com", Profissao = "Desenvolvedor Full-Stack" });
            ClienteModel.listagem.Add(
                new ClienteModel { Id = 7, Nome = "José", Sobrenome = "Penha", Email = "JosePenha@teste.com", Profissao = "BDA I" });
            ClienteModel.listagem.Add(
                new ClienteModel { Id = 8, Nome = "Ana", Sobrenome = "Camargo", Email = "AnaCamargo@teste.com", Profissao = "Arquiteto de Sistemas III" });
            ClienteModel.listagem.Add(
                new ClienteModel { Id = 9, Nome = "Pedro", Sobrenome = "Pinto", Email = "PedroPinto@teste.com", Profissao = "Engenheiro de Dados I" });
            ClienteModel.listagem.Add(
                new ClienteModel { Id = 10, Nome = "Joana", Sobrenome = "Souza", Email = "JoanaSouza@teste.com", Profissao = "Analista de Dados II" });
            ClienteModel.listagem.Add(
                new ClienteModel { Id = 11, Nome = "Beltrana", Sobrenome = "Oliveira", Email = "BeltranaOliveira@teste.com", Profissao = "Agilista III" });
            ClienteModel.listagem.Add(
                new ClienteModel { Id = 12, Nome = "Sicrana", Sobrenome = "Santos", Email = "SicranaSantos@teste.com", Profissao = "UX" });
        }

        // Metodos
        public static void Salvar(ClienteModel usuarioRequest)
        {
            ClienteModel usuarioResponse = ClienteModel.listagem.Find(user => user.Id == usuarioRequest.Id);

            if (usuarioResponse != null)
            {
                usuarioResponse.Nome = usuarioRequest.Nome;
                usuarioResponse.Sobrenome = usuarioRequest.Sobrenome;
                usuarioResponse.Email = usuarioRequest.Email;
                usuarioResponse.Profissao = usuarioRequest.Profissao;
            }
            else
            {
                usuarioRequest.Id = ClienteModel.listagem.Max(user => user.Id) + 1;
                ClienteModel.listagem.Add(usuarioRequest);
            }
        }

        public static bool Excluir(int id)
        {
            ClienteModel usuario = ClienteModel.listagem.Find(user => user.Id == id);

            if (usuario != null)
            {
                return ClienteModel.listagem.Remove(usuario);
            }

            return false;
        }
    }
}