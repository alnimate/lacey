using System.Xml.Serialization;

namespace Lacey.Medusa.MakeMoney.Services.Models.ScSaveFirebaseToken
{
    public sealed class ScSaveFirebaseTokenRequest
    {
        [XmlElement("FIREBASETOKEN")]
        public string FirebaseToken { get; set; }

        [XmlElement("CUSTOMER_ID")]
        public string CustomerId { get; set; }

        [XmlElement("VERSION")]
        public string Version { get; set; }
    }
}