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
            ViewBag.Message = "Bem-Vindxs";
            ViewBag.Paragraph = "Sistema de gerenciamento de cadastro";
            ViewBag.TemplateVersion = "Bootstrap v5.2.3";
            return View();
        }
    }
}