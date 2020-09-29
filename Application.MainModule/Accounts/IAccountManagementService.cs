using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.MainModule.Entities;

namespace Application.MainModule.Accounts
{
    public interface IAccountManagementService
    {
        Usuario CheckUsuario(string usuario);
        List<Usuario> GetAllUsuarios();

        void AddUsuario(Usuario user);
        Usuario FindUsuariobyID(int usuarioID);

        List<SelectAccionUser_Result> GetAccionUsuario(int usuarioID);

        List<Rol> GetAllRoles();
        Rol FindAccionesbyRolID(int rolID);
        List<string> FindControllerbyRolID(int rolID);
        List<Accion> FindAccionbyController(int rolID, string controller);

        void DeleteAccionbyRolID(int rolID, string valoresXML);
        int AddAccionbyRolID(int rolID, int accionID);
    }
}
