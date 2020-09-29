using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.MainModule.Entities
{
    public partial class CotizacionRCAdicional
    {
        public SelectList EvaluacionList { get; set; }
        public SelectList InclinacionList { get; set; }
    }
}
