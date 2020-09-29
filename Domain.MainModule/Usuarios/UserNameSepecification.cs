using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Specification;
using Domain.MainModule.Entities;

namespace Domain.MainModule.Usuarios
{
    public class UserNameSepecification : Specification<Usuario>
    {
        string _UserName;        

        public UserNameSepecification(string userName)
        {
            if (userName == string.Empty)
                throw new ArgumentNullException("userName");
            
            _UserName = userName;            
        }

        public override System.Linq.Expressions.Expression<Func<Usuario, bool>> SatisfiedBy()
        {
            Specification<Usuario> spec = new TrueSpecification<Usuario>();

            spec &= new DirectSpecification<Usuario>(c => c.NombreUsuario == _UserName);

            return spec.SatisfiedBy();
        }
    }
}
