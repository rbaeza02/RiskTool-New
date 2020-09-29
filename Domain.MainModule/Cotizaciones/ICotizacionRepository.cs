using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core;
using Domain.Core.Specification;
using Domain.MainModule.Entities;

namespace Domain.MainModule.Cotizaciones
{
    public interface ICotizacionRepository: IRepository<Cotizacion>
    {
        Cotizacion FindCotizacionbyID(int cotizacionID);
        Cotizacion FindCotizacion(ISpecification<Cotizacion> specification);
        List<Cotizacion> FindCotizaciones(ISpecification<Cotizacion> specification);
        int LastCotizacionID();
        int LastCotizacionLogID();
        int LastCotizacionEqContratistaEquipoID();
        int execUpdateCotizacionSubLineaNegocio(int cotizacionID, string datosSubLineaXML, string datosIncendioXML, string primerRiesgoXML);
        int execUpdatePrimerRiesgo(int cotizacionID);

        Cotizacion FindCotizacionDiversos(int cotizacionID);
        Cotizacion FindCotizacionRC(int cotizacionID);
        Cotizacion FindCotizacionRCExtRecall(int cotizacionID);
        Cotizacion FindCotizacionTransporte(int cotizacionID);
        Cotizacion FindCotizacionLogSISE(int cotizacionID);
        List<SelectCotizacionPresentacion_Result> GetCotizacionPresentacion(int cotizacionID);
        List<SelectPrimasPresentacion_Result> GetCotizacionPresentacionPrimas(int cotizacionID);
        List<SelectTextosPrimaPresentacion_Result> GetCotizacionPresentacionTextos(int cotizacionID);
        List<SelectTextosPrimaPresentacionRC_Result> GetCotizacionPresentacionTextosRC(int cotizacionID);
        List<SelectResumenPresentacion_Result> GetCotizacionPresentacionResumen(int cotizacionID);
        List<SelectPresentacionUbicaciones_Result> GetCotizacionPresentacionUbicacion(int cotizacionID);
        List<SelectEquipoPresentacion_Result> GetCotizacionPresentacionEquipo(int cotizacionID);
        List<SelectCotizacionPresentacionRC_Result> GetCotizacionPresentacionRC(int cotizacionID);
        List<Texto> GetTextobyCotizacionID(int cotizacionID);        
        int execUpdateCotizacionTexto(int cotizacionID, string vectorXML, string valoresAdicionalesXML);

        List<SelectPresentacionTransporte_Result> GetCotizacionPresentacionTrans(int cotizacionID);        

        int execUpdateCotizacionDiversos(int cotizacionID);
        int execUpdateCotizacionDiversosUbi(int cotizacionID);

        SelectAdjustedRateRang_Result FinAdjustedRateRang(int categoryID, int exposureTypeID, int limitID);

        //int execUpdateCotizacionTransporte(int cotizacionID);
        UpdateCotizacionTransporte_Result execUpdateCotizacionTransporte(int cotizacionID);
        void execCotizar(int cotizacionID);

        bool GetActivoCotizacion(int cotizacionID);
        List<string> GetMensajeLimite(int cotizacionID, int usuarioID);
        List<string> GetMensajeLimiteReaseguro(int cotizacionID);
        int execDeleteCotizacionEqContratistaEquipo();
        string GetRFCbyCotizacionID(int cotizacionID);
        int execSaveCotizacionPagador(CotizacionPagador cotizacionPagador);
        void execProcesarDiversos(int cotizacionID);
        void execProcesarRC(int cotizacionID, bool isFactorMin);
        Cotizacion FindCotizacionEQbyID(int cotizacionID);
        int execUpdateCotizacionEq(int cotizacionID, string equiposXML, string nombreArchivo);
        int execUpdateCMICDeducibles(int cotizacionID);
        double execSelectGastosAdmCalculado(int cotizacionID, double cuotaDeseada);
        ResultadoPrima GetPrimaCuota(int table, int cotizacionID);
    }
}
