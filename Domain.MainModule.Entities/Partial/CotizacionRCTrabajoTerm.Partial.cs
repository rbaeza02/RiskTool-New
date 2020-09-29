using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.MainModule.Entities
{
    public partial class CotizacionRCTrabajoTerm
    {
        public SelectList GiroList { get; set; }

        public int? DeducibleValorID { get; set; }
        public int? DeducibleUnidadID { get; set; }
        public int? DeducibleAplicaID { get; set; }
        public int? DeducibleValorIDMin { get; set; }
        public int? DeducibleUnidadIDMin { get; set; }
        public int? UnionMezclaDeducibleValorID { get; set; }
        public int? UnionMezclaDeducibleUnidadID { get; set; }
        public int? UnionMezclaDeducibleAplicaID { get; set; }
        public int? UnionMezclaDeducibleValorIDMin { get; set; }
        public int? UnionMezclaDeducibleUnidadIDMin { get; set; }
    }
}
