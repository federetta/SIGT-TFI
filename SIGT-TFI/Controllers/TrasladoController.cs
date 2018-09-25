using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using BLL;

namespace SIGT_TFI.Controllers
{
    public class TrasladoController : Controller
    {
        // GET: Traslado
        public ActionResult Index()
        {
            return View();
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
            return View();
        }

        // POST: Traslado/Create
        [HttpPost]
        public ActionResult Create(Transporte transporte)
        {
            try
            {
              

                return RedirectToAction("Index");
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
