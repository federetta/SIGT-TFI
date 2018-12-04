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
    public class ObraController : Controller
    {
        // GET: Obra
        [Authorize]
        public ActionResult Index(int id, string search, int? page)
        {
            var cp = new BLLObra();
            var lista = cp.ListByCompanyID(id);
            if (search == null) search = "";
            return View(lista.Where(x => x.Nombre.ToUpper().StartsWith(search.ToUpper())).ToList().ToPagedList(page ?? 1, 10));
        }

        // GET: Obra/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contacto/Create
        [Authorize]
        public ActionResult Create(int id)
        {
            var obra = new Obra();
            obra.IdCliente = id;

            return View(obra);
        }

        // POST: Contacto/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(Obra obra, int id)
        {

            BLLObra bll = new BLLObra();
            obra.IdCliente = id;
            obra.id = 0;

            bll.CreateObra(obra);
            return RedirectToAction("Index", new { id = id });
        }

        // GET: Obra/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Obra/Edit/5
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

        // GET: Obra/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Obra/Delete/5
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
