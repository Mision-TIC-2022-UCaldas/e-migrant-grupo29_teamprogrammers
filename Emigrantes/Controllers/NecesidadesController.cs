using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Emigrantes.Data;

namespace Emigrantes.Controllers
{
    public class NecesidadesController : Controller
    {
        private EmigrantesEntities db = new EmigrantesEntities();

        // GET: Necesidades
        public ActionResult Index()
        {
            var necesidades = db.Necesidades.Include(n => n.Emigrante).Include(n => n.migrantesNecesidad).Include(n => n.prioridadNecesidad);
            return View(necesidades.ToList());
        }

        // GET: Necesidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Necesidades necesidades = db.Necesidades.Find(id);
            if (necesidades == null)
            {
                return HttpNotFound();
            }
            return View(necesidades);
        }

        // GET: Necesidades/Create
        public ActionResult Create()
        {
            ViewBag.IdPersona = new SelectList(db.Emigrante, "id", "TipoIdentificacion");
            ViewBag.IdEmigranteNecesidad = new SelectList(db.migrantesNecesidad, "Id", "Necesidad");
            ViewBag.IdPrioridad = new SelectList(db.prioridadNecesidad, "Id", "Prioridad");
            return View();
        }

        // POST: Necesidades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,IdPersona,NombreNecesidad,Descripcion,IdPrioridad,IdEmigranteNecesidad")] Necesidades necesidades)
        {
            if (ModelState.IsValid)
            {
                db.Necesidades.Add(necesidades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPersona = new SelectList(db.Emigrante, "id", "TipoIdentificacion", necesidades.IdPersona);
            ViewBag.IdEmigranteNecesidad = new SelectList(db.migrantesNecesidad, "Id", "Necesidad", necesidades.IdEmigranteNecesidad);
            ViewBag.IdPrioridad = new SelectList(db.prioridadNecesidad, "Id", "Prioridad", necesidades.IdPrioridad);
            return View(necesidades);
        }

        // GET: Necesidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Necesidades necesidades = db.Necesidades.Find(id);
            if (necesidades == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPersona = new SelectList(db.Emigrante, "id", "TipoIdentificacion", necesidades.IdPersona);
            ViewBag.IdEmigranteNecesidad = new SelectList(db.migrantesNecesidad, "Id", "Necesidad", necesidades.IdEmigranteNecesidad);
            ViewBag.IdPrioridad = new SelectList(db.prioridadNecesidad, "Id", "Prioridad", necesidades.IdPrioridad);
            return View(necesidades);
        }

        // POST: Necesidades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,IdPersona,NombreNecesidad,Descripcion,IdPrioridad,IdEmigranteNecesidad")] Necesidades necesidades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(necesidades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPersona = new SelectList(db.Emigrante, "id", "TipoIdentificacion", necesidades.IdPersona);
            ViewBag.IdEmigranteNecesidad = new SelectList(db.migrantesNecesidad, "Id", "Necesidad", necesidades.IdEmigranteNecesidad);
            ViewBag.IdPrioridad = new SelectList(db.prioridadNecesidad, "Id", "Prioridad", necesidades.IdPrioridad);
            return View(necesidades);
        }

        // GET: Necesidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Necesidades necesidades = db.Necesidades.Find(id);
            if (necesidades == null)
            {
                return HttpNotFound();
            }
            return View(necesidades);
        }

        // POST: Necesidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Necesidades necesidades = db.Necesidades.Find(id);
            db.Necesidades.Remove(necesidades);
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
