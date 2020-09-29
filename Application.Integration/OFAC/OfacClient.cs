using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace Application.Integration.OFAC
{
    public class OfacClient
    {
        public string Dsik { get; private set; }
        public string Url { get; private set; }

        public OfacClient(string dsik, string url)
        {
            Dsik = dsik;
            Url = url;
        }

        public int SearchHitInquiry(string comercialName,
            string rfc,
            string direccion1,
            string ciudad,
            string postalCode,
            string codigoPaises,
            out string request, out string response)
        {
            var requestId = Guid.NewGuid().ToString();
            var envelope = GetEnvelope();
            envelope.Header = GetHeader();

            envelope.Body = new Request.Body
            {
                OFACSearchInqRq = new Request.OFACSearchInqRq
                {
                    RqUID = requestId,
                    TransactionRequestDt = DateTime.Today.ToString("yyyy-MM-ddThh:mm:ss.s"),
                    TransactionEffectiveDt = DateTime.Today.ToString("yyyy-MM-ddDDThh:mm:ss.s"),
                    CurCd = "USD",
                    SPName = "0",
                    NewReportInd = "1",
                    ReferenceNumber = rfc,
                    GeneralPartyInfo = new Request.GeneralPartyInfo
                    {
                        NameInfo = new Request.NameInfo
                        {
                            CommlName = new Request.CommlName
                            {
                                CommercialName = comercialName
                            }
                        },
                        Addr = new Request.Addr
                        {
                            Addr1 = direccion1,
                            City = ciudad,
                            PostalCode = postalCode,
                            CountryCd = codigoPaises
                        }
                    }
                }
            };


            XmlSerializer requestSerializer = new XmlSerializer(typeof(Request.Envelope));

            using (StringWriter textWriter = new StringWriter())
            {
                requestSerializer.Serialize(textWriter, envelope);
                request = textWriter.ToString();
            }
            try
            {
                HttpWebRequest webRequest = GetWebRequest();
                var data = Encoding.ASCII.GetBytes(request);
                webRequest.ContentLength = data.Length;
                using (var stream = webRequest.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var webResponse = (HttpWebResponse)webRequest.GetResponse();

                using (webResponse)
                {
                    XmlSerializer responseSerializer = new XmlSerializer(typeof(Response.Envelope));

                    using (Stream stream = webResponse.GetResponseStream())
                    {
                        var responseEnvelope = (Response.Envelope)responseSerializer.Deserialize(stream);
                        using (StringWriter textWriter = new StringWriter())
                        {
                            responseSerializer.Serialize(textWriter, responseEnvelope);
                            response = textWriter.ToString();
                        }



                        if (responseEnvelope.Body.OFACSearchInqRs.MsgStatus.MsgStatusCd.Equals("Success"))
                        {
                            if (!String.IsNullOrWhiteSpace(responseEnvelope.Body.OFACSearchInqRs.OFACSearchResults
                                .ItemIdInfo.OtherIdentifier.OtherId))
                            {
                                return Int32.Parse(responseEnvelope.Body.OFACSearchInqRs.OFACSearchResults
                                    .ItemIdInfo.OtherIdentifier.OtherId);
                            }
                            return 0;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                response = e.Message;
            }
            return -1;
        }

        private HttpWebRequest GetWebRequest()
        {
            var webRequest = (HttpWebRequest)HttpWebRequest.Create(Url);
            webRequest.Method = "POST";
            webRequest.ContentType = "text/xml;charset=UTF-8";
            webRequest.UserAgent = "BI-Web";
            webRequest.Headers.Add("SOAPAction", "http://wrberkley.com/services/OFACSupplementalService/v1/OFACSearchInquiry");
            return webRequest;
        }

        private Request.Envelope GetEnvelope()
        {
            var env = new Request.Envelope();
            env.Soapenv = "http://schemas.xmlsoap.org/soap/envelope/";
            env.Bts = "http://bts.services.wrberkley.com";
            env.Oas = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd/";
            //env.Oas1 = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd";
            //env.Ns = "http://www.wrberkley.com/schema/message/ofacsupplemental/1";
            //env.X = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/";
            //env.Ns1 = "http://www.wrberkley.com/schema/data/datacomponents/1";
            return env;
        }

        private Request.Header GetHeader()
        {
            var header = new Request.Header();
            header.Security = new Request.Security { Dsik = Dsik };
            return header;
        }
    }
}
