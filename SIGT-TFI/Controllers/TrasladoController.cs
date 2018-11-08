using System.Linq;
using System.Web.Mvc;
using Entities;
using BLL;
using PagedList;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using SIGT_TFI.Reports;
using Rotativa;
using OfficeOpenXml;

namespace SIGT_TFI.Controllers
{
    public class TrasladoController : Controller
    {
        // GET: Traslado
        public ActionResult Index(string search, int? page)
        {
            var cp = new BLLTraslado();
            var lista = cp.All();
            //var btc = new BLLTipoContribuyente();
            //ViewData["TipoContribuyente"] = btc.All();
            if (search == null) search = "";
            return View(lista.Where(x => x.NumeroTraslado.ToString().StartsWith(search.ToUpper())).ToList().ToPagedList(page ?? 1, 10));
        }

        // GET: Traslado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Traslado/Create
        public ActionResult Create()
        {
            var blltransporte = new BLLTransporte();
            ViewData["Transporte"] = blltransporte.List();
            var bllrecorrido = new BLLRecorrido();
            ViewData["Recorrido"] = bllrecorrido.ListAll();
            return View();
        }

        // POST: Traslado/Create
        [HttpPost]
        public ActionResult Create(Traslado traslado)
        {
            try
            {
                var blltraslado = new BLLTraslado();
                blltraslado.CreateTraslado(traslado);

                TempData["OKNormal"] = "Andoo";
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult ExportTraslados()
        {

            var cp = new BLLTraslado();
            var lista = cp.All();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport5.rpt"));
            rd.SetDatabaseLogon("fretta", "Napoli10");
            rd.SetDataSource(lista);
            //rd.SetParameterValue("numero_traslado", lala);
           
            
            //rd.SetDataSource(lista);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();



            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "lista.pdf");
        }

        public void ExportToXML()
        {
            var cp = new BLLTraslado();
            var lista = cp.All();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename = listado.xls");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            var serializer = new
            System.Xml.Serialization.XmlSerializer(lista.GetType());
            serializer.Serialize(Response.OutputStream, lista);
        }

        public void ExportToXLS()
        {
            var cp = new BLLTraslado();
            var lista = cp.All();

          
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Hoja1");
            workSheet.Cells[1, 1].LoadFromCollection(lista, true);
            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=ListaTraslados.xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
        //public void ExportToXSL()
        //{
        //    var cp = new BLLTraslado();
        //    var lista = cp.All();
        //    Response.ClearContent();
        //   Response.AddHeader("content-disposition", "attachment;filename=Contact.xls");
        //   Response.AddHeader("Content-Type", "application/vnd.ms-excel");
        //   WriteHtmlTable(lista, Response.Output);
        //    Response.End();

        //}

        // GET: Traslado/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Traslado/Edit/5
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

        // GET: Traslado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Traslado/Delete/5
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
