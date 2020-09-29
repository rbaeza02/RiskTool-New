using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core;
using Domain.Core.Specification;
using Domain.MainModule.Entities;

namespace Domain.MainModule.CotizacionCoberturaUbicaciones
{
    public interface ICotizacionCoberturaUbicacionRepository : IRepository<CotizacionCoberturaUbicacion>
    {
        List<CotizacionCoberturaUbicacion> FindCotizacionCoberturaUbicaciones(ISpecification<CotizacionCoberturaUbicacion> specification);
    }
}
