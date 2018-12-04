using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Entities;
using BLL;

namespace SIGT_TFI.Controllers
{
    public class RecorridoController : Controller
    {
        // GET: Recorrido
        [Authorize]
        public ActionResult Index(int id, string search, int? page)
        {
            var cp = new BLLRecorrido();
            var lista = cp.ListByObra(id);
            if (search == null) search = "";
            return View(lista.Where(x => x.Inicio.ToUpper().StartsWith(search.ToUpper())).ToList().ToPagedList(page ?? 1, 10));
        }

        // GET: Recorrido/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contacto/Create
        [Authorize]
        public ActionResult Create(int id)
        {
            var recorrido = new Recorrido();
            recorrido.IdObra = id;

            return View(recorrido);
        }

        // POST: Contacto/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(Recorrido recorrido, int id)
        {

            BLLRecorrido bll = new BLLRecorrido();
            recorrido.IdObra = id;
            recorrido.id = 0;

            bll.CreateRecorrido(recorrido);
            return RedirectToAction("Index", new { id = recorrido.IdObra });
        }

        // GET: Recorrido/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Recorrido/Edit/5
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

        // GET: Recorrido/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Recorrido/Delete/5
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
