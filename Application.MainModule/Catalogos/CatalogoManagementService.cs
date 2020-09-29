using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.MainModule.Catalogos;
using Domain.MainModule.Entities;

namespace Application.MainModule.Catalogos
{
    public class CatalogoManagementService : ICatalogoManagementService
    {
        ICatalogoRepository _catalogRepository;

        public CatalogoManagementService(ICatalogoRepository catalogoRepository)
        {
            if (catalogoRepository == (ICatalogoRepository)null)
                throw new ArgumentNullException("CatalogoRepository");

            _catalogRepository = catalogoRepository;
        }

        public List<EstadoCivil> AllEstadoCiviles()
        {
            return _catalogRepository.GetEstadoCiviles();
        }

        public List<Moneda> AllMonedas()
        {
            return _catalogRepository.GetMonedas();
        }

        public List<FormaPago> AllFormaPagos()
        {
            return _catalogRepository.GetFormaPago();
        }

        public List<TipoTelefono> AllTipoTelefonos()
        {
            return _catalogRepository.GetTipoTelefonos();
        }

        public List<TipoPersona> AllTipoPersonas()
        {
            return _catalogRepository.GetTipoPersonas();
        }
        public List<Genero> AllGeneros()
        {
            return _catalogRepository.GetGeneros();
        }

        public List<Ciudad> GetCiudadbyCP(string cp)
        {
            return _catalogRepository.GetCiudadbyCP(cp);
        }
        public List<Colonia> GetColoniabyCP(string cp, int ciudadID)
        {
            return _catalogRepository.GetColoniabyCP(cp,ciudadID);
        }
        public Dictionary<int, string> GetPaisEstadoMunicipiobyCP(string cp)
        {
            return _catalogRepository.GetPaisEstadoMunicipio(cp);
        }

        public SelectCodigoPostalDatos_Result GetDatosCodigoPostalbyCP(string cp)
        {
            return _catalogRepository.GetDatosCodigoPostal(cp);
        }

        public List<ZonaHidro> AllZonaHidros()
        {
            return _catalogRepository.GetZonaHidro();
        }

        public List<ZonaTEV> AllZonaTEVs()
        {
            return _catalogRepository.GetZonaTEV();
        }

        public List<TipoConstructivoIncendio> AllTipoConstructivoIncendios()
        {
            return _catalogRepository.GetTipoConstructivoIncendio();
        }

        public List<TipoConstructivoTerremoto> AllTipoConstructivoTerremotos()
        {
            return _catalogRepository.GetTipoConstructivoTerremotos();
        }

        public List<SubLineaNegocio> GetSubLineaNegocios(int negocioID)
        {
            return _catalogRepository.GetSubLineaNegociobyID(negocioID);
        }

        public List<SubLineaNegocio> AllSubLineaNegociosPrimerRiesgo()
        {
            return _catalogRepository.GetSubLineaNegociobyPrimerRiesgo();
        }

        public List<TipoOperacion> AllTipoOperaciones()
        {
            return _catalogRepository.GetTipoOperaciones();
        }

        public List<TipoCobertura> AllTipoCoberturas()
        {
            return _catalogRepository.GetTipoCoberturas();
        }

        public List<TipoCobertura> AllTipoCoberturasPimerRiesgo()
        {
            return _catalogRepository.GetTipoCoberturasPrimerRiesgo();
        }

        public List<SICDivision> AllSICDivisiones()
        {
            return _catalogRepository.GetSICDivisiones();
        }

        public List<SICGrupo> GetSICGrupobySICDivisionID(int sicDivisionID)
        {
            return _catalogRepository.GetSICGruposbyDivisionID(sicDivisionID);
        }

        public List<SIC> GetSICbySICGroupID(int sicGroupID)
        {
            return _catalogRepository.GetSICbyGrupoID(sicGroupID);
        }

        public List<SICClassMap> GetSICDetallebySICID(string sicID)
        {
            return _catalogRepository.GetSICDetalladobySICID(sicID);
        }

        public SICClassMap GetSICDetalladobyID(int sICClassMapID)
        {
            return _catalogRepository.GetSICDetalladobyID(sICClassMapID);
        }

        public int GetTipoConsTerremotobyIndencioID(int tipoConstructivoIncendioID)
        {
            int? valor = _catalogRepository.GetTipoConstructivoTerremotoDefault(tipoConstructivoIncendioID);
            return valor.HasValue ? valor.Value : 0;
        }
    
        public int GetTipoConsIncendiobySIC(string sicID)
        {
            int? valor = _catalogRepository.GetTipoConstructivoIncendioDefault(sicID);
            return valor.HasValue ? valor.Value : 0;
        }

        public Colonia GetColonibyID(int coloniaID)
        {
            return _catalogRepository.GetColoniabyID(coloniaID);
        }

        public List<Sucursal> AllSucursales()
        {
            return _catalogRepository.GetSucursales();
        }

        public List<Agente> GetAgentebySucursalID(int sucursalID)
        {
            return _catalogRepository.GetAgentebySucursalID(sucursalID);
        }

        public List<Contacto> GetContactobyAgenteID(int agenteID)
        {
            return _catalogRepository.GetContactobyAgenteID(agenteID);
        }

        public List<GrupoIncendio> AllGrupoIncendios()
        {
            return _catalogRepository.GetGrupoIncendios().OrderBy(o => o.nombre).ToList();
        }

        public List<GradoExposicion> AllGradoExposiciones()
        {
            return _catalogRepository.GetGradoExposiciones();
        }

        public List<ProteccionPrivada> AllProteccionPrivadas()
        {
            return _catalogRepository.GetProteccionPrivadas();
        }

        public List<ProteccionPublica> AllProteccionPublicas()
        {
            return _catalogRepository.GetProteccionPublicas();
        }

        public List<Exposicion> AllExposiciones()
        {
            return _catalogRepository.GetExposiciones();
        }

        public List<Table> AllTableData(int table)
        {
            return _catalogRepository.GetTableData(table).OrderBy(o => o.Label).ToList();
        }

        public string GetGlobalParambyID(int ParametroGlobalID)
        {
            return _catalogRepository.GetGlobalParam(ParametroGlobalID);
        }

        public string GetDatobyID(int id, int table)
        {
            return _catalogRepository.getDatobyID(id, table);
        }

        public List<SelectPagina_Result> FindPagina(int cotizacionID)
        {
            return _catalogRepository.FinPagina(cotizacionID);
        }
        
    }
}
