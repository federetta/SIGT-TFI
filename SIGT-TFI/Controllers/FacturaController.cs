using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using BLL;

namespace SIGT_TFI.Controllers
{
    public class FacturaController : Controller
    {
        // GET: Factura
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Buscar()
        {
            var btc = new BLLTipoContribuyente();
            ViewData["TipoContribuyente"] = btc.All();
            var btcomp = new BLLTipoComprobante();
            ViewData["TipoComprobante"] = btcomp.All();
            var letra = new BLLLetra();
            ViewData["Letra"] = letra.All();
            var bllempresa = new BLLEmpresa();
            ViewData["Cliente"] = bllempresa.AllCliente();
            ViewData["ListaTraslados"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Buscar(Factura factura)
        {
            try
            {
                var btc = new BLLTipoContribuyente();
                ViewData["TipoContribuyente"] = btc.All();
                var btcomp = new BLLTipoComprobante();
                ViewData["TipoComprobante"] = btcomp.All();
                var letra = new BLLLetra();
                ViewData["Letra"] = letra.All();
                var bllempresa = new BLLEmpresa();
                ViewData["Cliente"] = bllempresa.AllCliente();
                var fac = new BLLFactura();
                ViewData["ListaTraslados"] = fac.LISTAR_COMPROBANTE_DETALLE(factura).ToList();
                
                return View(factura);
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult GenerarFactura(FormCollection form)
        {
            string idtraslado = form["selected"];
            if (string.IsNullOrWhiteSpace(idtraslado)) throw new Exception("Debe seleccionar al menos un translado");
            var translations = idtraslado.Split(new char[] { ',' }).Select(x => Convert.ToInt32(x));
            var bll = new BLLFactura();
            var factura = new Factura();
          
          
            factura.IdTipo = Convert.ToInt32(form["IdTipoComprobante"]);
            factura.IdLetra = Convert.ToInt32(form["IdLetra"]);
            factura.FechaFactura = Convert.ToDateTime(form["FechaFactura"]);
            factura.IdCliente = Convert.ToInt32(form["IdCliente"]);
            bll.CrearFactura(factura);
            var Lista = new System.Collections.ArrayList();
            Lista.Add(new Factura());
            foreach (int value in translations)
            {
                factura.IdTraslado = value;
               
                bll.CrearFacturaDetalle(factura);
            }

            return View();
        }

        // GET: Factura/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Factura/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Factura/Create
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

        // GET: Factura/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Factura/Edit/5
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

        // GET: Factura/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Factura/Delete/5
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
