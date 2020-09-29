using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Integration.wsPoliza;
using Domain.MainModule.Entities;
using System.Xml;
using MarkupConverter;
using System.Threading;
using System.Web;
using System.IO;
using System.Configuration;

namespace Application.Integration.Translate
{
    public class TRObs
    {
        string rtf;
        List<SelectTextosPrimaPresentacion_Result> obs;
        public List<PasoObs> ObsTOwsObsTR(List<SISEObs_Result> entObservaciones)
        {
            PasoObs wsObs;
            
            List<PasoObs> observaciones = new List<PasoObs>();
                                    
            ConvertWordToRTF();
            
            rtf = File.ReadAllText(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["PathTransporte"] + ".rtf"));

            foreach (SISEObs_Result entObs in entObservaciones)
            {
                wsObs = new PasoObs();
                wsObs.Cod_item = entObs.cod_item.ToString();
                wsObs.Id_pv = entObs.id_pv.ToString();
                wsObs.Txt_obs = rtf;
                observaciones.Add(wsObs);
            }

            return observaciones;
        }

        public List<PasoObs> ObsTOwsObs(List<SISEObs_Result> entObservaciones, List<SelectTextosPrimaPresentacion_Result> textos)
        {
            PasoObs wsObs;

            List<PasoObs> observaciones = new List<PasoObs>();
            obs = textos;

            Thread thread = new Thread(GetRTF);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            foreach (SISEObs_Result entObs in entObservaciones)
            {
                wsObs = new PasoObs();
                wsObs.Cod_item = entObs.cod_item.ToString();
                wsObs.Id_pv = entObs.id_pv.ToString();
                wsObs.Txt_obs = rtf;//GetRTF(textos);
                observaciones.Add(wsObs);
            }

            return observaciones;
        }


        void GetRTF()
        {
            MarkupConverter.MarkupConverter markupConverter = new MarkupConverter.MarkupConverter();
            StringBuilder html = new StringBuilder("<Table>");
            string temp;

            foreach (SelectTextosPrimaPresentacion_Result texto in obs)
            {
                html.Append("<tr><td><b>");
                if (string.IsNullOrEmpty(texto.texto1))                
                    html.Append("&nbsp;");
                else
                    html.Append(texto.texto1);

                html.Append("</b></td><td>");

                if (string.IsNullOrEmpty(texto.texto2))
                    html.Append("&nbsp;");
                else
                    if(texto.texto2.Contains("<br>"))
                        foreach(string valor in texto.texto2.Split(new string[] { "<br>" }, StringSplitOptions.None))
                        {
                            temp = valor.StartsWith("&nbsp;") ? "." + valor: valor;
                            html.Append(temp);
                            html.Append("</td></tr><tr><td><b>&nbsp;</b></td><td>");
                        }                    
                    else
                        html.Append(texto.texto2);

                html.Append("</td></tr>");
            }
            html.Append("</table>");

            rtf = markupConverter.ConvertHtmlToRtf(html.ToString());

            rtf = rtf.Replace("cellx1440", "cellx3502").Replace("cellx2880", "cellx11136").Replace(@"clbrdrt\brdrs\brdrw15\brdrcf0\clbrdrl\brdrs\brdrw15\brdrcf0\clbrdrb\brdrs\brdrw15\brdrcf0\clbrdrr\brdrs\brdrw15\brdrcf0\","");
        }


        private void ConvertWordToRTF()
        {
            //Creating the instance of Word Application
            Microsoft.Office.Interop.Word.Application newApp = new Microsoft.Office.Interop.Word.Application();

            // specifying the Source & Target file names
            object Source = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["PathTransporte"] + ".doc");
            object Target = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["PathTransporte"] + ".rtf");

            // Use for the parameter whose type are not known or  
            // say Missing
            object Unknown = Type.Missing;

            // Source document open here
            // Additional Parameters are not known so that are  
            // set as a missing type
            newApp.Documents.Open(ref Source, ref Unknown,
                 ref Unknown, ref Unknown, ref Unknown,
                 ref Unknown, ref Unknown, ref Unknown,
                 ref Unknown, ref Unknown, ref Unknown,
                 ref Unknown, ref Unknown, ref Unknown, ref Unknown);

            // Specifying the format in which you want the output file 
            object format = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatRTF;

            //Changing the format of the document
            newApp.ActiveDocument.SaveAs(ref Target, ref format,
                    ref Unknown, ref Unknown, ref Unknown,
                    ref Unknown, ref Unknown, ref Unknown,
                    ref Unknown, ref Unknown, ref Unknown,
                    ref Unknown, ref Unknown, ref Unknown,
                    ref Unknown, ref Unknown);

            newApp.Documents.Close();
            newApp.Application.Quit();
            // for closing the application
            newApp.Quit(ref Unknown, ref Unknown, ref Unknown);
            



        }
    }
}
