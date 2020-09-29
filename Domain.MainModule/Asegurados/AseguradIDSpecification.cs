using Domain.Core.Specification;
using Domain.MainModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Asegurados
{
    public class AseguradIDSpecification: Specification<Asegurado>
    {
         int _AseguradoID;

         public AseguradIDSpecification(int aseguradoID)
        {
            if (aseguradoID <= 0)
                throw new ArgumentNullException("aseguradoID");
            _AseguradoID = aseguradoID;
        }

        public override System.Linq.Expressions.Expression<Func<Asegurado, bool>> SatisfiedBy()
        {
            Specification<Asegurado> spec = new TrueSpecification<Asegurado>();

            spec &= new DirectSpecification<Asegurado>(c => c.AseguradoID == _AseguradoID);

            return spec.SatisfiedBy();
        }
    }
}
