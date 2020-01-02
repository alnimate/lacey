using System.Xml.Serialization;

namespace Lacey.Medusa.MakeMoney.Services.Models.ScNewsAndroid
{
    public sealed class ScNewsAndroidItem
    {
        [XmlElement("TITLE")]
        public string Title { get; set; }

        [XmlElement("OFFERID")]
        public string OfferId { get; set; }

        [XmlElement("DESCRIPTIONTEXT")]
        public string DescriptionText { get; set; }

        [XmlElement("LINK")]
        public string Link { get; set; }

        [XmlElement("PHOTOURL")]
        public string PhotoUrl { get; set; }

        [XmlElement("ACTION")]
        public string Action { get; set; }

        [XmlElement("COUNTRY")]
        public string Country { get; set; }

        [XmlElement("PAYOUT")]
        public string Payout { get; set; }

        [XmlElement("ADNETWORK")]
        public string AdNetwork { get; set; }

        [XmlElement("TYPE")]
        public string Type { get; set; }

        [XmlElement("PROMO")]
        public string Promo { get; set; }
    }
}