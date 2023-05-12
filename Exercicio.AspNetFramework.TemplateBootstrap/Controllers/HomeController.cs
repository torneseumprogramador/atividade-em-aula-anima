using Exercicio.AspNetFramework.TemplateBootstrap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercicio.AspNetFramework.TemplateBootstrap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home - CRUD";
            ViewBag.PrimaryTitle = "CRUD";
            ViewBag.Message = "Bem-Vindxs";
            ViewBag.Paragraph = "Sistema de gerenciamento de cadastro";
            ViewBag.TemplateVersion = "Bootstrap v5.2.3";
            return View();
        }

        public ActionResult Listar()
        {
            ViewBag.PrimaryTitle = "Lista de Clientes";
            return View(ClienteModel.Listagem);
        }

        [HttpGet]
        public ActionResult Cadastrar(int? id)
        {
            if (id.HasValue && ClienteModel.Listagem.Any(user => user.Id == id))
            {
                ClienteModel cliente = ClienteModel.Listagem.Single(user => user.Id == id);

                return View(cliente);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(ClienteModel cliente)
        {
            ClienteModel.Salvar(cliente);

            return RedirectToAction(nameof(Listar));
        }

        public ActionResult Alterar(ClienteModel cliente)
        {
            return View();
        }

        public ActionResult Exluir(ClienteModel cliente)
        {
            return View();
        }
    }
}