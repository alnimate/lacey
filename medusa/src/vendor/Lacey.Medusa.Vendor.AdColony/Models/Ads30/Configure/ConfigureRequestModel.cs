using Newtonsoft.Json;

namespace Lacey.Medusa.Vendor.AdColony.Models.Ads30.Configure
{
    public sealed class ConfigureRequestModel
    {
        [JsonProperty("advertiser_id")]
        public string AdvertiserId { get; set; }

        [JsonProperty("carrier")]
        public string Carrier { get; set; }

        [JsonProperty("custom_id")]
        public string CustomId { get; set; }

        [JsonProperty("limit_tracking")]
        public bool LimitTracking { get; set; }

        [JsonProperty("ln")]
        public string Ln { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("media_path")]
        public string MediaPath { get; set; }

        [JsonProperty("temp_storage_path")]
        public string TempStoragePath { get; set; }

        [JsonProperty("device_brand")]
        public string DeviceBrand { get; set; }

        [JsonProperty("device_model")]
        public string DeviceModel { get; set; }

        [JsonProperty("device_type")]
        public string DeviceType { get; set; }

        [JsonProperty("network_type")]
        public string NetworkType { get; set; }

        [JsonProperty("os_name")]
        public string OsName { get; set; }

        [JsonProperty("os_version")]
        public string OsVersion { get; set; }

        [JsonProperty("sdk_version")]
        public string SdkVersion { get; set; }

        [JsonProperty("battery_level")]
        public int BatteryLevel { get; set; }

        [JsonProperty("sdk_type")]
        public string SdkType { get; set; }

        [JsonProperty("current_orientation")]
        public int CurrentOrientation { get; set; }

        [JsonProperty("timezone_ietf")]
        public string TimezoneIetf { get; set; }

        [JsonProperty("timezone_gmt_m")]
        public int TimezoneGmtM { get; set; }

        [JsonProperty("timezone_dst_m")]
        public int TimezoneDstM { get; set; }

        [JsonProperty("cell_service_country_code")]
        public string CellServiceCountryCode { get; set; }

        [JsonProperty("display_dpi")]
        public int DisplayDpi { get; set; }

        [JsonProperty("android_id_sha1")]
        public string AndroidIdSha1 { get; set; }

        [JsonProperty("device_api")]
        public int DeviceApi { get; set; }

        [JsonProperty("memory_used_mb")]
        public int MemoryUsedMb { get; set; }

        [JsonProperty("memory_class")]
        public int MemoryClass { get; set; }

        [JsonProperty("available_stores")]
        public string[] AvailableStores { get; set; }

        [JsonProperty("permissions")]
        public string[] Permissions { get; set; }

        [JsonProperty("immersion")]
        public bool Immersion { get; set; }

        [JsonProperty("screen_height")]
        public int ScreenHeight { get; set; }

        [JsonProperty("screen_width")]
        public int ScreenWidth { get; set; }

        [JsonProperty("cleartext_permitted")]
        public bool CleartextPermitted { get; set; }

        [JsonProperty("origin_store")]
        public string OriginStore { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("bundle_id")]
        public string BundleId { get; set; }

        [JsonProperty("zones")]
        public string[] Zones { get; set; }

        [JsonProperty("ad_history")]
        public object AdHistory { get; set; }

        [JsonProperty("ad_playing")]
        public object AdPlaying { get; set; }

        [JsonProperty("ad_queue")]
        public object AdQueue { get; set; }

        [JsonProperty("sid")]
        public string Sid { get; set; }

        [JsonProperty("s_imp_count")]
        public int SImpCount { get; set; }

        [JsonProperty("device_time")]
        public long DeviceTime { get; set; }

        [JsonProperty("controller_version")]
        public string ControllerVersion { get; set; }

        [JsonProperty("zone_ids")]
        public string[] ZoneIds { get; set; }

        [JsonProperty("force_ad_id")]
        public string ForceAdId { get; set; }

        [JsonProperty("test_mode")]
        public bool TestMode { get; set; }

        [JsonProperty("s_time")]
        public double STime { get; set; }

        [JsonProperty("ad_request")]
        public bool AdRequest { get; set; }

        [JsonProperty("device_audio")]
        public bool DeviceAudio { get; set; }

        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("guid_key")]
        public string GuidKey { get; set; }

        [JsonProperty("user_metadata")]
        public object UserMetadata { get; set; }
    }
}