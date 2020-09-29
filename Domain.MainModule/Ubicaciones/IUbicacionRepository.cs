using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core;
using Domain.Core.Specification;
using Domain.MainModule.Entities;

namespace Domain.MainModule.Ubicaciones
{
    public interface IUbicacionRepository : IRepository<Ubicacion>
    {
        List<Ubicacion> FindUbicaciones(ISpecification<Ubicacion> specification, int nroPagina, int tamaño);
        int LastUbicacionID();
        int LastNroUbicacion(int aseguradoID);
        int TotalUbicaciones(ISpecification<Ubicacion> specification);
        List<Ubicacion> FindUbicacionesValores(int cotizacionID);
        Ubicacion FindUbicacion(int ubicacionID);
        List<Table> GetUbicacionesbyCotizacionID(int cotizacionID);

    }
}
