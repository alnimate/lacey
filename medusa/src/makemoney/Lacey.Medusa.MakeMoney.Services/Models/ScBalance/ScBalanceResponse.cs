using System.Xml.Serialization;

namespace Lacey.Medusa.MakeMoney.Services.Models.ScBalance
{
    public sealed class ScBalanceResponse
    {
        [XmlElement("REQ_STATUS")]
        public string ReqStatus { get; set; }

        [XmlElement("USC_BALANCE")]
        public string UscBalance { get; set; }

        [XmlElement("SUSPENDED")]
        public string Suspended { get; set; }
    }
}