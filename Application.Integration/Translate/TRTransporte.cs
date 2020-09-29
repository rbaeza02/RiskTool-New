using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Integration.wsPoliza;
using Domain.MainModule.Entities;

namespace Application.Integration.Translate
{
    public static class TRTransporte
    {
        public static PasoTRANSPORTE TransporteTOwstransporte(SISETransporte_Result entTransporte)
        {
            PasoTRANSPORTE wsTransporte = new PasoTRANSPORTE();
            wsTransporte.Id_pv = entTransporte.id_pv.ToString();
            wsTransporte.Cod_item = entTransporte.cod_item.ToString();
            wsTransporte.Cod_tipo_seg = entTransporte.cod_tipo_seg;
            wsTransporte.Cod_tipo_merc = entTransporte.cod_tipo_merc;
            wsTransporte.Cod_medio_trans = entTransporte.cod_medio_trans.ToString();
            wsTransporte.Cod_origen_dest = entTransporte.cod_origen_dest;
            wsTransporte.Cod_tipo_prono = entTransporte.cod_tipo_prono;
            wsTransporte.Imp_pronostico = entTransporte.imp_pronostico.ToString();
            wsTransporte.Imp_prima_dep = entTransporte.imp_prima_dep.ToString();
            wsTransporte.Imp_limite_maxE = entTransporte.imp_limite_maxE.ToString();
            return wsTransporte;
        }
    }
}
