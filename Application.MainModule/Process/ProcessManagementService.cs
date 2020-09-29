using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Integration;
using Application.MainModule.Util;
using Domain.Core;
using Domain.MainModule.Catalogos;
using Domain.MainModule.Cotizaciones;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.Util;
using Domain.MainModule.WorkFlows;

namespace Application.MainModule.Process
{
    public class ProcessManagementService : IProcessManagementService
    {
        IWorkFlowRepository _workFlowRepository;
        ICotizacionRepository _cotizacionRepository;
        ICatalogoRepository _catalogoRepository;

        public ProcessManagementService(IWorkFlowRepository workFlowRepository,
            ICotizacionRepository cotizacionRepository, ICatalogoRepository catalogoRepository)
        {
            if (workFlowRepository == (IWorkFlowRepository)null)
                throw new ArgumentNullException("WorkFlowRepository");

            if (workFlowRepository == (ICotizacionRepository)null)
                throw new ArgumentNullException("CotizacionRepository");

            if (workFlowRepository == (ICatalogoRepository)null)
                throw new ArgumentNullException("CatalogoRepository");

            _workFlowRepository = workFlowRepository;
            _cotizacionRepository = cotizacionRepository;
            _catalogoRepository = catalogoRepository;
        }

        public List<workflow> FindWorkFlowxProcess(int processID)
        {
            ProcessIDSpecification spec = new ProcessIDSpecification(processID);
            return _workFlowRepository.FindWorkFlows(spec);
        }

        public int ProcessActivity(int processID, int step, string valor)
        {
            ProcessIDOrderIDSpecification spec = new ProcessIDOrderIDSpecification(processID, step);
            workflow activity = _workFlowRepository.FindWorkFlow(spec);

            string sp = activity.sp.Replace("{0}", valor);
            return _workFlowRepository.execWorkFlow(sp);
            
        }

        public string ProcessSISE(int cotizacionID, int usuarioID)
        {
            IUnitOfWork unitOfWork = _cotizacionRepository.UnitOfWork as IUnitOfWork;

            //Verificar si ya se ha mandado
            Cotizacion cot = _cotizacionRepository.FindCotizacionLogSISE(cotizacionID);
            if (cot.bk_te_CotizacionLog.ToList().Exists(x => x.isOK.Value))
                return cot.ErrorSISE();


            //Este ID sería el id_pv
            int cotizacionLogID = _cotizacionRepository.LastCotizacionLogID() + 1;
                        
            WsCotizador sise = new WsCotizador();
            string mensaje = sise.GrabarCotizacion(_workFlowRepository.GetSISEPol(cotizacionID, cotizacionLogID), _workFlowRepository.GetSISEAge(cotizacionID, cotizacionLogID),
                _workFlowRepository.GetSISECob(cotizacionID, cotizacionLogID), _workFlowRepository.GetSISEInc(cotizacionID, cotizacionLogID),
                _workFlowRepository.GetSISETransporte(cotizacionID, cotizacionLogID), _workFlowRepository.GetSISEObs(cotizacionID, cotizacionLogID),
                _workFlowRepository.GetSISEDetalle(cotizacionID, cotizacionLogID), _workFlowRepository.GetSISEAne(cotizacionID, cotizacionLogID), 
                _cotizacionRepository.GetCotizacionPresentacionTextos(cotizacionID));

            CotizacionLog log = new CotizacionLog()
            {
                CotizacionLogID = cotizacionLogID,
                cotizacionID = cotizacionID,
                mensaje = mensaje,
                usuarioID = usuarioID,
                LogTime = DateTime.Now,
                isOK = Function.IsOKSISE(mensaje)
            };

            cot.nroPoliza = Function.NroPolizaSISE(mensaje);
            cot.bk_te_CotizacionLog.Add(log);

            cot.Fecha = DateTime.Now;
            cot.isActivo = !log.isOK.Value;
            unitOfWork.Commit();

            return mensaje;
        }

        public List<SelectBeneficiario_Result> FindBeneficiariobyID(int cotizacionID, int ubicacionID)
        {
            return _workFlowRepository.GetBeneficiario(cotizacionID, ubicacionID);
        }

        public List<CotizacionPagador> GetPagadoresSISE(string rfc)
        {                        
            List<CotizacionPagador> pagadoresSISE;

            if (Convert.ToBoolean(_catalogoRepository.GetGlobalParam((int)globalParam.WSSiseAvailable)))
            {
                Integration.WsAsegurado ws = new Integration.WsAsegurado();
                pagadoresSISE = ws.ConsultarPagadores(rfc);
                pagadoresSISE.ForEach(x =>
                {
                    x.Banco = _catalogoRepository.GetNombreBanco(Convert.ToInt32(x.COD_BANCO_EMI), null);
                    x.Conducto = _catalogoRepository.GetNombreConducto(Convert.ToInt32(x.COD_CONDUCTO), null);
                });
            }
            else
                pagadoresSISE = null;

            /*
            pagadoresSISE = new List<CotizacionPagador>();
            pagadoresSISE.Add(new CotizacionPagador() { RFC = "AAAA000000AAA", Banco = "BANCO INTERNACIONAL", Conducto = "03 TRANSFERENCIA", SISEind_conducto = 1, nombre = "Prueba de la O", NroTarjeta = "1234", COD_CONDUCTO = "1" });
            pagadoresSISE.Add(new CotizacionPagador() { RFC = "AAAA000000AA1", Banco = "CI BANCO", Conducto = "02 CHEQUE", SISEind_conducto = 2, nombre = "Prueba de la O", NroTarjeta = "", COD_CONDUCTO = "2" });
            */

            return pagadoresSISE;
        }
    }
}
