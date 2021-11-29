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
    public class ServiciosController : Controller
    {
        private EmigrantesEntities db = new EmigrantesEntities();

        // GET: Servicios
        public ActionResult Index()
        {
            var servicios = db.Servicios.Include(s => s.Entidad);
            return View(servicios.ToList());
        }

        // GET: Servicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            return View(servicios);
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            ViewBag.IdEntidad = new SelectList(db.Entidad, "Id", "Razon_Social");
            return View();
        }

        // POST: Servicios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dI,Servicio,Maximo_Emigrantes,Fecha_Inicio,Fecha_fin,Estado_Servicio,Descripcion,IdEntidad")] Servicios servicios)
        {
            if (ModelState.IsValid)
            {
                db.Servicios.Add(servicios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEntidad = new SelectList(db.Entidad, "Id", "Razon_Social", servicios.IdEntidad);
            return View(servicios);
        }

        // GET: Servicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEntidad = new SelectList(db.Entidad, "Id", "Razon_Social", servicios.IdEntidad);
            return View(servicios);
        }

        // POST: Servicios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dI,Servicio,Maximo_Emigrantes,Fecha_Inicio,Fecha_fin,Estado_Servicio,Descripcion,IdEntidad")] Servicios servicios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEntidad = new SelectList(db.Entidad, "Id", "Razon_Social", servicios.IdEntidad);
            return View(servicios);
        }

        // GET: Servicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            return View(servicios);
        }

        // POST: Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servicios servicios = db.Servicios.Find(id);
            db.Servicios.Remove(servicios);
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
