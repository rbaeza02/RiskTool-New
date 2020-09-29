using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.MainModule.Catalogos;
using Application.MainModule.Cotizaciones;
using Application.MainModule.RiskReports;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.Util;
using MVC.Client.Extension.Messages;
using MVC.Client.Extension.Utilities;
using MVC.Client.Extensions.ActionFilters;
using MVC.Client.Extensions.Utilities;

namespace MVC.Client.Controllers
{
    [Authorize]
    [CustomAuthorize]
    [HandleCustomError]
    public class RiskReportController : Controller
    {
        private ICatalogoManagementService _CatalogoService;
        private IRiskReportManagementService _RiskReportService;
        private ICotizacionManagementService _CotizacionService;

        public RiskReportController(ICatalogoManagementService catalogoService, IRiskReportManagementService riskReportService,
            ICotizacionManagementService cotizacionService)
        {
            _CatalogoService = catalogoService;
            _RiskReportService = riskReportService;
            _CotizacionService = cotizacionService;
        }

        // GET: RiskReport
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetListCotizaciones(string vigenciaInicio, string vigenciaFin, string rfc)
        {
            string mensaje = string.Empty;
            string datos = string.Empty;
            DateTime inicio, fin;
            Nullable<DateTime> param1 = null, param2 = null;

            if (!string.IsNullOrEmpty(vigenciaInicio))
                if (!DateTime.TryParseExact(vigenciaInicio, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out inicio))
                    mensaje = "- Vigencia Inicio -> " + Resources.Messages.date_error;
                else
                    param1 = inicio;

            if (!string.IsNullOrEmpty(vigenciaFin))
                if (!DateTime.TryParseExact(vigenciaFin, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fin))
                    mensaje = mensaje + " - Vigencia Fin -> " + Resources.Messages.date_error;
                else
                    param2 = fin;

            if (string.IsNullOrEmpty(mensaje))
            {
                //List<Cotizacion> cot = _CotizacionService.FindCotizacionesbyFiltro(param1, param2, rfc, Helper.GetUserData().UserId);
                datos = Render.RenderRazorViewToString(this, "Templates/ListaCotizaciones", _CotizacionService.FindCotizacionesbyFiltro(param1, param2, rfc, Helper.GetUserData().UserId, null,null));
            }
            else
                mensaje = MessagesValidation.Error(mensaje).ToString();

            return this.Json(new { datos = datos, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        private void FillRiskReport(Cotizacion cot)
        {
            if (cot == null)
                return;

            if (cot.bk_te_LazCasualty != null)
            {
                cot.bk_te_LazCasualty.RetroactiveList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RRRetroactive), "Value", "Label");
                cot.bk_te_LazCasualty.TriggerList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RRTrigger), "Value", "Label");
                cot.bk_te_LazCasualty.TypeOcurrencyList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RRTypeOcurrency), "Value", "Label");
            }

            if(cot.bk_te_IncCOPE != null)
            {
                //ViewBag.ISOList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RRISO), "Value", "Label");
                ViewBag.ISOList = _CatalogoService.AllTableData((int)enumTable.RRISO);
                //ViewBag.ExposicionList = new SelectList(_CatalogoService.AllExposiciones(), "ExposicionID", "nombre"); 
                ViewBag.ExposicionList = _CatalogoService.AllExposiciones(); 
            }

            if (cot.bk_te_IncASAreaFuego != null)
            {
                //ViewBag.TipoConstIncendioList = new SelectList(_CatalogoService.AllTipoConstructivoIncendios(), "TipoConstructivoIncendioID", "Descripcion");
                ViewBag.TipoConstIncendioList = _CatalogoService.AllTipoConstructivoIncendios();
                ViewBag.SICDivisionList = _CatalogoService.AllSICDivisiones();
            }            
        }

        public ActionResult Datos()
        {
            int cotizacionID;
            if (Session["cotizacionID"] != null)
                cotizacionID = (int)Session["cotizacionID"];
            else
                return RedirectToAction("Index");

            Cotizacion cot = _RiskReportService.FindRiskReportbyID(cotizacionID);
            FillRiskReport(cot);

            return View(cot);
        }

        public ActionResult RedirectDatos(int id)
        {
            int cotizacionID = 0;

            if (id != 0)
            {
                cotizacionID = id;
                Session["cotizacionID"] = id;
            }

            if (Session["cotizacionID"] != null && cotizacionID == 0)
                cotizacionID = (int)Session["cotizacionID"];

            _RiskReportService.InsertRiskReport(id);
            return RedirectToAction("Datos");
        }

        [HttpPost]
        public ActionResult Datos(Cotizacion cotizacion)
        {
            if (ModelState.IsValid)
            {
                cotizacion = _RiskReportService.SaveRiskReportInc(cotizacion);
                ViewBag.Mensaje = Resources.Messages.successful_general;                
            }
            FillRiskReport(cotizacion);

            return View(cotizacion);
        }

        public ActionResult RiskReportInc()
        {
            int cotizacionID = 0;

            if (Session["cotizacionID"] != null)
                cotizacionID = (int)Session["cotizacionID"];

            //ViewBag.Modelo = ;
            return View(_RiskReportService.FindRiskReportIncbyID(cotizacionID));
        }

        public ActionResult RiskReportTrans()
        {
            int cotizacionID = 0;

            if (Session["cotizacionID"] != null)
                cotizacionID = (int)Session["cotizacionID"];

            //ViewBag.Modelo = ;
            return View(_RiskReportService.FindRiskReportTransbyID(cotizacionID));
        }

        public ActionResult RiskReportRC()
        {
            int cotizacionID = 0;

            if (Session["cotizacionID"] != null)
                cotizacionID = (int)Session["cotizacionID"];

            //ViewBag.Modelo = ;
            return View(_RiskReportService.FindRiskReportRCbyID(cotizacionID));
        }

        public ActionResult RiskBrowser()
        {
            int cotizacionID = 0;

            if (Session["cotizacionID"] != null)
                cotizacionID = (int)Session["cotizacionID"];

            //ViewBag.Modelo = ;
            return View(_RiskReportService.FindRiskBrowserbyID(cotizacionID));
        }
    }
}