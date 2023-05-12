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
        public ActionResult Index(string mensagem = null)
        {
            ViewBag.pessoas = Pessoa.Todos();

            ViewBag.mensagem = mensagem;

            return View();
        }
    }
}