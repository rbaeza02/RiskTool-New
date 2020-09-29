using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.MainModule.Entities;

namespace Application.MainModule.Catalogos
{
    public interface ICatalogoManagementService
    {
        List<EstadoCivil> AllEstadoCiviles();
        List<Moneda> AllMonedas();
        List<TipoTelefono> AllTipoTelefonos();
        List<TipoPersona> AllTipoPersonas();
        List<Genero> AllGeneros();
        List<Ciudad> GetCiudadbyCP(string cp);
        List<Colonia> GetColoniabyCP(string cp, int ciudadID);
        Dictionary<int, string> GetPaisEstadoMunicipiobyCP(string cp);
        List<ZonaHidro> AllZonaHidros();
        List<ZonaTEV> AllZonaTEVs();
        List<TipoConstructivoIncendio> AllTipoConstructivoIncendios();
        List<TipoConstructivoTerremoto> AllTipoConstructivoTerremotos();
        SelectCodigoPostalDatos_Result GetDatosCodigoPostalbyCP(string cp);
        List<SubLineaNegocio> GetSubLineaNegocios(int negocioID);
        List<FormaPago> AllFormaPagos();
        List<TipoOperacion> AllTipoOperaciones();
        List<TipoCobertura> AllTipoCoberturas();
        List<SICDivision> AllSICDivisiones();
        List<SICGrupo> GetSICGrupobySICDivisionID(int sicDivisionID);
        List<SIC> GetSICbySICGroupID(int sicGroupID);
        List<SICClassMap> GetSICDetallebySICID(string sicID);
        SICClassMap GetSICDetalladobyID(int sICClassMapID);
        int GetTipoConsTerremotobyIndencioID(int tipoConstructivoIncendioID);
        int GetTipoConsIncendiobySIC(string sicID);
        Colonia GetColonibyID(int coloniaID);
        List<Sucursal> AllSucursales();
        List<Agente> GetAgentebySucursalID(int sucursalID);
        List<Contacto> GetContactobyAgenteID(int agenteID);

        List<GrupoIncendio> AllGrupoIncendios();
        List<GradoExposicion> AllGradoExposiciones();
        List<ProteccionPrivada> AllProteccionPrivadas();
        List<ProteccionPublica> AllProteccionPublicas();
        List<Exposicion> AllExposiciones();
        List<SubLineaNegocio> AllSubLineaNegociosPrimerRiesgo();
        List<TipoCobertura> AllTipoCoberturasPimerRiesgo();

        List<Table> AllTableData(int table);

        string GetGlobalParambyID(int ParametroGlobalID);

        string GetDatobyID(int id, int table);
        List<SelectPagina_Result> FindPagina(int cotizacionID);
    }
}
