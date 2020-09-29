using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Specification;
using Domain.MainModule.Entities;

namespace Domain.MainModule.CotizacionCoberturas
{
    public class CotizacionIDSpecification : Specification<CotizacionCobertura>
    {
        int _CotizacionID;

        public CotizacionIDSpecification(int cotizacionID)
        {
            _CotizacionID = cotizacionID;
        }

        public override System.Linq.Expressions.Expression<Func<CotizacionCobertura, bool>> SatisfiedBy()
        {
            Specification<CotizacionCobertura> spec = new TrueSpecification<CotizacionCobertura>();

            spec &= new DirectSpecification<CotizacionCobertura>(c => c.CotizacionID == _CotizacionID);

            return spec.SatisfiedBy();
        }
    }
}
