using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Specification;
using Domain.MainModule.Cotizaciones;
using Domain.MainModule.Entities;
using Domain.MainModule.Ubicaciones;
using Infrastructure.CrossCutting.Logging;
using Infrastructure.Data.Core;
using Infrastructure.Data.MainModule.Resources;
using Infrastructure.Data.MainModule.UnitOfWork;
using Infrastructure.Data.Core.Extensions;

namespace Infrastructure.Data.MainModule.Repositories
{
    public class UbicacionRepository : Repository<Ubicacion>, IUbicacionRepository
    {
        public UbicacionRepository(IMainModuleUnitOfWork unitOfWork, ITraceManager traceManager) : base(unitOfWork, traceManager) { }

        public Ubicacion FindUbicacion(int ubicacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Ubicaciones
                                    .Where(x => x.UbicacionID == ubicacionID)
                                    .Include(j => j.bk_tr_CotizacionCoberturaUbi)
                                    .Include(j => j.bk_tr_CotizacionSubLineaUbi)
                                    .Include(j => j.bk_te_CotizacionUbicacion)
                                    .FirstOrDefault();

            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<Ubicacion> FindUbicaciones(ISpecification<Ubicacion> specification, int nroPagina, int tamaño)
        {
            //validate specification
            if (specification == (ISpecification<Ubicacion>)null)
                throw new ArgumentNullException("Ubicacion specification");

            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Ubicaciones
                                    .Where(specification.SatisfiedBy())
                                    .Include(j => j.bk_tc_Colonia)
                                    .OrderBy(c => c.UbicacionID)
                                    .Skip(nroPagina * tamaño)
                                    .Take(tamaño)
                                    .ToList();
                                    
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int LastUbicacionID()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Ubicaciones.Select(x => x.UbicacionID).DefaultIfEmpty().Max();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int LastNroUbicacion(int aseguradoID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Ubicaciones.Where(x => x.AseguradoID == aseguradoID).Select(x => x.nroUbicacion).DefaultIfEmpty().Max();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int TotalUbicaciones(ISpecification<Ubicacion> specification)
        {
            //validate specification
            if (specification == (ISpecification<Ubicacion>)null)
                throw new ArgumentNullException("Ubicacion specification");

            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Ubicaciones.Where(specification.SatisfiedBy()).Count();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }


        public List<Ubicacion> FindUbicacionesValores(int cotizacionID)
        {
            
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {                
                //perform operation in this repository

               
                
                //return activeContext.Ubicaciones
                //                    .Where(a => a.bk_tr_CotizacionCoberturaUbi.Any(i => i.CotizacionID == cotizacionID) || a.bk_tr_CotizacionSubLineaUbi.Any(i => i.CotizacionID == cotizacionID))
                //                    //.Where(a => a.bk_tr_CotizacionCoberturaUbi.Select(b => b.CotizacionID).Contains(cotizacionID) || a.bk_tr_CotizacionSubLineaUbi.Select(b => b.CotizacionID).Contains(cotizacionID))
                //                    .Include(j => j.bk_tr_CotizacionCoberturaUbi)
                //                    .Include("bk_tr_CotizacionCoberturaUbi.bk_tc_Cobertura")
                //                    .Include(j => j.bk_tr_CotizacionSubLineaUbi)
                //                    .Include("bk_tr_CotizacionSubLineaUbi.bk_tc_SubLineaNegocio")                                    
                //                    .OrderBy(c => c.nroUbicacion)
                //                    .ToList();
                List<Ubicacion> ubicaciones = activeContext.Ubicaciones
                                    .Where(a => a.bk_tr_CotizacionCoberturaUbi.Any(i => i.CotizacionID == cotizacionID) || a.bk_tr_CotizacionSubLineaUbi.Any(i => i.CotizacionID == cotizacionID))
                                    .OrderBy(c => c.nroUbicacion)                                    
                                    .ToList();
                
                
                List<CotizacionCoberturaUbi> cotCob = activeContext.CotizacionCoberturaUbis
                                    .Where(a => a.CotizacionID == cotizacionID)
                                    .Include(a => a.bk_tc_Cobertura)
                                    .ToList();

                List<CotizacionSubLineaUbi> cotSubLinea = activeContext.CotizacionSubLineaUbis
                                    .Where(a => a.CotizacionID == cotizacionID)
                                    .Include(a => a.bk_tc_SubLineaNegocio)
                                    .ToList();

                List<CotizacionUbicacion> cotUbicacion = activeContext.CotizacionUbicaciones
                                   .Where(a => a.CotizacionID == cotizacionID)
                                   .ToList();
                
                ubicaciones.ForEach(x => {

                    x.bk_tr_CotizacionCoberturaUbi.Clear();
                    x.bk_tr_CotizacionSubLineaUbi.Clear();
                    x.bk_te_CotizacionUbicacion.Clear();

                    cotCob.Where(a => a.UbicacionID == x.UbicacionID).ToList().ForEach(y => {
                        x.bk_tr_CotizacionCoberturaUbi.Add(y);
                    });
                    
                    cotSubLinea.Where(a => a.UbicacionID == x.UbicacionID).OrderBy(a => a.bk_tc_SubLineaNegocio.ordenPantalla).ToList().ForEach(y =>
                    {
                        x.bk_tr_CotizacionSubLineaUbi.Add(y);
                    });

                    cotUbicacion.Where(a => a.UbicacionID == x.UbicacionID).ToList().ForEach(y =>
                    {
                        x.bk_te_CotizacionUbicacion.Add(y);
                    });
                });

                return ubicaciones;
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        //public List<Ubicacion> FindUbicaciones(ISpecification<Ubicacion> specification, int pagina, int tamaño)
        //{
        //    //validate specification
        //    if (specification == (ISpecification<Ubicacion>)null)
        //        throw new ArgumentNullException("Ubicacion specification");

        //    IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
        //    if (activeContext != null)
        //    {
        //        //perform operation in this repository
        //        return activeContext.Ubicaciones
        //                            .Where(specification.SatisfiedBy())
        //                            .OrderBy(c => c.UbicacionID)
        //                            .Skip(pagina * tamaño)
        //                            .Take(tamaño)
        //                            .ToList();

        //    }
        //    else
        //        throw new InvalidOperationException(string.Format(
        //                                                        CultureInfo.InvariantCulture,
        //                                                        Messages.exception_InvalidStoreContext,
        //                                                        this.GetType().Name));
        //}

        public List<Table> GetUbicacionesbyCotizacionID(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
                return activeContext.ExecuteQuery<Table>("select ubi.UbicacionID Value, cast(ubi.nroUbicacion as varchar) + ' - ' + ubi.Domicilio_Calle + ' ' + ubi.Domicilio_NroExterior + ' ' + ubi.Domicilio_NroInterior Label " +
                            "from Cotizar.bk_tc_Ubicacion ubi join Cotizar.bk_te_Cotizacion cotizacion on cotizacion.AseguradoID = ubi.AseguradoID and cotizacion.CotizacionID = {0}", cotizacionID).ToList();
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }
    }
}
