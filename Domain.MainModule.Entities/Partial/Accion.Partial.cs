using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Domain.MainModule.Entities
{
    public partial class Accion
    {
        public int NroController { get; set; }
        public bool isPrimero { get; set; }


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

        public XmlDocument VectorToXML(string[] datos)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement el = (XmlElement)doc.AppendChild(doc.CreateElement("ROOT"));
            XmlElement el2;

            foreach (string line in datos)
            {
                el2 = (XmlElement)el.AppendChild(doc.CreateElement("accion"));
                el2.SetAttribute("id", line);
            }

            return doc;
        }
    }
}
