using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Specification;
using Domain.MainModule.Entities;
using Domain.MainModule.Cotizaciones;
using Infrastructure.CrossCutting.Logging;
using Infrastructure.Data.Core;
using Infrastructure.Data.MainModule.Resources;
using Infrastructure.Data.MainModule.UnitOfWork;
using Infrastructure.Data.Core.Extensions;
using Domain.MainModule.Entities.Util;

namespace Infrastructure.Data.MainModule.Repositories
{
    public class CotizacionRepository : Repository<Cotizacion>, ICotizacionRepository
    {
        public CotizacionRepository(IMainModuleUnitOfWork unitOfWork, ITraceManager traceManager) : base(unitOfWork, traceManager) { }

        public Cotizacion FindCotizacionbyID(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Cotizaciones
                                    .Where(x => x.CotizacionID == cotizacionID)
                                    .SingleOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public Cotizacion FindCotizacion(ISpecification<Cotizacion> specification)
        {
            //validate specification
            if (specification == (ISpecification<Cotizacion>)null)
                throw new ArgumentNullException("Cotizacion specification");

            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Cotizaciones
                                    .Where(specification.SatisfiedBy())
                                    .Include(j => j.bk_tc_Asegurado)
                                    .Include(j => j.bk_tr_CotizacionSubLineaNegocio)
                                    .Include(j => j.bk_tr_CotizacionTipoCobertura)
                                    .Include(j => j.bk_tc_Contacto)
                                    .Include("bk_tr_CotizacionSubLineaNegocio.bk_tc_SubLineaNegocio")
                                    .Include("bk_tr_CotizacionTipoCobertura.bk_tc_TipoCobertura")
                                    .SingleOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<Cotizacion> FindCotizaciones(ISpecification<Cotizacion> specification)
        {
            //validate specification
            if (specification == (ISpecification<Cotizacion>)null)
                throw new ArgumentNullException("Cotizacion specification");

            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Cotizaciones
                                    .Where(specification.SatisfiedBy())                                    
                                    .Include(p => p.bk_tc_Asegurado)
                                    .Include(p => p.bk_tc_Moneda)
                                    .Include(j => j.bk_tr_CotizacionSubLineaNegocio)
                                    .Include("bk_tr_CotizacionSubLineaNegocio.bk_tc_SubLineaNegocio")
                                    .ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }
               

        public Cotizacion FindCotizacionDiversos(int cotizacionID)
        {           
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                Cotizacion parent = activeContext.Cotizaciones
                                    .Where(x => x.CotizacionID == cotizacionID)
                                    .Include(p => p.bk_te_CotizacionAnuncio)
                                    .Include(p => p.bk_te_CotizacionCristal)
                                    .Include(p => p.bk_te_CotizacionRobo)
                                    .Include(p => p.bk_te_CotizacionDinVal)
                                    .Include(p => p.bk_te_CotizacionCaldera)
                                    .Include(p => p.bk_te_CotizacionCalderaPC)
                                    .Include(p => p.bk_te_CotizacionRotMaq)
                                    .Include(p => p.bk_te_CotizacionRotMaqPC)
                                    .Include(p => p.bk_te_CotizacionEqContratista)
                                    .Include(p => p.bk_te_CotizacionEqElec)
                                    .Include(p => p.bk_te_CotizacionEqElecPortExt)
                                    .Include(p => p.bk_te_CotizacionEqElecCostoOper)
                                    .Include(p => p.bk_te_CotizacionEqElecMovil)
                                    .Include(p => p.bk_te_CotizacionRCEqContratista)
                                    .Include(p => p.bk_tw_EqContratistaEquipo)
                                    .Include(p => p.bk_te_CotizacionDeducible)
                                    .Include("bk_te_CotizacionDeducible.bk_tc_Tarifa")
                                    .Include(p => p.bk_tc_Moneda)                                    
                                    .SingleOrDefault();
                
                //parent.bk_te_CotizacionDeducible = parent.bk_te_CotizacionDeducible.OrderBy(x => x.bk_tc_Tarifa.orden);
                var sorted = parent.bk_te_CotizacionDeducible.OrderBy(x => x.bk_tc_Tarifa.orden).ToList();
                parent.bk_te_CotizacionDeducible.Clear();

                for (int i = 0; i < sorted.Count(); i++)
                    parent.bk_te_CotizacionDeducible.Add(sorted[i]);



                return parent;

            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public Cotizacion FindCotizacionRC(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Cotizaciones
                                    .Where(x => x.CotizacionID == cotizacionID)
                                    .Include(p => p.bk_te_CotizacionRCActInm)
                                    //.Include(p => p.bk_te_CotizacionRCProducto)
                                    .Include(p => p.bk_te_CotizacionRCTrabajoTerm)
                                    .Include(p => p.bk_te_CotizacionRCTaller)
                                    .Include(p => p.bk_te_CotizacionRCEstacionamiento)
                                    .Include(p => p.bk_te_CotizacionRCVehiculoExc)
                                    .Include(p => p.bk_te_CotizacionRCConstruccion)
                                    .Include(p => p.bk_te_CotizacionRCHoteleria)
                                    .Include(p => p.bk_te_CotizacionDeducible)
                                    .Include(p => p.bk_te_CotizacionRCAdicional)
                                    .SingleOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public Cotizacion FindCotizacionRCExtRecall(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Cotizaciones
                                    .Where(x => x.CotizacionID == cotizacionID)
                                    .Include(p => p.bk_te_CotizacionRCProductoExtResultado)
                                    .Include(p => p.bk_te_CotizacionRCProductoExt)
                                    .Include(p => p.bk_te_CotizacionRCRecall)
                                    .Include(p => p.bk_te_CotizacionRCProductoExtPais)
                                    .SingleOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public Cotizacion FindCotizacionTransporte(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Cotizaciones
                                    .Where(x => x.CotizacionID == cotizacionID)
                                    .Include(p => p.bk_te_CotizacionTrans)
                                    .Include(p => p.bk_te_CotizacionTransConceptoEvaluacion)
                                    .Include("bk_te_CotizacionTransConceptoEvaluacion.bk_tw_TransConceptoEval")
                                    .SingleOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public Cotizacion FindCotizacionLogSISE(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Cotizaciones
                                    .Where(x => x.CotizacionID == cotizacionID)
                                    .Include(p => p.bk_te_CotizacionLog)
                                    .Include("bk_te_CotizacionLog.bk_tc_usuario")
                                    .Include(p => p.bk_te_CotizacionPagador)
                                    .SingleOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int LastCotizacionID()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Cotizaciones.Select(x => x.CotizacionID).DefaultIfEmpty().Max();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int LastCotizacionLogID()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.CotizacionLogs.Select(x => x.CotizacionLogID).DefaultIfEmpty().Max();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int LastCotizacionEqContratistaEquipoID()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.EqContratistaEquipos.Select(x => x.EqContratistaEquipoID).DefaultIfEmpty().Max();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int execUpdateCotizacionSubLineaNegocio(int cotizacionID, string datosSubLineaXML, string datosIncendioXML, string primerRiesgoXML)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
                return activeContext.ExecuteCommand("exec bk_sp_UpdateCotizacionSubLineaNegocio @CotizacionID={0}, @datosSubLinea={1}, @datosIncendio={2}, @datosPrimerRiesgo={3}", cotizacionID, datosSubLineaXML, datosIncendioXML, primerRiesgoXML);
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int execUpdatePrimerRiesgo(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
                return activeContext.ExecuteCommand("exec bk_sp_UpdatePrimerRiesgo @CotizacionID={0}, @ValorAsegurablePrimerRiesgo = null", cotizacionID);
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<Texto> GetTextobyCotizacionID(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                return activeContext.ExecuteQuery<Texto>("exec bk_sp_SelectTextoManual {0}", cotizacionID).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int execUpdateCotizacionTexto(int cotizacionID, string vectorXML, string valoresAdicionalesXML)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
                return activeContext.ExecuteCommand("exec bk_sp_UpdateCotizacionTexto @CotizacionID={0}, @datosTexto={1}, @datosAdicionales = {2}", cotizacionID, vectorXML, valoresAdicionalesXML);
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<SelectCotizacionPresentacion_Result> GetCotizacionPresentacion(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.SelectCotizacionPresentacion(cotizacionID).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<SelectPrimasPresentacion_Result> GetCotizacionPresentacionPrimas(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.SelectPrimasPresentacion(cotizacionID).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<SelectTextosPrimaPresentacion_Result> GetCotizacionPresentacionTextos(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.SelectTextosPrimaPresentacion(cotizacionID).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<SelectTextosPrimaPresentacionRC_Result> GetCotizacionPresentacionTextosRC(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.SelectTextosPrimaPresentacionRC(cotizacionID).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<SelectResumenPresentacion_Result> GetCotizacionPresentacionResumen(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.SelectResumenPresentacion(cotizacionID).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<SelectEquipoPresentacion_Result> GetCotizacionPresentacionEquipo(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.SelectEquipoPresentacion(cotizacionID).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<SelectPresentacionUbicaciones_Result> GetCotizacionPresentacionUbicacion(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.SelectPresentacionUbicaciones(cotizacionID).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<SelectPresentacionTransporte_Result> GetCotizacionPresentacionTrans(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.SelectPresentacionTransporte(cotizacionID).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<SelectCotizacionPresentacionRC_Result> GetCotizacionPresentacionRC(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.SelectCotizacionPresentacionRC(cotizacionID).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int execUpdateCotizacionDiversos(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
                return activeContext.ExecuteCommand("exec bk_sp_UpdateCotizacionDiversos @CotizacionID={0}", cotizacionID);
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int execUpdateCotizacionDiversosUbi(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
                return activeContext.ExecuteCommand("exec bk_sp_UpdateCotizacionDiversosUbi @CotizacionID={0}", cotizacionID);
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public SelectAdjustedRateRang_Result FinAdjustedRateRang(int categoryID, int exposureTypeID, int limitID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.SelectAdjustedRateRang(categoryID, exposureTypeID, limitID).FirstOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public UpdateCotizacionTransporte_Result execUpdateCotizacionTransporte(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
                return activeContext.UpdateCotizacionTransporte(cotizacionID).FirstOrDefault();
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public void execCotizar(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                activeContext.ExecuteCommand("exec bk_sp_UpdateCuotaCoberturaDetalle @CotizacionID={0}", cotizacionID);
                activeContext.ExecuteCommand("exec bk_sp_UpdateCuotaCobertura @CotizacionID={0}", cotizacionID);
                activeContext.ExecuteCommand("exec bk_sp_UpdatePrimaDiversos @CotizacionID={0}", cotizacionID);
                activeContext.ExecuteCommand("exec bk_sp_UpdatePrimaRC @CotizacionID={0}", cotizacionID);
                activeContext.ExecuteCommand("exec bk_sp_UpdateCotizacionSubLineaNegocioPrima @CotizacionID={0}", cotizacionID);
                activeContext.ExecuteCommand("exec bk_sp_UpdateCotizacionRCProductoExtResultado @CotizacionID={0}", cotizacionID);                
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public bool GetActivoCotizacion(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
                return activeContext.ExecuteQuery<bool>("select isActivo from Cotizar.bk_te_Cotizacion where CotizacionID = {0}", cotizacionID).ToList()[0];
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<string> GetMensajeLimite(int cotizacionID, int usuarioID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
                return activeContext.ExecuteQuery<string>("exec bk_sp_SelectValLimite @cotizacionID = {0}, @usuarioID = {1}", cotizacionID, usuarioID).ToList();
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<string> GetMensajeLimiteReaseguro(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
                return activeContext.ExecuteQuery<string>("exec bk_sp_SelectValLimiteReaseguro @cotizacionID = {0}", cotizacionID).ToList();
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int execDeleteCotizacionEqContratistaEquipo()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
                return activeContext.ExecuteCommand("exec bk_sp_DeleteEqContratistaEquipo", null);
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }
               
        public string GetRFCbyCotizacionID(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Cotizaciones
                                    .Where(x => x.CotizacionID == cotizacionID)
                                    .Select(y => y.bk_tc_Asegurado.RFC).SingleOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int execSaveCotizacionPagador(CotizacionPagador cotizacionPagador)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
                return activeContext.ExecuteCommand("exec bk_sp_UpdateCotizacionPagador @cotizacionID={0}, @cod_conducto = {1}, @cod_banco = {2}, @ind_conducto = {3}, " +
                        "@rfc = {4}, @nroTarjeta = {5}, @nombre = {6}", cotizacionPagador.CotizacionID, cotizacionPagador.COD_CONDUCTO, cotizacionPagador.COD_BANCO_EMI,
                        cotizacionPagador.SISEind_conducto, cotizacionPagador.RFC, cotizacionPagador.NroTarjeta, cotizacionPagador.nombre);
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public void execProcesarDiversos(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {                
                activeContext.ExecuteCommand("exec bk_sp_UpdatePrimaDiversos @CotizacionID={0}", cotizacionID);
                activeContext.ExecuteCommand("exec bk_sp_UpdateCotizacionSubLineaNegocioPrima @CotizacionID={0}", cotizacionID);
                activeContext.ExecuteCommand("exec bk_sp_UpdateCotizacionResumen @CotizacionID={0}", cotizacionID);                
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public void execProcesarRC(int cotizacionID, bool isFactorMin)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                if (isFactorMin)
                    activeContext.ExecuteCommand("exec bk_sp_UpdateFactorPrimaMinima @CotizacionID={0}", cotizacionID);

                activeContext.ExecuteCommand("exec bk_sp_UpdatePrimaRC @CotizacionID={0}, @isFactorMin={1}", cotizacionID, isFactorMin);
                activeContext.ExecuteCommand("exec bk_sp_UpdateCotizacionSubLineaNegocioPrima @CotizacionID={0}", cotizacionID);
                activeContext.ExecuteCommand("exec bk_sp_UpdateCotizacionResumen @CotizacionID={0}", cotizacionID);
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public ResultadoPrima GetPrimaCuota(int table, int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                switch (table)
                {
                    case (int)enumTableCotizacion.EqContratista:
                        return activeContext.ExecuteQuery<ResultadoPrima>("select isnull(Cuota,0) Cuota, isnull(Prima,0) Prima from Cotizar.bk_te_CotizacionEqContratista where cotizacionID = " + cotizacionID.ToString(), null).ToList()[0];
                    case (int)enumTableCotizacion.RCEqContratista:
                        return activeContext.ExecuteQuery<ResultadoPrima>("select isnull(Cuota,0) Cuota, isnull(Prima,0) Prima from Cotizar.bk_te_CotizacionRCEqContratista where cotizacionID = " + cotizacionID.ToString(), null).ToList()[0];
                    case (int)enumTableCotizacion.RCActInm:
                        return activeContext.ExecuteQuery<ResultadoPrima>("select isnull(Cuota,0) Cuota, isnull(Prima,0) Prima from Cotizar.bk_te_CotizacionRCActInm where cotizacionID = " + cotizacionID.ToString(), null).ToList()[0];
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

        public Cotizacion FindCotizacionEQbyID(int cotizacionID)
        {
            Cotizacion cot = new Cotizacion();
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                //cot.bk_te_CotizacionEqContratista = activeContext.CotizacionEqContratistas
                //                    .Where(x => x.CotizacionID == cotizacionID)
                //                    .SingleOrDefault();

                //cot.bk_te_CotizacionRCEqContratista = activeContext.CotizacionRCEqContratistas
                //                    .Where(x => x.CotizacionID == cotizacionID)
                //                    .SingleOrDefault();


                return activeContext.Cotizaciones
                    .Where(x => x.CotizacionID == cotizacionID)
                    .Include(x => x.bk_te_CotizacionEqContratista)
                    .Include(x => x.bk_te_CotizacionRCEqContratista)                    
                    .SingleOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int execUpdateCotizacionEq(int cotizacionID, string equiposXML, string nombreArchivo)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
                return activeContext.ExecuteCommand("exec bk_sp_InsertCotizacionEqContratistaEquipo @CotizacionID={0}, @datosEquipos={1}, @fileName = {2}", cotizacionID, equiposXML, nombreArchivo);
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int execUpdateCMICDeducibles(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
                return activeContext.ExecuteCommand("exec bk_sp_UpdateCotizacionDeducibleCMIC @CotizacionID={0}", cotizacionID);
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public double execSelectGastosAdmCalculado(int cotizacionID, double cuotaDeseada)
        {            
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)         
                return activeContext.ExecuteQuery<double>("exec bk_sp_SelectGactosAdmCalculado @CotizacionID={0}, @cuotaDeseada ={1}", cotizacionID, cuotaDeseada).ToList()[0];
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }
    }
}
