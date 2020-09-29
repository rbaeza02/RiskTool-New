using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public partial class SIC
    {
        public string NombreCompleto
        {
            get { return SISECod_giro_negocio + " - " + NombreESP; }
        }
    }
}
