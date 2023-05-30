using Charles_WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Charles_WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CadastroClientes()
        {
            ViewBag.clientes = Cliente.GetClientes();
            return View();
        }

        [HttpPost]
        public ActionResult Salvar(Cliente cliente)
        {
            Cliente.Salvar(cliente);
            //return View();
            return RedirectToAction("CadastroClientes");
        }


        [HttpPost]
        public ActionResult Excluir(int? id)
        {
            Cliente.Excluir(id.Value);

            return RedirectToAction("CadastroClientes");
        }

       

        [HttpPost]
        public ActionResult EditarCliente(Cliente cliente)
        {
            Cliente.Atualizar(cliente);

            return RedirectToAction("CadastroClientes");
        }
        [HttpGet]
        public ActionResult ObterClientes()
        {
            List<Cliente> clientes = Cliente.GetClientes();

            return PartialView("_ListaClientes", clientes);
        }

    }
}