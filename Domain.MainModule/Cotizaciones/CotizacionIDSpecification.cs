using Domain.Core.Specification;
using Domain.MainModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Cotizaciones
{
    public class CotizacionIDSpecification: Specification<Cotizacion>
    {
        int _CotizacionID;

        public CotizacionIDSpecification(int cotizacionID)
        {
            _CotizacionID = cotizacionID;
        }

        public override System.Linq.Expressions.Expression<Func<Cotizacion, bool>> SatisfiedBy()
        {
            Specification<Cotizacion> spec = new TrueSpecification<Cotizacion>();

            spec &= new DirectSpecification<Cotizacion>(c => c.CotizacionID == _CotizacionID);

            return spec.SatisfiedBy();
        }
    }
}
