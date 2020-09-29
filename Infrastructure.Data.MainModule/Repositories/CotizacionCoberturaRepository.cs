using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Specification;
using Domain.MainModule.CotizacionCoberturas;
using Domain.MainModule.Entities;
using Infrastructure.CrossCutting.Logging;
using Infrastructure.Data.Core;
using Infrastructure.Data.MainModule.UnitOfWork;
using Infrastructure.Data.Core.Extensions;
using System.Globalization;
using Infrastructure.Data.MainModule.Resources;

namespace Infrastructure.Data.MainModule.Repositories
{
    public class CotizacionCoberturaRepository : Repository<CotizacionCobertura>, ICotizacionCoberturaRepository
    {
        public CotizacionCoberturaRepository(IMainModuleUnitOfWork unitOfWork, ITraceManager traceManager) : base(unitOfWork, traceManager) { }

        public List<CotizacionCobertura> FindCotizacionCoberturas(ISpecification<CotizacionCobertura> specification)
        {
            //validate specification
            if (specification == (ISpecification<CotizacionCobertura>)null)
                throw new ArgumentNullException("CotizacionCobertura specification");

            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.CotizacionCoberturas
                                    .Where(specification.SatisfiedBy())
                                    .Include(j => j.bk_tc_Cobertura)
                                    .ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int LastCotizacionCoberturaID()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.CotizacionCoberturas.Select(x => x.CotizacionCoberturaID).DefaultIfEmpty().Max();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int execUpdateCotizacionCoberturaUbicacion(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
                return activeContext.ExecuteCommand("exec bk_sp_UpdateCotizacionCoberturaUbicacion @CotizacionID={0}", cotizacionID);
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }
    }
}
