using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.MainModule.Cotizaciones;
using Application.MainModule.Process;
using Domain.MainModule.Entities;
using MVC.Client.Extension.Messages;
using MVC.Client.Extension.Utilities;
using MVC.Client.Extensions.ActionFilters;
using Application.MainModule.Asegurados;
using Domain.MainModule.Entities.Util;
using Application.MainModule.Catalogos;
using MVC.Client.Extensions.Utilities;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Configuration;

namespace MVC.Client.Controllers
{
    [Authorize]
    [CustomAuthorize]
    [HandleCustomError]
    public class ProcessController : Controller
    {
        private IProcessManagementService _ProcessService;
        private ICotizacionManagementService _CotizacionService;
        private IAseguradoManagementService _AseguradoService;
        private ICatalogoManagementService _CatalogoService;

        public ProcessController(IProcessManagementService processService,
            ICotizacionManagementService cotizacionService, IAseguradoManagementService aseguradoService,
            ICatalogoManagementService catalogoService)
        {
            _ProcessService = processService;
            _CotizacionService = cotizacionService;
            _AseguradoService = aseguradoService;
            _CatalogoService = catalogoService;
        }

        public ActionResult Index()
        {
            return View();
        }

        #region ProcesaCotizacion

        public ActionResult ProcessCotizacion()
        {
            ViewBag.ProcessID = 1;
            return View(_ProcessService.FindWorkFlowxProcess(ViewBag.ProcessID));
        }

        public JsonResult ProcessStep(int procesoID, int orden)
        {
            int rownumber = -1;
            string errores = string.Empty;
            rownumber = _ProcessService.ProcessActivity(procesoID, orden, Session["cotizacionID"].ToString());

            return this.Json(rownumber, JsonRequestBehavior.AllowGet);
        }


        
        #endregion

        public ActionResult SendSiSE()
        {
            ViewBag.ProcessID = 2;
            if (_CotizacionService.FindCotizacionTransportebyID((int)Session["cotizacionID"]).bk_te_CotizacionTrans != null)
                ViewBag.Transporte = "1";
            else
                ViewBag.Transporte = "0";

            return View(_ProcessService.FindWorkFlowxProcess(ViewBag.ProcessID));
        }

        public JsonResult ProcessSendSISE()
        {
            string mensaje = MessagesValidation.Error(Resources.Messages.sesion_error).ToString();

            if (Session["cotizacionID"] != null)
            {
                mensaje = _ProcessService.ProcessSISE((int)Session["cotizacionID"],Helper.GetUserData().UserId);
                mensaje = MessagesValidation.Successful(mensaje).ToString();
            }

            return this.Json(mensaje, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FillDetailsReportTrans()
        {
            PresentacionTrans model = _CotizacionService.FindPresentacionTransCotizacionbyID((int)Session["cotizacionID"], Helper.GetUserData().UserId);
            string reportType = "Word";

            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/PresentacionTrans2.rdlc");
            localReport.DataSources.Clear();

            ReportDataSource rdc = new ReportDataSource("dsTransporte", model.Textos);
            ReportDataSource rdc1 = new ReportDataSource("dsCondiciones", model.Condiciones);

            ReportParameter param = new ReportParameter("isSendSISE", "True");
            localReport.SetParameters(param);
            localReport.DataSources.Add(rdc);
            localReport.DataSources.Add(rdc1);
            localReport.Refresh();


            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =
            "<DeviceInfo>" +
            "  <OutputFormat>PDF</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
            "  <MarginTop>0.2in</MarginTop>" +
            "  <MarginLeft>0.2in</MarginLeft>" +
            "  <MarginRight>0.2in</MarginRight>" +
            "  <MarginBottom>0.2in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            //Render the report
            renderedBytes = localReport.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            //return File(renderedBytes, mimeType);

            using (var fs = new FileStream(Server.MapPath(ConfigurationManager.AppSettings["PathTransporte"] + ".doc"), FileMode.Create, FileAccess.Write))
            {
                fs.Write(renderedBytes, 0, renderedBytes.Length);                
            }

            return this.Json("1", JsonRequestBehavior.AllowGet);
        }
        
        #region LogSISE

        public ActionResult LogSISE()
        {
            if (Session["cotizacionID"] != null)
            {
                int cotizacionID = (int)Session["cotizacionID"];
                ViewBag.UbicacionList = _AseguradoService.FindCatalogoUbicaciones(cotizacionID);
                ViewBag.TipoBeneficiarioList = _CatalogoService.AllTableData((int)enumTable.TipoBeneficiario);
                ViewBag.BeneficiariosNumber = _AseguradoService.GetNumberBenefbyCotizacion(cotizacionID);
                ViewBag.RFC = _CotizacionService.FindRFCCotizacionbyID(cotizacionID);

                Cotizacion cot = _CotizacionService.FindCotizacionLogbyID(cotizacionID);
                if (cot.bk_te_CotizacionLog.ToList().Exists(x => x.isOK.Value))
                    ViewBag.isEnable = false;
                else
                    ViewBag.isEnable = true;


                ViewBag.ListaAseguradoDiferencias = _AseguradoService.GetDiferenciaAsegurado(cot.AseguradoID);
                ViewBag.ErrorNroBeneficiarios = MessagesValidation.Error(cot.ErrorMaxBeneficiario());
                return View(cot);
            }
            return View();
        }

        public JsonResult GetListBeneficiarios(int ubicacionID)
        {
            List<SelectBeneficiario_Result> resultado = _ProcessService.FindBeneficiariobyID((int)Session["cotizacionID"], ubicacionID);
            resultado.ForEach(x => x.TipoBeneficiario = _CatalogoService.AllTableData((int)enumTable.TipoBeneficiario));

            return this.Json(Render.RenderRazorViewToString(this, "Templates/ListaBeneficiario", resultado), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPersonaSISE(string rfc)
        {
            Persona persona = _AseguradoService.FindPersonabyRFC(rfc);
            string mensaje = string.Empty;
            if (persona == null)            
                mensaje = persona.ErrorSISE();
            

            return this.Json(persona, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveBeneficiarios(string[] datos, int ubicacionID)
        {
            Persona persona = new Persona();
            string mensaje = persona.VectorValidation(datos);
            int nroBenef = 0;

            if (String.IsNullOrEmpty(mensaje))
            {
                _AseguradoService.SavePersona(persona.PersonaToXML(datos), (int)Session["cotizacionID"], ubicacionID);
                mensaje = MessagesValidation.Successful(Resources.Messages.successful_general).ToString();
                nroBenef = _AseguradoService.GetNumberBenefbyCotizacion((int)Session["cotizacionID"]);
            }
            else
                mensaje = MessagesValidation.Error(mensaje).ToString();

            return this.Json(new { Mensaje = mensaje, NroBenef = nroBenef }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetListPagadores(string rfc)
        {
            List<CotizacionPagador> pagadores = _ProcessService.GetPagadoresSISE(rfc);
            
            return this.Json(Render.RenderRazorViewToString(this, "Templates/ListaPagador", pagadores), JsonRequestBehavior.AllowGet);
        }

        public JsonResult SavePagador(int cod_conducto, string cod_banco, int ind_conducto, string rfc, string nroTarjeta, string nombre)
        {
            CotizacionPagador cotizacionPagador = new CotizacionPagador();
            cotizacionPagador.CotizacionID = (int)Session["cotizacionID"];
            cotizacionPagador.COD_CONDUCTO = cod_conducto.ToString();
            cotizacionPagador.COD_BANCO_EMI = cod_banco;
            cotizacionPagador.SISEind_conducto = ind_conducto;
            cotizacionPagador.RFC = rfc;
            cotizacionPagador.NroTarjeta = nroTarjeta;
            cotizacionPagador.nombre = nombre;

            _CotizacionService.SaveCotizacionPagador(cotizacionPagador);

            return this.Json(new { datos = cotizacionPagador, mensaje = MessagesValidation.Successful(Resources.Messages.successful_general).ToString() }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}