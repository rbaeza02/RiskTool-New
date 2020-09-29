using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
     [MetadataType(typeof(UsuarioMetaData))]
    public partial class Usuario : IPrincipal
    {
        public IIdentity Identity { get; private set; }

        public Usuario()
        { }

        public Usuario(string Username)
        {
            this.Identity = new GenericIdentity(Username);
        }

        public string NombreCompleto
        {
            get { return Nombre + ' ' + Apellido; }
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }


        [DataType(DataType.Password)]
        [Display(Name = "Confirma password")]
        [Compare("Contraseña", ErrorMessage = "La contraseña y la confirmación de la contraseña no son iguales.")]
        public string ConfirmPassword { get; set; }
        
    }

     public class CustomPrincipalSerializeModel
     {
         public int UserId { get; set; }
         public string UserName { get; set; }
     }

    public partial class UsuarioMetaData
    {
        [Required(ErrorMessage = "El Usuario es requerido")]        
        [Display(Name = "Usuario")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]        
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El mail es requerido")]
        [EmailAddress(ErrorMessage = "El mail no es correcto")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(100, ErrorMessage = "El {0} debe de contener al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Contraseña { get; set; }        
    }
  
}
