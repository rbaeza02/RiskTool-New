using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.MainModule.Catalogos;
using Domain.MainModule.Entities;
using Application.MainModule.Asegurados;
using System.Text.RegularExpressions;
using MVC.Client.Resources;
using MVC.Client.Extension.Messages;
using MVC.Client.Extensions.Utilities;
using MVC.Client.Extensions.ActionFilters;
using MVC.Client.Extension.Utilities;
using Application.Integration;
using Newtonsoft.Json;
using Domain.MainModule.Asegurados;
using System.Xml.Serialization;
using System.IO;
using Application.Integration.wsConsultaPersona;

namespace MVC.Client.Controllers
{
    [Authorize]
    [CustomAuthorize]
    [HandleCustomError]
    public class AseguradoController : Controller
    {
        #region constructor
        
        private ICatalogoManagementService _CatalogoService;
        private IAseguradoManagementService _AseguradoService;

        public AseguradoController(ICatalogoManagementService catalogoService, IAseguradoManagementService aseguradoService)
        {
            _CatalogoService = catalogoService;
            _AseguradoService = aseguradoService;
        }

        #endregion

        #region Asegurado
        
        public ActionResult Index(string id, string rfc)
        {
            ViewBag.SICDivisionList = _CatalogoService.AllSICDivisiones();

            if (string.IsNullOrEmpty(id) && string.IsNullOrEmpty(rfc))
                id = Session["AseguradoID"].ToString();

            int i;
            if(int.TryParse(id,out i))
            {
                Asegurado asegurado;

                if( i == 0 && rfc == null)
                    return RedirectToAction("List");

                if (i == 0 && (rfc.Length == 13 || rfc.Length == 12))
                    asegurado = new Asegurado(rfc.ToUpper());
                else
                {
                    asegurado = _AseguradoService.FindAseguradobyID(i);
                    Session["AseguradoID"] = i;
                }

                if (asegurado == null)
                    return View();

                asegurado.TipoPersonaList = new SelectList(_CatalogoService.AllTipoPersonas(), "TipoPersonaID", "Descripcion");
                asegurado.GeneroList = new SelectList(_CatalogoService.AllGeneros(), "GeneroID", "nombre");
                asegurado.EstadoCivilList = new SelectList(_CatalogoService.AllEstadoCiviles(), "EstadoCivilID", "Descripcion");
                asegurado.TipoTelefonoList = new SelectList(_CatalogoService.AllTipoTelefonos(), "TipoTelefonoID", "Descripcion");
                ViewBag.OFAC = MessagesValidation.Error(asegurado.ErrorOFAC());

                return View(asegurado);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(Asegurado asegurado, string colonia)
        {
            asegurado.TipoPersonaList = new SelectList(_CatalogoService.AllTipoPersonas(), "TipoPersonaID", "Descripcion");
            asegurado.GeneroList = new SelectList(_CatalogoService.AllGeneros(), "GeneroID", "nombre");
            asegurado.EstadoCivilList = new SelectList(_CatalogoService.AllEstadoCiviles(), "EstadoCivilID", "Descripcion");
            asegurado.TipoTelefonoList = new SelectList(_CatalogoService.AllTipoTelefonos(), "TipoTelefonoID", "Descripcion");
            ViewBag.SICDivisionList = _CatalogoService.AllSICDivisiones();
            ViewBag.OFAC = MessagesValidation.Error(asegurado.ErrorOFAC());

            int coloniaID;
            if (!Int32.TryParse(colonia, out coloniaID))
            {
                ModelState.Remove("ColoniaID");
                ModelState.AddModelError("ColoniaID", "La Colonia es requerida");
            }

            int ofac = _AseguradoService.BuscarOFAC(asegurado);

            if (ofac == 1)
            {
                ModelState.Remove("AseguradoID");
                ModelState.AddModelError("AseguradoID", "OFAC!!!");
            }
            if (ofac == -1)
            {
                ModelState.Remove("AseguradoID");
                ModelState.AddModelError("AseguradoID", "ERROR OFAC!!!");
            }

            

            if (ModelState.IsValid)
            {
                asegurado.usuarioid = Helper.GetUserData().UserId; 
                asegurado.ColoniaID = coloniaID;
                _AseguradoService.SavewsAsegurado(asegurado);
                Session["AseguradoID"] = asegurado.AseguradoID;

                ViewBag.Mensaje = Resources.Messages.successful_general;
            }

            return View(asegurado);
        }

        public JsonResult GetAsegurado(string rfc, string razonSocial)
        {
            string id = string.Empty, mensaje = string.Empty;

            Regex regex = new Regex(@"^([A-ZÑ\x26]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1])[A-Z|\d]{3})$");
            Match match = regex.Match(rfc.ToUpper());
            if (!match.Success)
                mensaje = MessagesValidation.Error(Messages.dataFormat_Error).ToString();

            if (string.IsNullOrEmpty(mensaje))
            {
                Asegurado a = _AseguradoService.FindwsAseguradobyRFC(rfc, Helper.GetUserData().UserId);
                if (a == null)
                    id = "0";
                else
                    id = a.AseguradoID.ToString();
            }

            Session["AseguradoID"] = id;

            return this.Json(new { id = id, error = mensaje }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscarCP(string cp, string dato)
        {
            Dictionary<int, string> datos = _CatalogoService.GetPaisEstadoMunicipiobyCP(cp);
            string pais = datos[3];
            string estado = datos[2];
            string municipio = datos[1];

            SelectList ciudades = new SelectList(_CatalogoService.GetCiudadbyCP(cp), "CiudadID", "Descripcion");

            return this.Json(new { Pais = pais, Estado = estado, Municipio = municipio, Ciudades = ciudades, Dato = dato }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscarColonia(string cp, string ciudadID)
        {
            if (string.IsNullOrEmpty(ciudadID))
                return this.Json(null, JsonRequestBehavior.AllowGet);
            else
                return this.Json(new SelectList(_CatalogoService.GetColoniabyCP(cp, Convert.ToInt32(ciudadID)), "ColoniaID", "Descripcion"), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region List
        public ActionResult List()
        {
            ViewBag.TipoPersonaList = new SelectList(_CatalogoService.AllTipoPersonas(), "TipoPersonaID", "Descripcion");
            return View();
        }

        public JsonResult GetListAsegurados(string rfc, string razonSocial, string nombre, string apellido1, string apellido2)
        {
            string mensaje = string.Empty;
            string datos = string.Empty;

            if (string.IsNullOrEmpty(rfc) && string.IsNullOrEmpty(razonSocial) && string.IsNullOrEmpty(nombre) && string.IsNullOrEmpty(apellido1) && string.IsNullOrEmpty(apellido2))
                mensaje = Resources.Messages.EmptyFilter_error;

            if (string.IsNullOrEmpty(mensaje))
            {
                //old
                //List<Asegurado> cot = _AseguradoService.FindAseguradobyFiltro(rfc, razonSocial, nombre, apellido1, apellido2);
                //datos = Render.RenderRazorViewToString(this, "Templates/ListaAsegurados", _AseguradoService.FindAseguradobyFiltro(rfc, razonSocial, nombre, apellido1, apellido2));

                //200928 - rbaeza - test
                var datosAseguradoWS = WsConsultaPersona.datosAseguradoWS(rfc);
                List<Asegurado> datosAsegurado = new List<Asegurado>();
                //Comparación de datos provenientes del servicio vs los datos de la BD
                if (datosAseguradoWS.PerCod > 0)
                {
                    datosAsegurado.Add(new Asegurado
                        {
                            Nombres = datosAseguradoWS.Asegurado[0].AseNom.ToString(),
                            Apellido1 = datosAseguradoWS.Asegurado[0].AseNomEx.ToString(),
                            Apellido2 = datosAseguradoWS.Asegurado[0].AseNomEx2.ToString(),
                            AseguradoID = datosAseguradoWS.Asegurado[0].AseCod,//Revisar a qué se refiere el campo AseCod
                            CURP = "",//Pendiente por revisar ya que no hay un campo explícito para el CURP en la respuesta del ws
                            TipoPersonaID = Int32.Parse(datosAseguradoWS.PerTipPer.ToString()),//Revisar a qué se refiere el campo PerTipPer
                            CodigoPostal = datosAseguradoWS.Direccion[0].PerLocaliMex[0].ToString(), //revisar si el código postal siempre viene separado por coma al final del campo PerLocaliMex
                            Cod_colonia = datosAseguradoWS.Direccion[0].PerDomici[0].ToString(),
                            RFC = datosAseguradoWS.RFC.ToString(),
                            RazonSocial = datosAseguradoWS.PerNom.ToString()//,
                            //SIC = //Revisar qué es?
                    }
                    ); 
                }
                else
                {
                    //Busca datos en BD
                    datosAsegurado = _AseguradoService.FindAseguradobyFiltro(rfc, razonSocial, nombre, apellido1, apellido2);
                }

                datos = Render.RenderRazorViewToString(this, "Templates/ListaAsegurados", datosAsegurado);

                
            }
            else
                mensaje = MessagesValidation.Error(mensaje).ToString();

            return this.Json(new { datos = datos, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RedirectNewCotizacion(string rfc)
        {
            Session["cotizacionID"] = null;

            return RedirectToAction("Crear", "Cotizar", new { rfc = rfc });
        }

        #endregion

        #region Ubicacion

        private void fill(List<Ubicacion> ubicaciones, int aseguradID, string pagina)
        {
            ViewBag.AseguradoID = aseguradID;
            int nroPagina;

            if (!Int32.TryParse(pagina, out nroPagina))
                nroPagina = 0;

            Dictionary<int, string> datos;
            ViewBag.TotalGrupos = Math.Ceiling(_AseguradoService.TotalUbicaciones(aseguradID)/3.0);
            ViewBag.Pagina = nroPagina;
            //int ciudadID;
            //var selected;

            foreach (Ubicacion ubicacion in ubicaciones)
            {
                datos = _CatalogoService.GetPaisEstadoMunicipiobyCP(ubicacion.CodigoPostal);
                ubicacion.Pais = datos[3];
                ubicacion.Estado = datos[2];
                ubicacion.Municipio = datos[1];
                ubicacion.CiudadList = new SelectList(_CatalogoService.GetCiudadbyCP(ubicacion.CodigoPostal), "CiudadID", "Descripcion");

                if (ubicacion.ColoniaID == 0)
                    ubicacion.ColoniaList = new SelectList(new List<Colonia>());
                else
                {
                    if (ubicacion.bk_tc_Colonia == null)
                        ubicacion.CiudadID = _CatalogoService.GetColonibyID(ubicacion.ColoniaID).CiudadID.Value;
                    else
                        ubicacion.CiudadID = ubicacion.bk_tc_Colonia.CiudadID.Value;

                    ubicacion.ColoniaList = new SelectList(_CatalogoService.GetColoniabyCP(ubicacion.CodigoPostal, ubicacion.CiudadID), "ColoniaID", "Descripcion");
                }

                //ubicacion.Eliminado = false;
                //ubicacion.Mostrar = true;
            }

            if (ubicaciones.Count < 3)
            {
                for (int i = ubicaciones.Count; i < 3; i++)
                    ubicaciones.Add(new Ubicacion() { 
                        Eliminado = false, Mostrar = false, AseguradoID = aseguradID, ColoniaList = new SelectList(new List<Colonia>()),
                        nroPiso = 1, nroSotano = 0
                    });
            }
        }

        public ActionResult Ubicacion(string pagina, string nro, string aseguradoIDs)
        {
            int comprobacion;
            if (aseguradoIDs != "")            
                if (int.TryParse(aseguradoIDs,out comprobacion))
                    if (comprobacion > 0)
                        Session["AseguradoID"] = comprobacion;
            


            int aseguradoID;
            int nroUbicacion;

            ViewBag.TipoConstIncendioList = new SelectList(_CatalogoService.AllTipoConstructivoIncendios(), "TipoConstructivoIncendioID", "Descripcion");
            ViewBag.TipoConstTerremotoList = new SelectList(_CatalogoService.AllTipoConstructivoTerremotos(), "TipoConstructivoTerremotoID", "NombreCompleto");
            ViewBag.ZonaHidroList = new SelectList(_CatalogoService.AllZonaHidros(), "ZonaHidroID", "nombre");
            ViewBag.ZonaTEVList = new SelectList(_CatalogoService.AllZonaTEVs(), "ZonaTEVID", "nombre");
            ViewBag.SICDivisionList = _CatalogoService.AllSICDivisiones();
            ViewBag.Error = false;
            ViewBag.NroRegistros = 0;

            //string id = Session["AseguradoID"];

            //if (Int32.TryParse(id, out aseguradoID))
            if (Session["AseguradoID"] != null)
            {
                aseguradoID = Convert.ToInt16(Session["AseguradoID"]); // (int)Session["AseguradoID"];
                List<Ubicacion> lista;

                if (Int32.TryParse(nro, out nroUbicacion))
                    lista = _AseguradoService.FindUbicacionbyNroUbic(aseguradoID, nroUbicacion);
                else
                    lista = _AseguradoService.FindUbicaciones(aseguradoID, pagina, 3);

                fill(lista, aseguradoID, pagina);

                ViewBag.NroRegistros = lista.Where(p => p.Mostrar).ToList().Count;

                return View(lista);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Ubicacion(List<Ubicacion> ubicaciones, string pagina)
        {
            ViewBag.TipoConstIncendioList = new SelectList(_CatalogoService.AllTipoConstructivoIncendios(), "TipoConstructivoIncendioID", "Descripcion");
            ViewBag.TipoConstTerremotoList = new SelectList(_CatalogoService.AllTipoConstructivoTerremotos(), "TipoConstructivoTerremotoID", "NombreCompleto");
            ViewBag.ZonaHidroList = new SelectList(_CatalogoService.AllZonaHidros(), "ZonaHidroID", "nombre");
            ViewBag.ZonaTEVList = new SelectList(_CatalogoService.AllZonaTEVs(), "ZonaTEVID", "nombre");
            ViewBag.SICDivisionList = _CatalogoService.AllSICDivisiones();
            //ViewBag.NroRegistros = lista.Where(p => p.AseguradoID != 0).ToList().Count;

            //Eliminamos los errores de los que no grabaremos
            int i = 0;
            foreach(Ubicacion ubicacion in ubicaciones)
            {
                if (ubicacion.Eliminado || !ubicacion.Mostrar)
                {
                    ModelState.Remove("[" + i.ToString() + "].nroUbicacion");
                    ModelState.Remove("[" + i.ToString() + "].CodigoPostal");
                    ModelState.Remove("[" + i.ToString() + "].Domicilio_Calle");
                    ModelState.Remove("[" + i.ToString() + "].Domicilio_NroExterior");
                    ModelState.Remove("[" + i.ToString() + "].ColoniaID");
                    ModelState.Remove("[" + i.ToString() + "].Latitud");
                    ModelState.Remove("[" + i.ToString() + "].Longitud");
                    ModelState.Remove("[" + i.ToString() + "].TipoConstructivoIncendioID");
                    ModelState.Remove("[" + i.ToString() + "].TipoConstructivoTerremotoID");
                    ModelState.Remove("[" + i.ToString() + "].ZonaTEVID");
                    ModelState.Remove("[" + i.ToString() + "].ZonaHidroID");
                    ModelState.Remove("[" + i.ToString() + "].nroPiso");
                    ModelState.Remove("[" + i.ToString() + "].nroSotano");
                    ModelState.Remove("[" + i.ToString() + "].añoConstruccion");
                    ModelState.Remove("[" + i.ToString() + "].SIC");
                    ModelState.Remove("[" + i.ToString() + "].UbicacionCosta");
                    ModelState.Remove("[" + i.ToString() + "].AnalisisFire");
                }

                i++;
            }
            
            if (ModelState.IsValid)
            {
                ViewBag.Error = false;
                _AseguradoService.SaveUbicacion(ubicaciones);

                List<Ubicacion> lista = _AseguradoService.FindUbicaciones(ubicaciones[0].AseguradoID, pagina, 3);
                fill(lista, ubicaciones[0].AseguradoID, pagina);

                ViewBag.NroRegistros = ubicaciones.Where(p => p.Mostrar).ToList().Count;

                ViewBag.Mensaje = Resources.Messages.successful_general;
                return View(lista);
            }
            else
            {
                fill(ubicaciones, ubicaciones[0].AseguradoID, pagina);
                ViewBag.Error = true;
            }

            ViewBag.NroRegistros = ubicaciones.Where(p => p.Mostrar).ToList().Count;

            return View(ubicaciones);
        }


        public JsonResult GetDatosCP(string cp, string dato)
        {
            return this.Json(new { Dato = dato, Info = _CatalogoService.GetDatosCodigoPostalbyCP(cp) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTipoConsTerremoto(int tipoConsIncendioID)
        {
            return this.Json(_CatalogoService.GetTipoConsTerremotobyIndencioID(tipoConsIncendioID) , JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTipoConsIncendio(string sic)
        {
            return this.Json(_CatalogoService.GetTipoConsIncendiobySIC(sic), JsonRequestBehavior.AllowGet);
        }

        #endregion
        
        public JsonResult GetGrupoToSelection(int divisionID)
        {
            return this.Json(new SelectList(_CatalogoService.GetSICGrupobySICDivisionID(divisionID), "SICGrupoID", "nombre"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSICToSelection(int grupoID)
        {
            return this.Json(new SelectList(_CatalogoService.GetSICbySICGroupID(grupoID), "SISECod_giro_negocio", "NombreCompleto"), JsonRequestBehavior.AllowGet);
        }
        
    }
}