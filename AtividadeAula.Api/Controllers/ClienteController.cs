using AtividadeAula.Api.Models;
using AtividadeAula.Api.Services;
using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;

namespace AtividadeAula.Api.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteService clienteService = new ClienteService();

        // GET: Cliente
        public ActionResult Index()
        {
            var clientes = clienteService.ListaClientes();
            return View(clientes);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente  = clienteService.BuscaClientePorId(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,CPF")] Cliente clienteModel)
        {
            if (ModelState.IsValid)
            {
                clienteService.InserirCliente(clienteModel);
                return RedirectToAction("Index");
            }

            return View(clienteModel);
        }

        //GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clienteModel = clienteService.BuscaClientePorId(id);
            if (clienteModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,CPF")] Cliente clienteModel)
        {
            if (ModelState.IsValid)
            {
                clienteService.AtualizaCliente(clienteModel);
                return RedirectToAction("Index");
            }
            return View(clienteModel);
        }

        // GET: Cliente/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ClienteModel clienteModel = _db.Clientes.Find(id);
        //    if (clienteModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(clienteModel);
        //}

        //// POST: Cliente/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ClienteModel clienteModel = _db.Clientes.Find(id);
        //    _db.Clientes.Remove(clienteModel);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
