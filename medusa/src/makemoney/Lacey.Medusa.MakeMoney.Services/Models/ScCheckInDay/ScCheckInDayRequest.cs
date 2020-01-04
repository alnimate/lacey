using System.Xml.Serialization;

namespace Lacey.Medusa.MakeMoney.Services.Models.ScCheckInDay
{
    public sealed class ScCheckInDayRequest
    {
        [XmlElement("CUSTOMER_ID")]
        public string CustomerId { get; set; }

        [XmlElement("VERSION")]
        public string Version { get; set; }
    }
}