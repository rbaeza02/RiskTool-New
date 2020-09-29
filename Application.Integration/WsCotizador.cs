using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Integration.Translate;
using Domain.MainModule.Entities;
using Application.Integration.wsPoliza;

namespace Application.Integration
{
    public class WsCotizador
    {
        private wsPoliza.DataClient dt;

        public WsCotizador()
        {
            dt = new wsPoliza.DataClient();
        }

        public string GrabarCotizacion(SISEPol_Result poliza, SISEAge_Result agente, List<SISECob_Result> cob, List<SISEInc_Result> inc, SISETransporte_Result transporte,
            List<SISEObs_Result> obs, List<SISEEquipoDetalle_Result> detalle, List<SISEClausula_Result> clausula, List<SelectTextosPrimaPresentacion_Result> textos)
        {
            try
            {
                TRObs obsObject = new TRObs();

                List<PasoObs> texto;
                if (transporte == null)
                    texto = obsObject.ObsTOwsObs(obs, textos);
                else
                    texto = obsObject.ObsTOwsObsTR(obs);

                
                return dt.insertarCamposIntegracion(null, new List<wsPoliza.PasoAge>() { TRAgente.AgenteTOwsAgente(agente) },
                null, TRCob.CobTOwsCob(cob), null, transporte == null ? null : new List<wsPoliza.PasoTRANSPORTE>() { TRTransporte.TransporteTOwstransporte(transporte) },
                null, new List<wsPoliza.PasoPol>() { TRPoliza.PolizaTOwsPoliza(poliza) }, texto, null,
                TRInc.IncTOwsInc(inc), null, TRDetalle.DetalleTOwsDetalle(detalle), TRClausula.ClausulaTOwsAne(clausula));
                
                //return "001_7_00000197_01_0";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
           
        }

        
    }
}
