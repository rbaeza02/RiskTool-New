using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.MainModule.Catalogos;
using Domain.MainModule.Entities;
using Application.MainModule.Cotizaciones;
using MVC.Client.Extensions.Utilities;
using System.Globalization;
using MVC.Client.Extension.Messages;
using Application.MainModule.Asegurados;
using Domain.MainModule.Entities.Util;
using MVC.Client.Extensions.ActionFilters;
using Microsoft.Reporting.WebForms;
using MVC.Client.Extension.Utilities;
using Application.MainModule.Accounts;
using System.IO;
using Application.MainModule.Util;

namespace MVC.Client.Controllers
{
    [Authorize]
    [CustomAuthorize]
    [HandleCustomError]
    public class CotizarController : Controller
    {
        #region Constructor

        private ICatalogoManagementService _CatalogoService;
        private ICotizacionManagementService _CotizacionService;
        private IAseguradoManagementService _AseguradoService;
        private IAccountManagementService _AccountService;

        public CotizarController(ICatalogoManagementService catalogoService, ICotizacionManagementService cotizacionService,
            IAseguradoManagementService aseguradoService, IAccountManagementService accountService)
        {
            _CatalogoService = catalogoService;
            _CotizacionService = cotizacionService;
            _AseguradoService = aseguradoService;
            _AccountService = accountService;
        }

        #endregion

        #region Index

        public ActionResult Index()
        {
            ViewBag.UsuarioList = new SelectList(_AccountService.GetAllUsuarios(), "UsuarioID", "NombreCompleto");
            return View();
        }

        public JsonResult GetListCotizaciones(string vigenciaInicio, string vigenciaFin, string rfc, int usuarioID, string nombre, string nroPol)
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
                //List<Cotizacion> cot = _CotizacionService.FindCotizacionesbyFiltro(param1, param2, rfc, usuarioID);
                datos = Render.RenderRazorViewToString(this, "Templates/ListaCotizaciones", _CotizacionService.FindCotizacionesbyFiltro(param1, param2, rfc, usuarioID, nombre, nroPol));
            }
            else
                mensaje = MessagesValidation.Error(mensaje).ToString();

            return this.Json(new { datos = datos, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Crear

        private void CrearDatos()
        {
            ViewBag.MiscelaneoList = new SelectList(_CatalogoService.GetSubLineaNegocios(3), "SubLineaNegocioID", "nombre");
            ViewBag.TecnicoList = new SelectList(_CatalogoService.GetSubLineaNegocios(4), "SubLineaNegocioID", "nombre");
            ViewBag.RCList = new SelectList(_CatalogoService.GetSubLineaNegocios(5), "SubLineaNegocioID", "nombre");

            ViewBag.MonedaList = new SelectList(_CatalogoService.AllMonedas(), "MonedaID", "nombre");
            ViewBag.FormaPagoList = new SelectList(_CatalogoService.AllFormaPagos(), "FormaPagoID", "nombre");
            ViewBag.TipoOperacionList = new SelectList(_CatalogoService.AllTipoOperaciones(), "TipoOperacionID", "Nombre");
            ViewBag.ErrorNotFound = MessagesValidation.Error(Resources.Messages.NotFound_error);
            ViewBag.SucursalList = _CatalogoService.AllSucursales();

            //PrimerRiesgo
            ViewBag.PrimerRiesgoAll = _CatalogoService.AllSubLineaNegociosPrimerRiesgo();
            ViewBag.PrimerRiesgoCobAll = _CatalogoService.AllTipoCoberturasPimerRiesgo();


        }

        public ActionResult Crear(string id, string rfc)
        {
            CrearDatos();

            int cotizacionID = 0;
            Cotizacion cot;
            if ((Int32.TryParse(id, out cotizacionID) || Session["cotizacionID"] != null) && id != "0")
            {
                cotizacionID = cotizacionID == 0 ? (int)Session["cotizacionID"] : cotizacionID;
                cot = _CotizacionService.FindCotizacionbyID(cotizacionID);
                Session["cotizacionID"] = cotizacionID;
                Session["paginas"] = _CatalogoService.FindPagina(cotizacionID);

                //Checks
                cot.Incendio = cot.bk_tr_CotizacionSubLineaNegocio.Where(x => x.bk_tc_SubLineaNegocio.LineaNegocioID == 1).ToList().Count > 0 ? true : false;
                cot.Hidro = cot.bk_tr_CotizacionSubLineaNegocio.Where(x => x.bk_tc_SubLineaNegocio.LineaNegocioID == 7).ToList().Count > 0 ? true : false;
                cot.Terremoto = cot.bk_tr_CotizacionSubLineaNegocio.Where(x => x.SubLineaNegocioID == 19).ToList().Count > 0 ? true : false;
                cot.TerremotoBI = cot.bk_tr_CotizacionSubLineaNegocio.Where(x => x.SubLineaNegocioID == 21).ToList().Count > 0 ? true : false;

                cot.Transporte = cot.bk_tr_CotizacionSubLineaNegocio.Where(x => x.bk_tc_SubLineaNegocio.LineaNegocioID == 2).ToList().Count > 0 ? true : false;

                //Primer Riesgo
                ViewBag.PrimerRiesgoSelection = cot.bk_tr_CotizacionSubLineaNegocio.Where(x => x.isPrimerRiesgo.HasValue).Where(x => x.isPrimerRiesgo.Value).Select(x => x.bk_tc_SubLineaNegocio).ToList();
                ViewBag.PrimerRiesgoCobSelection = cot.bk_tr_CotizacionTipoCobertura.Where(x => x.isPrimerRiesgo.HasValue).Where(x => x.isPrimerRiesgo.Value).Select(x => x.bk_tc_TipoCobertura).ToList();

                //Coberturas
                cot.Miscelaneos = string.Join(",", cot.bk_tr_CotizacionSubLineaNegocio.Where(x => x.bk_tc_SubLineaNegocio.LineaNegocioID == 3 && x.bk_tc_SubLineaNegocio.isActivo).Select(x => x.bk_tc_SubLineaNegocio.nombre));
                cot.Tecnicos = string.Join(",", cot.bk_tr_CotizacionSubLineaNegocio.Where(x => x.bk_tc_SubLineaNegocio.LineaNegocioID == 4 && x.bk_tc_SubLineaNegocio.isActivo).Select(x => x.bk_tc_SubLineaNegocio.nombre));
                cot.RC = string.Join(",", cot.bk_tr_CotizacionSubLineaNegocio.Where(x => x.bk_tc_SubLineaNegocio.LineaNegocioID == 5 && x.bk_tc_SubLineaNegocio.isActivo).Select(x => x.bk_tc_SubLineaNegocio.nombre));

                cot.NombreAsegurado = cot.bk_tc_Asegurado.NombreCompleto;
                cot.RFCAsegurado = cot.bk_tc_Asegurado.RFC;
                cot.isOFAC = cot.bk_tc_Asegurado.isOFAC.HasValue ? cot.bk_tc_Asegurado.isOFAC.Value : false;

                //Revisar si ya esta emitido
                if (cot.isActivo)
                    cot.Fecha = DateTime.Now;
            }
            else
            {
                Session["paginas"] = _CatalogoService.FindPagina(0);
                cot = new Cotizacion() { Fecha = DateTime.Now, VigenciaFin = DateTime.Now.AddYears(1), VigenciaInicio = DateTime.Now };                
                //cot.Incendio = true;
                //cot.Hidro = true;
                //cot.Terremoto = true;
                //cot.TerremotoBI = true;
                //cot.Transporte = true;
                //cot.Miscelaneos = string.Join(",", _CatalogoService.GetSubLineaNegocios(3).Select(x => x.nombre));
                //cot.Tecnicos = string.Join(",", _CatalogoService.GetSubLineaNegocios(4).Select(x => x.nombre));
                //cot.RC = string.Join(",", _CatalogoService.GetSubLineaNegocios(5).Select(x => x.nombre));
                cot.LimitPrimerRiesgo = null;
                cot.isActivo = true;

                //Valores Default
                List<Table> defaultValues = _CatalogoService.AllTableData((int)enumTable.Defaults);

                cot.MonedaID = Convert.ToInt32(defaultValues.Where(x => x.Value == 2).FirstOrDefault().Label);
                cot.Comision = Convert.ToDouble(defaultValues.Where(x => x.Value == 3).FirstOrDefault().Label);
                cot.GastosAdquisicion = Convert.ToDouble(defaultValues.Where(x => x.Value == 4).FirstOrDefault().Label);
                cot.GastosAdministracion = Convert.ToDouble(defaultValues.Where(x => x.Value == 5).FirstOrDefault().Label);
                cot.OtrosGastosAdq = Convert.ToDouble(defaultValues.Where(x => x.Value == 19).FirstOrDefault().Label);
                cot.Utilidad = Convert.ToDouble(defaultValues.Where(x => x.Value == 6).FirstOrDefault().Label);
                cot.Participacion = Convert.ToDouble(defaultValues.Where(x => x.Value == 7).FirstOrDefault().Label);
                cot.isNew = defaultValues.Where(x => x.Value == 8).FirstOrDefault().Label == "1" ? true : false;
                cot.TipoCambio = Convert.ToDouble(defaultValues.Where(x => x.Value == 9).FirstOrDefault().Label);

                //Primer Riesgo
                ViewBag.PrimerRiesgoSelection = ViewBag.PrimerRiesgoAll;
                ViewBag.PrimerRiesgoCobSelection = ViewBag.PrimerRiesgoCobAll;
                                
                cot.bk_tc_Asegurado = _AseguradoService.FindAseguradobyRFC(rfc);
                cot.NombreAsegurado = cot.bk_tc_Asegurado == null? null: cot.bk_tc_Asegurado.NombreCompleto;
                cot.RFCAsegurado = cot.bk_tc_Asegurado == null? null: cot.bk_tc_Asegurado.RFC;
                cot.isOFAC = cot.bk_tc_Asegurado == null? false : (cot.bk_tc_Asegurado.isOFAC.HasValue ? cot.bk_tc_Asegurado.isOFAC.Value : false);
            }

            cot.PrimerRiesgo = cot.LimitPrimerRiesgo != null ? true : false;

            return View(cot);
        }

        [HttpPost]
        public ActionResult Crear(Cotizacion cotizacion)
        {
            //bool incendioBool = false, transporteBool = false;
            if (cotizacion.PrimerRiesgo && !cotizacion.LimitPrimerRiesgo.HasValue)
            {
                ModelState.Remove("LimitPrimerRiesgo");
                ModelState.AddModelError("LimitPrimerRiesgo", "LimitPrimerRiesgo: " + Resources.Messages.EmptyData_error);
            }

            if (cotizacion.AseguradoID == 0)
            {
                ModelState.Remove("AseguradoID");
                ModelState.AddModelError("AseguradoID", "Asegurado: " + Resources.Messages.EmptyData_error);
            }

            if (!cotizacion.isNew && cotizacion.nroPolizaAnt == null)
            {
                ModelState.Remove("nroPolizaAnt");
                ModelState.AddModelError("nroPolizaAnt", "Poliza Anterior: " + Resources.Messages.EmptyData_error);
            }

            if (!cotizacion.isActivo)
            {
                ModelState.Remove("CotizacionID");
                ModelState.AddModelError("CotizacionID", "Cotizacion: " + cotizacion.ErrorEmitida());
            }
            else
                if (cotizacion.VigenciaInicio >= cotizacion.VigenciaFin)
                {
                    ModelState.Remove("CotizacionID");
                    ModelState.AddModelError("CotizacionID", "Fecha de Vigencias: " + Resources.Messages.dataRange_Error);
                }
                else
                {
                    int diasRetro = Convert.ToInt32(_CatalogoService.GetGlobalParambyID((int)globalParam.DiasRetro));
                    if ((DateTime.Now - cotizacion.VigenciaInicio).Days > diasRetro)
                    {
                        ModelState.Remove("CotizacionID");
                        ModelState.AddModelError("CotizacionID", "Fecha de Vigencias: " + cotizacion.ErrorRetroactividad(diasRetro));
                    }
                    else
                        if (string.IsNullOrEmpty(cotizacion.Miscelaneos) && string.IsNullOrEmpty(cotizacion.Tecnicos) && string.IsNullOrEmpty(cotizacion.RC) && !cotizacion.Incendio && !cotizacion.Transporte)
                        {
                            ModelState.Remove("CotizacionID");
                            ModelState.AddModelError("CotizacionID", "Tipo de Bienes: " + Resources.Messages.EmptyData_error);
                        }
                        else
                        {
                            int diasFuturo = Convert.ToInt32(_CatalogoService.GetGlobalParambyID((int)globalParam.DiasFuturo));
                            if ((cotizacion.VigenciaInicio - DateTime.Now).Days > diasFuturo)
                            {
                                ModelState.Remove("CotizacionID");
                                ModelState.AddModelError("CotizacionID", "Fecha de Vigencias: " + cotizacion.ErrorFuturo(diasFuturo));
                            }
                        }
                }
            

            if (!cotizacion.Incendio && (cotizacion.Hidro || cotizacion.Terremoto || cotizacion.TerremotoBI))
            {
                ModelState.Remove("Incendio");
                ModelState.AddModelError("Incendio", "Cotizacion Incendio: " + Resources.Messages.dataDependency_Error);
            }

            if (!cotizacion.Terremoto && cotizacion.TerremotoBI)
            {
                ModelState.Remove("Terremoto");
                ModelState.AddModelError("Terremoto", "Cotizacion Terremoto: " + Resources.Messages.dataDependency_Error);
            }

            if (ModelState.IsValid)
            {
                cotizacion.usuarioid = Helper.GetUserData().UserId;
                cotizacion.ValidarTrans();
                _CotizacionService.SaveCotizacion(cotizacion);
                ViewBag.Mensaje = Resources.Messages.successful_general;
                Session["cotizacionID"] = cotizacion.CotizacionID;
                Session["paginas"] = _CatalogoService.FindPagina(cotizacion.CotizacionID);
            }

            CrearDatos();

            //PrimerRiesgo
            if(cotizacion.PrimerRiesgoSubLinea!= null)
            {
                string[] arraySubLinea = cotizacion.PrimerRiesgoSubLinea.Split(",".ToCharArray()[0]);
                ViewBag.PrimerRiesgoSelection = ((List<SubLineaNegocio>)ViewBag.PrimerRiesgoAll).Where(x => !string.IsNullOrEmpty(Array.Find(arraySubLinea, s => s.Equals(x.SubLineaNegocioID.ToString())))).ToList();
            }
            else            
                ViewBag.PrimerRiesgoSelection = new List<SubLineaNegocio>();
            
            if(cotizacion.PrimerTipoCobertura!= null)
            {
                string[] arrayTipoCob = cotizacion.PrimerTipoCobertura.Split(",".ToCharArray()[0]);
                ViewBag.PrimerRiesgoCobSelection = ((List<TipoCobertura>)ViewBag.PrimerRiesgoCobAll).Where(x => !string.IsNullOrEmpty(Array.Find(arrayTipoCob, s => s.Equals(x.TipoCoberturaID.ToString())))).ToList();
            }
            else
                ViewBag.PrimerRiesgoCobSelection = new List<TipoCobertura>();
            
            //cotizacion.PrimerRiesgo = cotizacion.LimitPrimerRiesgo != null ? true : false;

            //cotizacion.bk_tc_Asegurado = _AseguradoService.FindAseguradobyRFC(rfc);

            return View(cotizacion);
        }

        public JsonResult GetAsegurado(string rfc)
        {
            string id, nombre = string.Empty, _RFC = string.Empty; 
            bool isOFAC = false;

            Asegurado a = _AseguradoService.FindAseguradobyRFC(rfc);
            if (a == null)
                id = "0";
            else
            {
                id = a.AseguradoID.ToString();
                nombre = a.NombreCompleto;
                _RFC = a.RFC;
                isOFAC = a.isOFAC.HasValue ? a.isOFAC.Value : false;
            }

            return this.Json(new { id = id, nombre = nombre, rfc = _RFC, isOFAC = isOFAC }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAgenteToSelection(int sucursalID)
        {
            return this.Json(new { datos = new SelectList(_CatalogoService.GetAgentebySucursalID(sucursalID), "AgenteID", "NombreCompleto")}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetContactoToSelection(int agenteID)
        {
            return this.Json(new { datos = new SelectList(_CatalogoService.GetContactobyAgenteID(agenteID), "ContactoID", "NombreCompleto") }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Valores

        private void DatosUbicacion()
        {
            //ViewBag.GrupoIncendioList = new SelectList(_CatalogoService.AllGrupoIncendios(), "GrupoIncendioID", "nombre");
            ViewBag.GrupoIncendioList = _CatalogoService.AllGrupoIncendios();
            //ViewBag.GradoExposicionList = new SelectList(_CatalogoService.AllGradoExposiciones(), "GradoExposicionID", "nombre");
            ViewBag.GradoExposicionList = _CatalogoService.AllGradoExposiciones();
            //ViewBag.ProteccionPrivadaList = new SelectList(_CatalogoService.AllProteccionPrivadas(), "ProteccionPrivadaID", "nombre");
            ViewBag.ProteccionPrivadaList = _CatalogoService.AllProteccionPrivadas();
            //ViewBag.ProteccionPublicaList = new SelectList(_CatalogoService.AllProteccionPublicas(), "ProteccionPublicaID", "nombre");
            ViewBag.ProteccionPublicaList = _CatalogoService.AllProteccionPublicas();
            
            //ViewBag.ExposicionList = new SelectList(_CatalogoService.AllExposiciones(), "ExposicionID", "nombre");
            ViewBag.ExposicionList = _CatalogoService.AllExposiciones();

            //ViewBag.GanBrutasList = new SelectList(_CatalogoService.AllTableData((int)enumTable.PerConsGanBrutas), "Value", "Label");
            ViewBag.GanBrutasList = _CatalogoService.AllTableData((int)enumTable.PerConsGanBrutas).OrderBy(x => x.Value).ToList();
            //ViewBag.IndemnizacionList = new SelectList(_CatalogoService.AllTableData((int)enumTable.PerConsIndemnizacion), "Value", "Label");
            ViewBag.IndemnizacionList = _CatalogoService.AllTableData((int)enumTable.PerConsIndemnizacion).OrderBy(x => x.Value).ToList();
            //ViewBag.RedIngresoList = new SelectList(_CatalogoService.AllTableData((int)enumTable.PerConsRedIngreso), "Value", "Label");
            ViewBag.RedIngresoList = _CatalogoService.AllTableData((int)enumTable.PerConsRedIngreso).OrderBy(x => x.Value).ToList();
            //ViewBag.SegContingList = new SelectList(_CatalogoService.AllTableData((int)enumTable.PerConsSegConting), "Value", "Label");
            ViewBag.SegContingList = _CatalogoService.AllTableData((int)enumTable.PerConsSegConting).OrderBy(x => x.Value).ToList();
        }

        public ActionResult Valores()
        {
            int cotizacionID = 0;
            
            if (Session["cotizacionID"] != null)
                cotizacionID = (int)Session["cotizacionID"];

            DatosUbicacion();
            return View(_CotizacionService.FindValoresUbicacionesbyCotizacionID(cotizacionID));
        }

        [HttpPost]
         public ActionResult Valores(List<Ubicacion> ubicaciones)
        {
            if(!_CotizacionService.FindActivoCotizacionbyID((int)Session["cotizacionID"]))
            {
                ModelState.Remove("CotizacionID");
                ModelState.AddModelError("CotizacionID", "Cotizacion: " + (new Cotizacion()).ErrorEmitida());
            }

            if (ModelState.IsValid)
            {
                _CotizacionService.SaveValores(ubicaciones, (int)Session["cotizacionID"]);
                ViewBag.Mensaje = Resources.Messages.successful_general;
            }

            DatosUbicacion();
            return View(ubicaciones);
        }

        #endregion

        #region Diversos

        private void FillDiversos(Cotizacion cot)
        {
            if (cot == null)
                return;

            if (cot.bk_te_CotizacionCristal != null)
                cot.bk_te_CotizacionCristal.GradoExposicionList = new SelectList(_CatalogoService.AllTableData((int)enumTable.CristalesExp), "Value", "Label");

            if (cot.bk_te_CotizacionRobo != null)
            {
                cot.bk_te_CotizacionRobo.AlarmaList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RoboAlarma), "Value", "Label");
                cot.bk_te_CotizacionRobo.PoliciaList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RoboPolicia), "Value", "Label");
                cot.bk_te_CotizacionRobo.CircuitoList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RoboCircuito), "Value", "Label");
                cot.bk_te_CotizacionRobo.GiroList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RoboGiro), "Value", "Label");
            }

            if (cot.bk_te_CotizacionDinVal != null)
            {
                cot.bk_te_CotizacionDinVal.CilindroList = new SelectList(_CatalogoService.AllTableData((int)enumTable.DinValCilindro), "Value", "Label");
                cot.bk_te_CotizacionDinVal.GiroList = new SelectList(_CatalogoService.AllTableData((int)enumTable.DinValGiro), "Value", "Label");
                cot.bk_te_CotizacionDinVal.PoliciaList = new SelectList(_CatalogoService.AllTableData((int)enumTable.DinValPolicia), "Value", "Label");
                cot.bk_te_CotizacionDinVal.TipoAlarmaList = new SelectList(_CatalogoService.AllTableData((int)enumTable.DinValTipoAlarma), "Value", "Label");
            }

            if (cot.bk_te_CotizacionCaldera != null)
            {
                cot.bk_te_CotizacionCaldera.MantList = new SelectList(_CatalogoService.AllTableData((int)enumTable.CalderaMant), "Value", "Label");
                cot.bk_te_CotizacionCaldera.TipoProcesoList = new SelectList(_CatalogoService.AllTableData((int)enumTable.CalderaTipoProc), "Value", "Label");
            }

            if (cot.bk_te_CotizacionCalderaPC != null)
            {
                cot.bk_te_CotizacionCalderaPC.DeducibleList = new SelectList(_CatalogoService.AllTableData((int)enumTable.CalderaPCDeducible), "Value", "Label");
                cot.bk_te_CotizacionCalderaPC.EqReservaList = new SelectList(_CatalogoService.AllTableData((int)enumTable.CalderaPCEqRva), "Value", "Label");
                cot.bk_te_CotizacionCalderaPC.PeriodoList = new SelectList(_CatalogoService.AllTableData((int)enumTable.CalderaPCPeriodo), "Value", "Label");
                cot.bk_te_CotizacionCalderaPC.RefCriticasList = new SelectList(_CatalogoService.AllTableData((int)enumTable.CalderaPCRefCriticas), "Value", "Label");
            }

            if (cot.bk_te_CotizacionRotMaq != null)
            {
                cot.bk_te_CotizacionRotMaq.GiroList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RotMaqGiro), "Value", "Label");
                cot.bk_te_CotizacionRotMaq.MantenimientoList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RotMaqMant), "Value", "Label");
            }

            if (cot.bk_te_CotizacionRotMaqPC != null)
            {
                cot.bk_te_CotizacionRotMaqPC.DeducibleList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RotMaqPCDeducible), "Value", "Label");
                cot.bk_te_CotizacionRotMaqPC.EqRepuestoList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RotMaqPCEqRpto), "Value", "Label");
                cot.bk_te_CotizacionRotMaqPC.PeriodoList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RotMaqPCPeriodo), "Value", "Label");
                cot.bk_te_CotizacionRotMaqPC.RefCriticasList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RotMaqPCRefCriticas), "Value", "Label");
            }

            if (cot.bk_te_CotizacionEqContratista != null)
            {
                cot.bk_te_CotizacionEqContratista.IncendioList = new SelectList(_CatalogoService.AllTableData((int)enumTable.EqContratistaInc), "Value", "Label");
                cot.bk_te_CotizacionEqContratista.MantenimientoList = new SelectList(_CatalogoService.AllTableData((int)enumTable.EqContratistaMant), "Value", "Label");
                cot.bk_te_CotizacionEqContratista.MovilidadList = new SelectList(_CatalogoService.AllTableData((int)enumTable.EqContratistaMov), "Value", "Label");
                cot.bk_te_CotizacionEqContratista.RastreoList = new SelectList(_CatalogoService.AllTableData((int)enumTable.EqContratistaRastreo), "Value", "Label");
                cot.bk_te_CotizacionEqContratista.RiesgoList = new SelectList(_CatalogoService.AllTableData((int)enumTable.EqContratistaRiesgo), "Value", "Label");
            }

            if (cot.bk_te_CotizacionEqElec != null)
            {
                cot.bk_te_CotizacionEqElec.GiroList = new SelectList(_CatalogoService.AllTableData((int)enumTable.EqElecGiro), "Value", "Label");
                cot.bk_te_CotizacionEqElec.IncendioList = new SelectList(_CatalogoService.AllTableData((int)enumTable.EqElecInc), "Value", "Label");
                cot.bk_te_CotizacionEqElec.RiesgoList = new SelectList(_CatalogoService.AllTableData((int)enumTable.EqElecRiesgo), "Value", "Label");
            }

            if (cot.bk_te_CotizacionEqElecMovil != null)
            {
                cot.bk_te_CotizacionEqElecMovil.TipoList = new SelectList(_CatalogoService.AllTableData((int)enumTable.EqElecMovilTipo), "Value", "Label");
            }

            if (cot.bk_te_CotizacionDeducible != null)
            {
                ViewBag.DeducibleValorList = _CatalogoService.AllTableData((int)enumTable.DeducibleValor).OrderBy(x => x.Value).ToList();
                ViewBag.UnidadDeducibleList = _CatalogoService.AllTableData((int)enumTable.UnidadDeducible);
                ViewBag.DeducibleAplicaList = _CatalogoService.AllTableData((int)enumTable.DeducibleAplica).OrderBy(x => x.Label).ToList();
            }

            var paginas = (List<SelectPagina_Result>)Session["paginas"];
            if (paginas != null)
            {
                var opcion = paginas.Find(x => x.actionName == "Diversos" && x.controllerName == "Cotizar");
                if (opcion != null)
                    ViewBag.NexPage = paginas.Find(x => x.orden == opcion.orden + 1 && x.ControllerContainer == "Cotizar");
            }
        }

        public ActionResult Diversos()
        {
            int cotizacionID = 0;

            if (Session["cotizacionID"] != null)
                cotizacionID = (int)Session["cotizacionID"];

            Cotizacion cot = _CotizacionService.FindCotizacionDiversobyID(cotizacionID);

            FillDiversos(cot);

            return View(cot);
        }

        [HttpPost]
        public ActionResult Diversos(Cotizacion cot, HttpPostedFileBase file)
        {
            if (!cot.isActivo)
            {
                ModelState.Remove("CotizacionID");
                ModelState.AddModelError("CotizacionID", "Cotizacion: " + cot.ErrorEmitida());
            }
            else
            {
                if (cot.bk_te_CotizacionEqContratista.Huelga.HasValue)
                    if (cot.bk_te_CotizacionEqContratista.ValorAsegurable < cot.bk_te_CotizacionEqContratista.Huelga)
                    {
                        ModelState.Remove("bk_te_CotizacionEqContratista.Huelga");
                        ModelState.AddModelError("bk_te_CotizacionEqContratista.Huelga", "Eq Contratista: " + cot.ErrorHuelga());
                    }

                if (cot.bk_te_CotizacionEqContratista.BienesBajoTierra.HasValue)
                    if (cot.bk_te_CotizacionEqContratista.ValorAsegurable < cot.bk_te_CotizacionEqContratista.BienesBajoTierra)
                    {
                        ModelState.Remove("bk_te_CotizacionEqContratista.BienesBajoTierra");
                        ModelState.AddModelError("CotizacionID", "Eq Contratista: " + cot.ErrorBienesBajoTierra());
                    }

                if (cot.bk_te_CotizacionEqContratista.GastosExtra.HasValue)
                    if (cot.bk_te_CotizacionEqContratista.ValorAsegurable < cot.bk_te_CotizacionEqContratista.GastosExtra)
                    {
                        ModelState.Remove("bk_te_CotizacionEqContratista.BienesBajoTierra");
                        ModelState.AddModelError("CotizacionID", "Eq Contratista: " + cot.ErrorGastosExtra());
                    }

                if (cot.bk_te_CotizacionEqContratista.CausaExterna.HasValue)
                    if (cot.bk_te_CotizacionEqContratista.ValorAsegurable < cot.bk_te_CotizacionEqContratista.CausaExterna)
                    {
                        ModelState.Remove("bk_te_CotizacionEqContratista.ErrorCausaExt");
                        ModelState.AddModelError("CotizacionID", "Eq Contratista: " + cot.ErrorCausaExt());
                    }

                if (cot.bk_te_CotizacionEqContratista.Terrorismo.HasValue)
                    if (cot.bk_te_CotizacionEqContratista.ValorAsegurable < cot.bk_te_CotizacionEqContratista.Terrorismo)
                    {
                        ModelState.Remove("bk_te_CotizacionEqContratista.ErrorCausaExt");
                        ModelState.AddModelError("CotizacionID", "Eq Contratista: " + cot.ErrorTerrorismo());
                    }                
            }

            if (ModelState.IsValid)
            {
                              
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string newFileName = cot.CotizacionID.ToString() + "_" + DateTime.Now.ToString("yyyyMMdd") + "_" + fileName;
                    var path = Path.Combine(Server.MapPath("~/Files/Equipos/"), newFileName);
                    file.SaveAs(path);

                    List<string> datos = Function.ReadFile(path);

                    CotizacionEqContratista eq = new CotizacionEqContratista();
                    List<string> errores = eq.ValidarEquipoFile(datos);

                    if (errores.Count > 0)
                    {
                        ViewBag.MensajeError = string.Join("<br/>", errores);
                        FillDiversos(cot);
                        return View(cot);
                    }

                    _CotizacionService.SaveEquiposbyCotizacionID(cot.CotizacionID, eq.EquipoToXML(datos).InnerXml, newFileName);
                }
                
                
                cot = _CotizacionService.SaveCotizacionDiversos(cot);                

                ViewBag.Mensaje = Resources.Messages.successful_general;
            }

            FillDiversos(cot);
            return View(cot);
        }

        public JsonResult SaveEqContratista(double comision, double otrosGastosAdq, double utilidad, double gastosAdm)
        {
            int cotizacionID = 0;

            if (Session["cotizacionID"] != null)
                cotizacionID = (int)Session["cotizacionID"];

            Cotizacion cot = _CotizacionService.SaveParamCotizacion(comision, otrosGastosAdq, utilidad, gastosAdm, cotizacionID);

            return this.Json(new { CuotaBaseEQ = cot.bk_te_CotizacionEqContratista.CuotaBase, CuotaEQ = cot.bk_te_CotizacionEqContratista.Cuota,
                                   CuotaInflaEQ = cot.bk_te_CotizacionEqContratista.CuotaInflacion,
                                   PrimaEQ = cot.bk_te_CotizacionEqContratista.Prima,
                                   CuotaRC = cot.bk_te_CotizacionRCEqContratista.Cuota,
                                   PrimaRC = cot.bk_te_CotizacionRCEqContratista.Prima
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGastosAdmCalculado(double cuotaDeseada)
        {
            int cotizacionID = 0;
            if (Session["cotizacionID"] != null)
                cotizacionID = (int)Session["cotizacionID"];

            return this.Json(_CotizacionService.FindGastosAdmCalculado(cotizacionID, cuotaDeseada/100), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region RC

        private void FillRC(Cotizacion cot)
        {
            if (cot.bk_te_CotizacionRCActInm != null)
            {
                cot.bk_te_CotizacionRCActInm.GrupoIncendioList = new SelectList(_CatalogoService.AllGrupoIncendios(), "GrupoIncendioID", "nombre");
                cot.bk_te_CotizacionRCActInm.TipoRiesgoList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RCActInmTipoRiesgo), "Value", "Label");
                cot.bk_te_CotizacionRCActInm.CruzadaList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RCActInmCruzada), "Value", "Label");
            }

            //if (cot.bk_te_CotizacionRCProducto != null)
            //    cot.bk_te_CotizacionRCProducto.GiroList = new SelectList(_CatalogoService.AllGrupoIncendios(), "GrupoIncendioID", "nombre");

            if (cot.bk_te_CotizacionRCTrabajoTerm != null)
                cot.bk_te_CotizacionRCTrabajoTerm.GiroList = new SelectList(_CatalogoService.AllGrupoIncendios(), "GrupoIncendioID", "nombre");

            if (cot.bk_te_CotizacionDeducible != null)
            {
                ViewBag.DeducibleValorList = _CatalogoService.AllTableData((int)enumTable.DeducibleValor).OrderBy(x => x.Value).ToList();
                ViewBag.UnidadDeducibleList = _CatalogoService.AllTableData((int)enumTable.UnidadDeducible);
                ViewBag.DeducibleAplicaList = _CatalogoService.AllTableData((int)enumTable.DeducibleAplica).OrderBy(x => x.Label).ToList();
            }

            if(cot.bk_te_CotizacionRCAdicional != null)
            {
                cot.bk_te_CotizacionRCAdicional.EvaluacionList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RCEvaluacion), "Value", "Label");
                cot.bk_te_CotizacionRCAdicional.InclinacionList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RCInclinacion), "Value", "Label");
            }
        }

        public ActionResult RC()
        {
            int cotizacionID = 0;

            if (Session["cotizacionID"] != null)
                cotizacionID = (int)Session["cotizacionID"];

            Cotizacion cot = _CotizacionService.FindCotizacionRCbyID(cotizacionID);
            FillRC(cot);
            return View(cot);
        }

        [HttpPost]
        public ActionResult RC(Cotizacion cot)
        {
            if (!cot.isActivo)
            {
                ModelState.Remove("CotizacionID");
                ModelState.AddModelError("CotizacionID", "Cotizacion: " + cot.ErrorEmitida());
            }

            if (ModelState.IsValid)
            {
                cot = _CotizacionService.SaveCotizacionRC(cot);
                ViewBag.Mensaje = Resources.Messages.successful_general;
            }

            FillRC(cot);
            return View(cot);
        }

        #endregion

        #region Texto

        public ActionResult Texto()
        {
            int cotizacionID = 0;

            if (Session["cotizacionID"] != null)
                cotizacionID = (int)Session["cotizacionID"];

            ViewBag.CotizacionID = cotizacionID;
            return View(_CotizacionService.FindTextobyCotizacionID(cotizacionID));
        }

        public JsonResult SaveTexto(int cotizacionID, string[] valores, string[] textoAdicional, string[] textoIDs)
        {
            Texto texto = new Texto();
            string mensaje;

            if (!_CotizacionService.FindActivoCotizacionbyID((int)Session["cotizacionID"]))
            {
                mensaje = MessagesValidation.Error("Cotizacion: " + (new Cotizacion()).ErrorEmitida()).ToString();
            }
            else
            {
                mensaje = texto.VectorValidation(valores);

                if (string.IsNullOrEmpty(mensaje))
                    mensaje = texto.VectorValidationAdicional(textoAdicional, textoIDs);

                if (string.IsNullOrEmpty(mensaje))
                {
                    _CotizacionService.SaveTextobyCotizacionID(cotizacionID, texto.VectorToXML(valores).InnerXml, texto.VectorAdicionalToXML(textoAdicional, textoIDs).InnerXml);
                    mensaje = MessagesValidation.Successful(Resources.Messages.successful_general).ToString();
                }
                else
                    mensaje = MessagesValidation.Error(mensaje).ToString();

            }

            return this.Json(mensaje, JsonRequestBehavior.AllowGet);
        }

        #endregion
        
        #region RCExt

        public JsonResult GetSICDetalladoToSelection(string sicID)
        {
            return this.Json(new SelectList(_CatalogoService.GetSICDetallebySICID(sicID), "SICClassMapID", "NombreCompleto"), JsonRequestBehavior.AllowGet);
        }

        private void FillRCExtRecall(Cotizacion cot)
        {
            ViewBag.SICDivisionList = _CatalogoService.AllSICDivisiones();

            if (cot.bk_te_CotizacionRCProductoExt != null)
            {
                cot.bk_te_CotizacionRCProductoExt.ActInmLimAgregadoList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RCActInmLimAgregado), "Value", "Label");
                cot.bk_te_CotizacionRCProductoExt.ProdLimAgregadoList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RCProdLimAgregado), "Value", "Label");
            }

            if (cot.bk_te_CotizacionRCProductoExtResultado != null)
            {
                //cot.bk_te_CotizacionRCProductoExt.TipoCoberturaList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RCProdTipoCobertura), "Value", "Label");
                //cot.bk_te_CotizacionRCProductoExt.BaseDeducibleList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RCProdBaseDeducible), "Value", "Label");
                ViewBag.BaseDeducibleList = _CatalogoService.AllTableData((int)enumTable.RCProdBaseDeducible);
                ViewBag.TipoCoberturaList = _CatalogoService.AllTableData((int)enumTable.RCProdTipoCobertura);
 
                SICClassMap info;
                foreach (var item in cot.bk_te_CotizacionRCProductoExtResultado)
                {
                    info = _CatalogoService.GetSICDetalladobyID(item.SICClassMapID.Value);
                    item.nombreClassMap = info.Codigo + " - " + info.nombreING;
                    item.nombreSIC = info.bk_tc_SIC.SISECod_giro_negocio + " - " + info.bk_tc_SIC.NombreING;
                }
            }

            if (cot.bk_te_CotizacionRCRecall != null)
            {
                cot.bk_te_CotizacionRCRecall.CategoryList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RCRecallCategory), "Value", "Label");
                cot.bk_te_CotizacionRCRecall.CoverageList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RCRecallCoverage), "Value", "Label");
                cot.bk_te_CotizacionRCRecall.ExposureTypeList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RCRecallExposureType), "Value", "Label");
                cot.bk_te_CotizacionRCRecall.BatchAmountList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RCRecallBatchAmount).OrderBy(x => x.Value), "Value", "Label");
                cot.bk_te_CotizacionRCRecall.LimitList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RCRecallLimit).OrderBy(x => x.Value), "Value", "Label");
                cot.bk_te_CotizacionRCRecall.DeducibleList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RCRecallDeducible), "Value", "Label");
                cot.bk_te_CotizacionRCRecall.OccupancyList = new SelectList(_CatalogoService.AllTableData((int)enumTable.RCRecallOccupancy), "Value", "Label");
            }
        }

        public ActionResult RCExtRecall()
        {
            int cotizacionID = 0;

            if (Session["cotizacionID"] != null)
                cotizacionID = (int)Session["cotizacionID"];

            Cotizacion cot = _CotizacionService.FindCotizacionRCExtRecallbyID(cotizacionID);
            FillRCExtRecall(cot);
            return View(cot);
        }

        [HttpPost]
        public ActionResult RCExtRecall(Cotizacion cot)
        {
            if (!cot.isActivo)
            {
                ModelState.Remove("CotizacionID");
                ModelState.AddModelError("CotizacionID", "Cotizacion: " + cot.ErrorEmitida());
            }

            if (cot.bk_te_CotizacionRCRecall != null)
                if (cot.bk_te_CotizacionRCRecall.AdjustedRateRangeMin.HasValue && cot.bk_te_CotizacionRCRecall.AdjustedRateRangeMax.HasValue && cot.bk_te_CotizacionRCRecall.SelectedRateSales.HasValue)
                {
                    if (cot.bk_te_CotizacionRCRecall.SelectedRateSales.Value > cot.bk_te_CotizacionRCRecall.AdjustedRateRangeMax.Value ||
                        cot.bk_te_CotizacionRCRecall.SelectedRateSales.Value < cot.bk_te_CotizacionRCRecall.AdjustedRateRangeMin.Value)
                    {
                        ModelState.Remove("SelectedRateSales");
                        ModelState.AddModelError("SelectedRateSales", "SelectedRateSales: " + Resources.Messages.data_Error);
                    }
                }

            if (ModelState.IsValid)
            {
                cot = _CotizacionService.SaveCotizacionRCExtRecall(cot);
                ViewBag.Mensaje = Resources.Messages.successful_general;
            }

            FillRCExtRecall(cot);

            return View(cot);
        }

        public JsonResult GetRCRecallRate(int categoryID, int exposureTypeID, int limitID)
        {
            return this.Json(_CotizacionService.FindCotizacionRCRecallRate(categoryID, exposureTypeID, limitID), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Transporte

        private void FillTransporte(Cotizacion cot)
        {
            if (cot.bk_te_CotizacionTrans != null)
            {
                cot.bk_te_CotizacionTrans.ModalidadPolizaList = new SelectList(_CatalogoService.AllTableData((int)enumTable.TransModalidadPoliza), "Value", "Label");
                cot.bk_te_CotizacionTrans.CommodityList = new SelectList(_CatalogoService.AllTableData((int)enumTable.TransCommodity), "Value", "Label");
                cot.bk_te_CotizacionTrans.TipoBienList = new SelectList(_CatalogoService.AllTableData((int)enumTable.TransTipoBien), "Value", "Label");
                cot.bk_te_CotizacionTrans.ModalidadCobList = new SelectList(_CatalogoService.AllTableData((int)enumTable.TransModalidadCob), "Value", "Label");
                cot.bk_te_CotizacionTrans.TipoMercaList = new SelectList(_CatalogoService.AllTableData((int)enumTable.TransTipoMerca), "Value", "Label");
                cot.bk_te_CotizacionTrans.TrayectoAsegList = new SelectList(_CatalogoService.AllTableData((int)enumTable.TransTrayectoAseg), "Value", "Label");
                cot.bk_te_CotizacionTrans.MediosList = new SelectList(_CatalogoService.AllTableData((int)enumTable.TransMedios), "Value", "Label");
                cot.bk_te_CotizacionTrans.AjusteAltaSinList = new SelectList(_CatalogoService.AllTableData((int)enumTable.TransAjusteAltaSin), "Value", "Label");

                ViewBag.Evaluaciones = _CatalogoService.AllTableData((int)enumTable.TransEvaluacion);
            }
        }

        public ActionResult Transporte()
        {
            int cotizacionID = 0;

            if (Session["cotizacionID"] != null)
                cotizacionID = (int)Session["cotizacionID"];

            Cotizacion cot = _CotizacionService.FindCotizacionTransportebyID(cotizacionID);
            FillTransporte(cot);
            return View(cot);
        }

        [HttpPost]
        public ActionResult Transporte(Cotizacion cot)
        {
            if (!cot.isActivo)
            {
                ModelState.Remove("CotizacionID");
                ModelState.AddModelError("CotizacionID", "Cotizacion: " + cot.ErrorEmitida());
            }

            if (ModelState.IsValid)
            {
                cot = _CotizacionService.SaveCotizacionTransporte(cot);
                ViewBag.Mensaje = Resources.Messages.successful_general;
            }

            FillTransporte(cot);

            return View(cot);
        }

        public JsonResult GetTipoBien(int commodityID)
        {
            return this.Json(_CatalogoService.GetDatobyID(commodityID, (int)enumTableID.TipoBien), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCommodityClass(int tipoBienID)
        {
            return this.Json(_CatalogoService.GetDatobyID(tipoBienID, (int)enumTableID.Class), JsonRequestBehavior.AllowGet);
        }

        public ActionResult PresentacionTrans()
        {
            int cotizacionID = 0;

            if (Session["cotizacionID"] != null)
                cotizacionID = (int)Session["cotizacionID"];

            return View(_CotizacionService.FindPresentacionTransCotizacionbyID(cotizacionID, Helper.GetUserData().UserId));
            //return View();
        }

        //public JsonResult SaveCuota(string prima, int cotizacionId)
        //{
        //    string mensaje = string.Empty;
        //    double nuevoPrima;

        //    if (double.TryParse(prima, out nuevoPrima))
        //    {
        //        _CotizacionService.SaveCotizacionTransporteCuota(nuevoPrima, cotizacionId);
        //        mensaje = MessagesValidation.Successful(Resources.Messages.successful_general).ToString();
        //    }
        //    else
        //        mensaje = MessagesValidation.Error(Resources.Messages.data_Error).ToString();


        //    return this.Json(mensaje, JsonRequestBehavior.AllowGet);
        //}

        #endregion

        #region Presentacion
        
        public ActionResult Presentacion()
        {
            int cotizacionID = 0;

            if (Session["cotizacionID"] != null)
                cotizacionID = (int)Session["cotizacionID"];

            //ViewBag.Modelo = ;
            return View(_CotizacionService.FindPresentacionCotizacionbyID(cotizacionID, Helper.GetUserData().UserId,false));
        }

        public ActionResult PresentacionRC()
        {
            int cotizacionID = 0;

            if (Session["cotizacionID"] != null)
                cotizacionID = (int)Session["cotizacionID"];

            //ViewBag.Modelo = ;
            return View(_CotizacionService.FindPresentacionCotizacionbyID(cotizacionID, Helper.GetUserData().UserId,true));
        }

        public JsonResult EjecutarIncendio()
        {
            string mensaje = string.Empty;
            int cotizacionID = 0;
            if (Session["cotizacionID"] != null)
            {
                cotizacionID = (int)Session["cotizacionID"];
                _CotizacionService.Cotizar(cotizacionID);
                mensaje = MessagesValidation.Successful(Resources.Messages.successful_general).ToString();
                return this.Json(mensaje, JsonRequestBehavior.AllowGet);
            }

            mensaje = MessagesValidation.Error(Resources.Messages.data_Error).ToString();
            return this.Json(mensaje, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DetailsReportPDF(int id)
        {
            if (Session["cotizacionID"] != null)
                return FillDetailsReport((int)Session["cotizacionID"], "PDF", _CotizacionService.FindPresentacionCotizacionbyID((int)Session["cotizacionID"], Helper.GetUserData().UserId, id == 1), id==1);

            return null;
        }

        public ActionResult DetailsReportExcel(int id)
        {
            if (Session["cotizacionID"] != null)
                return FillDetailsReport((int)Session["cotizacionID"], "Excel", _CotizacionService.FindPresentacionCotizacionbyID((int)Session["cotizacionID"], Helper.GetUserData().UserId, id == 1), id == 1);

            return null;
        }

        public ActionResult DetailsReportTransWord()
        {
            if (Session["cotizacionID"] != null)
                return FillDetailsReportTrans((int)Session["cotizacionID"], "Word", _CotizacionService.FindPresentacionTransCotizacionbyID((int)Session["cotizacionID"], Helper.GetUserData().UserId));

            return null;
        }

        public ActionResult DetailsReportTransPDF()
        {
            if (Session["cotizacionID"] != null)
                return FillDetailsReportTrans((int)Session["cotizacionID"], "PDF", _CotizacionService.FindPresentacionTransCotizacionbyID((int)Session["cotizacionID"], Helper.GetUserData().UserId));

            return null;
        }

        private FileContentResult FillDetailsReportTrans(int cotizacionID, string reportType, PresentacionTrans model)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/PresentacionTrans2.rdlc");
            localReport.DataSources.Clear();

            ReportDataSource rdc = new ReportDataSource("dsTransporte", model.Textos);
            ReportDataSource rdc1 = new ReportDataSource("dsCondiciones", model.Condiciones);
            
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
            return File(renderedBytes, mimeType);
        }

        private FileContentResult FillDetailsReport(int cotizacionID, string reportType, Presentacion model, bool isRC)
        {
            LocalReport localReport = new LocalReport();
            if (isRC)
                localReport.ReportPath = Server.MapPath("~/Reports/PresentacionCotizacionRC.rdlc");
            else
                localReport.ReportPath = Server.MapPath("~/Reports/PresentacionCotizacion.rdlc");
            localReport.DataSources.Clear();

            ReportDataSource rdc = new ReportDataSource("dsCabecera", model.DatosGenerales);
            ReportDataSource rdc1 = new ReportDataSource("dsPrima", model.Primas);
            ReportDataSource rdc2 = new ReportDataSource("dsResumen", model.Resumen);            
            ReportDataSource rdc4, rdc3;
            if (isRC)
            {
                rdc3 = new ReportDataSource("dsTexto", model.TextosRC);
                rdc4 = new ReportDataSource("dsCabeceraRC", model.DatosGeneralesRC);                
            }
            else
            {
                rdc3 = new ReportDataSource("dsTexto", model.Textos);
                rdc4 = new ReportDataSource("dsEquipo", model.Equipos);
            }                

            localReport.DataSources.Add(rdc);
            localReport.DataSources.Add(rdc1);
            localReport.DataSources.Add(rdc2);
            localReport.DataSources.Add(rdc3);
            localReport.DataSources.Add(rdc4);
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
            //Response.AddHeader(“content-disposition”, “attachment; filename=NorthWindCustomers.” + fileNameExtension);
            return File(renderedBytes, mimeType);
        }

        #endregion
        
        public ActionResult PresentacionUbicacion()
        {
            int cotizacionID = 0;

            if (Session["cotizacionID"] != null)
                cotizacionID = (int)Session["cotizacionID"];
                        
            return View(_CotizacionService.FindPresentacionUbicacionbyID(cotizacionID));
        }
        

        public ActionResult Resultado()
        {
            return View();
        }
    }
}