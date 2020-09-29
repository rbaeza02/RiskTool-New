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
    public static class TRPoliza
    {
        public static PasoPol PolizaTOwsPoliza(SISEPol_Result entPoliza)
        {
            PasoPol wsPoliza = new PasoPol();
            wsPoliza.Cod_operacion = entPoliza.cod_operacion.ToString();
            wsPoliza.Pje_part = entPoliza.Pje_part.ToString();
            wsPoliza.Id_pv = entPoliza.id_pv.ToString();
            wsPoliza.Cod_suc = entPoliza.cod_suc.ToString();
            wsPoliza.Cod_ramo = entPoliza.cod_ramo.ToString();
            wsPoliza.Aaaa_endoso = entPoliza.aaaa_endoso.ToString();
            wsPoliza.Nro_endoso = entPoliza.nro_endoso.ToString();
            wsPoliza.Fec_vig_desde = entPoliza.fec_vig_desde;
            wsPoliza.Fec_vig_hasta = entPoliza.fec_vig_hasta;
            wsPoliza.Cod_grupo_endo = entPoliza.cod_grupo_endo.ToString();
            wsPoliza.Cod_tipo_endo = entPoliza.cod_tipo_endo.ToString();
            wsPoliza.Cod_tipo_poliza = entPoliza.cod_tipo_poliza.ToString();
            wsPoliza.Imp_suma_asegurada = Math.Round(entPoliza.imp_suma_asegurada.Value,2).ToString();
            wsPoliza.Imp_prima_me = Math.Round(entPoliza.imp_prima_me.Value, 2).ToString();
            wsPoliza.Imp_deremi_me = Math.Round(entPoliza.imp_deremi_me.Value, 2).ToString();
            wsPoliza.Imp_iva_me = Math.Round(entPoliza.imp_iva_me.Value, 2).ToString();
            wsPoliza.Imp_recfin_me = Math.Round(entPoliza.imp_recfin_me.Value, 2).ToString();
            wsPoliza.Imp_premio_me = Math.Round(entPoliza.imp_premio_me.Value, 2).ToString();
            wsPoliza.Cod_moneda = entPoliza.cod_moneda.ToString();
            //wsPoliza.cod_dir_envio = entPoliza.cod_dir_envio.ToString();
            wsPoliza.Pje_iva = entPoliza.pje_iva.ToString();
            wsPoliza.Pje_recargo = Math.Round(entPoliza.pje_recargo.Value, 6).ToString();
            wsPoliza.Pje_gastos_emision = entPoliza.pje_gastos_emision;
            wsPoliza.Pol_estado = entPoliza.pol_estado.ToString();
            wsPoliza.Cod_periodo_pago = entPoliza.cod_periodo_pago.Value.ToString();
            wsPoliza.Cod_usuario = entPoliza.cod_usuario.ToString();
            wsPoliza.Fec_tarifa = entPoliza.fec_tarifa;
            wsPoliza.Cod_nivel_facturacion = entPoliza.cod_nivel_facturacion.ToString();
            wsPoliza.Cod_nivel_imp_factura = entPoliza.cod_nivel_imp_factura.ToString();
            wsPoliza.Txt_RFC = entPoliza.RFC;
            wsPoliza.Cod_pto_vta = entPoliza.Cod_pto_vta.ToString();
            wsPoliza.Cod_clase_riesgo = entPoliza.cod_clase_riesgo.ToString();
            wsPoliza.Cod_tipo_riesgo = entPoliza.cod_tipo_riesgo.ToString();
            wsPoliza.Cod_Sus = entPoliza.cod_sus;
            wsPoliza.Txt_RFC_Pagador = entPoliza.txt_RFC_Pagador;
            wsPoliza.Cod_conducto = entPoliza.Cod_conducto;
            return wsPoliza;
        }

    }
}