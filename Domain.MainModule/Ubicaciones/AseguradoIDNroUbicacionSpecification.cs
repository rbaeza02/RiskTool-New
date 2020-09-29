using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Specification;
using Domain.MainModule.Entities;

namespace Domain.MainModule.Ubicaciones
{
    public class AseguradoIDNroUbicacionSpecification : Specification<Ubicacion>
    {
        int _AseguradoID, _NroUbicacion;

        public AseguradoIDNroUbicacionSpecification(int aseguradoID, int nroUbicacion)
        {            
            _AseguradoID = aseguradoID;
            _NroUbicacion = nroUbicacion;
        }

        public override System.Linq.Expressions.Expression<Func<Ubicacion, bool>> SatisfiedBy()
        {
            Specification<Ubicacion> spec = new TrueSpecification<Ubicacion>();

            spec &= new DirectSpecification<Ubicacion>(c => c.AseguradoID == _AseguradoID && c.nroUbicacion == _NroUbicacion);

            return spec.SatisfiedBy();
        }
    }
}
