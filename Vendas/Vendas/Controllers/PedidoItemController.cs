using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vendas.DAL;
using Vendas.Models;

namespace Vendas.Controllers
{
    public class PedidoItemController : Controller
    {
        private Context db = new Context();

        public ActionResult ListarItens(int id)
        {
            var lista = db.PedidoItem.Where(m => m.Pedido.Id == id);
            ViewBag.Pedido = id;
            return PartialView(lista);
        }

        public ActionResult SalvarItens(string material, decimal quantidade, decimal valorUnitario, decimal valorTotal, int idPedido)
        {
            var item = new PedidoItem()
            {
                Material = material,
                Quantidade = quantidade,
                ValorUnitario = valorUnitario,
                ValorTotal = valorTotal,
                Pedido = db.Pedido.Find(idPedido)
            };

            db.PedidoItem.Add(item);
            db.SaveChanges();

            return Json(new { Resultado = item.Id }, JsonRequestBehavior.AllowGet);
        }

        // GET: PedidoItem
        public ActionResult Index()
        {
            var pedidoItem = db.PedidoItem.Include(p => p.Pedido);
            return View(pedidoItem.ToList());
        }

        // GET: PedidoItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoItem pedidoItem = db.PedidoItem.Find(id);
            if (pedidoItem == null)
            {
                return HttpNotFound();
            }
            return View(pedidoItem);
        }

        // GET: PedidoItem/Create
        public ActionResult Create()
        {
            ViewBag.IdPedido = new SelectList(db.Pedido, "Id", "Id");
            return View();
        }

        // POST: PedidoItem/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Material,Quantidade,ValorUnitario,ValorTotal,IdPedido")] PedidoItem pedidoItem)
        {
            if (ModelState.IsValid)
            {
                db.PedidoItem.Add(pedidoItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPedido = new SelectList(db.Pedido, "Id", "Id", pedidoItem.IdPedido);
            return View(pedidoItem);
        }

        // GET: PedidoItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoItem pedidoItem = db.PedidoItem.Find(id);
            if (pedidoItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPedido = new SelectList(db.Pedido, "Id", "Id", pedidoItem.IdPedido);
            return View(pedidoItem);
        }

        // POST: PedidoItem/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Material,Quantidade,ValorUnitario,ValorTotal,IdPedido")] PedidoItem pedidoItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidoItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPedido = new SelectList(db.Pedido, "Id", "Id", pedidoItem.IdPedido);
            return View(pedidoItem);
        }

        // GET: PedidoItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoItem pedidoItem = db.PedidoItem.Find(id);
            if (pedidoItem == null)
            {
                return HttpNotFound();
            }
            return View(pedidoItem);
        }

        // POST: PedidoItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PedidoItem pedidoItem = db.PedidoItem.Find(id);
            db.PedidoItem.Remove(pedidoItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
