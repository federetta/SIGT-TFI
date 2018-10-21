using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using BLL;
using Rotativa;

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
            ViewData["ListaFacturas"] = null;
            return View();
        }

        public ActionResult BuscarComprobante()
        {
           
            var btcomp = new BLLTipoComprobante();
            ViewData["TipoComprobante"] = btcomp.All();
            var letra = new BLLLetra();
            ViewData["Letra"] = letra.All();
            var bllempresa = new BLLEmpresa();
            ViewData["Cliente"] = bllempresa.AllCliente();
            ViewData["ListaFacturas"] = null;
            return View();
        }


        [HttpPost]
        public ActionResult BuscarComprobante(Factura factura)
        {

            var btcomp = new BLLTipoComprobante();
            ViewData["TipoComprobante"] = btcomp.All();
            var letra = new BLLLetra();
            ViewData["Letra"] = letra.All();
            var bllempresa = new BLLEmpresa();
            ViewData["Cliente"] = bllempresa.AllCliente();
            factura.IdTipo = 1;
            var fac = new BLLFactura();
            ViewData["ListaFacturas"] = fac.VW_FACTURA_CABECERA(factura).ToList();
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
            bll.CrearTotales(factura);

            return View();
        }

        public ActionResult PDF(Factura Factura)
        {
            try
            {
    
                return new ActionAsPdf("makePDFFact") { FileName = "invoice" + Factura.id + ".pdf" };
                //return Json(new { Result = "" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                Nullable<int> idUser = null;
                string ip = "Unknown";
                try
                {
                    idUser = (int)Session["userID"];
                }
                catch (Exception ex) { }
                try
                {
                    ip = Session["_ip"].ToString();
                }
                catch (Exception ex) { }
                try
                {
                    //Bita.guardarBitacora(new BIZBitacora("Error", "Error al intentar imprimir factura", idUser, ip));
                }
                catch (Exception ex) { }
                return Json(new { Result = "Error" }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult makePDFFact()
        {
            var bll = new BLLFactura();
            var factura = new Factura();
            factura.id = 13;
            var doc = bll.VW_FACTURA_CABECERA(factura);
            return View(doc);

        }
    }
}

