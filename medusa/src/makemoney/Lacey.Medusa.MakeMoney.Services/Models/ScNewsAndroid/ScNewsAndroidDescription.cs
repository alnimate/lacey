using System.Xml.Serialization;

namespace Lacey.Medusa.MakeMoney.Services.Models.ScNewsAndroid
{
    public sealed class ScNewsAndroidDescription
    {
        [XmlElement("NEWS")]
        public ScNewsAndroidItem[] News { get; set; }
    }
}