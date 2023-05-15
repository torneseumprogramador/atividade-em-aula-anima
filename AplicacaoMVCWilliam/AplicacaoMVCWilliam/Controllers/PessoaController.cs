using AplicacaoMVCWilliam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace AplicacaoMVCWilliam.Controllers
{
    public class PessoaController : Controller
    {
        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            if (!Request.Form["nome"].IsEmpty())
            {
                Pessoa pessoa = new Pessoa();
                pessoa.Nome = Request.Form["nome"];
                pessoa.CPF = Request.Form["cpf"];
                pessoa.Telefone = Request.Form["telefone"];
                pessoa.Salvar();

                ViewBag.mensagem = "Cadastrado com sucesso!";
            }

            return RedirectToAction("Index", "Home", new { mensagem = ViewBag.mensagem } );
        }
    }
}