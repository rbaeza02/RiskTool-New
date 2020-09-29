using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.MainModule.Entities;
using Domain.MainModule.Personas;
using Infrastructure.CrossCutting.Logging;
using Infrastructure.Data.Core;
using Infrastructure.Data.MainModule.Resources;
using Infrastructure.Data.MainModule.UnitOfWork;

namespace Infrastructure.Data.MainModule.Repositories
{
    public class PersonaRepository : Repository<Persona>, IPersonaRepository
    {
        public PersonaRepository(IMainModuleUnitOfWork unitOfWork, ITraceManager traceManager) : base(unitOfWork, traceManager) { }

        public Persona GetPersonabyRFC(string rfc)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Personas.Where(x => x.RFC == rfc).FirstOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int LastPersonaID()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Personas.Select(x => x.PersonaID).DefaultIfEmpty().Max();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int GetNumberBeneficiarios(int cotizacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.ExecuteQuery<int>("select count(*) from cotizar.bk_te_CotizacionUbiBenef where CotizacionID = {0}", cotizacionID).ToList()[0];
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int execUpdateBeneficiarioCotizacion(string datosXML, int cotizacionID, int ubicacionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
                return activeContext.ExecuteCommand("exec bk_sp_UpdateBeneficiarioCotizacion @datos={0}, @CotizacionID={1}, @UbicacionID={2}", datosXML, cotizacionID, ubicacionID);
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }
    }
}
