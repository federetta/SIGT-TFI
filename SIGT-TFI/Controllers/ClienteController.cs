using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SIGT_TFI.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
           
            
            var cp = new BLLEmpresa();
            var lista = cp.All();

            return View(lista);

        }
        public ActionResult IndexSearch(string text)
        {

            text = "pr";
            var cp = new BLLEmpresa();
            var lista = cp.Search(text);

            return View(lista);

        }



        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            var cp = new BLLEmpresa();
            var empresa = cp.SelectByID(id);

            return View(empresa);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            var be = new BLLEmpresa();
            var bte = new BLL.BLLTipoEmpresa();
            var btc = new BLLTipoContribuyente();
            ViewData["TipoEmpresa"] = bte.All();
            ViewData["TipoContribuyente"] = btc.All();
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Empresa empresa)
        {
            try
            {
                empresa.Tipo_Empresa = 1;
                var be = new BLLEmpresa();
                var bte = new BLL.BLLTipoEmpresa();
                var btc = new BLLTipoContribuyente();
                ViewData["TipoEmpresa"] = bte.All();
                ViewData["TipoContribuyente"] = btc.All();
                be.CreateProveedor(empresa);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            var cp = new BLLEmpresa();
            var empresa = cp.SelectByID(id);

            return View(empresa);
           
        }

        // POST: Cliente/Edit/5
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

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cliente/Delete/5
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
