using System.Xml.Serialization;

namespace Application.Integration.OFAC.Response
{
    [XmlRoot(ElementName = "MsgStatus", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
    public class MsgStatus
    {
        [XmlElement(ElementName = "MsgStatusCd", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public string MsgStatusCd { get; set; }
        [XmlElement(ElementName = "MsgStatusDesc", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public string MsgStatusDesc { get; set; }
    }

    [XmlRoot(ElementName = "OtherIdentifier", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
    public class OtherIdentifier
    {
        [XmlElement(ElementName = "OtherIdTypeCd", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public string OtherIdTypeCd { get; set; }
        [XmlElement(ElementName = "OtherId", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public string OtherId { get; set; }
    }

    [XmlRoot(ElementName = "ItemIdInfo", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
    public class ItemIdInfo
    {
        [XmlElement(ElementName = "OtherIdentifier", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public OtherIdentifier OtherIdentifier { get; set; }
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

    [XmlRoot(ElementName = "GeneralPartyInfo", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
    public class GeneralPartyInfo
    {
        [XmlElement(ElementName = "NameInfo", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public NameInfo NameInfo { get; set; }
    }

    [XmlRoot(ElementName = "OFACHitInfo", Namespace = "http://www.wrberkley.com/schema/data/datacomponents/1")]
    public class OFACHitInfo
    {
        [XmlElement(ElementName = "GeneralPartyInfo", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public GeneralPartyInfo GeneralPartyInfo { get; set; }
        [XmlElement(ElementName = "Score", Namespace = "http://www.wrberkley.com/schema/data/datacomponents/1")]
        public string Score { get; set; }
        [XmlElement(ElementName = "Program", Namespace = "http://www.wrberkley.com/schema/data/datacomponents/1")]
        public string Program { get; set; }
        [XmlElement(ElementName = "Description", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public string Description { get; set; }
        [XmlElement(ElementName = "EffectiveDtTime", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public string EffectiveDtTime { get; set; }
    }

    [XmlRoot(ElementName = "OFACSearchResults", Namespace = "http://www.wrberkley.com/schema/data/datacomponents/1")]
    public class OFACSearchResults
    {
        [XmlElement(ElementName = "ItemIdInfo", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public ItemIdInfo ItemIdInfo { get; set; }
        [XmlElement(ElementName = "GeneralPartyInfo", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public GeneralPartyInfo GeneralPartyInfo { get; set; }
        [XmlElement(ElementName = "OFACHitInfo", Namespace = "http://www.wrberkley.com/schema/data/datacomponents/1")]
        public OFACHitInfo OFACHitInfo { get; set; }
    }

    [XmlRoot(ElementName = "OFACSearchInqRs", Namespace = "http://www.wrberkley.com/schema/message/ofacsupplemental/1")]
    public class OFACSearchInqRs
    {
        [XmlElement(ElementName = "RqUID", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public string RqUID { get; set; }
        [XmlElement(ElementName = "TransactionResponseDt", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public string TransactionResponseDt { get; set; }
        [XmlElement(ElementName = "CurCd", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public string CurCd { get; set; }
        [XmlElement(ElementName = "MsgStatus", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public MsgStatus MsgStatus { get; set; }
        [XmlElement(ElementName = "SPName", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public string SPName { get; set; }
        [XmlElement(ElementName = "ReferenceNumber", Namespace = "http://www.ACORD.org/standards/PC_Surety/ACORD1/xml/")]
        public string ReferenceNumber { get; set; }
        [XmlElement(ElementName = "NewReportInd", Namespace = "http://www.wrberkley.com/schema/data/datacomponents/1")]
        public string NewReportInd { get; set; }
        [XmlElement(ElementName = "OFACSearchResults", Namespace = "http://www.wrberkley.com/schema/data/datacomponents/1")]
        public OFACSearchResults OFACSearchResults { get; set; }
        [XmlAttribute(AttributeName = "wrb-m", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Wrbm { get; set; }
        [XmlAttribute(AttributeName = "ac", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ac { get; set; }
        [XmlAttribute(AttributeName = "wrb-d", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Wrbd { get; set; }
        [XmlAttribute(AttributeName = "wrb-doc", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Wrbdoc { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }
    }

    [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Body
    {
        [XmlElement(ElementName = "OFACSearchInqRs", Namespace = "http://www.wrberkley.com/schema/message/ofacsupplemental/1")]
        public OFACSearchInqRs OFACSearchInqRs { get; set; }
    }

    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Envelope
    {
        [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public Body Body { get; set; }
        [XmlAttribute(AttributeName = "soap", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Soap { get; set; }
        [XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns2 { get; set; }
        [XmlAttribute(AttributeName = "ns3", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns3 { get; set; }
        [XmlAttribute(AttributeName = "ns4", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns4 { get; set; }
        [XmlAttribute(AttributeName = "ns5", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns5 { get; set; }
        [XmlAttribute(AttributeName = "ns6", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns6 { get; set; }
        [XmlAttribute(AttributeName = "ns7", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns7 { get; set; }
        [XmlAttribute(AttributeName = "ns8", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns8 { get; set; }
    }
}

