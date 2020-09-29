using Domain.Core.Specification;
using Domain.MainModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Asegurados
{
    public class RFCSpecification: Specification<Asegurado>
    {
         string _RFC;

        public RFCSpecification(string rfc)
        {            
            _RFC = rfc;
        }

        public override System.Linq.Expressions.Expression<Func<Asegurado, bool>> SatisfiedBy()
        {
            Specification<Asegurado> spec = new TrueSpecification<Asegurado>();

            spec &= new DirectSpecification<Asegurado>(c => c.RFC.Equals(_RFC));

            return spec.SatisfiedBy();
        }
    }
}
