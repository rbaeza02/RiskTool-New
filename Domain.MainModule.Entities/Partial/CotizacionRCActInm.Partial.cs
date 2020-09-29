using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.MainModule.Entities
{
    public partial class CotizacionRCActInm
    {
        public SelectList GrupoIncendioList { get; set; }
        public SelectList TipoRiesgoList { get; set; }
        public double MaxPagoVoluntarioUrgenciaMedica { get; set; }
        public SelectList CruzadaList { get; set; }
        public int? DeducibleValorID { get; set; }
        public int? DeducibleUnidadID { get; set; }
        public int? DeducibleAplicaID { get; set; }
        public int? DeducibleValorIDMin { get; set; }
        public int? DeducibleUnidadIDMin { get; set; }
        public int? ArrendatarioDeducibleValorID { get; set; }
        public int? ArrendatarioDeducibleUnidadID { get; set; }
        public int? ArrendatarioDeducibleAplicaID { get; set; }
        public int? ArrendatarioDeducibleValorIDMin { get; set; }
        public int? ArrendatarioDeducibleUnidadIDMin { get; set; }
        public int? BienesDeducibleValorID { get; set; }
        public int? BienesDeducibleUnidadID { get; set; }
        public int? BienesDeducibleAplicaID { get; set; }
        public int? BienesDeducibleValorIDMin { get; set; }
        public int? BienesDeducibleUnidadIDMin { get; set; }
        public int? CruzadaDeducibleValorID { get; set; }
        public int? CruzadaDeducibleUnidadID { get; set; }
        public int? CruzadaDeducibleAplicaID { get; set; }
        public int? CruzadaDeducibleValorIDMin { get; set; }
        public int? CruzadaDeducibleUnidadIDMin { get; set; }
        public int? ContaminacionDeducibleValorID { get; set; }
        public int? ContaminacionDeducibleUnidadID { get; set; }
        public int? ContaminacionDeducibleAplicaID { get; set; }
        public int? ContaminacionDeducibleValorIDMin { get; set; }
        public int? ContaminacionDeducibleUnidadIDMin { get; set; }
        public int? AsumidaDeducibleValorID { get; set; }
        public int? AsumidaDeducibleUnidadID { get; set; }
        public int? AsumidaDeducibleAplicaID { get; set; }
        public int? AsumidaDeducibleValorIDMin { get; set; }
        public int? AsumidaDeducibleUnidadIDMin { get; set; }
        public int? ContIndependienteDeducibleValorID { get; set; }
        public int? ContIndependienteDeducibleUnidadID { get; set; }
        public int? ContIndependienteDeducibleAplicaID { get; set; }
        public int? ContIndependienteDeducibleValorIDMin { get; set; }
        public int? ContIndependienteDeducibleUnidadIDMin { get; set; }
        
    }
}
