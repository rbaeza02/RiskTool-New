using Domain.Core;
using Domain.MainModule.Asegurados;
using Domain.MainModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.MainModule.Ubicaciones;
using Domain.MainModule.Catalogos;
using System.Transactions;
using Application.Integration.OFAC;
using Domain.MainModule.Entities.Util;
using Domain.MainModule.Personas;
using System.Xml;

namespace Application.MainModule.Asegurados
{
    public class AseguradoManagementService : IAseguradoManagementService
    {
        #region Constructor
        
        IAseguradoRepository _aseguradoRepository;
        IUbicacionRepository _ubicacionRepository;
        ICatalogoRepository _catalogoRepository;
        IPersonaRepository _personaRepository;

        public AseguradoManagementService(IAseguradoRepository aseguradoRepository,
            IUbicacionRepository ubicacionRepository, ICatalogoRepository catalogoRepository,
            IPersonaRepository personaRepository)
        {
            if (aseguradoRepository == (IAseguradoRepository)null)
                throw new ArgumentNullException("aseguradoRepository");

            if (ubicacionRepository == (IUbicacionRepository)null)
                throw new ArgumentNullException("ubicacionRepository");

            if (catalogoRepository == (ICatalogoRepository)null)
                throw new ArgumentNullException("catalogoRepository");

            if (personaRepository == (IPersonaRepository)null)
                throw new ArgumentNullException("personaRepository");

            _aseguradoRepository = aseguradoRepository;
            _ubicacionRepository = ubicacionRepository;
            _catalogoRepository = catalogoRepository;
            _personaRepository = personaRepository;
        }

        #endregion

        #region Asegurado

        public List<Asegurado> FindAseguradobyFiltro(string rfc, string razonSocial, string nombre, string apellido1, string apellido2)
        {
            FiltroSpecification filtroSpec = new FiltroSpecification(rfc, razonSocial, nombre, apellido1, apellido2);
            return _aseguradoRepository.FindAseguradobyFiltro(filtroSpec);
        }

        public Asegurado FindAseguradobyRFC(string rfc)
        {
            RFCSpecification rfcSpec = new RFCSpecification(rfc);
            return _aseguradoRepository.FindAsegurado(rfcSpec);             
        }

        public Asegurado FindwsAseguradobyRFC(string rfc, int usuarioID)
        {
            //Buscamos la base local
            RFCSpecification rfcSpec = new RFCSpecification(rfc);
            Asegurado localAsegurado = _aseguradoRepository.FindAsegurado(rfcSpec);

            //Buscamos en el servicio            
            Asegurado wsAsegurado;

            if (Convert.ToBoolean(_catalogoRepository.GetGlobalParam((int)globalParam.WSSiseAvailable)))
            {
                Integration.WsAsegurado ws = new Integration.WsAsegurado();
                wsAsegurado = ws.ConsultarAsegurado(rfc);
            }
            else
                wsAsegurado = null;

            if (wsAsegurado == null) //No lo encontró en el WS
                return localAsegurado;
            else //tenemos que actualizar los datos locales con lo que se encuentra en el WS
            {
                IUnitOfWork unitOfWork = _aseguradoRepository.UnitOfWork as IUnitOfWork;

                if (localAsegurado == null) //No lo encontró en el local         
                {
                    localAsegurado = new Asegurado(rfc);
                    localAsegurado.SIC = string.Empty;
                }

                localAsegurado.ColoniaID = _catalogoRepository.GetColoniabySISEid(Convert.ToInt32(wsAsegurado.Cod_colonia)).ColoniaID;
                localAsegurado.EstadoCivilID = _catalogoRepository.GetEstadoCivilbySISEid(Convert.ToInt32(wsAsegurado.Cod_est_civil)).EstadoCivilID;
                localAsegurado.TipoTelefonoID = _catalogoRepository.GetTipoTelefonobySISEid(Convert.ToInt32(wsAsegurado.Cod_tipo_telef)).TipoTelefonoID;
                localAsegurado.GeneroID = _catalogoRepository.GetGenerobySISEid(wsAsegurado.Cod_sexo).GeneroID;
                localAsegurado.TipoPersonaID = _catalogoRepository.GetTipoPersonabiSISEid(Convert.ToInt32(wsAsegurado.Cod_TipoPersona)).TipoPersonaID;
                localAsegurado.Apellido1 = wsAsegurado.Apellido1;
                localAsegurado.Apellido2 = wsAsegurado.Apellido2;
                localAsegurado.CodigoPostal = wsAsegurado.CodigoPostal;
                localAsegurado.CURP = wsAsegurado.CURP;
                localAsegurado.DomicilioFiscal_Calle = wsAsegurado.DomicilioFiscal_Calle;
                localAsegurado.DomicilioFiscal_NroExterior = wsAsegurado.DomicilioFiscal_NroExterior;
                localAsegurado.DomicilioFiscal_NroInterior = wsAsegurado.DomicilioFiscal_NroInterior;
                localAsegurado.FechaNacimiento = wsAsegurado.FechaNacimiento;
                localAsegurado.LugarNacimiento = wsAsegurado.LugarNacimiento;
                localAsegurado.Nombres = wsAsegurado.Nombres;
                localAsegurado.RazonSocial = wsAsegurado.RazonSocial;
                localAsegurado.RFC = wsAsegurado.RFC;                
                localAsegurado.Telefono = wsAsegurado.Telefono;
                localAsegurado.usuarioid = usuarioID;
                

                if(localAsegurado.AseguradoID == 0)
                {
                    localAsegurado.AseguradoID = _aseguradoRepository.LastAseguradoID() + 1;
                    _aseguradoRepository.Add(localAsegurado);
                }
                else
                    _aseguradoRepository.Modify(localAsegurado);

                unitOfWork.Commit();

                localAsegurado = FindAseguradobyID(localAsegurado.AseguradoID);

            }

            return localAsegurado;

        }

        public Asegurado FindAseguradobyID(int aseguradoID)
        {
            AseguradIDSpecification aseguradoSpec = new AseguradIDSpecification(aseguradoID);
            return _aseguradoRepository.FindAsegurado(aseguradoSpec);
        }

        public void SavewsAsegurado(Asegurado asegurado)
        {
            if (asegurado.TipoPersonaID == 2) //Moral
            {
                asegurado.Nombres = null;
                asegurado.Apellido1 = null;
                asegurado.Apellido2 = null;
            }
            else
                asegurado.RazonSocial = null;

            TransactionOptions txSettings = new TransactionOptions()
            {
                Timeout = TransactionManager.DefaultTimeout,
                IsolationLevel = IsolationLevel.Serializable // review this option
            };

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, txSettings))
            {
                IUnitOfWork unitOfWork = _aseguradoRepository.UnitOfWork as IUnitOfWork;
                IUnitOfWork ubicOfWork = _ubicacionRepository.UnitOfWork as IUnitOfWork;
                if (asegurado.AseguradoID == 0)
                {
                    asegurado.AseguradoID = _aseguradoRepository.LastAseguradoID() + 1;
                    _aseguradoRepository.Add(asegurado);
                }
                else
                    _aseguradoRepository.Modify(asegurado);

                if (_ubicacionRepository.LastNroUbicacion(asegurado.AseguradoID) == 0)
                {
                    //Crear una ubicacion por default con los datos del asegurado
                    Ubicacion ubic = new Ubicacion();
                    ubic.UbicacionID = _ubicacionRepository.LastUbicacionID() + 1;
                    ubic.AseguradoID = asegurado.AseguradoID;
                    ubic.CodigoPostal = asegurado.CodigoPostal;
                    ubic.Domicilio_Calle = asegurado.DomicilioFiscal_Calle;
                    ubic.Domicilio_NroExterior = asegurado.DomicilioFiscal_NroExterior;
                    ubic.Domicilio_NroInterior = asegurado.DomicilioFiscal_NroInterior;
                    ubic.ColoniaID = asegurado.ColoniaID;
                    ubic.SIC = asegurado.SIC;
                    ubic.nroPiso = 1;
                    ubic.nroSotano = 0;

                    ubic.TipoConstructivoIncendioID = _catalogoRepository.GetTipoConstructivoIncendioDefault(asegurado.SIC).Value;
                    ubic.TipoConstructivoTerremotoID = _catalogoRepository.GetTipoConstructivoTerremotoDefault(ubic.TipoConstructivoIncendioID).Value;

                    SelectCodigoPostalDatos_Result datosCP = _catalogoRepository.GetDatosCodigoPostal(ubic.CodigoPostal);
                    ubic.Latitud = datosCP.latitud;
                    ubic.Longitud = datosCP.longitud;
                    ubic.ZonaHidroID = datosCP.ZonaHidroID.Value;
                    ubic.ZonaTEVID = datosCP.ZonaTEVID.Value;
                    ubic.UbicacionCosta = datosCP.esCosta.Value;
                    ubic.añoConstruccion = asegurado.FechaNacimiento.Year;
                    ubic.nroUbicacion = 1;

                    _ubicacionRepository.Add(ubic);  
                }

                unitOfWork.CommitAndRefreshChanges();
                ubicOfWork.CommitAndRefreshChanges();

                //Commit the transaction
                scope.Complete();
            }

            asegurado = FindAseguradobyID(asegurado.AseguradoID);
            //Integration.WsAsegurado ws = new Integration.WsAsegurado();
            //string dato = ws.GrabarAsegurado(asegurado);
            
        }

        public List<string> GetDiferenciaAsegurado(int aseguradoID)
        {
            List<string> listErrores = new List<string>();

            //Base de Datos
            AseguradIDSpecification aseguradoSpec = new AseguradIDSpecification(aseguradoID);
            Asegurado ase = _aseguradoRepository.FindAsegurado(aseguradoSpec);

            //Web Services
            Integration.WsAsegurado ws = new Integration.WsAsegurado();
            
            Asegurado wsAsegurado = null;
            if (Convert.ToBoolean(_catalogoRepository.GetGlobalParam((int)globalParam.WSSiseAvailable)))
                wsAsegurado = ws.ConsultarAsegurado(ase.RFC);            

            if (wsAsegurado == null)
                listErrores.Add("Asegurado|" + ase.ErrorSISE() + "|" + ase.ErrorSISE());
            else
            {
                if (ase.NombreCompleto != wsAsegurado.NombreCompleto)
                    listErrores.Add("NombreCompleto|" + ase.NombreCompleto + "|" + wsAsegurado.NombreCompleto);

                if (ase.CURP != wsAsegurado.CURP)
                    listErrores.Add("CURP|" + ase.CURP + "|" + wsAsegurado.NombreCompleto);

                if (ase.FechaNacimiento != wsAsegurado.FechaNacimiento)
                    listErrores.Add("FechaNacimiento|" + ase.FechaNacimiento.ToString("dd/MM/yyyy") + "|" + wsAsegurado.FechaNacimiento.ToString("dd/MM/yyyy"));

                if (ase.DomicilioFiscal_Calle != wsAsegurado.DomicilioFiscal_Calle)
                    listErrores.Add("DomicilioFiscal_Calle|" + ase.DomicilioFiscal_Calle + "|" + wsAsegurado.DomicilioFiscal_Calle);

                if (ase.DomicilioFiscal_NroExterior != wsAsegurado.DomicilioFiscal_NroExterior)
                    listErrores.Add("DomicilioFiscal_NroExterior|" + ase.DomicilioFiscal_NroExterior + "|" + wsAsegurado.DomicilioFiscal_NroExterior);

                if (ase.DomicilioFiscal_NroInterior != wsAsegurado.DomicilioFiscal_NroInterior)
                    listErrores.Add("DomicilioFiscal_NroInterior|" + ase.DomicilioFiscal_NroInterior + "|" + wsAsegurado.DomicilioFiscal_NroInterior);

                if (ase.LugarNacimiento != wsAsegurado.LugarNacimiento)
                    listErrores.Add("LugarNacimiento|" + ase.LugarNacimiento + "|" + wsAsegurado.LugarNacimiento);

                if (ase.CodigoPostal != wsAsegurado.CodigoPostal)
                    listErrores.Add("CodigoPostal|" + ase.CodigoPostal + "|" + wsAsegurado.CodigoPostal);

                if (ase.SIC != wsAsegurado.SIC)
                    listErrores.Add("SIC|" + ase.SIC + "|" + wsAsegurado.SIC);
            }
            return listErrores;
        }

        #endregion

        #region Ubicaciones

        public List<Ubicacion> FindUbicaciones(int aseguradoID, string pagina, int tamaño)
        {
            int nroPagina;

            if (!Int32.TryParse(pagina, out nroPagina))
                nroPagina = 0;


            AseguradoIDSpecification ubicSpec = new AseguradoIDSpecification(aseguradoID);
            List<Ubicacion> ubicaciones = _ubicacionRepository.FindUbicaciones(ubicSpec, nroPagina, tamaño);
            ubicaciones.ForEach(x => {x.Mostrar = true; x.Eliminado=false;});
            return ubicaciones;
        }

        public List<Ubicacion> FindUbicacionbyNroUbic(int aseguradoID, int nroUbicacion)
        {
            AseguradoIDNroUbicacionSpecification ubicSpec = new AseguradoIDNroUbicacionSpecification(aseguradoID, nroUbicacion);
            List<Ubicacion> ubicaciones = _ubicacionRepository.FindUbicaciones(ubicSpec, 0, 1);
            ubicaciones.ForEach(x => { x.Mostrar = true; x.Eliminado = false; });
            return ubicaciones;
        }

        public void SaveUbicacion(List<Ubicacion> ubicaciones)
        {
            IUnitOfWork unitOfWork = _ubicacionRepository.UnitOfWork as IUnitOfWork;
            int i = 1;
            foreach(Ubicacion ubicacion in ubicaciones)
            {
                if (ubicacion.Mostrar) //Si se muestra en la pantalla
                    if (ubicacion.UbicacionID == 0 & !ubicacion.Eliminado) //Nuevo y no esta marcado como eliminado
                    {
                        ubicacion.UbicacionID = _ubicacionRepository.LastUbicacionID() + i;
                        ubicacion.nroUbicacion = _ubicacionRepository.LastNroUbicacion(ubicacion.AseguradoID) + i;
                        _ubicacionRepository.Add(ubicacion);
                        i++;
                    }
                    else
                        if (ubicacion.Eliminado && ubicacion.UbicacionID != 0)
                            _ubicacionRepository.Remove(ubicacion);
                        else
                            _ubicacionRepository.Modify(ubicacion);
            }
            
            unitOfWork.Commit();
        }

        public int TotalUbicaciones(int aseguradoID)
        {
            AseguradoIDSpecification ubicSpec = new AseguradoIDSpecification(aseguradoID);
            return _ubicacionRepository.TotalUbicaciones(ubicSpec);            
        }

        public List<Table> FindCatalogoUbicaciones(int cotizacionID)
        {
            return _ubicacionRepository.GetUbicacionesbyCotizacionID(cotizacionID);
        }

        #endregion

        #region OFAC

        public int BuscarOFAC(Asegurado asegurado)
        {
            if (Convert.ToBoolean(_catalogoRepository.GetGlobalParam((int)globalParam.OFACAvailable)))
            {
                OfacClient ofac = new OfacClient(_catalogoRepository.GetGlobalParam((int)globalParam.DSIK), _catalogoRepository.GetGlobalParam((int)globalParam.ServerOFAC));
                string request, response;
                int respuesta = ofac.SearchHitInquiry(asegurado.NombreCompleto, asegurado.RFC, asegurado.DomicilioFiscal_Calle + ' ' + asegurado.DomicilioFiscal_NroExterior, "Mexico", asegurado.CodigoPostal, "MX", out request, out response);

                if (respuesta == 0)
                    asegurado.isOFAC = false;

                if (respuesta >= 1)
                    asegurado.isOFAC = true;

                return respuesta;
            }
            else
            {
                asegurado.isOFAC = false;
                return 0;
            }

            //asegurado.isOFAC = true;
            //return 20;

        }

        #endregion

        #region Persona

        public Persona FindPersonabyRFC(string rfc)
        {
            Persona wsPersona;

            if (Convert.ToBoolean(_catalogoRepository.GetGlobalParam((int)globalParam.WSSiseAvailable)))
            {
                Integration.WsAsegurado ws = new Integration.WsAsegurado();
                wsPersona = ws.ConsultarPersona(rfc);
            }
            else
                wsPersona = null;

            if (wsPersona == null)
                return null;

            IUnitOfWork unitOfWork = _personaRepository.UnitOfWork as IUnitOfWork;

            Persona entPersona = _personaRepository.GetPersonabyRFC(rfc);
            if (entPersona == null)
            {
                wsPersona.PersonaID = _personaRepository.LastPersonaID() + 1;
                _personaRepository.Add(wsPersona);
            }
            else
            {
                entPersona.Nombres = wsPersona.Nombres;
                entPersona.Apellido1 = wsPersona.Apellido1;
                entPersona.Apellido2 = wsPersona.Apellido2;
                entPersona.RazonSocial = wsPersona.RazonSocial;
                entPersona.SISEcod_Aseg = wsPersona.SISEcod_Aseg;
                _personaRepository.Modify(entPersona);
            }

            unitOfWork.Commit();

            return wsPersona;

            //return new Persona() { RFC = "ABCD010101ABC", Nombres = "Prueba", Apellido1 = "Apellido 1", Apellido2 = "Apellido 2", PersonaID = 27 };

            
        }

        public void SavePersona(XmlDocument datos, int cotizacionID, int ubicacionID)
        {
            _personaRepository.execUpdateBeneficiarioCotizacion(datos.InnerXml, cotizacionID, ubicacionID);
        }

        public int GetNumberBenefbyCotizacion(int cotizacionID)
        {
            return _personaRepository.GetNumberBeneficiarios(cotizacionID);
        }
        #endregion
    }
}
