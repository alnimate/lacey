using System.Xml.Serialization;

namespace Lacey.Medusa.MakeMoney.Services.Models.ScDevice
{
    public sealed class ScDeviceRequest
    {
        [XmlElement("AUTO_NAME")]
        public string AutoName { get; set; }

        [XmlElement("MODEL")]
        public string Model { get; set; }

        [XmlElement("UNIQUE_ID")]
        public string UniqueId { get; set; }

        [XmlElement("MANUFACTURER")]
        public string Manufacturer { get; set; }

        [XmlElement("APP_VERSION")]
        public string AppVesrsion { get; set; }

        [XmlElement("CARRIER")]
        public string Carrier { get; set; }

        [XmlElement("BRAND")]
        public string Brand { get; set; }

        [XmlElement("DEVICELANGUAGE")]
        public string DeviceLanguage { get; set; }

        [XmlElement("FIREBASETOKEN")]
        public string FirebaseToken { get; set; }

        [XmlElement("PUSH_ID")]
        public string PushId { get; set; }

        [XmlElement("REFERAL_CODE")]
        public string ReferalCode { get; set; }

        [XmlElement("DEPLOYMENT_TYPE")]
        public string DeploymentType { get; set; }

        [XmlElement("SCREEN_HEIGHT")]
        public string ScreenHeight { get; set; }

        [XmlElement("AUTO_EMAIL")]
        public string AutoEmail { get; set; }

        [XmlElement("OS_VERSION")]
        public string OsVersion { get; set; }

        [XmlElement("SCREEN_WIDTH")]
        public string ScreenWidth { get; set; }
    }
}