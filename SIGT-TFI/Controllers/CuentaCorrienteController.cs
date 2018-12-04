using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Entities;

namespace SIGT_TFI.Controllers
{
    public class CuentaCorrienteController : Controller
    {
        // GET: CuentaCorriente
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        // GET: CuentaCorriente/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }


        [Authorize]
        public ActionResult BuscarComprobantes()
        {

            
            var bllempresa = new BLLEmpresa();
            ViewData["Cliente"] = bllempresa.AllCliente();
            ViewData["ListaFacturas"] = null;
            ViewData["ListaCobranzas"] = null;
            ViewData["SaldoCuentaCorriente"] = null;
            return View();
        }


        [Authorize]
        [HttpPost]
        public ActionResult BuscarComprobantes(Cliente factura)
        {

            
            var bllempresa = new BLLEmpresa();
            ViewData["Cliente"] = bllempresa.AllCliente();
            var fac = new BLLFactura();
            ViewData["ListaFacturas"] = fac.VW_FACTURA_SALDO(factura).ToList();
            var cob = new BLLCobranza();
            ViewData["ListaCobranzas"] = cob.BuscarCobranza_View(factura).ToList();
            ViewData["SaldoCuentaCorriente"] = cob.SaldoCuentaCorriente(factura).ToList();
            return View();
        }

        // GET: CuentaCorriente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CuentaCorriente/Create
        [Authorize]
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

        // GET: CuentaCorriente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CuentaCorriente/Edit/5
        [Authorize]
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

        // GET: CuentaCorriente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CuentaCorriente/Delete/5
        [Authorize]
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
