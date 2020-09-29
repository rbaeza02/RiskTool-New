using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Specification;
using Domain.MainModule.CotizacionCoberturaUbicaciones;
using Domain.MainModule.Entities;
using Infrastructure.CrossCutting.Logging;
using Infrastructure.Data.Core;
using Infrastructure.Data.MainModule.UnitOfWork;
using Infrastructure.Data.MainModule.Resources;
using Infrastructure.Data.Core.Extensions;
using System.Globalization;

namespace Infrastructure.Data.MainModule.Repositories
{
    public class CotizacionCoberturaUbicacionRepository : Repository<CotizacionCoberturaUbicacion>, ICotizacionCoberturaUbicacionRepository
    {
        public CotizacionCoberturaUbicacionRepository(IMainModuleUnitOfWork unitOfWork, ITraceManager traceManager) : base(unitOfWork, traceManager) { }

        public List<CotizacionCoberturaUbicacion> FindCotizacionCoberturaUbicaciones(ISpecification<CotizacionCoberturaUbicacion> specification)
        {
            //validate specification
            if (specification == (ISpecification<CotizacionCoberturaUbicacion>)null)
                throw new ArgumentNullException("CotizacionCoberturaUbicacion specification");

            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.CotizacionCoberturaUbicaciones
                                    .Where(specification.SatisfiedBy())
                                    .Include(j => j.bk_tc_Ubicacion)
                                    .Include(j => j.bk_tr_CotizacionCobertura)
                                    .Include("bk_tr_CotizacionCobertura.bk_tc_Cobertura")
                                    .Include("bk_tr_CotizacionCobertura.bk_tc_LineaNegocio")
                                    .Include("bk_tr_CotizacionCobertura.bk_tc_Cobertura.bk_tc_TipoCobertura")
                                    .ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }
    }
}
