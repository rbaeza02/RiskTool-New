using Domain.MainModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainModule.Cotizaciones
{
    public interface ICotizacionManagementService
    {
        List<Cotizacion> FindCotizacionesbyFiltro(Nullable<DateTime> inicioVigencia, Nullable<DateTime> finVigencia, string rfc, int usuarioID, string nombre, string nroPol);
        Cotizacion FindCotizacionbyID(int cotizacionID);
        void SaveCotizacion(Cotizacion cotizacion);

        List<Ubicacion> FindValoresUbicacionesbyCotizacionID(int cotizacionID);
        void SaveValores(List<Ubicacion> ubicaciones, int cotizacionID);
        //List<CotizacionCobertura> FindCotizacionCoberturasbyID(int cotizacionID);
        //void SaveCotizacionCobertura(int cotizacionID, string[] incendio, string[] terremoto, string[] hidro);
        //List<CotizacionCoberturaUbicacion> FindCotizacionCoberturaUbicacionesbyID(int cotizacionID);

        Cotizacion FindCotizacionDiversobyID(int cotizacionID);
        Cotizacion FindCotizacionRCbyID(int cotizacionID);
        Cotizacion FindCotizacionRCExtRecallbyID(int cotizacionID);
        Cotizacion FindCotizacionTransportebyID(int cotizacionID);

        Cotizacion SaveCotizacionDiversos(Cotizacion cotizacion);
        Cotizacion SaveCotizacionRC(Cotizacion cotizacion);
        Cotizacion SaveCotizacionRCExtRecall(Cotizacion cotizacion);
        Cotizacion SaveCotizacionTransporte(Cotizacion cotizacion);
        //void SaveCotizacionTransporteCuota(double prima, int cotizacionID);

        Presentacion FindPresentacionCotizacionbyID(int cotizacionID, int usuarioID, bool isRC);
        PresentacionUbicacion FindPresentacionUbicacionbyID(int cotizacionID);
        List<Texto> FindTextobyCotizacionID(int cotizacionID);

        PresentacionTrans FindPresentacionTransCotizacionbyID(int cotizacionID, int usuarioID);

        SelectAdjustedRateRang_Result FindCotizacionRCRecallRate(int categoryID, int exposureTypeID, int limitID);
                
        void SaveTextobyCotizacionID(int cotizacionID, string valoresXML, string valoresAdicionalesXML);
        void Cotizar(int cotizacionID);

        Cotizacion FindCotizacionLogbyID(int cotizacionID);
        bool FindActivoCotizacionbyID(int cotizacionID);

        string FindRFCCotizacionbyID(int cotizacionID);
        void SaveCotizacionPagador(CotizacionPagador cotizacionPagador);
        Cotizacion SaveParamCotizacion(double comision, double otrosGastosAdq, double utilidad, double gastosAdm, int cotizacionID);
        void SaveEquiposbyCotizacionID(int cotizacionID, string equiposXML, string nombreArchivo);
        double FindGastosAdmCalculado(int cotizacionID, double cuotaDeseada);
    }
}
