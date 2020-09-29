/* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */
using System.Xml.Serialization;

namespace Application.Integration.OFAC.Request
{
    [XmlRoot(ElementName = "Security", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
    public class Security
    {
        [XmlElement(ElementName = "dsik", Namespace = "http://bts.services.wrberkley.com")]
        public string Dsik { get; set; }
    }

    [XmlRoot(ElementName = "Header", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Header
    {
        [XmlElement(ElementName = "TransactionManagement", Namespace = "http://bts.services.wrberkley.com")]
        public string TransactionManagement { get; set; }
        [XmlElement(ElementName = "Security", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
        public Security Security { get; set; }
    }

    [XmlRoot(ElementName = "CommlName", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
    public class CommlName
    {
        [XmlElement(ElementName = "CommercialName", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public string CommercialName { get; set; }
    }

    [XmlRoot(ElementName = "NameInfo", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
    public class NameInfo
    {
        [XmlElement(ElementName = "CommlName", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public CommlName CommlName { get; set; }
    }

    [XmlRoot(ElementName = "Addr", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
    public class Addr
    {
        [XmlElement(ElementName = "Addr1", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public string Addr1 { get; set; }
        [XmlElement(ElementName = "City", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public string City { get; set; }
        [XmlElement(ElementName = "PostalCode", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public string PostalCode { get; set; }
        [XmlElement(ElementName = "CountryCd", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public string CountryCd { get; set; }
    }

    [XmlRoot(ElementName = "GeneralPartyInfo", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
    public class GeneralPartyInfo
    {
        [XmlElement(ElementName = "NameInfo", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public NameInfo NameInfo { get; set; }
        [XmlElement(ElementName = "Addr", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public Addr Addr { get; set; }
    }

    [XmlRoot(ElementName = "OFACSearchInqRq", Namespace = "http://www.wrberkley.com/schema/message/ofacsupplemental/1")]
    public class OFACSearchInqRq
    {
        [XmlElement(ElementName = "RqUID", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public string RqUID { get; set; }
        [XmlElement(ElementName = "TransactionRequestDt", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public string TransactionRequestDt { get; set; }
        [XmlElement(ElementName = "TransactionEffectiveDt", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public string TransactionEffectiveDt { get; set; }
        [XmlElement(ElementName = "CurCd", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public string CurCd { get; set; }
        [XmlElement(ElementName = "SPName", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public string SPName { get; set; }
        [XmlElement(ElementName = "ReferenceNumber", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public string ReferenceNumber { get; set; }
        [XmlElement(ElementName = "NewReportInd", Namespace = "http://www.wrberkley.com/schema/data/datacomponents/1")]
        public string NewReportInd { get; set; }
        [XmlElement(ElementName = "GeneralPartyInfo", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public GeneralPartyInfo GeneralPartyInfo { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }

    [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Body
    {
        [XmlElement(ElementName = "OFACSearchInqRq", Namespace = "http://www.wrberkley.com/schema/message/ofacsupplemental/1")]
        public OFACSearchInqRq OFACSearchInqRq { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }

    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Envelope
    {
        [XmlElement(ElementName = "Header", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public Header Header { get; set; }
        [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public Body Body { get; set; }
        [XmlAttribute(AttributeName = "soapenv", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Soapenv { get; set; }
        [XmlAttribute(AttributeName = "ac", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ac { get; set; }
        [XmlAttribute(AttributeName = "bts", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Bts { get; set; }
        [XmlAttribute(AttributeName = "oas", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Oas { get; set; }
        [XmlAttribute(AttributeName = "wrb-d", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Wrbd { get; set; }
        [XmlAttribute(AttributeName = "wrb-doc", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Wrbdoc { get; set; }
        [XmlAttribute(AttributeName = "wrb-m", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Wrbm { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }
    }
}
