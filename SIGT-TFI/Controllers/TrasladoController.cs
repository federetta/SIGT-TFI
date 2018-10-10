using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using BLL;
using PagedList;
using PagedList.Mvc;

namespace SIGT_TFI.Controllers
{
    public class TrasladoController : Controller
    {
        // GET: Traslado
        public ActionResult Index(string search, int? page)
        {
            var cp = new BLLTraslado();
            var lista = cp.All();
            //var btc = new BLLTipoContribuyente();
            //ViewData["TipoContribuyente"] = btc.All();
            if (search == null) search = "";
            return View(lista.Where(x => x.NumeroTraslado.ToString().StartsWith(search.ToUpper())).ToList().ToPagedList(page ?? 1, 10));
        }

        // GET: Traslado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Traslado/Create
        public ActionResult Create()
        {
            var blltransporte = new BLLTransporte();
            ViewData["Transporte"] = blltransporte.List();
            var bllrecorrido = new BLLRecorrido();
            ViewData["Recorrido"] = bllrecorrido.ListAll();
            return View();
        }

        // POST: Traslado/Create
        [HttpPost]
        public ActionResult Create(Traslado traslado)
        {
            try
            {
                var blltraslado = new BLLTraslado();
                blltraslado.CreateTraslado(traslado);


                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: Traslado/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Traslado/Edit/5
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

        // GET: Traslado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Traslado/Delete/5
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
