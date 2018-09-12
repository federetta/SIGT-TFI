using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using BLL;

namespace SIGT_TFI.Controllers
{
    public class DomicilioController : Controller
    {
        // GET: Domicilio
        public ActionResult Index(int id)
        {
            var cp = new BLLDomicilio();
            var lista = cp.ListByProviderID(id);

            var blllocalidad = new BLLLocalidad();
            ViewData["Localidad"] = blllocalidad.All();

            var bllprovincia = new BLLProvincia();
            ViewData["Provincia"] = bllprovincia.All();
            
            return View(lista);
        }

        // GET: Domicilio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Domicilio/Create
        public ActionResult Create(int id)
        {
            var blllocalidad = new BLLLocalidad();
            ViewData["Localidad"] = blllocalidad.All();

            var bllprovincia = new BLLProvincia();
            ViewData["Provincia"] = bllprovincia.All();
            var domicilio = new Domicilio();
            domicilio.Idempresa = id;

            return View(domicilio);
        }

        // POST: Domicilio/Create
        [HttpPost]
        public ActionResult Create(Domicilio domicilio, int id)
        {
            try
            {

                BLLDomicilio bll = new BLLDomicilio();
                domicilio.Idempresa = id;
                domicilio.Id = 0;

                bll.CreateDomicilio(domicilio);
                return RedirectToAction("Index", new { id = id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Domicilio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Domicilio/Edit/5
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

        // GET: Domicilio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Domicilio/Delete/5
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
