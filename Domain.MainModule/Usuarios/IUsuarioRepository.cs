using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core;
using Domain.Core.Specification;
using Domain.MainModule.Entities;

namespace Domain.MainModule.Usuarios
{
    public interface IUsuarioRepository: IRepository<Usuario>
    {
        Usuario FindUser(ISpecification<Usuario> specification);
        int LastUserID();
        List<SelectAccionUser_Result> GetAccionUsuario(int usuarioID);

        List<Rol> GetRoles();

        Rol FindAccionesbyRolID(int rolID);
        List<string> GetControllerbyRol(int rolID);
        List<Accion> GetAccionesbyController(int rolID, string controller);

        int execDeleteAccionRol(int rolID, string vectorXML);
        int execAddAccionRol(int rolID, int accionID);

        List<Usuario> GetAllUsuario();

    }
}
