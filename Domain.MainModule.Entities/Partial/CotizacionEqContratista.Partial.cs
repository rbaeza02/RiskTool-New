using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml;

namespace Domain.MainModule.Entities
{
    public partial class CotizacionEqContratista
    {
        public SelectList IncendioList { get; set; }
        public SelectList MantenimientoList { get; set; }
        public SelectList MovilidadList { get; set; }
        public SelectList RastreoList { get; set; }
        public SelectList RiesgoList { get; set; }


        public List<string> ValidarEquipoFile(List<string> equipos)
        {
            List<string> errores = new List<string>();
            string[] datos;
            int año;
            float monto;

            if (equipos.Count < 2)
                errores.Add("Archivo sin datos");

            for(int i = 1; i < equipos.Count; i++)
            {
                datos = Regex.Split(equipos[i], ",");

                if (datos.Count() != 5)
                    errores.Add("Error Fila " + (i + 1).ToString() + ": Faltan columnas");
                else
                {
                    if (int.TryParse(datos[0], out año))
                    {
                        if (año != 0)
                            if ((año < 1950 || año > DateTime.Now.Year))                        
                                errores.Add("Error Fila " + (i + 1).ToString() + ": Año incorrecto");
                    }
                    else
                        errores.Add("Error Formato, Fila " + (i + 1).ToString() + ": Año incorrecto");

                    if (float.TryParse(datos[4], out monto))
                    {
                        if (monto < 0)
                            errores.Add("Error Fila " + (i + 1).ToString() + ": Monto negativo");
                    }
                    else
                        errores.Add("Error Formato, Fila " + (i + 1).ToString() + ": Monto incorrecto");

                }

            }

            return errores;            
        }

        public XmlDocument EquipoToXML(List<string> equipos)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement el = (XmlElement)doc.AppendChild(doc.CreateElement("ROOT"));
            XmlElement el2;
            string[] datos;

            for (int i = 1; i < equipos.Count; i++)
            {
                datos = Regex.Split(equipos[i], ",");

                el2 = (XmlElement)el.AppendChild(doc.CreateElement("Equipo"));
                el2.SetAttribute("Anio", datos[0]);
                el2.SetAttribute("Marca", datos[1]);
                el2.SetAttribute("Descripcion", datos[2]);
                el2.SetAttribute("Serie", datos[3]);
                el2.SetAttribute("valor", datos[4]);
            }
            
            return doc;
        }
    }
}
