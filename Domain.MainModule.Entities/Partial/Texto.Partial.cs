using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Domain.MainModule.Entities
{
    public partial class Texto
    {       

        public string VectorValidation(string[] datos)
        {
            int i = 1, j = 0;

            if (datos == null)
                return String.Empty;

            foreach (string line in datos)
            {
                if (!Int32.TryParse(line, out i))
                    return Resources.Messages.exception_BadVector.Replace("{1}", line).Replace("{2}", (j).ToString());

                j++;
            }

            return String.Empty;
        }


        public string VectorValidationAdicional(string[] texto, string[] ids)
        {
            int i = 1, j = 0;

            if (texto == null && ids == null)
                return String.Empty;

            if (texto.Count() != ids.Count())
                return Resources.Messages.exception_NotMatch;

            foreach (string line in ids)
            {
                if (!Int32.TryParse(line, out i))
                    return Resources.Messages.exception_BadVector.Replace("{1}", line).Replace("{2}", (j).ToString());

                j++;
            }

            return String.Empty;
        }

        public XmlDocument VectorToXML(string[] datos)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement el = (XmlElement)doc.AppendChild(doc.CreateElement("ROOT"));
            XmlElement el2;

            if (datos == null)
                return doc;

            foreach (string line in datos)
            {
                el2 = (XmlElement)el.AppendChild(doc.CreateElement("texto"));
                el2.SetAttribute("id", line);
            }

            return doc;
        }


        public XmlDocument VectorAdicionalToXML(string[] texto, string[] ids)
        {
            XmlDocument doc = new XmlDocument();

            if (texto == null)
                return doc;
                        
            XmlElement el = (XmlElement)doc.AppendChild(doc.CreateElement("ROOT"));
            XmlElement el2;

            for (int i = 0; i < ids.Count(); i++ )
            {
                el2 = (XmlElement)el.AppendChild(doc.CreateElement("adicional"));
                el2.SetAttribute("id", ids[i]);
                el2.SetAttribute("texto", texto[i]);
            }
                
            return doc;
        }


    }
}
