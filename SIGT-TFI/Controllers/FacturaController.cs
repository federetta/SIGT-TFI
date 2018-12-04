using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using BLL;
using Rotativa;
using SIGT_TFI.Models;

namespace SIGT_TFI.Controllers
{
    public class FacturaController : Controller
    {
        public static int GIdFactura;
        // GET: Factura
        public ActionResult Index()
        {
            
            return View();
        }
        [Authorize]
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

        [Authorize]
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


        [Authorize]
        [HttpPost]
        public ActionResult BuscarComprobante(Cliente factura)
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


        [Authorize]
        [HttpPost]
        public ActionResult Buscar(Cliente factura)
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
        [Authorize]
        [HttpPost]
        public ActionResult GenerarFactura(FormCollection form)
        {
            string idtraslado = form["selected"];
            if (string.IsNullOrWhiteSpace(idtraslado)) throw new Exception("Debe seleccionar al menos un translado");
            var translations = idtraslado.Split(new char[] { ',' }).Select(x => Convert.ToInt32(x));
            var bll = new BLLFactura();
            var factura = new Cliente();
          
          
            factura.IdTipo = Convert.ToInt32(form["IdTipoComprobante"]);
            factura.IdLetra = Convert.ToInt32(form["IdLetra"]);
            factura.FechaFactura = Convert.ToDateTime(form["FechaFactura"]);
            factura.IdCliente = Convert.ToInt32(form["IdCliente"]);
            var user = User.Identity.Name;

            bll.CrearFactura(factura, user);
            var Lista = new System.Collections.ArrayList();
            Lista.Add(new Cliente());
            foreach (int value in translations)
            {
                factura.IdTraslado = value;
               
                bll.CrearFacturaDetalle(factura, user);
            }
            bll.CrearTotales(factura, user);

            return RedirectToAction("BuscarComprobante");
        }
        
        public ActionResult PDF(Cliente Factura)
        {
                 GIdFactura = Factura.id;
                 return new ActionAsPdf("PDF4") { FileName = "invoice" + GIdFactura + ".pdf" };
                //return Json(new { Result = "" }, JsonRequestBehavior.AllowGet);
       

        }
        
        public ActionResult PDF4()
        {
            var bll = new BLLFactura();
            var factura = new Cliente();
            var doc = bll.VW_FACTURA_HISTORICO2(GIdFactura);
            Models.FacturaPDFViewModels Vista = MapVista(doc);
            return View(Vista);

        }
        
        private FacturaPDFViewModels MapVista(List<Cliente> doc)
        {
            FacturaPDFViewModels model = new FacturaPDFViewModels();
            List<TrasladoPDFViewModels> listatraslado = new List<TrasladoPDFViewModels>();
            foreach (var item in doc)
            {
                model.Letra = item.Letra;
                model.Tipo = item.Tipo;
                model.NumeroFactura = item.NumeroFactura;
                model.FechaFactura = item.FechaFactura;
                model.Subtotal = item.Subtotal;
                model.Iva = item.Iva;
                model.Total = item.Total;
                model.Cuit = item.Cuit;
                model.RazonSocial = item.RazonSocial;
                model.Calle = item.Calle;
                model.numero = item.numero;
                model.Localidad = item.Localidad;
                model.TipoContribuyente = item.TipoContribuyente;
                TrasladoPDFViewModels traslados = new TrasladoPDFViewModels();
                traslados.NumeroTraslado = item.NumeroTraslado;
                traslados.carga = item.carga;
                traslados.Precio = item.Precio;
                traslados.Comision = item.Comision;
                traslados.PrecioTotal = item.Precio + item.Comision;
                traslados.PrecioxCant = (item.Precio + item.Comision) * (item.carga);
                listatraslado.Add(traslados);
                
                }
                     model.ListaTraslados = listatraslado;
                       return model;
                }
        }
    }


