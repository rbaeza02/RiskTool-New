using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.MainModule.Entities;

namespace Application.MainModule.Process
{
    public interface IProcessManagementService
    {
        List<workflow> FindWorkFlowxProcess(int processID);
        int ProcessActivity(int processID, int step, string valor);

        string ProcessSISE(int cotizacionID, int usuarioID);
        List<SelectBeneficiario_Result> FindBeneficiariobyID(int cotizacionID, int ubicacionID);

        List<CotizacionPagador> GetPagadoresSISE(string rfc);
    }
}
