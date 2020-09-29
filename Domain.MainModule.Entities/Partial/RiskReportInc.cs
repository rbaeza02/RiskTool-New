using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public class RiskReportInc
    {
        public List<SelectRiskReportGeneralInformation_Result> GeneralInformation { get; set; }
        public List<SelectRiskReportUbicaciones_Result> Ubicaciones { get; set; }
        public List<SelectRiskReportCOPE_Result> COPE { get; set; }
        public List<SelectRiskReportASAreaInc_Result> ASAreaInc { get; set; }
        public List<SelectRiskReportAS_Result> AS { get; set; }
    }
}
