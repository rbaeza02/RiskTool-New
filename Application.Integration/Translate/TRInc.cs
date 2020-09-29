using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Integration.wsPoliza;
using Domain.MainModule.Entities;

namespace Application.Integration.Translate
{
    public static class TRInc
    {
        public static List<PasoInc> IncTOwsInc(List<SISEInc_Result> entIncisos)
        {
            PasoInc wsInc;
            List<PasoInc> wsIncisos = new List<PasoInc>();

            foreach (SISEInc_Result entInc in entIncisos)
            {
                wsInc = new PasoInc();
                wsInc.Id_pv = entInc.id_pv.ToString();
                wsInc.Cod_item = entInc.cod_item.ToString();
                wsInc.Cod_ind_cob = entInc.cod_ind_cob.ToString();
                wsInc.Cod_giro_negocio = entInc.cod_giro_negocio;
                wsInc.Cod_pais = entInc.cod_pais.ToString();
                wsInc.Cod_dpto = entInc.cod_dpto.ToString();
                wsInc.Cod_municipio = entInc.cod_municipio.ToString();
                wsInc.Cod_ciudad = entInc.cod_ciudad.ToString();
                wsInc.Cod_colonia = entInc.cod_colonia.ToString();
                wsInc.Txt_direccion = entInc.txt_direccion;
                wsInc.Nro_exterior = entInc.nro_exterior;
                wsInc.Nro__interior = entInc.nro_interior;
                wsInc.Cod_postal = entInc.cod_postal;
                wsInc.Cod_hazard_grade = entInc.cod_hazard_grade.ToString();
                wsInc.Cod_constr = entInc.cod_constr;
                wsInc.Imp_deremi_me = Math.Round(entInc.imp_deremi_me.Value,2).ToString();
                wsInc.Imp_iva_me = Math.Round(entInc.imp_iva_me.Value,2).ToString();
                wsInc.Imp_premio_me = Math.Round(entInc.imp_premio_me.Value,2).ToString();
                wsInc.Imp_participa_me = Math.Round(entInc.Imp_participa_me.Value,2).ToString();
                wsInc.Imp_recfin_me = Math.Round(entInc.imp_recfin_me.Value,2).ToString();
                wsInc.Cnt_pisos = entInc.cnt_pisos.ToString();
                wsInc.Cod_SIC = entInc.cod_SIC;
                wsInc.Cnt_pisos_sot = entInc.cnt_pisos_sot.ToString();
                wsInc.Aaaa_construccion = entInc.aaaa_construccion.ToString();
                wsInc.Zona_amis_terremoto = entInc.zona_amis_terremoto.ToString();
                wsInc.Zona_amis_huracan = entInc.zona_amis_huracan.ToString();
                wsInc.Cod_benef_1 = entInc.cod_benef_1.ToString();
                wsInc.Cod_tipo_benef1 = entInc.cod_tipo_benef1.ToString();
                wsInc.Txt_nombre_benef1 = entInc.txt_nombre_benef1;
                wsInc.Cod_benef_2 = entInc.cod_benef_2.ToString();
                wsInc.Cod_tipo_benef2 = entInc.cod_tipo_benef2.ToString();
                wsInc.Txt_nombre_benef2 = entInc.txt_nombre_benef2;
                wsInc.Cod_benef_3 = entInc.cod_benef_3.ToString();
                wsInc.Cod_tipo_benef3 = entInc.cod_tipo_benef3.ToString();
                wsInc.Txt_nombre_benef3 = entInc.txt_nombre_benef3;

                wsIncisos.Add(wsInc);
            }



            return wsIncisos;
        }
    }
}
