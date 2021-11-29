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
    public class EntidadsController : Controller
    {
        private EmigranteEntities db = new EmigranteEntities();

        // GET: Entidads
        public ActionResult Index()
        {
            var entidad = db.Entidad.Include(e => e.sectorEntidad).Include(e => e.tipoSolicitud);
            return View(entidad.ToList());
        }

        // GET: Entidads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entidad entidad = db.Entidad.Find(id);
            if (entidad == null)
            {
                return HttpNotFound();
            }
            return View(entidad);
        }

        // GET: Entidads/Create
        public ActionResult Create()
        {
            ViewBag.IdSector = new SelectList(db.sectorEntidad, "Id", "Sector");
            ViewBag.IdTipoSolicitud = new SelectList(db.tipoSolicitud, "Id", "Solicitud");
            return View();
        }

        // POST: Entidads/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Razon_Social,Nit,Direccion,Telefono,Correo,Pagina,IdSector,Ciudad,IdTipoSolicitud")] Entidad entidad)
        {
            if (ModelState.IsValid)
            {
                db.Entidad.Add(entidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSector = new SelectList(db.sectorEntidad, "Id", "Sector", entidad.IdSector);
            ViewBag.IdTipoSolicitud = new SelectList(db.tipoSolicitud, "Id", "Solicitud", entidad.IdSector);
            return View(entidad);
        }

        // GET: Entidads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entidad entidad = db.Entidad.Find(id);
            if (entidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSector = new SelectList(db.sectorEntidad, "Id", "Sector", entidad.IdSector);
            ViewBag.IdTipoSolicitud = new SelectList(db.tipoSolicitud, "Id", "Solicitud", entidad.IdSector);
            return View(entidad);
        }

        // POST: Entidads/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Razon_Social,Nit,Direccion,Telefono,Correo,Pagina,IdSector,Ciudad,IdTipoSolicitud")] Entidad entidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSector = new SelectList(db.sectorEntidad, "Id", "Sector", entidad.IdSector);
            ViewBag.IdTipoSolicitud = new SelectList(db.tipoSolicitud, "Id", "Solicitud", entidad.IdSector);
            return View(entidad);
        }

        // GET: Entidads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entidad entidad = db.Entidad.Find(id);
            if (entidad == null)
            {
                return HttpNotFound();
            }
            return View(entidad);
        }

        // POST: Entidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entidad entidad = db.Entidad.Find(id);
            db.Entidad.Remove(entidad);
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
