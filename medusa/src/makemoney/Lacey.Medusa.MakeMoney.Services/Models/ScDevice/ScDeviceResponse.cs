using System.Xml.Serialization;

namespace Lacey.Medusa.MakeMoney.Services.Models.ScDevice
{
    public sealed class ScDeviceResponse
    {
        [XmlElement("REQ_STATUS")]
        public string ReqStatus { get; set; }

        [XmlElement("CUSTOMER_ID")]
        public string CustomerId { get; set; }

        [XmlElement("USC_BALANCE")]
        public string UscBalance { get; set; }

        [XmlElement("SUSPENDED")]
        public string Suspended { get; set; }

        [XmlElement("EMAIL_ADDRESS")]
        public string EmailAddress { get; set; }

        [XmlElement("REFERAL_CODE")]
        public string ReferalCode { get; set; }

        [XmlElement("RETURNING")]
        public string Returning { get; set; }

        [XmlElement("REFERRED")]
        public string Referred { get; set; }
    }
}