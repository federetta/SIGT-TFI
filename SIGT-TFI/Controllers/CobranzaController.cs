using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;

namespace SIGT_TFI.Controllers
{
    public class CobranzaController : Controller
    {
        [Authorize]

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

        // GET: Cobranza/Create/Detalle
        [Authorize]
        public ActionResult CreateDetalle(Cobranza cobranza)
        {
            var btc = new BLLEntidadBancaria();
            ViewData["EntidadBancaria"] = btc.All();
            var btcomp = new BllMedioPago();
            ViewData["MedioPago"] = btcomp.All();
            var bllempresa = new BLLEmpresa();
            ViewData["Cliente"] = bllempresa.AllCliente();
            return View();
        }
        [Authorize]
        [HttpPost]
        // GET: Cobranza/Create/Detalle
        public ActionResult GenerarCobranza(FormCollection form)
        {
           
            
            var idmedios = form["IdMedioPago"].Split(new char[] { ',' }).Select(x => Convert.ToInt32(x)).ToList();
            var identidadbancarias = form["IdEntidadBancaria"].Split(new char[] { ',' }).Select(x => Convert.ToInt32(x)).ToList();
            var numerorecibos = form["NumeroRecibo"].Split(new char[] { ',' }).Select(x => Convert.ToInt32(x)).ToList();
            var fechas = form["FechaRecibo"].Split(new char[] { ',' }).Select(x => Convert.ToDateTime(x)).ToList();
            var plazos = form["PlazoRecibo"].Split(new char[] { ',' }).Select(x => Convert.ToInt32(x)).ToList();
            var endosables = form["Endosable"].Split(new char[] { ',' }).Select(x => Convert.ToBoolean(x)).ToList();
            var directos = form["Directo"].Split(new char[] { ',' }).Select(x => Convert.ToBoolean(x)).ToList();
            var docs = form["DocLibrador"].Split(new char[] { ',' }).Select(x => Convert.ToInt32(x)).ToList();
            var idcobranzas = form["idcobranza"].Split(new char[] { ',' }).Select(x => Convert.ToInt32(x)).ToList();
            var montos = form["Monto"].Split(new char[] { ',' }).Select(x => Convert.ToDouble(x)).ToList();
            var lista = new List<Recibo>();
            int len = idmedios.Count();
            for (int i = 0; i<len;i++)
            {
                lista.Add(new Recibo
                {
                    IdMedioPago = idmedios[i],
                    IdEntidadBancaria = identidadbancarias[i],
                    NumeroRecibo = numerorecibos[i],
                    FechaRecibo = fechas[i],
                    PlazoRecibo = plazos[i],
                    Endosable = endosables[i],
                    Directo = directos[i],
                    DocLibrador = docs[i],
                    idcobranza = idcobranzas[i],
                    Monto = montos[i],
                });

            }
            var bll = new BLLCobranza();
            var user = User.Identity.Name;

            bll.CrearCobranzaDetalle(lista,user);
                       

            return RedirectToAction("Create");
        }


        // POST: Cobranza/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(Cobranza cobranza)
        {
            try
            {
                var bll = new BLLCobranza();
                var user = User.Identity.Name;

                bll.CrearCobranzaCabecera(cobranza, user);
                ViewBag.Mesagge = "lala";
                return RedirectToAction("CreateDetalle", new { id = cobranza.IdCobranzaCabecera });
            }
            catch
            {
                return View();
            }
        }

      

       

        
    }
}
