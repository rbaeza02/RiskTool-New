using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.MainModule.Entities;
using Domain.Core.Specification;

namespace Domain.MainModule.Asegurados
{
    public interface IAseguradoRepository : IRepository<Asegurado>    
    {
        Asegurado FindAsegurado(ISpecification<Asegurado> specification);
        int LastAseguradoID();
        List<Asegurado> FindAseguradobyFiltro(ISpecification<Asegurado> specification);
        
    }
}
