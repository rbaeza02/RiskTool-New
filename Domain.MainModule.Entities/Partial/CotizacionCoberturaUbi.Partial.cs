using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public partial class CotizacionCoberturaUbi
    {
        public string NombreCobertura { get; set; }
        public bool isPct_Mes { get; set; }
        public bool isPct { get; set; }
        public bool isMes { get; set; }
    }
}
