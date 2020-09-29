using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml;

namespace Domain.MainModule.Entities
{
    [MetadataType(typeof(CotizacionMetaData))]
    public partial class Cotizacion
    {
        public bool PrimerRiesgo { get; set; }
        public String PrimerRiesgoSubLinea { get; set; }
        public String PrimerTipoCobertura { get; set; }

        public bool Incendio { get; set; }
        public bool Hidro { get; set; }
        public bool Terremoto { get; set; }
        public bool TerremotoBI { get; set; }
        public bool Transporte { get; set; }

        public String Miscelaneos { get; set; }
        public String Tecnicos { get; set; }
        public String RC { get; set; }        

        public String NombreAsegurado { get; set; }
        public String RFCAsegurado { get; set; }

        public bool isOFAC { get; set; }

        public string ErrorSISE()
        {
            return Resources.Messages.exception_CotizacionSISE;
        }

        public string ErrorRetroactividad(int dias)
        {
            return Resources.Messages.exception_CotizacionRetroactividad.Replace("{1}", dias.ToString());
        }

        public string ErrorFuturo(int dias)
        {
            return Resources.Messages.exception_CotizacionFuturo.Replace("{1}", dias.ToString());
        }

        public string ErrorHuelga()
        {
            return Resources.Messages.exception_CotizacionHuelga.ToString();
        }

        public string ErrorBienesBajoTierra()
        {
            return Resources.Messages.exception_CotizacionBienesBajoTierra.ToString();
        }

        public string ErrorGastosExtra()
        {
            return Resources.Messages.exception_CotizacionGastosExtra.ToString();
        }

        public string ErrorCausaExt()
        {
            return Resources.Messages.exception_CotizacionCausaExt.ToString();
        }

        public string ErrorTerrorismo()
        {
            return Resources.Messages.exception_CotizacionTerrorismo.ToString();
        }

        public string ErrorEmitida()
        {
            return Resources.Messages.exception_CotizacionInactiva;
        }

        public string ErrorMaxBeneficiario()
        {
            return Resources.Messages.exception_MaxBenef;
        }

        public XmlDocument SubLineaNegocioToXML()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement el = (XmlElement)doc.AppendChild(doc.CreateElement("ROOT"));
            XmlElement el2;

            if (string.IsNullOrEmpty(Miscelaneos) && string.IsNullOrEmpty(Tecnicos) && string.IsNullOrEmpty(RC))
                return doc;

            if (!string.IsNullOrEmpty(Miscelaneos))
                foreach (string line in Regex.Split(Miscelaneos, ","))
                {
                    el2 = (XmlElement)el.AppendChild(doc.CreateElement("Comp"));
                    el2.SetAttribute("name", line);                
                }

            if(!string.IsNullOrEmpty(Tecnicos))
                foreach (string line in Regex.Split(Tecnicos, ","))
                {
                    el2 = (XmlElement)el.AppendChild(doc.CreateElement("Comp"));
                    el2.SetAttribute("name", line);
                }

            if(!string.IsNullOrEmpty(RC))
                foreach (string line in Regex.Split(RC, ","))
                {
                    el2 = (XmlElement)el.AppendChild(doc.CreateElement("Comp"));
                    el2.SetAttribute("name", line);
                }

            return doc;
        }

        public XmlDocument PrimerRiesgoToXML()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement el = (XmlElement)doc.AppendChild(doc.CreateElement("ROOT"));
            XmlElement el2;

            if (string.IsNullOrEmpty(PrimerRiesgoSubLinea) && string.IsNullOrEmpty(PrimerTipoCobertura))
                return doc;

            if (!string.IsNullOrEmpty(PrimerRiesgoSubLinea))
                foreach (string line in Regex.Split(PrimerRiesgoSubLinea, ","))
                {
                    el2 = (XmlElement)el.AppendChild(doc.CreateElement("Sub"));
                    el2.SetAttribute("id", line);
                }

            if (!string.IsNullOrEmpty(PrimerTipoCobertura))
                foreach (string line in Regex.Split(PrimerTipoCobertura, ","))
                {
                    el2 = (XmlElement)el.AppendChild(doc.CreateElement("Cob"));
                    el2.SetAttribute("id", line);
                }

            return doc;
        }

        public XmlDocument IncendioToXML()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement el = (XmlElement)doc.AppendChild(doc.CreateElement("ROOT"));
            XmlElement el2;

            if(Incendio)
            {
                el2 = (XmlElement)el.AppendChild(doc.CreateElement("Sub"));
                el2.SetAttribute("id", "17");
            }

            if (Hidro)
            {
                el2 = (XmlElement)el.AppendChild(doc.CreateElement("Sub"));
                el2.SetAttribute("id", "20");
            }

            if (Terremoto)
            {
                el2 = (XmlElement)el.AppendChild(doc.CreateElement("Sub"));
                el2.SetAttribute("id", "19");
            }

            if (TerremotoBI)
            {
                el2 = (XmlElement)el.AppendChild(doc.CreateElement("Sub"));
                el2.SetAttribute("id", "21");
            }

            if (Transporte)
            {
                el2 = (XmlElement)el.AppendChild(doc.CreateElement("Sub"));
                el2.SetAttribute("id", "18");
            }

            return doc;
        }

        public void ValidarTrans()
        {
            if(Transporte)
            {
                Incendio = false;
                Hidro = false;
                Terremoto = false;
                TerremotoBI = false;
                Miscelaneos = null;
                Tecnicos = null;
                RC = null;
                PrimerRiesgoSubLinea = null;
                PrimerTipoCobertura = null;
            }
        }
    }

    public partial class CotizacionMetaData
    {
        [Required(ErrorMessage = "La Fecha es requerida")]                
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El Inicio de Vigencia es requerido")]
        public DateTime VigenciaInicio { get; set; }

        [Required(ErrorMessage = "El Fin de Vigencia es requerido")]
        public DateTime VigenciaFin { get; set; }

        [Range(10, 20, ErrorMessage = "Los Gastos de administración deben estar entre 10% y 20%")]
        public double GastosAdministracion { get; set; }

        [Range(1, 5, ErrorMessage = "La Utilidad debe estar entre 1% y 5%")]
        public double Utilidad { get; set; }

        [Range(0, 30, ErrorMessage = "La Comisión debe estar entre 0% y 30%")]
        public double Comision { get; set; }

        [Range(0, 10, ErrorMessage = "Los otros gastos de Adquisición deben estar entre 0% y 10%")]
        public double OtrosGastosAdq { get; set; }

        [Range(0, 100, ErrorMessage = "La Participación no tiene un valor válido")]
        public Nullable<double> Participacion { get; set; }

        [Range(0, 100, ErrorMessage = "La Inflación no tiene un valor válido")]
        public Nullable<decimal> Inflacion { get; set; }

        [Required(ErrorMessage = "El Tipo de Cambio es requerido")]
        [Range(0, 100, ErrorMessage = "El Tipo de Cambio no tiene un valor válido")]
        public Nullable<double> TipoCambio { get; set; }

        [Required(ErrorMessage = "El Contacto es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "El Contacto no tiene un valor válido")]
        public Nullable<int> ContactoID { get; set; }
    }
}
