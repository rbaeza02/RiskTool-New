using Domain.Core.Specification;
using Domain.MainModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Asegurados
{
    public class FiltroSpecification: Specification<Asegurado>
    {
        string _RFC, _RazonSocial, _Nombre, _Apellido1, _Apellido2;
        public FiltroSpecification(string rfc, string razonSocial, string nombre, string apellido1, string apellido2)
        {            
            _RFC = rfc;
            _RazonSocial = razonSocial;
            _Nombre = nombre;
            _Apellido1 = apellido1;
            _Apellido2 = apellido2;
        }

        public override System.Linq.Expressions.Expression<Func<Asegurado, bool>> SatisfiedBy()
        {
            Specification<Asegurado> spec = new TrueSpecification<Asegurado>();

            if (!string.IsNullOrEmpty(_RFC))
                spec &= new DirectSpecification<Asegurado>(c => c.RFC.Contains(_RFC));

            if (!string.IsNullOrEmpty(_RazonSocial))
                spec &= new DirectSpecification<Asegurado>(c => c.RazonSocial.Contains(_RazonSocial));

            if (!string.IsNullOrEmpty(_Nombre))
                spec &= new DirectSpecification<Asegurado>(c => c.Nombres.Contains(_Nombre));

            if (!string.IsNullOrEmpty(_Apellido1))
                spec &= new DirectSpecification<Asegurado>(c => c.Apellido1.Contains(_Apellido1));

            if (!string.IsNullOrEmpty(_Apellido2))
                spec &= new DirectSpecification<Asegurado>(c => c.Apellido2.Contains(_Apellido2));

            return spec.SatisfiedBy();
        }
    }
}
