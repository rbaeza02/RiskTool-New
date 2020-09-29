using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml;
using Domain.MainModule.Entities.Util;

namespace Domain.MainModule.Entities
{
    
    public partial class Persona
    {       

        public string NombreCompleto
        {
            get { return RazonSocial == null ? Nombres + ' ' + Apellido1 + ' ' + Apellido2 : RazonSocial; }
        }

        public string ErrorSISE()
        {
            return Resources.Messages.exception_PersonaNotFound;
        }

        public string VectorValidation(string[] datos)
        {
            int i = 1, j = 0;            

            if (datos == null)
                return String.Empty;

            foreach (string line in datos)
            {
                if (!Int32.TryParse(line.Split(',')[0], out i))
                    return Resources.Messages.exception_BadVector.Replace("{1}", "trBenef").Replace("{2}", (j).ToString());
                if (!Int32.TryParse(line.Split(',')[1], out i))
                    return Resources.Messages.exception_BadVector.Replace("{1}", "idPersona").Replace("{2}", (j).ToString());
                if (!Int32.TryParse(line.Split(',')[2], out i))
                    return Resources.Messages.exception_BadVector.Replace("{1}", "idTipoBeneficiario").Replace("{2}", (j).ToString());

                j++;
            }

            return String.Empty;
        }

        public XmlDocument PersonaToXML(string[] datos)
        {
            //List<SelectPortfolioPreTrade_Result> result = new List<SelectPortfolioPreTrade_Result>();
            XmlDocument doc = new XmlDocument();
            XmlElement el = (XmlElement)doc.AppendChild(doc.CreateElement("ROOT"));
            XmlElement el2;

            if (datos == null)
                return doc;

            foreach (string line in datos)
            {                
                el2 = (XmlElement)el.AppendChild(doc.CreateElement("Benef"));
                el2.SetAttribute("new", line.Split(',')[0]);
                el2.SetAttribute("idPersona", line.Split(',')[1]);
                el2.SetAttribute("idTipoBeneficiario", line.Split(',')[2]);
            }

            return doc;
        }
    }

    
}
