using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core;
using Domain.Core.Specification;
using Domain.MainModule.Entities;

namespace Domain.MainModule.Personas
{
    public interface IPersonaRepository : IRepository<Persona>
    {
        Persona GetPersonabyRFC(string rfc);
        int LastPersonaID();
        int execUpdateBeneficiarioCotizacion(string datosXML, int cotizacionID, int ubicacionID);

        int GetNumberBeneficiarios(int cotizacionID);
    }
}
