using Application.Integration.wsConsultaPersona;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Application.Integration
{
    public class WsConsultaPersona
    {
        public static SDTConsultaPersonaOut.Persona datosAseguradoWS(string rfc)
        {
            SDTConsultaPersonaOut.Persona result = new SDTConsultaPersonaOut.Persona();
            try
            {
                if (rfc == "" || rfc is null)
                {
                    rfc = "XAXX010101000";
                }

                var response = CallWebService(rfc);
                string datosAsegurado = getBetween(response.ToString(), "<Persona>", "</Persona>");
                if (datosAsegurado.Length > 0)
                {
                    var serializer = new XmlSerializer(typeof(SDTConsultaPersonaOut.Persona));
                    using (TextReader reader = new StringReader(datosAsegurado))
                    {
                        result = (SDTConsultaPersonaOut.Persona)serializer.Deserialize(reader);
                    }
                }
            }
            catch { }
            return result;
        }

        public static string CallWebService(string rfc)
        {
            var _url = "https://testcol.berkleyonline.com.ar:8443/BIWebMXTest/servlet/com.berkleycomercial10.awsconsultapersona?wsdl";
            var _action = "";

            XmlDocument soapEnvelopeXml = CreateSoapEnvelope(rfc);
            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
                Console.Write(soapResult);
            }
            return soapResult;
        }

        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            //webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope(string rfc)
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();
            string c1 = @"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"" 
                            xmlns:ber=""Berkley_Comercial_10"">   
                          <SOAP-ENV:Body>      
                            <ber:WSConsultaPersona.Execute>      
                            <ber:Sdtconsultapersonain>      
                            <ber:RFC>";
            string c2 = @"</ber:RFC>
                          </ber:Sdtconsultapersonain>
                          </ber:WSConsultaPersona.Execute>
                         </SOAP-ENV:Body>
                        </SOAP-ENV:Envelope>";

            soapEnvelopeDocument.LoadXml(c1 + rfc + c2);
            return soapEnvelopeDocument;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0); //+ strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, (End + strEnd.Length) - Start);
            }

            return "";
        }
    }
}
