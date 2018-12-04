using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using BLL;
using PagedList;
using PagedList.Mvc;

namespace SIGT_TFI.Controllers
{
    public class ProveedorController : Controller
    {
        [Authorize]
        // GET: Empresa
        public ActionResult Index(string search, int ? page)
        {
            var cp = new BLLEmpresa();
            var lista = cp.AllProveedor();
            var btc = new BLLTipoContribuyente();
            ViewData["TipoContribuyente"] = btc.All();
            if (search == null) search = "";
            return View(lista.Where(x => x.RazonSocial.ToUpper().StartsWith(search.ToUpper())).ToList().ToPagedList(page ?? 1, 10));
           
        }

        // GET: Empresa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Empresa/Create
        [Authorize]
        public ActionResult Create()
        {
            var be = new BLLEmpresa();
            var bte = new BLL.BLLTipoEmpresa();
            var btc = new BLLTipoContribuyente();
            ViewData["TipoEmpresa"] = bte.All();
            ViewData["TipoContribuyente"] = btc.All();
             return View();
        }

        // GET: Cliente/Create
        [Authorize]
        public ActionResult CreateProveedor()
        {
            var be = new BLLEmpresa();
            var bte = new BLL.BLLTipoEmpresa();
            var btc = new BLLTipoContribuyente();
            ViewData["TipoContribuyente"] = btc.All();
            ViewData["TipoEmpresa"] = bte.All();
            
            return View();
        }

        // POST: Empresa/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(Empresa proveedor)
        {
            try
            {
                var user = User.Identity.Name;

                BLLEmpresa bllempresa = new BLLEmpresa();
                bllempresa.CreateProveedor(proveedor, user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empresa/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var btc = new BLLTipoContribuyente();
            ViewData["TipoContribuyente"] = btc.All();
            var cp = new BLLEmpresa();
            var empresa = cp.SelectByID(id);

            return View(empresa);
        }

        // POST: Empresa/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(int id, Empresa proveedor)
        {
            try
            {
                var btc = new BLLTipoContribuyente();
                ViewData["TipoContribuyente"] = btc.All();
                BLLEmpresa bllempresa = new BLLEmpresa();
                bllempresa.UpdateProveedor(proveedor);
                return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Empresa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Empresa/Delete/5
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
