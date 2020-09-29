using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core;
using Domain.Core.Specification;
using Domain.MainModule.Entities;

namespace Domain.MainModule.CotizacionCoberturas
{
    public interface ICotizacionCoberturaRepository : IRepository<CotizacionCobertura>
    {
        List<CotizacionCobertura> FindCotizacionCoberturas(ISpecification<CotizacionCobertura> specification);
        int LastCotizacionCoberturaID();
        int execUpdateCotizacionCoberturaUbicacion(int cotizacionID);
    }
}
