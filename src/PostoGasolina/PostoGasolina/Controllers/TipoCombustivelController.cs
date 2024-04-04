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
    public class TipoCombustivelController : Controller
    {
        private BDPostoEntities db = new BDPostoEntities();

        // GET: TipoCombustivel
        public ActionResult Index()
        {
            return View(db.TipoCombustivel.ToList());
        }

        // GET: TipoCombustivel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCombustivel tipoCombustivel = db.TipoCombustivel.Find(id);
            if (tipoCombustivel == null)
            {
                return HttpNotFound();
            }
            return View(tipoCombustivel);
        }

        // GET: TipoCombustivel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoCombustivel/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Descricao")] TipoCombustivel tipoCombustivel)
        {
            if (ModelState.IsValid)
            {
                db.TipoCombustivel.Add(tipoCombustivel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoCombustivel);
        }

        // GET: TipoCombustivel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCombustivel tipoCombustivel = db.TipoCombustivel.Find(id);
            if (tipoCombustivel == null)
            {
                return HttpNotFound();
            }
            return View(tipoCombustivel);
        }

        // POST: TipoCombustivel/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Descricao")] TipoCombustivel tipoCombustivel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoCombustivel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoCombustivel);
        }

        // GET: TipoCombustivel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCombustivel tipoCombustivel = db.TipoCombustivel.Find(id);
            if (tipoCombustivel == null)
            {
                return HttpNotFound();
            }
            return View(tipoCombustivel);
        }

        // POST: TipoCombustivel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoCombustivel tipoCombustivel = db.TipoCombustivel.Find(id);
            db.TipoCombustivel.Remove(tipoCombustivel);
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
