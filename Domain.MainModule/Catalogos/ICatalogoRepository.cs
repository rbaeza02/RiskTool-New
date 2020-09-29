using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core;
using Domain.MainModule.Entities;

namespace Domain.MainModule.Catalogos
{
    public interface ICatalogoRepository : IRepository<Moneda>
    {
        List<EstadoCivil> GetEstadoCiviles();
        List<Moneda> GetMonedas();
        List<TipoTelefono> GetTipoTelefonos();
        List<TipoPersona> GetTipoPersonas();
        List<Genero> GetGeneros();
        List<Pais> GetPaises(bool isAll);
        List<Ciudad> GetCiudadbyCP(string cp);
        List<Colonia> GetColoniabyCP(string cp, int ciudadID);
        Colonia GetColoniabyID(int coloniaID);
        Dictionary<int, string> GetPaisEstadoMunicipio(string cp);
        List<ZonaHidro> GetZonaHidro();
        List<ZonaTEV> GetZonaTEV();
        List<TipoConstructivoIncendio> GetTipoConstructivoIncendio();

        SelectCodigoPostalDatos_Result GetDatosCodigoPostal(string cp);

        Colonia GetColoniabySISEid(int siseID);
        EstadoCivil GetEstadoCivilbySISEid(int siseID);
        TipoTelefono GetTipoTelefonobySISEid(int siseID);
        Genero GetGenerobySISEid(string siseID);
        TipoPersona GetTipoPersonabiSISEid(int siseID);
        List<SubLineaNegocio> GetSubLineaNegociobyID(int negocioID);
        List<SubLineaNegocio> GetSubLineaNegociobyLimit();

        List<FormaPago> GetFormaPago();
        List<TipoOperacion> GetTipoOperaciones();
        List<TipoCobertura> GetTipoCoberturas();
        List<SICDivision> GetSICDivisiones();
        List<SICGrupo> GetSICGruposbyDivisionID(int sicDivisionID);
        List<SIC> GetSICbyGrupoID(int sicGrupoID);
        List<SICClassMap> GetSICDetalladobySICID(string sicID);
        SICClassMap GetSICDetalladobyID(int SICClassMapID);
        List<TipoConstructivoTerremoto> GetTipoConstructivoTerremotos();        
        int? GetTipoConstructivoTerremotoDefault(int tipoConstructivoIncendioID);
        int? GetTipoConstructivoIncendioDefault(string sicID);

        List<Sucursal> GetSucursales();
        List<Agente> GetAgentebySucursalID(int sucursalID);
        List<Contacto> GetContactobyAgenteID(int agenteID);

        List<GrupoIncendio> GetGrupoIncendios();
        List<GradoExposicion> GetGradoExposiciones();
        List<ProteccionPrivada> GetProteccionPrivadas();
        List<ProteccionPublica> GetProteccionPublicas();
        List<Exposicion> GetExposiciones();

        List<SubLineaNegocio> GetSubLineaNegociobyPrimerRiesgo();
        List<TipoCobertura> GetTipoCoberturasPrimerRiesgo();

        List<Table> GetTableData(int table);

        string getDatobyID(int id, int table);

        List<TransCondicion> GetCondicionesTrans();

        List<SelectPagina_Result> FinPagina(int cotizacionID);
        string GetGlobalParam(int ParametroGlobalID);

        string GetNombreBanco(int? cod_banco, int? bancoID);
        string GetNombreConducto(int? cod_conducto, int? conductoID);
    }
}
