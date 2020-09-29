using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.MainModule.Entities;
using Application.Integration.wsPoliza;

namespace Application.Integration.Translate
{
    public static class TRAgente
    {
        public static PasoAge AgenteTOwsAgente(SISEAge_Result entAgente)
        {
            PasoAge wsAgente = new PasoAge();
            wsAgente.Id_pv = entAgente.id_pv.ToString();
            wsAgente.Cod_suc = entAgente.cod_suc.ToString();
            wsAgente.Cod_ramo = entAgente.cod_ramo.ToString();
            wsAgente.Cod_tipo_agente = entAgente.cod_tipo_agente.ToString();
            wsAgente.Cod_agente = entAgente.cod_agente.ToString();
            wsAgente.Pje_comis_normal = entAgente.Pje_comis_normal.ToString();
            wsAgente.Pje_comis_extra = entAgente.Pje_comis_extra.ToString();
            wsAgente.Imp_comis_normal_me = Math.Round(entAgente.imp_comis_normal_me.Value, 2).ToString();
            return wsAgente;
        }

    }
}