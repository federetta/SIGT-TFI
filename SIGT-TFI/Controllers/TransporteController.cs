using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Entities;

namespace SIGT_TFI.Controllers
{
    public class TransporteController : Controller
    {
        // GET: Transporte
        public ActionResult Index(int id)
        {
            var cp = new BLL.BLLTransporte();
            var lista = cp.ListByProviderID(id);
            var transporte = new Transporte();
            TempData["mydata"] = transporte.IdProveedor;
            return View(lista);
        }

        // GET: Transporte/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Transporte/Create
        public ActionResult Create(int id)
        {
            var tranp = new Transporte();
            tranp.IdProveedor = id;

            return View(tranp);
        }

        // POST: Transporte/Create
        [HttpPost]
        public ActionResult Create(Transporte transporte, int id)
        {
          
            BLLTransporte blltransporte = new BLLTransporte();
            transporte.IdProveedor = id;
            

            blltransporte.CreateProveedor(transporte);
                return RedirectToAction("Index", new { id = id });
          
          
        }

        // GET: Transporte/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Transporte/Edit/5
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

        // GET: Transporte/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Transporte/Delete/5
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
