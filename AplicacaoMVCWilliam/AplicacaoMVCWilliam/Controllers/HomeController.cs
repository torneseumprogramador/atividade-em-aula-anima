using AplicacaoMVCWilliam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace AplicacaoMVCWilliam.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.pessoas = Pessoa.Todos();

            if (!Request.Form["nome"].IsEmpty())
            {
                Pessoa pessoa = new Pessoa();
                pessoa.Nome = Request.Form["nome"];
                pessoa.CPF = Request.Form["cpf"];
                pessoa.Telefone = Request.Form["telefone"];
                pessoa.Salvar();

                ViewBag.mensagem = "Cadastrado com sucesso!";
            }


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
    }
}