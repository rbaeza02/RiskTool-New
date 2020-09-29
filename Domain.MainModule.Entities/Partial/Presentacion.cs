using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public class Presentacion
    {
        public List<SelectCotizacionPresentacion_Result> DatosGenerales { get; set; }
        public List<SelectPrimasPresentacion_Result> Primas { get; set; }
        public List<SelectTextosPrimaPresentacion_Result> Textos { get; set; }
        public List<SelectResumenPresentacion_Result> Resumen { get; set; }
        public List<SelectEquipoPresentacion_Result> Equipos { get; set; }
        public List<SelectCotizacionPresentacionRC_Result> DatosGeneralesRC { get; set; }
        public List<SelectTextosPrimaPresentacionRC_Result> TextosRC { get; set; }
        public string MensajeError { get; set; }
    }
}
