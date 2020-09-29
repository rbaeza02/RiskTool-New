using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Domain.MainModule.Entities.Util;

namespace Domain.MainModule.Entities
{
    [MetadataType(typeof(AseguradoMetaData))]
    public partial class Asegurado
    {
        public SelectList TipoPersonaList { get; set; }
        public SelectList GeneroList { get; set; }
        public SelectList EstadoCivilList { get; set; }
        public SelectList TipoTelefonoList { get; set; }
        public Asegurado(string rfc)
        {
            RFC = rfc;
            if (rfc.Length == 13)
                FechaNacimiento = new DateTime(Funciones.getAño(rfc.Substring(4, 2)), Convert.ToInt32(rfc.Substring(6, 2)), Convert.ToInt32(rfc.Substring(8, 2)));
            else
                FechaNacimiento = new DateTime(Funciones.getAño(rfc.Substring(3, 2)), Convert.ToInt32(rfc.Substring(5, 2)), Convert.ToInt32(rfc.Substring(7, 2)));

            TipoPersonaID = rfc.Length == 12 ? 2 : 1;
            LugarNacimiento = "Mexico";
        }

        public Asegurado() { }

        //public string Cod_ciudad { get; set; }
        public string Cod_colonia { get; set; }
        //public string Cod_dpto { get; set; }
        public string Cod_est_civil { get; set; }
        //public string Cod_municipio{ get; set; }
        //public string Cod_pais { get; set; }
        public string Cod_TipoPersona { get; set; }
        public string Cod_sexo { get; set; }
        public string Cod_tipo_telef { get; set; }
               

        public string ErrorSISE()
        {
            return Resources.Messages.exception_AseguradoNotFound;
        }

        public string ErrorOFAC()
        {
            return Resources.Messages.exception_AseguradoOFAC;
        }

        public string SISEcod_ciudad
        {
            get { return bk_tc_Colonia.bk_tc_Ciudad.SISEcod_ciudad.ToString(); }            
        }

        public string SISEcod_colonia
        {
            get { return bk_tc_Colonia.SISEcod_colonia.ToString(); }            
        }

        public string SISEcod_dpto
        {
            get { return bk_tc_Colonia.bk_tc_Municipio.bk_tc_Estado.SISEcod_dpto.ToString(); }            
        }

        public string SISEcod_est_civil
        {
            get { return bk_tc_EstadoCivil.SISEcod_est_civil.ToString(); }            
        }

        public string SISEcod_municipio
        {
            get { return bk_tc_Colonia.bk_tc_Municipio.SISEcod_municipio.ToString(); }            
        }

        public string SISEcod_pais
        {
            get { return bk_tc_Colonia.bk_tc_Municipio.bk_tc_Estado.bk_tc_Pais.SISEcod_pais.ToString(); }            
        }

        public string SISEcod_TipoPersona
        {
            get { return bk_tc_TipoPersona.SISEcod_TipoPersona.ToString(); }            
        }

        public string SISEcod_tipo_telef
        {
            get { return bk_tc_TipoTelefono.SISEcod_tipo_telef.ToString(); }            
        }

        public string NombreCompleto
        {
            get { return TipoPersonaID == 1 ? Nombres + ' ' + Apellido1 + ' ' + Apellido2 : RazonSocial; }
        }
    }

    public partial class AseguradoMetaData
    {
        [Required(ErrorMessage = "El Código Postal es requerido")]
        [RegularExpression("[0-9]{5}", ErrorMessage="Ingresar un Código Postal válido")]
        public string CodigoPostal { get; set; }

        [Required(ErrorMessage = "El RFC es requerido")]
        public string RFC { get; set; }

        [Required(ErrorMessage = "La Calle del Domicilio Fiscal es requerido")]
        [StringLength(30, ErrorMessage = "La Calle del Domicilio no puede exceder los 30 caracteres")]
        public string DomicilioFiscal_Calle { get; set; }

        [Required(ErrorMessage = "El Nro Exterior del Domicilio Fiscal es requerido")]
        [StringLength(10,ErrorMessage ="El Nro Exterior no puede exceder los 10 caracteres")]
        public string DomicilioFiscal_NroExterior { get; set; }

        [StringLength(10, ErrorMessage = "El Nro Interior no puede exceder los 10 caracteres")]
        public string DomicilioFiscal_NroInterior { get; set; }

        [Required(ErrorMessage = "El Nro SIC es requerido")]
        [RegularExpression("[0-9]{4}", ErrorMessage = "Ingresar un nro SIC válido")]
        public string SIC { get; set; }

        //[Required(ErrorMessage = "El Nro Telefónico es requerido")]
        //public string Telefono { get; set; }
        
        //[Range(1,9999999999, ErrorMessage="La Colonia es requerida")]
        //public int ColoniaID { get; set; }

        
    }
}
