using System.Xml.Serialization;

namespace Lacey.Medusa.MakeMoney.Services.Models.ScNewsAndroid
{
    public sealed class ScNewsAndroidRequest
    {
        [XmlElement("OS")]
        public string Os { get; set; }

        [XmlElement("COUNTRY")]
        public string Country { get; set; }

        [XmlElement("CUSTOMER_ID")]
        public string CustomerId { get; set; }

        [XmlElement("VERSION")]
        public string Version { get; set; }

        [XmlElement("ADVERTISINGID")]
        public string AdvertisingId { get; set; }
    }
}