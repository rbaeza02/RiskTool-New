using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public partial class SICClassMap
    {
        public string NombreCompleto { get { return Codigo + " - " + nombreING; } }

        
    }
}
