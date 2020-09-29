using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Integration.wsPoliza;
using Domain.MainModule.Entities;

namespace Application.Integration.Translate
{
    public class TRClausula
    {
        public static List<PasoAne> ClausulaTOwsAne(List<SISEClausula_Result> entClausulas)
        {
            PasoAne wsAne;
            List<PasoAne> anexos = new List<PasoAne>();
            if (entClausulas.Count == 0)
                return null;

            foreach (SISEClausula_Result entClausula in entClausulas)
            {
                wsAne = new PasoAne();
                wsAne.Id_pv = entClausula.id_pv.ToString();
                wsAne.Cod_suc = entClausula.cod_suc.Value.ToString();
                wsAne.Cod_item = entClausula.cod_item.ToString();
                wsAne.Cod_ind_cob = entClausula.cod_ind_cob.ToString();
                wsAne.Cod_tipo_anexo = entClausula.cod_tipo_anexo.ToString();
                wsAne.Cod_anexo = entClausula.cod_anexo.Value.ToString();

                anexos.Add(wsAne);
            }

            return anexos;
        }
    }
}
