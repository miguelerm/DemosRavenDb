using LuceneSpanishSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuceneSpanishSearch.Controllers
{
    public class DocumentosController : Controller
    {
        // GET: Documentos
        public ActionResult Index()
        {
            var docs = new DocumentoIndexModel[] { };
            // TODO: Consultar los documentos de la colección de RavenDB
            return View(docs);
        }

        public ActionResult Editar(int id)
        {
            var modelo = new DocumentoEditarModel();
            // TODO: consultar el documento con el id indicado en la colección de RavenDB
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

            // TODO: Guardar cambios en la colección de RavenDB.

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

            // TODO: Crar el documento en la colección de RavenDB.
            return RedirectToAction("Index");
        }


        public ActionResult Eliminar(int id)
        {
            var modelo = new DocumentoDetallesModel { Id = id };
            // TODO: Consultar el documento en la colección de RavenDB.
            return View(modelo);
        }

        [HttpPost]
        [ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarEliminar(int id)
        {
            // TODO: Eliminar el documento de la colección de RavenDb.
            return RedirectToAction("Index");
        }
    }
}