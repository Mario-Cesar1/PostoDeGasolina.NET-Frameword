using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PostoGasolina.Models;

namespace PostoGasolina.Controllers
{
    public class VeiculoController : Controller
    {
        private BDPostoEntities db = new BDPostoEntities();

        // GET: Veiculo
        public ActionResult Index()
        {
            var veiculo = db.Veiculo.Include(v => v.Motorista1).Include(v => v.TipoCombustivel1);
            return View(veiculo.ToList());
        }

        // GET: Veiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculo.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // GET: Veiculo/Create
        public ActionResult Create()
        {
            ViewBag.Motorista = new SelectList(db.Motorista, "id", "Nome");
            ViewBag.TipoCombustivel = new SelectList(db.TipoCombustivel, "id", "Descricao");
            return View();
        }

        // POST: Veiculo/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Marca,TipoCombustivel,Motorista")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Veiculo.Add(veiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Motorista = new SelectList(db.Motorista, "id", "Nome", veiculo.Motorista);
            ViewBag.TipoCombustivel = new SelectList(db.TipoCombustivel, "id", "Descricao", veiculo.TipoCombustivel);
            return View(veiculo);
        }

        // GET: Veiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculo.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Motorista = new SelectList(db.Motorista, "id", "Nome", veiculo.Motorista);
            ViewBag.TipoCombustivel = new SelectList(db.TipoCombustivel, "id", "Descricao", veiculo.TipoCombustivel);
            return View(veiculo);
        }

        // POST: Veiculo/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Marca,TipoCombustivel,Motorista")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Motorista = new SelectList(db.Motorista, "id", "Nome", veiculo.Motorista);
            ViewBag.TipoCombustivel = new SelectList(db.TipoCombustivel, "id", "Descricao", veiculo.TipoCombustivel);
            return View(veiculo);
        }

        // GET: Veiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculo.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // POST: Veiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Veiculo veiculo = db.Veiculo.Find(id);
            db.Veiculo.Remove(veiculo);
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
