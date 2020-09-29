using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Application.MainModule.Accounts;
using Application.MainModule.Catalogos;
using Domain.MainModule.Entities;
using MVC.Client.Extension.Messages;
using MVC.Client.Extension.Utilities;
using MVC.Client.Extensions.ActionFilters;
using MVC.Client.Extensions.Utilities;
using MVC.Client.Models;
using MVC.Client.Resources;
using Newtonsoft.Json;

namespace MVC.Client.Controllers
{
    [Authorize]
    [CustomAuthorize]
    [HandleCustomError]
    public class AccountController : Controller
    {

        private IAccountManagementService _AccountService;
        private ICatalogoManagementService _CatalogoService;

        public AccountController(IAccountManagementService accountService, ICatalogoManagementService catalogoService)
        {
            _AccountService = accountService;
            _CatalogoService = catalogoService;
        }
                
        public ActionResult Index()
        {
            return View(_AccountService.GetAllUsuarios());
        }


        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                var user = _AccountService.CheckUsuario(model.UserName);

                if (user != null)
                {
                    Session["paginas"] = _CatalogoService.FindPagina(0);
                    Session["permisos"] = _AccountService.GetAccionUsuario(user.UsuarioID);

                    //var roles = user.Roles.Select(m => m.RoleName).ToArray();

                    var hashCode = user.VCode;  
                    //Password Hasing Process Call Helper Class Method    
                    var encodingPasswordString = Helper.EncodePassword(model.Password, hashCode);  
                    //Check Login Detail User Name Or Password
                    if (user.Contraseña.Equals(encodingPasswordString))
                    {
                        CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                        serializeModel.UserId = user.UsuarioID;
                        serializeModel.UserName = user.NombreUsuario;

                        string userData = JsonConvert.SerializeObject(serializeModel);
                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                                 1,
                                user.NombreUsuario,
                                 DateTime.Now,
                                 DateTime.Now.AddMinutes(2880),
                                 false,
                                 userData);

                        string encTicket = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                        Response.Cookies.Add(faCookie);

                        return RedirectToAction("Index", "Home");
                    }                    
                }
                
                ModelState.AddModelError("", "Incorrect username and/or password");
                
            }

            return View(model);
        }

        //
        // GET: /Account/Register           
        public ActionResult Register(string id, string mensaje)
        {
            if (string.IsNullOrEmpty(id))
                id = "0";

            Usuario user = _AccountService.FindUsuariobyID(Convert.ToInt32(id));
            ViewBag.Message = mensaje;
            ViewBag.SucursalList = new SelectList(_CatalogoService.AllSucursales(), "SucursalID", "nombre");
            ViewBag.RolList = new SelectList(_AccountService.GetAllRoles(), "rolID", "nombre");
            
            
            return View(user);
        }

        //
        // POST: /Account/Register
        [HttpPost]        
        [ValidateAntiForgeryToken]        
        public ActionResult Register(Usuario model)
        {
            ViewBag.SucursalList = new SelectList(_CatalogoService.AllSucursales(), "SucursalID", "nombre");
            ViewBag.RolList = new SelectList(_AccountService.GetAllRoles(), "rolID", "nombre");

            if (ModelState.IsValid)
            {
                model.VCode = Helper.GeneratePassword(10);
                model.Contraseña = Helper.EncodePassword(model.Contraseña, model.VCode);

                _AccountService.AddUsuario(model);

                return RedirectToAction("Register", new { id = model.UsuarioID, mensaje = Resources.Messages.successful_general });
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

                	
        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            if (code == null) 
            {
                return View("Error");
            }
            return View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var user = await UserManager.FindByNameAsync(model.Email);
                //if (user == null)
                //{
                //    ModelState.AddModelError("", "No user found.");
                //    return View();
                //}
                //IdentityResult result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
                //if (result.Succeeded)
                //{
                //    return RedirectToAction("ResetPasswordConfirmation", "Account");
                //}
                //else
                //{
                //    AddErrors(result);
                //    return View();
                //}
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }


        public ActionResult Rol(string active)
        {
            List<Rol> roles = _AccountService.GetAllRoles();

            if (roles.Exists(x => x.rolID.ToString() == active) )
                ViewBag.isActive = active;
            else
                ViewBag.isActive = "1";

            return View(roles);
        }

        //[HttpPost]
        //public ActionResult Rol(List<Rol> roles)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //_CotizacionService.SaveValores(ubicaciones, (int)Session["cotizacionID"]);
        //        ViewBag.Mensaje = Resources.Messages.successful_general;
        //    }

        //    return View(roles);
        //}

        public JsonResult GetListAcciones(int rolID)
        {            
            return this.Json(
                new
                {
                    controlador = new SelectList(_AccountService.FindControllerbyRolID(rolID).Select(x => new SelectListItem { Text = x, Value = x }), "Value", "Text"),
                    acciones = Render.RenderRazorViewToString(this, "Templates/Rol", _AccountService.FindAccionesbyRolID(rolID))
                }
                , JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAccion(int rolID, string controllerA)
        {
            return this.Json(new SelectList(_AccountService.FindAccionbyController(rolID, controllerA), "AccionID", "descripcion"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteAccion(int rolID, string[] valores)
        {
            Accion accion = new Accion();
            string mensaje = accion.VectorValidation(valores);
            int codigoMensaje = 0;

            if (string.IsNullOrEmpty(mensaje))
            {
                _AccountService.DeleteAccionbyRolID(rolID, accion.VectorToXML(valores).InnerXml);
                codigoMensaje = 1;
                //mensaje = MessagesValidation.Successful(Resources.Messages.successful_general).ToString();
            }
            else
                mensaje = MessagesValidation.Error(mensaje).ToString();

            return this.Json(new { mensaje = mensaje, codigo = codigoMensaje }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddAccion(int rolID, int accionID)
        {
            int codigoMensaje = 0;
            string mensaje = string.Empty;
            codigoMensaje = _AccountService.AddAccionbyRolID(rolID, accionID);
            
            if (codigoMensaje == 0)
                mensaje = MessagesValidation.Error(Messages.EmptyData_error).ToString();

            return this.Json(new { mensaje = mensaje, codigo = codigoMensaje }, JsonRequestBehavior.AllowGet);
        }
        
        
        //
        // GET: /Account/Manage
        //public ActionResult Manage(ManageMessageId? message)
        //{
        //    ViewBag.StatusMessage =
        //        message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
        //        : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
        //        : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
        //        : message == ManageMessageId.Error ? "An error has occurred."
        //        : "";
        //    ViewBag.HasLocalPassword = HasPassword();
        //    ViewBag.ReturnUrl = Url.Action("Manage");
        //    return View();
        //}

        ////
        //// POST: /Account/Manage
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Manage(ManageUserViewModel model)
        //{
        //    bool hasPassword = HasPassword();
        //    ViewBag.HasLocalPassword = hasPassword;
        //    ViewBag.ReturnUrl = Url.Action("Manage");
        //    if (hasPassword)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
        //            if (result.Succeeded)
        //            {
        //                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
        //                await SignInAsync(user, isPersistent: false);
        //                return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
        //            }
        //            else
        //            {
        //                AddErrors(result);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        // User does not have a password so remove any validation errors caused by a missing OldPassword field
        //        ModelState state = ModelState["OldPassword"];
        //        if (state != null)
        //        {
        //            state.Errors.Clear();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
        //            if (result.Succeeded)
        //            {
        //                return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
        //            }
        //            else
        //            {
        //                AddErrors(result);
        //            }
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

      
        //
        // POST: /Account/LogOff
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            Session["paginas"] = null;
            Session["permisos"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Keepalive()
        {
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

      

        

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

       
    }
}