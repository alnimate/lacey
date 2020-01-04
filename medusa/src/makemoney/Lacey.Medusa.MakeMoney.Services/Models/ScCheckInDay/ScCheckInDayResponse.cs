using System.Xml.Serialization;

namespace Lacey.Medusa.MakeMoney.Services.Models.ScCheckInDay
{
    public sealed class ScCheckInDayResponse
    {
        [XmlElement("REQ_STATUS")]
        public string ReqStatus { get; set; }

        [XmlElement("DESCRIPTION")]
        public string Description { get; set; }
    }
}