using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Sql;
using System.Data.SqlClient;
using Emigrantes.ConexionBD;
using System.Data;
using System.ComponentModel;
using Emigrantes.Data;
using System.Net;

namespace Emigrantes.Controllers
{
    public class BuscarEmigrantesController : Controller
    {
        private EmigrantesEntities db = new EmigrantesEntities();
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
    }