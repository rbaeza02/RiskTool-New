using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Specification;
using Domain.MainModule.Entities;
using Domain.MainModule.Usuarios;
using Infrastructure.CrossCutting.Logging;
using Infrastructure.Data.Core;
using Infrastructure.Data.MainModule.Resources;
using Infrastructure.Data.MainModule.UnitOfWork;
using Infrastructure.Data.Core.Extensions;
using Domain.Core.Entities;
using System.Collections.ObjectModel;

namespace Infrastructure.Data.MainModule.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IMainModuleUnitOfWork unitOfWork, ITraceManager traceManager) : base(unitOfWork, traceManager) { }

        public Usuario FindUser(ISpecification<Usuario> specification)
        {
            //validate specification
            if (specification == (ISpecification<Usuario>)null)
                throw new ArgumentNullException("User specification");

            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Usuarios
                                    .Where(specification.SatisfiedBy())
                                    .Include(x => x.bk_tr_UsuarioSubLinea)
                                    .Include("bk_tr_UsuarioSubLinea.bk_tc_SubLineaNegocio")
                                    .SingleOrDefault();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<Usuario> GetAllUsuario(){
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Usuarios
                                    .Include(x => x.bk_tc_Rol)
                                    .ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int LastUserID()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.Usuarios.Select(x => x.UsuarioID).DefaultIfEmpty().Max();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<SelectAccionUser_Result> GetAccionUsuario(int usuarioID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                return activeContext.SelectAccionUser(usuarioID).ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }


        public List<Rol> GetRoles()
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                return activeContext.Roles
                    .OrderBy(x => x.nombre)
                    .ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public Rol FindAccionesbyRolID(int rolID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                Rol rol = activeContext.Roles
                    .Where(x => x.rolID == rolID)
                    .Include(x => x.bk_tc_Accion)
                    .FirstOrDefault();

                List<Accion> acciones = rol.bk_tc_Accion.OrderBy(x => x.controllerName).ToList();
                rol.bk_tc_Accion.Clear();
                string controller = string.Empty;

                foreach(Accion acc in acciones)
                {
                    if (controller == acc.controllerName)
                        acc.isPrimero = false;
                    else
                    {
                        acc.isPrimero = true;
                        acc.NroController = acciones.Where(x => x.controllerName == acc.controllerName).Count();
                    }

                    controller = acc.controllerName;
                    rol.bk_tc_Accion.Add(acc);
                }

                return rol;
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<string> GetControllerbyRol(int rolID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                List<int> accionesRol = activeContext.Roles.Where(x => x.rolID == rolID).Include(x => x.bk_tc_Accion).FirstOrDefault().bk_tc_Accion.Select(x => x.AccionID).ToList();

                return activeContext.Acciones
                    .Where(x => !accionesRol.Contains(x.AccionID) && x.isActive.Value)
                    .Select(x => x.controllerName)
                    .Distinct()
                    .ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public List<Accion> GetAccionesbyController(int rolID, string controller)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
            {
                //perform operation in this repository
                List<int> accionesRol = activeContext.Roles.Where(x => x.rolID == rolID).Include(x => x.bk_tc_Accion).FirstOrDefault().bk_tc_Accion.Select(x => x.AccionID).ToList();

                return activeContext.Acciones
                    .Where(x => !accionesRol.Contains(x.AccionID) && x.isActive.Value && x.controllerName == controller)                    
                    .ToList();
            }
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }
        
        public int execDeleteAccionRol(int rolID, string vectorXML)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
                return activeContext.ExecuteCommand("exec bk_sp_DeleteRolAccion @RolID={0}, @datosAccion={1}", rolID, vectorXML);
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }

        public int execAddAccionRol(int rolID, int accionID)
        {
            IMainModuleUnitOfWork activeContext = this.UnitOfWork as IMainModuleUnitOfWork;
            if (activeContext != null)
                return activeContext.ExecuteCommand("exec bk_sp_AddRolAccion @RolID={0}, @AccionID={1}", rolID, accionID);
            else
                throw new InvalidOperationException(string.Format(
                                                                CultureInfo.InvariantCulture,
                                                                Messages.exception_InvalidStoreContext,
                                                                this.GetType().Name));
        }       
        
    }
}
