using System.Xml.Serialization;

namespace Lacey.Medusa.MakeMoney.Services.Models.ScBalance
{
    public sealed class ScBalanceRequest
    {
        [XmlElement("CUSTOMER_ID")]
        public string CustomerId { get; set; }

        [XmlElement("VERSION")]
        public string Version { get; set; }
    }
}