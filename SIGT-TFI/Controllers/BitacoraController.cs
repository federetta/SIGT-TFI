using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using BLL;
using PagedList;
using PagedList.Mvc;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

namespace SIGT_TFI.Controllers
{
    public class BitacoraController : Controller
    {
        // GET: Bitacora
        [Authorize]
        public ActionResult Index(string search, int? page)
        {
            var cp = new BLLBitacoraSQL();
            var lista = cp.LISTAR_Bitacora();
            if (search == null) search = "";
            return View(lista.Where(x => x.tipo.ToUpper().StartsWith(search.ToUpper())).ToList().ToPagedList(page ?? 1, 10));

        }

        // GET: Bitacora/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bitacora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bitacora/Create
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

        // GET: Bitacora/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bitacora/Edit/5
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

        // GET: Bitacora/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bitacora/Delete/5
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
