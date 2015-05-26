using LuceneSpanishSearch.Models;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuceneSpanishSearch.Controllers
{
    public class DocumentosController : Controller
    {
        private IDocumentSession session;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            session = DataBaseSession.Open();
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            session.Dispose();
        }

        // GET: Documentos
        public ActionResult Index()
        {
            var docs = session.Query<Documento>().ProjectFromIndexFieldsInto<DocumentoIndexModel>().ToList();
            return View(docs);
        }

        public ActionResult Editar(int id)
        {
            var doc = session.Load<Documento>(id);
            var modelo = new DocumentoEditarModel
            {
                Id = id,
                Titulo = doc.Titulo,
                Contenido = doc.Contenido
            };
            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, DocumentoEditarModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            var doc = session.Load<Documento>(id);
            doc.Titulo = modelo.Titulo;
            doc.Contenido = modelo.Contenido;
            session.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(DocumentoCrearModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            session.Store(new Documento { 
                Contenido = modelo.Contenido,
                Titulo = modelo.Titulo,
                FechaCreacion = DateTime.UtcNow
            });

            session.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Eliminar(int id)
        {
            var doc = session.Load<Documento>(id);
            var modelo = new DocumentoDetallesModel { 
                Id = id ,
                FechaCreacion = doc.FechaCreacion,
                Titulo = doc.Titulo,
                Contenido = doc.Contenido
            };
            return View(modelo);
        }

        [HttpPost]
        [ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarEliminar(int id)
        {
            session.Delete<Documento>(id);
            session.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}