﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using BLL;

namespace SIGT_TFI.Controllers
{
    public class ListaPrecioController : Controller
    {
        // GET: ListaPrecio
        public ActionResult Index()
        {
            var cp = new BLLListaPrecio();
            var lala = 1;
            var lista = cp.ListByRecorrido(lala);
            return View(lista);
        }

        public ActionResult Buscar()
        {
            var bll = new BLLRecorrido();
            ViewData["Recorrido"] = bll.ListAll();
            ViewData["ListaPrecio"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult Buscar(FormCollection form)
        {
            var bllPrecio = new BLLListaPrecio();
            var bllrecorrido = new BLLRecorrido();
            var listaPrecio = new ListaPrecio();
            listaPrecio.idrecorrido = Convert.ToInt32(form["IdRecorrido"]);
            ViewData["ListaPrecio"] = bllPrecio.ListByRecorrido(listaPrecio.idrecorrido).ToList();
            ViewData["Recorrido"] = bllrecorrido.ListAll();
            return View();
        }


        // GET: ListaPrecio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ListaPrecio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListaPrecio/Create
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            try
            {
                var bllPrecio = new BLLListaPrecio();
                var bllrecorrido = new BLLRecorrido();
                var listaPrecio = new ListaPrecio();
                listaPrecio.idrecorrido = Convert.ToInt32(form["IdRecorrido"]);
                listaPrecio.fechainicial = Convert.ToDateTime(form["FechaInicial"]);
                listaPrecio.precio = Convert.ToDecimal(form["Precio"]);
                listaPrecio.comision = Convert.ToDecimal(form["Comision"]);
                bllPrecio.CrearListaPrecio(listaPrecio);
                ViewData["ListaPrecio"] = bllPrecio.ListByRecorrido(listaPrecio.idrecorrido).ToList();
                ViewData["Recorrido"] = bllrecorrido.ListAll();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ListaPrecio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ListaPrecio/Edit/5
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

        // GET: ListaPrecio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ListaPrecio/Delete/5
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
