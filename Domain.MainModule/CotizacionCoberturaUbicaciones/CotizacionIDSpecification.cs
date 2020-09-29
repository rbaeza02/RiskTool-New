using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Specification;
using Domain.MainModule.Entities;

namespace Domain.MainModule.CotizacionCoberturaUbicaciones
{
    public class CotizacionIDSpecification : Specification<CotizacionCoberturaUbicacion>
    {
        int _CotizacionID;

        public CotizacionIDSpecification(int cotizacionID)
        {
            _CotizacionID = cotizacionID;
        }

        public override System.Linq.Expressions.Expression<Func<CotizacionCoberturaUbicacion, bool>> SatisfiedBy()
        {
            Specification<CotizacionCoberturaUbicacion> spec = new TrueSpecification<CotizacionCoberturaUbicacion>();

            spec &= new DirectSpecification<CotizacionCoberturaUbicacion>(c => c.bk_tr_CotizacionCobertura.CotizacionID == _CotizacionID);

            return spec.SatisfiedBy();
        }
    }
}
