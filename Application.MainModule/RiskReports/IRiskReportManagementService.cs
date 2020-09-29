using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.MainModule.Entities;

namespace Application.MainModule.RiskReports
{
    public interface IRiskReportManagementService
    {
        Cotizacion FindRiskReportbyID(int cotizacionID);
        RiskReportInc FindRiskReportIncbyID(int cotizacionID);
        Cotizacion SaveRiskReportInc(Cotizacion cotizacion);
        RiskReportTrans FindRiskReportTransbyID(int cotizacionID);
        RiskReportRC FindRiskReportRCbyID(int cotizacionID);
        RiskBrowser FindRiskBrowserbyID(int cotizacionID);
        void InsertRiskReport(int cotizacionid);
    }
}
