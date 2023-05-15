using NET_Framework_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NET_Framework_MVC.Controllers
{
    public class LivroController : Controller
    {
        // GET: Livro
        public ActionResult Index()
        {
            ViewBag.livros = LivroModel.Todos();
            return View(new
            {
                Livros = LivroModel.Todos()
            });
        }

        // GET: Livro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Livro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livro/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                LivroModel livro = new LivroModel();
                livro.Titulo = collection["Titulo"];
                livro.Autor = collection["Autor"];
                livro.Categoria = collection["Categoria"];

                livro.add();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Livro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Livro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Livro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Livro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
