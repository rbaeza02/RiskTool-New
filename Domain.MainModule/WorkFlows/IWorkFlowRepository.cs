using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core;
using Domain.Core.Specification;
using Domain.MainModule.Entities;

namespace Domain.MainModule.WorkFlows
{
    public interface IWorkFlowRepository: IRepository<workflow>
    {
        List<workflow> FindWorkFlows(ISpecification<workflow> specification);
        workflow FindWorkFlow(ISpecification<workflow> specification);
        int execWorkFlow(string command);

        SISEPol_Result GetSISEPol(int cotizacionID, int cotizacionLogID);
        SISEAge_Result GetSISEAge(int cotizacionID, int cotizacionLogID);
        List<SISECob_Result> GetSISECob(int cotizacionID, int cotizacionLogID);
        List<SISEInc_Result> GetSISEInc(int cotizacionID, int cotizacionLogID);
        SISETransporte_Result GetSISETransporte(int cotizacionID, int cotizacionLogID);
        List<SISEObs_Result> GetSISEObs(int cotizacionID, int cotizacionLogID);
        List<SelectBeneficiario_Result> GetBeneficiario(int cotizacionID, int ubicacionID);
        List<SISEEquipoDetalle_Result> GetSISEDetalle(int cotizacionID, int cotizacionLogID);
        List<SISEClausula_Result> GetSISEAne(int cotizacionID, int cotizacionLogID);
    }
}
