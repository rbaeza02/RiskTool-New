using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.MainModule.Entities
{
   [MetadataType(typeof(UbicacionMetaData))]
    public partial class Ubicacion
    {        
        public SelectList CiudadList { get; set; }
        public SelectList ColoniaList { get; set; }

        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }

        public int CiudadID { get; set; }

        public Boolean Eliminado { get; set; } //Saber si es eliminado desde la pantalla
        public Boolean Mostrar { get; set; } //Saber si es mostrado en la pantalla
    }


    public partial class UbicacionMetaData
    {        
        [Required(ErrorMessage = "El Nro Ubicación es requerido")]
        public int nroUbicacion { get; set; }

        [Required(ErrorMessage = "El Código Postal es requerido")]
        [RegularExpression("[0-9]{5}", ErrorMessage = "Ingresar un Código Postal válido")]
        public string CodigoPostal { get; set; }

        [Required(ErrorMessage = "La Calle del domicilio es requerido")]
        public string Domicilio_Calle { get; set; }

        [Required(ErrorMessage = "El Número Exterior del domicilio es requerido")]
        public string Domicilio_NroExterior { get; set; }

        [Required(ErrorMessage = "La Colonia es requerida")]
        public int ColoniaID { get; set; }

        [Required(ErrorMessage = "La Latitud es requerida")]
        public int Latitud { get; set; }

        [Required(ErrorMessage = "La Longitud es requerida")]
        public int Longitud { get; set; }

        [Required(ErrorMessage = "El Tipo Constructivo de Incendio es requerido")]
        public int TipoConstructivoIncendioID { get; set; }

        [Required(ErrorMessage = "El Tipo Constructivo de Terremoto es requerido")]
        public int TipoConstructivoTerremotoID { get; set; }

        [Required(ErrorMessage = "La Zona Terremoto es requerida")]
        public int ZonaTEVID { get; set; }

        [Required(ErrorMessage = "La Zona Hidro es requerida")]
        public int ZonaHidroID { get; set; }

        [Required(ErrorMessage = "El nro de pisos es requerido")]
        [Range(1, 50, ErrorMessage = "El nro de pisos no puede ser mayor a 50 ni menor a 1")]
        public int nroPiso { get; set; }

        [Required(ErrorMessage = "El nro de sótanos es requerido")]
        [Range(0, 20, ErrorMessage = "El nro de sótanos no puede ser mayor a 20 ni menor a 0")]
        public int nroSotano { get; set; }

        [RegularExpression("[0-9]{4}", ErrorMessage = "Ingresar un año válido")]
        [CustomValidation(typeof(UbicacionYearValidation), "ValidaYear")]
        public Nullable<int> añoConstruccion { get; set; }

        [Required(ErrorMessage = "El Nro SIC es requerido")]
        [RegularExpression("[0-9]{4}", ErrorMessage = "Ingresar un nro SIC válido")]
        public string SIC { get; set; }

        [Required(ErrorMessage = "Es requerido saber si está en una Ubicación con Costa")]
        public string UbicacionCosta { get; set; }

        [Required(ErrorMessage = "Es requerido saber si tiene análisis Fire")]
        public string AnalisisFire { get; set; }
    }


    public class UbicacionYearValidation
    {
        public static ValidationResult ValidaYear(Nullable<int> year)
        {
            if (year.HasValue)
                return year > DateTime.Now.Year
                    ? new ValidationResult("El Año de Construcción no puede ser mayor al actual")
                    : ValidationResult.Success;
            else
                return null;
        }
    }
    
}
