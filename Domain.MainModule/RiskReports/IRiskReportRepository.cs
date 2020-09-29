using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core;
using Domain.Core.Specification;
using Domain.MainModule.Entities;

namespace Domain.MainModule.RiskReports
{
    public interface IRiskReportRepository : IRepository<Cotizacion>
    {
        Cotizacion FindRiskReport(int cotizacionID);
        List<SelectRiskReportGeneralInformation_Result> GetRiskReportGeneralInf(int cotizacionID);
        List<SelectRiskReportUbicaciones_Result> GetRiskReportUbicaciones(int cotizacionID);
        List<SelectRiskReportCOPE_Result> GetRiskReportCOPE(int cotizacionID);
        List<SelectRiskReportASAreaInc_Result> GetRiskReportASAreaFuego(int cotizacionID);
        List<SelectRiskReportAS_Result> GetRiskReportAS(int cotizacionID);
        List<SelectRiskReportTransporte_Result> GetRiskReportTransporte(int cotizacionID);
        List<SelectRiskReportRC_Result> GetRiskReportRC(int cotizacionID);
        List<SelectRiskBrowser_Result> GetRiskBrowser(int cotizacionID);

        int execInsertRiskReport(int cotizacionID);

        int LastIncASAreaFuegoID();
    }
}
