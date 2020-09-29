using Domain.Core.Specification;
using Domain.MainModule.Asegurados;
using Domain.MainModule.Entities;
using Infrastructure.CrossCutting.Logging;
using Infrastructure.Data.Core;
using Infrastructure.Data.MainModule.Resources;
using Infrastructure.Data.MainModule.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.Core.Extensions;

namespace Infrastructure.Data.MainModule.Repositories
{
    public class AseguradoRepository : Repository<Asegurado>, IAseguradoRepository
    {
        public AseguradoRepository(IMainModuleUnitOfWork unitOfWork, ITraceManager traceManager) : base(unitOfWork, traceManager) { }

        public Asegurado FindAsegurado(ISpecification<Asegurado> specification)
        {
            //validate specification
            if (specification == (ISpecification<Asegurado>)null)
                throw new ArgumentNullException("Asegurado specification");

            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Asegurados
                                    .Where(specification.SatisfiedBy())
                                    .Include(j => j.bk_tc_Colonia)
                                    .Include(j => j.bk_tc_EstadoCivil)
                                    .Include(j => j.bk_tc_TipoPersona)
                                    .Include(j => j.bk_tc_TipoTelefono)
                                    .Include("bk_tc_Colonia.bk_tc_Ciudad")
                                    .Include("bk_tc_Colonia.bk_tc_Municipio")
                                    .Include("bk_tc_Colonia.bk_tc_Municipio.bk_tc_Estado")
                                    .Include("bk_tc_Colonia.bk_tc_Municipio.bk_tc_Estado.bk_tc_Pais")
                                    .SingleOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int LastAseguradoID()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Asegurados.Select(x => x.AseguradoID).DefaultIfEmpty().Max();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<Asegurado> FindAseguradobyFiltro(ISpecification<Asegurado> specification)
        {
            //validate specification
            if (specification == (ISpecification<Asegurado>)null)
                throw new ArgumentNullException("Asegurado specification");

            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Asegurados
                                    .Where(specification.SatisfiedBy())
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
