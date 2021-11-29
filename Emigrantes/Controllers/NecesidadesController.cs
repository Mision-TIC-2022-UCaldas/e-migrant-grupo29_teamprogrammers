using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Emigrantes;

namespace Emigrantes.Controllers
{
    public class NecesidadesController : Controller
    {
        private EmigranteEntities db = new EmigranteEntities();

        // GET: Necesidades
        public ActionResult Index()
        {
            var necesidades = db.Necesidades.Include(n => n.Emigrante).Include(n => n.migrantesNecesidad).Include(n => n.prioridadNecesidad).Include(n => n.tipoSolicitud);
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
            ViewBag.IdPersona = new SelectList(db.Emigrante, "id", "Identificacion");
            ViewBag.IdEmigranteNecesidad = new SelectList(db.Emigrante, "id", "id");
            ViewBag.IdPrioridad = new SelectList(db.prioridadNecesidad, "Id", "Prioridad");
            ViewBag.IdTipoServicio = new SelectList(db.tipoSolicitud, "Id", "Solicitud");
            return View();
        }

        // POST: Necesidades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,IdPersona,Descripcion,IdPrioridad,IdEmigranteNecesidad,IdTipoServicio")] Necesidades necesidades)
        {
            if (ModelState.IsValid)
            {
                db.Necesidades.Add(necesidades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPersona = new SelectList(db.Emigrante, "id", "Identificacion", necesidades.IdPersona);
            ViewBag.IdEmigranteNecesidad = new SelectList(db.migrantesNecesidad, "Id", "Necesidad", necesidades.IdEmigranteNecesidad);
            ViewBag.IdPrioridad = new SelectList(db.prioridadNecesidad, "Id", "Prioridad", necesidades.IdPrioridad);
            ViewBag.IdTipoServicio = new SelectList(db.tipoSolicitud, "Id", "Solicitud", necesidades.IdTipoServicio);
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
            ViewBag.IdPersona = new SelectList(db.Emigrante, "id", "Identificacion", necesidades.IdPersona);
            ViewBag.IdEmigranteNecesidad = new SelectList(db.migrantesNecesidad, "Id", "Necesidad", necesidades.IdEmigranteNecesidad);
            ViewBag.IdPrioridad = new SelectList(db.prioridadNecesidad, "Id", "Prioridad", necesidades.IdPrioridad);
            ViewBag.IdTipoServicio = new SelectList(db.tipoSolicitud, "Id", "Solicitud", necesidades.IdTipoServicio);
            return View(necesidades);
        }

        // POST: Necesidades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,IdPersona,Descripcion,IdPrioridad,IdEmigranteNecesidad,IdTipoServicio")] Necesidades necesidades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(necesidades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPersona = new SelectList(db.Emigrante, "id", "Identificacion", necesidades.IdPersona);
            ViewBag.IdEmigranteNecesidad = new SelectList(db.migrantesNecesidad, "Id", "Necesidad", necesidades.IdEmigranteNecesidad);
            ViewBag.IdPrioridad = new SelectList(db.prioridadNecesidad, "Id", "Prioridad", necesidades.IdPrioridad);
            ViewBag.IdTipoServicio = new SelectList(db.tipoSolicitud, "Id", "Solicitud", necesidades.IdTipoServicio);
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
