using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.MainModule.Entities;
using Infrastructure.CrossCutting.Logging;
using Infrastructure.Data.Core;
using Infrastructure.Data.MainModule.Resources;
using Infrastructure.Data.MainModule.UnitOfWork;
using Domain.MainModule.Catalogos;
using Infrastructure.Data.Core.Extensions;
using Domain.MainModule.Entities.Util;

namespace Infrastructure.Data.MainModule.Repositories
{
    public class CatalogoRepository : Repository<Moneda>, ICatalogoRepository
    {
        public CatalogoRepository(IMainModuleUnitOfWork unitOfWork, ITraceManager traceManager) : base(unitOfWork, traceManager) { }

        public List<EstadoCivil> GetEstadoCiviles()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.EstadoCiviles.OrderBy(x => x.Descripcion).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public EstadoCivil GetEstadoCivilbySISEid(int siseID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.EstadoCiviles.Where(p => p.SISEcod_est_civil == siseID).FirstOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<Moneda> GetMonedas()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Monedas.OrderBy(x => x.nombre).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<TipoTelefono> GetTipoTelefonos()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.TipoTelefonos.OrderBy(x => x.Descripcion).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }
        public TipoTelefono GetTipoTelefonobySISEid(int siseID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.TipoTelefonos.Where(p => p.SISEcod_tipo_telef == siseID).FirstOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<TipoPersona> GetTipoPersonas()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.TipoPersonas.OrderByDescending(x => x.Descripcion).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public TipoPersona GetTipoPersonabiSISEid(int siseID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.TipoPersonas.Where(p => p.SISEcod_TipoPersona == siseID).FirstOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<Genero> GetGeneros()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Generos.OrderBy(x => x.nombre).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<Pais> GetPaises(bool isAll)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                if (isAll)
                    return activeContext.Paises.OrderBy(x => x.Descripcion).ToList();
                else
                    return activeContext.Paises.Where(x => x.modifier.HasValue).OrderBy(x => x.Descripcion).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public Genero GetGenerobySISEid(string siseID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Generos.Where(p => p.SISEcod_sexo == siseID).FirstOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<Ciudad> GetCiudadbyCP(string cp)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Ciudades.Where( x => x.bk_tc_Colonia.Any(y => y.CodigoPostal == cp)).OrderBy(x => x.Descripcion).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<Colonia> GetColoniabyCP(string cp, int ciudadID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Colonias.Where(y => y.CodigoPostal == cp && y.CiudadID == ciudadID).OrderBy(x => x.Descripcion).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public Colonia GetColoniabyID(int coloniaID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Colonias.Where(y => y.ColoniaID == coloniaID).FirstOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public Colonia GetColoniabySISEid(int siseID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Colonias.Where(y => y.SISEcod_colonia == siseID).FirstOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public Dictionary<int,string> GetPaisEstadoMunicipio(string cp)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                Dictionary<int, string> valores = new Dictionary<int, string>();
                Municipio m = activeContext.Municipios.Where(x => x.bk_tc_Colonia.Any(y => y.CodigoPostal == cp)).GroupBy(v => v.Descripcion).Select(group => group.FirstOrDefault()).FirstOrDefault();
                if (m != null)
                {
                    Estado e = activeContext.Estados.Where(x => x.EstadoID == m.EstadoID).FirstOrDefault();
                    Pais p = activeContext.Paises.Where(x => x.PaisID == e.PaisID).FirstOrDefault();

                    valores.Add(1, m.Descripcion);
                    valores.Add(2, e.Descripcion);
                    valores.Add(3, p.Descripcion);
                }
                else
                {
                    valores.Add(1, string.Empty);
                    valores.Add(2, string.Empty);
                    valores.Add(3, string.Empty);
                }

                return valores;
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<ZonaHidro> GetZonaHidro()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.ZonaHidros.OrderBy(x => x.nombre).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<ZonaTEV> GetZonaTEV()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.ZonaTEVs.OrderBy(x => x.nombre).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<TipoConstructivoIncendio> GetTipoConstructivoIncendio()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.TipoConstructivoIncendios.OrderBy(x => x.Descripcion).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public SelectCodigoPostalDatos_Result GetDatosCodigoPostal(string cp)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.SelectCodigoPostalDatos(cp).FirstOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<SubLineaNegocio> GetSubLineaNegociobyID(int negocioID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.SubLineaNegocios.Where(p => p.LineaNegocioID == negocioID && p.isActivo).OrderBy(x => x.nombre).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<SubLineaNegocio> GetSubLineaNegociobyPrimerRiesgo()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.SubLineaNegocios.Where(p => p.isPrimerRiesgo).OrderBy(x => x.ordenPantalla).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<SubLineaNegocio> GetSubLineaNegociobyLimit()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.SubLineaNegocios.Where(p => p.isLimit).OrderBy(x => x.ordenPresentacion).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<FormaPago> GetFormaPago()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.FormaPagos.ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<TipoOperacion> GetTipoOperaciones()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.TipoOperaciones.ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<TipoCobertura> GetTipoCoberturas()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.TipoCoberturas.Include(j => j.bk_tc_Cobertura).OrderBy(x => x.nombre).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<TipoCobertura> GetTipoCoberturasPrimerRiesgo()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.TipoCoberturas.Where(x => x.isPrimerRiesgo).OrderBy(x => x.nombrePrimerRiesgo).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<SICDivision> GetSICDivisiones()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.SICDivisiones.OrderBy(x => x.nombre).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<SICGrupo> GetSICGruposbyDivisionID(int sicDivisionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.SICGrupos.Where(x => x.SICDivisionID == sicDivisionID).OrderBy(x => x.nombre).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<SIC> GetSICbyGrupoID(int sicGrupoID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.SICs.Where(x => x.SICGrupoID == sicGrupoID).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<SICClassMap> GetSICDetalladobySICID(string sicID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //return activeContext.ExecuteQuery<Table>("select SICClassMapID Value, Codigo + ' ' + nombreING Label from bk_tc_SICClassMap where SICid = " + sicID.ToString(), null).ToList();
                return activeContext.SICClassMaps.Where(x => x.bk_tc_SIC.SISECod_giro_negocio == sicID).OrderBy(x => x.Codigo).ThenBy(x => x.nombreING).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public SICClassMap GetSICDetalladobyID(int SICClassMapID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //return activeContext.ExecuteQuery<Table>("select SICClassMapID Value, Codigo + ' ' + nombreING Label from bk_tc_SICClassMap where SICid = " + sicID.ToString(), null).ToList();
                return activeContext.SICClassMaps.Where(x => x.SICClassMapID == SICClassMapID)
                    .Include(x => x.bk_tc_SIC)
                    .FirstOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<TipoConstructivoTerremoto> GetTipoConstructivoTerremotos()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.TipoConstructivoTerremotos.OrderBy(x => x.Descripcion).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int? GetTipoConstructivoTerremotoDefault(int tipoConstructivoIncendioID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.TipoConstructivoIncendios.Where(x=> x.TipoConstructivoIncendioID == tipoConstructivoIncendioID).Select(x => x.TipoConstructivoTerremotoIDDefault).FirstOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int? GetTipoConstructivoIncendioDefault(string sicID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.SICs.Where(x => x.SISECod_giro_negocio == sicID).Select(x => x.TipoConstructivoIncendioIDDefault).FirstOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<Sucursal> GetSucursales()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Sucursales.OrderBy(x => x.nombre).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<Agente> GetAgentebySucursalID(int sucursalID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Agentes.Where(x => x.SucursalID == sucursalID).OrderBy(x => x.nombre).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<Contacto> GetContactobyAgenteID(int agenteID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Contactos.Where(x => x.AgenteID == agenteID).OrderBy(x=> x.Apellido1).ThenBy(x => x.Apellido2).ThenBy(x => x.Nombre).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<GrupoIncendio> GetGrupoIncendios()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.GrupoIncendios.OrderBy(x => x.nombre).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<GradoExposicion> GetGradoExposiciones()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.GradoExposiciones.ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<ProteccionPrivada> GetProteccionPrivadas()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.ProteccionPrivadas.OrderBy(x => x.nombre).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<ProteccionPublica> GetProteccionPublicas()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.ProteccionPublicas.OrderBy(x => x.nombre).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<Exposicion> GetExposiciones()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Exposiciones.OrderBy(x => x.nombre).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<Table> GetTableData(int table)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {                
                switch(table)
                {
                    case (int)enumTable.CristalesExp:
                        return activeContext.ExecuteQuery<Table>("select CristalesExpID Value, nombre Label from Cotizar.bk_tw_CristalesExp", null).ToList();
                    case (int)enumTable.RoboAlarma:
                        return activeContext.ExecuteQuery<Table>("select RoboAlarmaID Value, nombre Label from Cotizar.bk_tw_RoboAlarma", null).ToList();
                    case (int)enumTable.RoboCircuito:
                        return activeContext.ExecuteQuery<Table>("select RoboCircuitoID Value, nombre Label from Cotizar.bk_tw_RoboCircuito", null).ToList();
                    case (int)enumTable.RoboPolicia:
                        return activeContext.ExecuteQuery<Table>("select RoboPoliciaID Value, nombre Label from Cotizar.bk_tw_RoboPolicia", null).ToList();
                    case (int)enumTable.RoboGiro:
                        return activeContext.ExecuteQuery<Table>("select RoboGiroID Value, nombre Label from Cotizar.bk_tw_RoboGiro", null).ToList();
                    case (int)enumTable.DinValCilindro:
                        return activeContext.ExecuteQuery<Table>("select DinValCilindroID Value, nombre Label from Cotizar.bk_tw_DinValCilindro", null).ToList();
                    case (int)enumTable.DinValTipoAlarma:
                        return activeContext.ExecuteQuery<Table>("select DinValTipoAlarmaID Value, nombre Label from Cotizar.bk_tw_DinValTipoAlarma", null).ToList();
                    case (int)enumTable.DinValPolicia:
                        return activeContext.ExecuteQuery<Table>("select DinValPoliciaID Value, nombre Label from Cotizar.bk_tw_DinValPolicia", null).ToList();
                    case (int)enumTable.DinValGiro:
                        return activeContext.ExecuteQuery<Table>("select DinValGiroID Value, nombre Label from Cotizar.bk_tw_DinValGiro", null).ToList();
                    case (int)enumTable.CalderaMant:
                        return activeContext.ExecuteQuery<Table>("select CalderaMantID Value, nombre Label from Cotizar.bk_tw_CalderaMant", null).ToList();
                    case (int)enumTable.CalderaTipoProc:
                        return activeContext.ExecuteQuery<Table>("select CalderaTipoProcID Value, nombre Label from Cotizar.bk_tw_CalderaTipoProc", null).ToList();
                    case (int)enumTable.CalderaPCEqRva:
                        return activeContext.ExecuteQuery<Table>("select CalderaPCEqRvaID Value, nombre Label from Cotizar.bk_tw_CalderaPCEqRva", null).ToList();
                    case (int)enumTable.CalderaPCRefCriticas:
                        return activeContext.ExecuteQuery<Table>("select CalderaPCRefCriticasID Value, nombre Label from Cotizar.bk_tw_CalderaPCRefCriticas", null).ToList();
                    case (int)enumTable.CalderaPCDeducible:
                        return activeContext.ExecuteQuery<Table>("select CalderaPCDeducibleID Value, nombre Label from Cotizar.bk_tw_CalderaPCDeducible", null).ToList();
                    case (int)enumTable.CalderaPCPeriodo:
                        return activeContext.ExecuteQuery<Table>("select CalderaPCPeriodoID Value, nombre Label from Cotizar.bk_tw_CalderaPCPeriodo", null).ToList();                    
                    case (int)enumTable.RotMaqMant:
                        return activeContext.ExecuteQuery<Table>("select RotMaqMantID Value, nombre Label from Cotizar.bk_tw_RotMaqMant", null).ToList();
                    case (int)enumTable.RotMaqGiro:
                        return activeContext.ExecuteQuery<Table>("select RotMaqGiroID Value, nombre Label from Cotizar.bk_tw_RotMaqGiro", null).ToList();                    
                    case (int)enumTable.RotMaqPCEqRpto:
                        return activeContext.ExecuteQuery<Table>("select RotMaqPCEqRptoID Value, nombre Label from Cotizar.bk_tw_RotMaqPCEqRpto", null).ToList();
                    case (int)enumTable.RotMaqPCRefCriticas:
                        return activeContext.ExecuteQuery<Table>("select RotMaqPCRefCriticasID Value, nombre Label from Cotizar.bk_tw_RotMaqPCRefCriticas", null).ToList();
                    case (int)enumTable.RotMaqPCDeducible:
                        return activeContext.ExecuteQuery<Table>("select RotMaqPCDeducibleID Value, nombre Label from Cotizar.bk_tw_RotMaqPCDeducible", null).ToList();
                    case (int)enumTable.RotMaqPCPeriodo:
                        return activeContext.ExecuteQuery<Table>("select RotMaqPCPeriodoID Value, nombre Label from Cotizar.bk_tw_RotMaqPCPeriodo", null).ToList();
                    case (int)enumTable.EqContratistaMant:
                        return activeContext.ExecuteQuery<Table>("select EqContratistaMantID Value, nombre Label from Cotizar.bk_tw_EqContratistaMant", null).ToList();
                    case (int)enumTable.EqContratistaRiesgo:
                        return activeContext.ExecuteQuery<Table>("select EqContratistaRiesgoID Value, nombre Label from Cotizar.bk_tw_EqContratistaRiesgo", null).ToList();
                    case (int)enumTable.EqContratistaRastreo:
                        return activeContext.ExecuteQuery<Table>("select EqContratistaRastreoID Value, nombre Label from Cotizar.bk_tw_EqContratistaRastreo", null).ToList();
                    case (int)enumTable.EqContratistaInc:
                        return activeContext.ExecuteQuery<Table>("select EqContratistaIncID Value, nombre Label from Cotizar.bk_tw_EqContratistaInc", null).ToList();
                    case (int)enumTable.EqContratistaMov:
                        return activeContext.ExecuteQuery<Table>("select EqContratistaMovID Value, nombre Label from Cotizar.bk_tw_EqContratistaMov", null).ToList();
                    case (int)enumTable.EqElecRiesgo:
                        return activeContext.ExecuteQuery<Table>("select EqElecRiesgoID Value, nombre Label from Cotizar.bk_tw_EqElecRiesgo", null).ToList();
                    case (int)enumTable.EqElecInc:
                        return activeContext.ExecuteQuery<Table>("select EqElecIncID Value, nombre Label from Cotizar.bk_tw_EqElecInc", null).ToList();
                    case (int)enumTable.EqElecGiro:
                        return activeContext.ExecuteQuery<Table>("select EqElecGiroID Value, nombre Label from Cotizar.bk_tw_EqElecGiro", null).ToList();
                    case (int)enumTable.EqElecMovilTipo:
                        return activeContext.ExecuteQuery<Table>("select EqElecMovilTipoID Value, nombre Label from Cotizar.bk_tw_EqElecMovilTipo", null).ToList();
                    case (int)enumTable.RCActInmTipoRiesgo:
                        return activeContext.ExecuteQuery<Table>("select RCActInmTipoRiesgoID Value, nombre Label from Cotizar.bk_tw_RCActInmTipoRiesgo", null).ToList();
                    case (int)enumTable.RCActInmLimAgregado:
                        return activeContext.ExecuteQuery<Table>("select RCActInmLimAgregadoID Value, nombre Label from Cotizar.bk_tw_RCActInmLimAgregado", null).ToList();
                    case (int)enumTable.RCProdLimAgregado:
                        return activeContext.ExecuteQuery<Table>("select RCProdLimAgregadoID Value, nombre Label from Cotizar.bk_tw_RCProdLimAgregado", null).ToList();
                    case (int)enumTable.RCProdTipoCobertura:
                        return activeContext.ExecuteQuery<Table>("select RCProdTipoCoberturaID Value, nombre Label from Cotizar.bk_tw_RCProdTipoCobertura", null).ToList();
                    case (int)enumTable.RCProdBaseDeducible:
                        return activeContext.ExecuteQuery<Table>("select RCProdBaseDeducibleID Value, nombre Label from Cotizar.bk_tw_RCProdBaseDeducible", null).ToList();
                    case (int)enumTable.RCRecallCategory:
                        return activeContext.ExecuteQuery<Table>("select RCRecallCategoryID Value, nombre Label from Cotizar.bk_tw_RCRecallCategory", null).ToList();
                    case (int)enumTable.RCRecallCoverage:
                        return activeContext.ExecuteQuery<Table>("select RCRecallCoverageID Value, nombre Label from Cotizar.bk_tw_RCRecallCoverage", null).ToList();
                    case (int)enumTable.RCRecallExposureType:
                        return activeContext.ExecuteQuery<Table>("select RCRecallExposureTypeID Value, nombre Label from Cotizar.bk_tw_RCRecallExposureType", null).ToList();
                    case (int)enumTable.RCRecallBatchAmount:
                        return activeContext.ExecuteQuery<Table>("select RCRecallBatchAmountID Value, nombre Label from Cotizar.bk_tw_RCRecallBatchAmount", null).ToList();
                    case (int)enumTable.RCRecallLimit:
                        return activeContext.ExecuteQuery<Table>("select RCRecallLimitID Value, FORMAT(limit,'#,###') Label from Cotizar.bk_tw_RCRecallLimit", null).ToList();
                    case (int)enumTable.RCRecallDeducible:
                        return activeContext.ExecuteQuery<Table>("select RCRecallDeducibleID Value, FORMAT(amount,'#,###') Label from Cotizar.bk_tw_RCRecallDeducible", null).ToList();
                    case (int)enumTable.RCRecallOccupancy:
                        return activeContext.ExecuteQuery<Table>("select occ.RCRecallOccupancyID Value, occ.nombre + ' - ' + score.nombre Label from Cotizar.bk_tw_RCRecallOccupancy occ join cotizar.bk_tw_RCRecallExposureType score on score.RCRecallExposureTypeID = occ.RCRecallExposureTypeID", null).ToList();
                    case (int)enumTable.TransModalidadPoliza:
                        return activeContext.ExecuteQuery<Table>("select TransModalidadPolizaID Value, nombre Label from Cotizar.bk_tw_TransModalidadPoliza", null).ToList();
                    case (int)enumTable.TransCommodity:
                        return activeContext.ExecuteQuery<Table>("select TransCommodityID Value, nombre Label from Cotizar.bk_tw_TransCommodity", null).ToList();
                    case (int)enumTable.TransTipoBien:
                        return activeContext.ExecuteQuery<Table>("select TransTipoBienID Value, nombre Label from Cotizar.bk_tw_TransTipoBien", null).ToList();
                    case (int)enumTable.TransModalidadCob:
                        return activeContext.ExecuteQuery<Table>("select TransModalidadCobID Value, nombre Label from Cotizar.bk_tw_TransModalidadCob", null).ToList();
                    case (int)enumTable.TransTipoMerca:
                        return activeContext.ExecuteQuery<Table>("select TransTipoMercaID Value, nombre Label from Cotizar.bk_tw_TransTipoMerca", null).ToList();
                    case (int)enumTable.TransTrayectoAseg:
                        return activeContext.ExecuteQuery<Table>("select TransTrayectoAsegID Value, nombre Label from Cotizar.bk_tw_TransTrayectoAseg", null).ToList();
                    case (int)enumTable.TransMedios:
                        return activeContext.ExecuteQuery<Table>("select TransMediosID Value, nombre Label from Cotizar.bk_tw_TransMedios", null).ToList();
                    case (int)enumTable.TransAjusteAltaSin:
                        return activeContext.ExecuteQuery<Table>("select TransAjusteAltaSinId Value, Texto Label from Cotizar.bk_tw_TransAjusteAltaSin", null).ToList();
                    case (int)enumTable.TransEvaluacion:
                        return activeContext.ExecuteQuery<Table>("select TransEvaluacionID Value, nombre Label from Cotizar.bk_tw_TransEvaluacion", null).ToList();
                    case (int)enumTable.RRRetroactive:
                        return activeContext.ExecuteQuery<Table>("select RetroactiveId Value, nombre Label from RiskReport.bk_tw_Retroactive", null).ToList();
                    case (int)enumTable.RRTrigger:
                        return activeContext.ExecuteQuery<Table>("select TriggerId Value, nombre Label from RiskReport.bk_tw_Trigger", null).ToList();
                    case (int)enumTable.RRTypeOcurrency:
                        return activeContext.ExecuteQuery<Table>("select TypeOcurrencyId Value, nombre Label from RiskReport.bk_tw_TypeOcurrency", null).ToList();
                    case (int)enumTable.RRISO:
                        return activeContext.ExecuteQuery<Table>("select ISOid Value, nombre Label from RiskReport.bk_tw_ISO", null).ToList();
                    case (int)enumTable.PerConsGanBrutas:
                        return activeContext.ExecuteQuery<Table>("select GananciasBrutas Value, FORMAT(GananciasBrutas,'0.00') + '%' Label from Cotizar.bk_tw_PerdidasConsGanBrutas", null).ToList();
                    case (int)enumTable.PerConsIndemnizacion:
                        return activeContext.ExecuteQuery<Table>("select nroMeses Value, cast(nroMeses as varchar) + ' meses' Label from Cotizar.bk_tw_PerdidasConsIndemnizacion", null).ToList();
                    case (int)enumTable.PerConsRedIngreso:
                        return activeContext.ExecuteQuery<Table>("select nroMeses Value, cast(nroMeses as varchar) + ' meses' Label from Cotizar.bk_tw_PerdidasConsRedIngreso", null).ToList();
                    case (int)enumTable.PerConsSegConting:
                        return activeContext.ExecuteQuery<Table>("select GananciasBrutas Value, FORMAT(GananciasBrutas,'0.00') + '%' Label from Cotizar.bk_tw_PerdidasConsSegConting", null).ToList();
                    case (int)enumTable.Defaults:
                        return activeContext.ExecuteQuery<Table>("select parametroGlobalID Value, valor Label from bk_tc_ParametroGLobal where parametroGlobalID between 2 and 9 or parametroGlobalID = 19", null).ToList();
                    case (int)enumTable.DeducibleValor:
                        return activeContext.ExecuteQuery<Table>("select DeducibleValorID Value, FORMAT(Valor,'#,###') Label from bk_tc_DeducibleValor", null).ToList();
                    case (int)enumTable.UnidadDeducible:
                        return activeContext.ExecuteQuery<Table>("select UnidadDeducibleID Value, Descripcion Label from bk_tc_UnidadDeducible", null).ToList();
                    case (int)enumTable.DeducibleAplica:
                        return activeContext.ExecuteQuery<Table>("select DeducibleAplicaID Value, Descripcion Label from bk_tc_DeducibleAplica", null).ToList();
                    case (int)enumTable.TipoBeneficiario:
                        return activeContext.ExecuteQuery<Table>("select TipoBeneficiarioID Value, nombre Label from bk_tc_TipoBeneficiario", null).ToList();
                    case (int)enumTable.RCActInmCruzada:
                        return activeContext.ExecuteQuery<Table>("select RCActInmCruzadaID Value, nombre Label from cotizar.bk_tw_RCActInmCruzada", null).ToList();
                    case (int)enumTable.RCEvaluacion:
                        return activeContext.ExecuteQuery<Table>("select RCEvaluacionID Value, nombre Label from Cotizar.bk_tw_RCEvaluacion", null).ToList();
                    case (int)enumTable.RCInclinacion:
                        return activeContext.ExecuteQuery<Table>("select RCInclinacionID Value, nombre Label from Cotizar.bk_tw_RCInclinacion", null).ToList();
                    default:
                        return null;
                }
                
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public string GetGlobalParam(int ParametroGlobalID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
                return activeContext.ExecuteQuery<string>("select valor from bk_tc_ParametroGLobal where parametroGlobalID = " + ParametroGlobalID.ToString(), null).ToList()[0];            
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<TransCondicion> GetCondicionesTrans()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.TransCondiciones.ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public string getDatobyID(int id, int table)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                switch (table)
                {
                    case (int)enumTableID.TipoBien:
                        return activeContext.ExecuteQuery<string>("select cast(isnull(TransTipoBienID,'') as varchar) from Cotizar.bk_tw_TransCommodity where TransCommodityID = " + id.ToString(), null).ToList()[0];
                    case (int)enumTableID.Class:
                        return activeContext.ExecuteQuery<string>("select Class from Cotizar.bk_tw_TransTipoBien where TransTipoBienID = " + id.ToString(), null).ToList()[0];

                    default:
                        return null;
                }

            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<SelectPagina_Result> FinPagina(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.SelectPagina(cotizacionID).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public string GetNombreBanco(int? cod_banco, int? bancoID)
        {
            if (!cod_banco.HasValue && !bancoID.HasValue) return string.Empty;

            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
                if (cod_banco.HasValue)
                    return activeContext.ExecuteQuery<string>("select nombre from bk_tc_Banco where SISEcod_banco = " + cod_banco.ToString(), null).ToList()[0];
                else
                    return activeContext.ExecuteQuery<string>("select nombre from bk_tc_Banco where BancoID = " + bancoID.ToString(), null).ToList()[0];
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public string GetNombreConducto(int? cod_conducto, int? conductoID)
        {
            if (!cod_conducto.HasValue && !conductoID.HasValue) return string.Empty;

            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
                if (cod_conducto.HasValue)
                    return activeContext.ExecuteQuery<string>("select nombre from bk_tc_Conducto where SISEcod_conducto = " + cod_conducto.ToString(), null).ToList()[0];
                else
                    return activeContext.ExecuteQuery<string>("select nombre from bk_tc_Conducto where ConductoID = " + conductoID.ToString(), null).ToList()[0];
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }
    }
}
