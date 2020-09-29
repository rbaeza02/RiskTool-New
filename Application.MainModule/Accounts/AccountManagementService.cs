using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core;
using Domain.MainModule.Entities;
using Domain.MainModule.Usuarios;
using Domain.MainModule.Catalogos;

namespace Application.MainModule.Accounts
{
    public class AccountManagementService: IAccountManagementService
    {
        IUsuarioRepository _userRepository;
        ICatalogoRepository _catalogoRepository;

        public AccountManagementService(IUsuarioRepository userRepository, ICatalogoRepository catalogoRepository)
        {
            if (userRepository == (IUsuarioRepository)null)
                throw new ArgumentNullException("userRepository");

            if (catalogoRepository == (ICatalogoRepository)null)
                throw new ArgumentNullException("catalogoRepository");

            _userRepository = userRepository;
            _catalogoRepository = catalogoRepository;
        }

        public Usuario CheckUsuario(string usuario)
        {
            UserNameSepecification usuarioSpec = new UserNameSepecification(usuario);
            return _userRepository.FindUser(usuarioSpec);

            //return new Usuario("jorge") { };
        }


        public Usuario FindUsuariobyID(int usuarioID)
        {
            if (usuarioID == 0)
            {
                Usuario usuarioNuevo = new Usuario();
                UsuarioSubLinea usuarioSub;
                usuarioNuevo.isActivo = true;

                //List<SubLineaNegocio> subLinea = _catalogoRepository.GetSubLineaNegociobyLimit();
                _catalogoRepository.GetSubLineaNegociobyLimit().ForEach(x => {
                    usuarioSub = new UsuarioSubLinea() { UsuarioID = usuarioID};
                    usuarioSub.bk_tc_SubLineaNegocio = x;
                    usuarioSub.Limite = 0;
                    usuarioNuevo.bk_tr_UsuarioSubLinea.Add(usuarioSub);
                });

                //usuarioNuevo.bk_tr_UsuarioSubLinea.Add()

                return usuarioNuevo;
                //return new Usuario() { isActivo = true };
            }
                

            UserIDSepecification userIDSpec = new UserIDSepecification(usuarioID);
            return _userRepository.FindUser(userIDSpec);
        }

        public void AddUsuario(Usuario user)
        {
            //Add user
            IUnitOfWork unitOfWork = _userRepository.UnitOfWork as IUnitOfWork;

            if (user.UsuarioID > 0)
            {
                foreach(UsuarioSubLinea item in user.bk_tr_UsuarioSubLinea)
                {
                    item.ChangeTracker.ChangeTrackingEnabled = true;
                    item.ChangeTracker.State = Domain.Core.Entities.ObjectState.Modified;
                }
                _userRepository.Modify(user);
            }
            else
            {
                user.UsuarioID = _userRepository.LastUserID() + 1; //Last ID + 1
                user.isActivo = true;
                _userRepository.Add(user);
            }
            unitOfWork.Commit();
        }


        public List<Usuario> GetAllUsuarios()
        {
            return _userRepository.GetAllUsuario().ToList();
        }

        public List<SelectAccionUser_Result> GetAccionUsuario(int usuarioID)
        {
            return _userRepository.GetAccionUsuario(usuarioID);
        }

        public List<Rol> GetAllRoles()
        {
            return _userRepository.GetRoles().ToList();
        }

        public Rol FindAccionesbyRolID(int rolID)
        {
            return _userRepository.FindAccionesbyRolID(rolID);
        }

        public List<string> FindControllerbyRolID(int rolID)
        {
            return _userRepository.GetControllerbyRol(rolID);
        }

        public List<Accion> FindAccionbyController(int rolID, string controller)
        {
            return _userRepository.GetAccionesbyController(rolID, controller);
        }

        public void DeleteAccionbyRolID(int rolID, string valoresXML)
        {
            _userRepository.execDeleteAccionRol(rolID, valoresXML);
        }

        public int AddAccionbyRolID(int rolID, int accionID)
        {
            return _userRepository.execAddAccionRol(rolID, accionID);
        }
    }
}
