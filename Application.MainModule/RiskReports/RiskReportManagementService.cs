using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.MainModule.Entities;
using Domain.MainModule.RiskReports;
using Domain.Core;

namespace Application.MainModule.RiskReports
{
    public class RiskReportManagementService : IRiskReportManagementService
    {
        IRiskReportRepository _riskReportRepository;

        public RiskReportManagementService(IRiskReportRepository riskReportRepository)            
        {
            if (riskReportRepository == (IRiskReportRepository)null)
                throw new ArgumentNullException("RiskReportRepository");

            _riskReportRepository = riskReportRepository;            
        }

        public Cotizacion FindRiskReportbyID(int cotizacionID)
        {
            Cotizacion cot = _riskReportRepository.FindRiskReport(cotizacionID);
            FillRiskReport(cot);

            return cot;
        }

        private void FillRiskReport(Cotizacion cot)
        {
            int i, contador;

            //Aumentamos a un max de 10 las areas de fuego
            cot.bk_te_IncASAreaFuego.Select(x => x.UbicacionID).Distinct().ToList().ForEach(y =>
            {

                contador = 1;
                cot.bk_te_IncASAreaFuego.Where(u => u.UbicacionID == y).ToList().ForEach(z =>
                {
                    z.Nro = contador;
                    z.Visible = true;
                    contador++;
                });

                for (i = cot.bk_te_IncASAreaFuego.Where(u => u.UbicacionID == y).Count(); i < 10; i++)
                {
                    cot.bk_te_IncASAreaFuego.Add(new IncASAreaFuego { IncASAreaFuegoID = 0, CotizacionID = cot.CotizacionID, UbicacionID = y, Nro = contador, Visible = false });
                    contador++;
                }
            });
        }

        public RiskReportInc FindRiskReportIncbyID(int cotizacionID)
        {
            RiskReportInc presentacion = new RiskReportInc();
            presentacion.GeneralInformation = _riskReportRepository.GetRiskReportGeneralInf(cotizacionID);
            presentacion.Ubicaciones = _riskReportRepository.GetRiskReportUbicaciones(cotizacionID);
            presentacion.COPE = _riskReportRepository.GetRiskReportCOPE(cotizacionID);
            presentacion.ASAreaInc = _riskReportRepository.GetRiskReportASAreaFuego(cotizacionID);
            presentacion.AS = _riskReportRepository.GetRiskReportAS(cotizacionID);
            return presentacion;
        }

        public Cotizacion SaveRiskReportInc(Cotizacion cotizacion)
        {
            //Grabar Cotizacion 
            IUnitOfWork unitOfWork = _riskReportRepository.UnitOfWork as IUnitOfWork;

            //Cotizacion cotDatos = _cotizacionRepository.FindCotizacion(cotizacion.CotizacionID);

            Cotizacion cotDatos = _riskReportRepository.FindRiskReport(cotizacion.CotizacionID);
            cotDatos.bk_te_IncGeneralInf = cotizacion.bk_te_IncGeneralInf;            
            cotDatos.bk_te_LazCasualty = cotizacion.bk_te_LazCasualty;
            cotDatos.bk_te_IncAS = cotizacion.bk_te_IncAS;

            cotDatos.bk_te_IncCOPE.Clear();
            cotizacion.bk_te_IncCOPE.ToList().ForEach(x => cotDatos.bk_te_IncCOPE.Add(x));

            int maxIncASArea = _riskReportRepository.LastIncASAreaFuegoID();
            IncASAreaFuego modificacion;
            
            //cotDatos.bk_te_IncASAreaFuego.Clear();
            cotizacion.bk_te_IncASAreaFuego.Where(x => x.Visible).ToList().ForEach(x => {
                if (x.IncASAreaFuegoID == 0)
                {
                    x.IncASAreaFuegoID = maxIncASArea + 1;
                    cotDatos.bk_te_IncASAreaFuego.Add(x);
                    maxIncASArea++;                    
                }
                else
                {
                    modificacion = cotDatos.bk_te_IncASAreaFuego.Where(y => y.IncASAreaFuegoID == x.IncASAreaFuegoID).SingleOrDefault();
                    modificacion.ISOid = x.ISOid;
                    modificacion.SIC = x.SIC;
                    modificacion.pct = x.pct;
                    modificacion.TipoConstructivoIncendioID = x.TipoConstructivoIncendioID;
                }
            });

            //cotizacion.bk_te_IncASAreaFuego.Where( =>) .ToList().ForEach(x => cotDatos.bk_te_IncASAreaFuego.Add(x));

            _riskReportRepository.Modify(cotDatos);

            unitOfWork.Commit();

            FillRiskReport(cotDatos);
            return cotDatos;
        }

        public void InsertRiskReport(int cotizacionid)
        {
            _riskReportRepository.execInsertRiskReport(cotizacionid);
        }

        public RiskReportTrans FindRiskReportTransbyID(int cotizacionID)
        {
            RiskReportTrans presentacion = new RiskReportTrans();
            presentacion.GeneralInformation = _riskReportRepository.GetRiskReportTransporte(cotizacionID);
            return presentacion;
        }

        public RiskReportRC FindRiskReportRCbyID(int cotizacionID)
        {
            RiskReportRC presentacion = new RiskReportRC();
            presentacion.GeneralInformation = _riskReportRepository.GetRiskReportRC(cotizacionID);
            return presentacion;
        }

        public RiskBrowser FindRiskBrowserbyID(int cotizacionID)
        {
            RiskBrowser presentacion = new RiskBrowser();
            presentacion.GeneralInformation = _riskReportRepository.GetRiskBrowser(cotizacionID);
            return presentacion;
        }
    }
}
