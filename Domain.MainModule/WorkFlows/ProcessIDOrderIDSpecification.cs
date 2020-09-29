
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.MainModule.Entities;
using Domain.Core.Specification;

namespace Domain.MainModule.WorkFlows
{
    public class ProcessIDOrderIDSpecification
      : Specification<workflow>
    {
        int _Id;
        int _Order;

        public ProcessIDOrderIDSpecification(int id, int order)
        {
            if(id<=0)
                throw new ArgumentNullException("id");

            if (order <= 0)
                throw new ArgumentNullException("orden");
            
            _Id = id;
            _Order = order;
        }

        public override System.Linq.Expressions.Expression<Func<workflow, bool>> SatisfiedBy()
        {
            Specification<workflow> spec = new TrueSpecification<workflow>();

            spec &= new DirectSpecification<workflow>(c => c.procesoID == _Id && c.orden == _Order);

            return spec.SatisfiedBy();
        }

        
    }
}
