
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.MainModule.Entities;
using Domain.Core.Specification;

namespace Domain.MainModule.WorkFlows
{
    public class ProcessIDSpecification    
      : Specification<workflow>
    {
        int _Id;

        public ProcessIDSpecification(int id)
        {
            if(id<=0)
                throw new ArgumentNullException("id");
            
            _Id = id;            
        }

        public override System.Linq.Expressions.Expression<Func<workflow, bool>> SatisfiedBy()
        {
            Specification<workflow> spec = new TrueSpecification<workflow>();

            spec &= new DirectSpecification<workflow>(c => c.procesoID == _Id && c.isActivo.Value);


            return spec.SatisfiedBy();
        }

        
    }
}
