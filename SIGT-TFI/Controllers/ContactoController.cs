using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using BLL;

namespace SIGT_TFI.Controllers
{
    public class ContactoController : Controller
    {
        // GET: Contacto
        public ActionResult Index(int id)
        {
            var cp = new BLLContacto();
            var lista = cp.ListByCompanyID(id);
            var btc = new BLLTipoContacto();
            ViewData["TipoContacto"] = btc.All();
            //var transporte = new Transporte();
            //TempData["mydata"] = transporte.IdProveedor;
            return View(lista);
        }

        // GET: Contacto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contacto/Create
        public ActionResult Create(int id)
        {
            var btc = new BLLTipoContacto();
            ViewData["TipoContacto"] = btc.All();
            var contacto = new Contacto();
            contacto.idempresa = id;

            return View(contacto);
        }

        // POST: Contacto/Create
        [HttpPost]
        public ActionResult Create(Contacto contacto, int id)
        {

            BLLContacto bll = new BLLContacto();
            contacto.idempresa = id;
           contacto.id = 0;

            bll.CreateContacto(contacto);
            return RedirectToAction("Index", new { id = id });
        }

            // GET: Contacto/Edit/5
            public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contacto/Edit/5
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

        // GET: Contacto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contacto/Delete/5
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
