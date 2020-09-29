using Domain.Core.Specification;
using Domain.MainModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Cotizaciones
{
    public class DesdeHastaRFCSpecification: Specification<Cotizacion>
    {
        Nullable<DateTime> _Desde, _Hasta;
        string _RFC, _Nombre, _NroPol;
        int _Usuario;

        public DesdeHastaRFCSpecification(Nullable<DateTime> desde, Nullable<DateTime> hasta, string rfc, int usuarioID, string nombre, string nroPol)
        {            
            _RFC = rfc;
            _Desde = desde;
            _Hasta = hasta;
            _Usuario = usuarioID;
            _Nombre = nombre;
            _NroPol = nroPol;
        }

        public override System.Linq.Expressions.Expression<Func<Cotizacion, bool>> SatisfiedBy()
        {
            int nroPol;
            Specification<Cotizacion> spec = new TrueSpecification<Cotizacion>();

            if (_Desde != null)
                spec &= new DirectSpecification<Cotizacion>(c => c.VigenciaInicio >= _Desde);
            
            if (_Hasta != null)
                spec &= new DirectSpecification<Cotizacion>(c => c.VigenciaFin <= _Hasta);

            if (!string.IsNullOrEmpty(_NroPol))
            {
                if (int.TryParse(_NroPol,out nroPol))
                    spec &= new DirectSpecification<Cotizacion>(c => c.nroPoliza == nroPol);
            }

            if (!string.IsNullOrEmpty(_RFC))
                spec &= new DirectSpecification<Cotizacion>(c => c.bk_tc_Asegurado.RFC.Equals(_RFC));

            if (!string.IsNullOrEmpty(_Nombre))
                spec &= new DirectSpecification<Cotizacion>(c => c.bk_tc_Asegurado.Nombres.Contains(_Nombre) || 
                    c.bk_tc_Asegurado.Apellido1.Contains(_Nombre) || c.bk_tc_Asegurado.Apellido2.Contains(_Nombre) ||
                    c.bk_tc_Asegurado.RazonSocial.Contains(_Nombre));

            spec &= new DirectSpecification<Cotizacion>(c => c.usuarioid == _Usuario);

            return spec.SatisfiedBy();
        }
    }
}
