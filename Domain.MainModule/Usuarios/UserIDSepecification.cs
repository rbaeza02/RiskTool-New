using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Specification;
using Domain.MainModule.Entities;

namespace Domain.MainModule.Usuarios
{
    public class UserIDSepecification : Specification<Usuario>
    {
        int _UserID;


        public UserIDSepecification(int userID)
        {
            if (userID <= 0)
                throw new ArgumentNullException("UserID");

            _UserID = userID;
        }

        public override System.Linq.Expressions.Expression<Func<Usuario, bool>> SatisfiedBy()
        {
            Specification<Usuario> spec = new TrueSpecification<Usuario>();

            spec &= new DirectSpecification<Usuario>(c => c.UsuarioID == _UserID);

            return spec.SatisfiedBy();
        }
    }
}
