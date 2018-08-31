using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGT_TFI.Controllers
{
    public class TipoEmpresaController : Controller
    {
        // GET: TipoEmpresa
        public ActionResult Index()
        {
            var TipoEmpresaBll = new BLL.BLLTipoEmpresa();
            var lista = TipoEmpresaBll.All();
            return View(lista);
        }

        // GET: TipoEmpresa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoEmpresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEmpresa/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoEmpresa/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoEmpresa/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoEmpresa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoEmpresa/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
