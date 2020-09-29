using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Integration.wsPoliza;
using Domain.MainModule.Entities;

namespace Application.Integration.Translate
{
    public static class TRCob
    {
        public static List<PasoCob> CobTOwsCob(List<SISECob_Result> entCoberturas)
        {
            PasoCob wsCob;
            List<PasoCob> wsCoberturas = new List<PasoCob>();
            
            foreach (SISECob_Result entCob in entCoberturas)
            {
                wsCob = new PasoCob();
                wsCob.Id_pv = entCob.id_pv.ToString();
                wsCob.Cod_item = entCob.cod_item.ToString();
                wsCob.Cod_ind_cob = entCob.cod_ind_cob.ToString();
                wsCob.Cod_ramo = entCob.cod_ramo.ToString();
                wsCob.Cod_tarifa = entCob.cod_tarifa.ToString();
                wsCob.Cod_tipo_tasa = entCob.cod_tipo_tasa.ToString();
                wsCob.Cod_giro_negocio = entCob.cod_giro_negocio;
                wsCob.Cod_objeto = entCob.cod_objeto;
                wsCob.Imp_suma_asegurable = entCob.imp_suma_asegurable.ToString();
                wsCob.Imp_suma_aseg = entCob.imp_suma_aseg.ToString();
                wsCob.Imp_deduc = entCob.imp_deduc.ToString();
                wsCob.Imp_prima = entCob.imp_prima.ToString();
                wsCob.Imp_prima_tasa = entCob.imp_prima_tasa.ToString();
                wsCob.Pje_inflacion = entCob.pje_inflacion.ToString();
                wsCob.Pje_inflacion_prima = entCob.pje_inflacion_prima.ToString();
                wsCob.Imp_suma_inflacion = entCob.imp_suma_inflacion.ToString();
                wsCob.Imp_prima_inflacion = entCob.imp_prima_inflacion.ToString();
                wsCob.Sn_acum_prima_total = entCob.Sn_acum_prima_total.ToString();
                wsCob.Sn_acum_suma_total = entCob.Sn_acum_suma_total.ToString();
                wsCob.Pje_tasa = entCob.Pje_tasa.ToString();
                wsCob.Cod_unidad_deduc = entCob.Cod_unidad_deduc.ToString();
                wsCob.Cod_deduc_aplica = entCob.Cod_deduc_aplica.ToString();
                wsCob.Txt_detalle = entCob.txt_detalle;
                wsCoberturas.Add(wsCob);
            }

            return wsCoberturas;
        }
    }
}
