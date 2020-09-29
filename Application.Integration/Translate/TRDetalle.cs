using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Integration.wsPoliza;
using Domain.MainModule.Entities;

namespace Application.Integration.Translate
{
    public class TRDetalle
    {
        public static List<PasoDetalle> DetalleTOwsDetalle(List<SISEEquipoDetalle_Result> entDetalles)
        {
            PasoDetalle wsDetalle;
            List<PasoDetalle> detalles = new List<PasoDetalle>();
            if (entDetalles.Count == 0)
                return null;

            foreach (SISEEquipoDetalle_Result entDetalle in entDetalles)
            {
                wsDetalle = new PasoDetalle();
                wsDetalle.Anio = entDetalle.anio.ToString();
                wsDetalle.Cod_ind_cob = entDetalle.cod_ind_cob.ToString();
                wsDetalle.Descripcion = entDetalle.Descripcion;
                wsDetalle.ID_PV = entDetalle.ip_pv.ToString();
                wsDetalle.Limite = entDetalle.Limite.ToString();
                wsDetalle.Marca = entDetalle.Marca;
                wsDetalle.NumConse = entDetalle.NroSerie;
                
                detalles.Add(wsDetalle);
            }

            return detalles;
        }
    }
}
