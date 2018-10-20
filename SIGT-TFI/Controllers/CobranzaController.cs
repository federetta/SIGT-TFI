using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGT_TFI.Controllers
{
    public class CobranzaController : Controller
    {
        // GET: Cobranza
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cobranza/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cobranza/Create
        public ActionResult Create()
        {
            var btc = new BLLEntidadBancaria();
            ViewData["EntidadBancaria"] = btc.All();
            var btcomp = new BllMedioPago();
            ViewData["MedioPago"] = btcomp.All();
            var bllempresa = new BLLEmpresa();
            ViewData["Cliente"] = bllempresa.AllCliente();
            return View();
        }

        // POST: Cobranza/Create
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

        // GET: Cobranza/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cobranza/Edit/5
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

        // GET: Cobranza/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cobranza/Delete/5
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
