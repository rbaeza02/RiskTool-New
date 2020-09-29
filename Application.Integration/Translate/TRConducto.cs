using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Integration.wsPoliza;
using Domain.MainModule.Entities;

namespace Application.Integration.Translate
{
    public class TRConducto
    {
        public static List<CotizacionPagador> wsConductoTOCotizacionPagador(List<wsSistran.Conducto> wsConductos)
        {
            List<CotizacionPagador> pagadores = new List<CotizacionPagador>();
            CotizacionPagador pagador;

            foreach (wsSistran.Conducto conducto in wsConductos)
            {
                pagador = new CotizacionPagador();
                pagador.NroTarjeta = conducto.NUM_TJTA;
                pagador.COD_BANCO_EMI = conducto.COD_BANCO_EMI;
                pagador.COD_CONDUCTO = conducto.COD_CONDUCTO;
                pagador.SISEind_conducto = Convert.ToInt32(conducto.IND_CONDUCTO);
                pagador.RFC = conducto.RFC;
                pagador.nombre = conducto.TXT_NOM_PAGADOR;                
                pagadores.Add(pagador);
            }

            return pagadores;
        }
    }
}
