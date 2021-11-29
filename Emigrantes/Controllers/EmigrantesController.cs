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
    public class EmigrantesController : Controller
    {
        private EmigrantesEntities db = new EmigrantesEntities();

        // GET: Emigrantes
        public ActionResult Index()
        {
            var emigrante = db.Emigrante.Include(e => e.situacionLaboral);
            return View(emigrante.ToList());
        }

        // GET: Emigrantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emigrante emigrante = db.Emigrante.Find(id);
            if (emigrante == null)
            {
                return HttpNotFound();
            }
            return View(emigrante);
        }

        // GET: Emigrantes/Create
        public ActionResult Create()
        {
            ViewBag.IdEstadoLaboral = new SelectList(db.situacionLaboral, "Id", "SituacionL");
            return View();
        }

        // POST: Emigrantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,TipoIdentificacion,Identificacion,Nombres,Apellidos,PaisOrigen,Fecha_Nacimiento,Correo,Telefono,Direccion,Ciudad,IdEstadoLaboral")] Emigrante emigrante)
        {
            if (ModelState.IsValid)
            {
                db.Emigrante.Add(emigrante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstadoLaboral = new SelectList(db.situacionLaboral, "Id", "SituacionL", emigrante.IdEstadoLaboral);
            return View(emigrante);
        }

        // GET: Emigrantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emigrante emigrante = db.Emigrante.Find(id);
            if (emigrante == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstadoLaboral = new SelectList(db.situacionLaboral, "Id", "SituacionL", emigrante.IdEstadoLaboral);
            return View(emigrante);
        }

        // POST: Emigrantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,TipoIdentificacion,Identificacion,Nombres,Apellidos,PaisOrigen,Fecha_Nacimiento,Correo,Telefono,Direccion,Ciudad,IdEstadoLaboral")] Emigrante emigrante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emigrante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEstadoLaboral = new SelectList(db.situacionLaboral, "Id", "SituacionL", emigrante.IdEstadoLaboral);
            return View(emigrante);
        }

        // GET: Emigrantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emigrante emigrante = db.Emigrante.Find(id);
            if (emigrante == null)
            {
                return HttpNotFound();
            }
            return View(emigrante);
        }

        // POST: Emigrantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emigrante emigrante = db.Emigrante.Find(id);
            db.Emigrante.Remove(emigrante);
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
