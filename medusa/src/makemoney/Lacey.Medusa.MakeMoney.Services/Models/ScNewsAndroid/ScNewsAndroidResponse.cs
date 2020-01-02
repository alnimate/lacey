using System.Xml.Serialization;

namespace Lacey.Medusa.MakeMoney.Services.Models.ScNewsAndroid
{
    public sealed class ScNewsAndroidResponse
    {
        [XmlElement("REQ_STATUS")]
        public string ReqStatus { get; set; }

        [XmlElement("DESCRIPTION")]
        public string Description { get; set; }

        [XmlElement("NEWS")]
        public ScNewsAndroidItem[] News { get; set; }
    }
}