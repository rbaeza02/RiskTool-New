using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public partial class CotizacionPagador
    {
        public string COD_BANCO_EMI { get; set; }
        public string COD_CONDUCTO { get; set; }

        public string Conducto { get; set; }
        public string Banco { get; set; }


    }
}
