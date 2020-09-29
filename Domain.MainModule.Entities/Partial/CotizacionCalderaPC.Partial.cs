using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.MainModule.Entities
{
    public partial class CotizacionCalderaPC
    {
        public SelectList EqReservaList { get; set; }
        public SelectList DeducibleList { get; set; }
        public SelectList PeriodoList { get; set; }
        public SelectList RefCriticasList { get; set; }
    }
}
