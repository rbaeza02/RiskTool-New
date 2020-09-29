using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Specification;
using Domain.MainModule.Entities;

namespace Domain.MainModule.Ubicaciones
{
    public class AseguradoIDSpecification : Specification<Ubicacion>
    {
        int _AseguradoID;

        public AseguradoIDSpecification(int aseguradoID)
        {            
            _AseguradoID = aseguradoID;
        }

        public override System.Linq.Expressions.Expression<Func<Ubicacion, bool>> SatisfiedBy()
        {
            Specification<Ubicacion> spec = new TrueSpecification<Ubicacion>();

            spec &= new DirectSpecification<Ubicacion>(c => c.AseguradoID == _AseguradoID);

            return spec.SatisfiedBy();
        }
    }
}
