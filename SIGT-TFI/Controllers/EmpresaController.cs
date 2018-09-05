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
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult Index(string search, int ? page)
        {
            var cp = new BLLEmpresa();
            var lista = cp.All();
            if (search == null) search = "";
            return View(lista.Where(x => x.RazonSocial.ToUpper().StartsWith(search.ToUpper())).ToList().ToPagedList(page ?? 1, 10));
           
        }

        // GET: Empresa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Empresa/Create
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
        public ActionResult CreateCliente()
        {
            var be = new BLLEmpresa();
            var bte = new BLL.BLLTipoEmpresa();
            var btc = new BLLTipoContribuyente();
            ViewData["TipoEmpresa"] = bte.All();
            ViewData["TipoContribuyente"] = btc.All();
            return View();
        }

        // POST: Empresa/Create
        [HttpPost]
        public ActionResult Create(Empresa empresa)
        {
            try
            {
                BLLEmpresa bllempresa = new BLLEmpresa();
                bllempresa.CreateCliente(empresa);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empresa/Edit/5
        public ActionResult Edit(int id)
        {
            var cp = new BLLEmpresa();
            var empresa = cp.SelectByID(id);

            return View(empresa);
        }

        // POST: Empresa/Edit/5
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

        // GET: Empresa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Empresa/Delete/5
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
