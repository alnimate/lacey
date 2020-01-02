using System.Xml.Serialization;

namespace Lacey.Medusa.MakeMoney.Services.Models.ScSaveFirebaseToken
{
    public sealed class ScSaveFirebaseTokenResponse
    {
        [XmlElement("REQ_STATUS")]
        public string ReqStatus { get; set; }
    }
}