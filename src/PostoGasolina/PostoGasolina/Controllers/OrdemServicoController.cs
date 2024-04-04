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
    public class OrdemServicoController : Controller
    {
        private BDPostoEntities db = new BDPostoEntities();

        // GET: OrdemServico
        public ActionResult Index()
        {
            var ordemServico = db.OrdemServico.Include(o => o.Motorista).Include(o => o.Posto);
            return View(ordemServico.ToList());
        }

        // GET: OrdemServico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdemServico ordemServico = db.OrdemServico.Find(id);
            if (ordemServico == null)
            {
                return HttpNotFound();
            }
            return View(ordemServico);
        }

        // GET: OrdemServico/Create
        public ActionResult Create()
        {
            ViewBag.IdMotorista = new SelectList(db.Motorista, "id", "Nome");
            ViewBag.idPosto = new SelectList(db.Posto, "id", "Nome");
            return View();
        }

        // POST: OrdemServico/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ValorLitro,DataOrdem,QtdCombustivel,IdMotorista,idPosto")] OrdemServico ordemServico)
        {
            if (ModelState.IsValid)
            {
                db.OrdemServico.Add(ordemServico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMotorista = new SelectList(db.Motorista, "id", "Nome", ordemServico.IdMotorista);
            ViewBag.idPosto = new SelectList(db.Posto, "id", "Nome", ordemServico.idPosto);
            return View(ordemServico);
        }

        // GET: OrdemServico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdemServico ordemServico = db.OrdemServico.Find(id);
            if (ordemServico == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMotorista = new SelectList(db.Motorista, "id", "Nome", ordemServico.IdMotorista);
            ViewBag.idPosto = new SelectList(db.Posto, "id", "Nome", ordemServico.idPosto);
            return View(ordemServico);
        }

        // POST: OrdemServico/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ValorLitro,DataOrdem,QtdCombustivel,IdMotorista,idPosto")] OrdemServico ordemServico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordemServico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMotorista = new SelectList(db.Motorista, "id", "Nome", ordemServico.IdMotorista);
            ViewBag.idPosto = new SelectList(db.Posto, "id", "Nome", ordemServico.idPosto);
            return View(ordemServico);
        }

        // GET: OrdemServico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdemServico ordemServico = db.OrdemServico.Find(id);
            if (ordemServico == null)
            {
                return HttpNotFound();
            }
            return View(ordemServico);
        }

        // POST: OrdemServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdemServico ordemServico = db.OrdemServico.Find(id);
            db.OrdemServico.Remove(ordemServico);
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
