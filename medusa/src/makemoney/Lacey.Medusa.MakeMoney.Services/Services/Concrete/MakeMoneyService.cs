using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Core.Extensions;
using Lacey.Medusa.Common.Core.Serializers;
using Lacey.Medusa.Common.Core.Utils;
using Lacey.Medusa.Common.Email.Services.Email;
using Lacey.Medusa.MakeMoney.Services.Const;
using Lacey.Medusa.MakeMoney.Services.Extensions;
using Lacey.Medusa.MakeMoney.Services.Models.ScBalance;
using Lacey.Medusa.MakeMoney.Services.Models.ScCheckInDay;
using Lacey.Medusa.MakeMoney.Services.Models.ScDevice;
using Lacey.Medusa.MakeMoney.Services.Models.ScNewsAndroid;
using Lacey.Medusa.MakeMoney.Services.Models.ScSaveFirebaseToken;
using Lacey.Medusa.MakeMoney.Services.Models.Settings;
using Lacey.Medusa.MakeMoney.Services.Providers;
using Lacey.Medusa.Vendor.AdColony.Models.Ads30.Configure;
using Lacey.Medusa.Vendor.AdColony.Models.Events3.Rewardv4vc;
using Lacey.Medusa.Vendor.AdColony.Services;
using Lacey.Medusa.Vendor.AdColony.Utils;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Lacey.Medusa.MakeMoney.Services.Services.Concrete
{
    public sealed class MakeMoneyService : IMakeMoneyService
    {
        #region Fields/Constructors

        private readonly ILogger logger;

        private readonly IEmailProvider emailProvider;

        private readonly bool isSendEmails;

        private readonly string userSecretsFile;

        private readonly string commonSecretsFile;

        private readonly IMmStoreService storeService;

        private readonly IAds30Service ads30Service;

        private readonly IEvents3Service events3Service;

        private readonly MakeMoneyProvider makeMoney;

        private ScDeviceResponse scDevice;

        private bool isNewDevice;

        private UserSettings userSettings;

        public MakeMoneyService(
            ILogger logger,
            IEmailProvider emailProvider,
            bool isSendEmails, 
            string userSecretsFile, 
            string commonSecretsFile, 
            IMmStoreService storeService, 
            IAds30Service ads30Service,
            IEvents3Service events3Service)
        {
            this.logger = logger;
            this.emailProvider = emailProvider;
            this.isSendEmails = isSendEmails;
            this.userSecretsFile = userSecretsFile;
            this.commonSecretsFile = commonSecretsFile;
            this.storeService = storeService;
            this.ads30Service = ads30Service;
            this.events3Service = events3Service;

            this.makeMoney = new MakeMoneyProvider(new BaseClientService.Initializer
            {
                Serializer = new NoRootXmlSerializer()
            });

            this.userSettings = JsonConvert.DeserializeObject<UserSettings>(File.ReadAllText(this.userSecretsFile));
        }

        #endregion

        public async Task Run()
        {
            await this.ScDevice();

            await this.ScSaveFirebaseToken();

            await this.ScNewsAndroid();

            await this.ScCheckInDay();

            while (true)
            {
                var delayed = false;
                var configure = await this.ads30Service.Configure(this.GetAdColonyConfigureRequest());
                var macros = new[]
                {
                    configure.App.Macros.S2,
                    configure.App.Macros.S3,
                    configure.App.Macros.S4,
                    configure.App.Macros.S5,
                    configure.App.Macros.S6,
                    configure.App.Macros.S7,
                    configure.App.Macros.S8,
                    configure.App.Macros.S9,
                    configure.App.Macros.S10,
                    configure.App.Macros.S11,
                }.Where(m => !string.IsNullOrEmpty(m));

                foreach (var m in macros)
                {
                    var reward = await this.Rewardv4Vc(m);
                    var seAdColonyCredit = await this.SeAdColonyCredit(reward.V4VcCallback);
                    if (string.IsNullOrEmpty(seAdColonyCredit))
                    {
                        continue;
                    }
                    DelayUtils.Delay();
                    delayed = true;
                }

                if (!delayed)
                {
                    DelayUtils.Delay();
                }
            }
        }

        #region private methods

        private async Task ScDevice()
        {
            if (this.IsAuthenticated())
            {
                return;
            }

            await ProceedUtils.Proceed<bool?>(this.logger, async () =>
            {
                var session = this.storeService.GetScDevice();
                if (session != null)
                {
                    this.scDevice = session;
                    this.logger.LogTrace(this.scDevice.GetLog());
                    return true;
                }

                var request = this.makeMoney.ScDevice.ScDevice(new ScDeviceRequest
                {
                    AutoName = string.Empty,
                    Model = "Android SDK built for x86",
                    UniqueId = this.userSettings.UniqueId,
                    Manufacturer = "Google",
                    AppVesrsion = "4.0",
                    Carrier = "Android",
                    Brand = "google",
                    DeviceLanguage = "en-US",
                    FirebaseToken = this.userSettings.FirebaseToken,
                    PushId = string.Empty,
                    ReferalCode = string.Empty,
                    DeploymentType = "1",
                    ScreenHeight = "1794",
                    AutoEmail = string.Empty,
                    OsVersion = "9",
                    ScreenWidth = "1080"
                }).SetDefault();

                var response = await request.ExecuteAsync();
                if (response == null)
                {
                    this.logger.LogError("Authorization failed.");
                    DelayUtils.LargeDelay();
                    return null;
                }

                this.scDevice = response;
                this.logger.LogTrace(this.scDevice.GetLog());
                this.storeService.SaveScDevice(this.scDevice);
                this.isNewDevice = true;
                return true;
            });
        }

        private async Task ScSaveFirebaseToken()
        {
            if (!this.IsAuthenticated())
            {
                return;
            }

            if (!this.IsNewDevice())
            {
                return;
            }

            await ProceedUtils.Proceed<bool?>(this.logger, async () =>
            {
                var request = this.makeMoney.ScSaveFirebaseToken.ScSaveFirebaseToken(new ScSaveFirebaseTokenRequest
                {
                    FirebaseToken = this.userSettings.FirebaseToken,
                    CustomerId = this.scDevice.CustomerId,
                    Version = this.userSettings.UniqueId
                }).SetDefault();

                var response = await request.ExecuteAsync();
                this.logger.LogTrace(response.GetLog());
                return true;
            });
        }

        private async Task ScNewsAndroid()
        {
            if (!this.IsAuthenticated())
            {
                return;
            }

            await ProceedUtils.Proceed<bool?>(this.logger, async () =>
            {
                var request = this.makeMoney.ScNewsAndroid.ScNewsAndroid(new ScNewsAndroidRequest
                {
                    Os = "9",
                    Country = string.Empty,
                    CustomerId = this.scDevice.CustomerId,
                    Version = this.userSettings.UniqueId,
                    AdvertisingId = this.userSettings.AdvertiserId
                }).SetDefault();

                var response = await request.ExecuteAsync();
                this.logger.LogTrace(response.GetLog());
                return true;
            });
        }

        private async Task ScCheckInDay()
        {
            if (!this.IsAuthenticated())
            {
                return;
            }

            await ProceedUtils.Proceed<bool?>(this.logger, async () =>
            {
                var request = this.makeMoney.ScCheckInDay.ScCheckInDay(new ScCheckInDayRequest
                {
                    CustomerId = this.scDevice.CustomerId,
                    Version = this.userSettings.UniqueId,
                }).SetDefault();

                var response = await request.ExecuteAsync();
                this.logger.LogTrace(response.GetLog());
                return true;
            });
        }

        private async Task ScBalance()
        {
            if (!this.IsAuthenticated())
            {
                return;
            }

            await ProceedUtils.Proceed<bool?>(this.logger, async () =>
            {
                var request = this.makeMoney.ScBalance.ScBalance(new ScBalanceRequest
                {
                    CustomerId = this.scDevice.CustomerId,
                    Version = this.userSettings.UniqueId,
                }).SetDefault();

                var response = await request.ExecuteAsync();
                this.logger.LogTrace(response.GetLog());
                return true;
            });
        }

        private async Task<string> SeAdColonyCredit(string callback)
        {
            if (!this.IsAuthenticated())
            {
                return string.Empty;
            }

            if (string.IsNullOrEmpty(callback))
            {
                return string.Empty;
            }

            return await ProceedUtils.Proceed(this.logger, async () =>
            {
                var r = HttpUtility.ParseQueryString(new Uri(callback).Query);
                var request = this.makeMoney.SeAdColonyCredit.SeAdColonyCredit(
                    r["id"],
                    r["uid"],
                    r["zone"],
                    r["amount"],
                    r["currency"],
                    r["verifier"],
                    r["open_udid"],
                    r["udid"],
                    r["odin1"],
                    r["mac_sha1"],
                    r["custom_id"]).SetSe();

                var response = await request.ExecuteAsync();
                this.logger.LogTrace(response.GetLog());
                return response;
            });
        }

        private async Task<Rewardv4VcModel> Rewardv4Vc(string pl)
        {
            return await ProceedUtils.Proceed(this.logger, async () =>
            {
                var guid = Guid.NewGuid().ToString();
                var request = new Rewardv4VcRequestModel
                {
                    EventType = "reward_v4vc",
                    Guid = guid,
                    GuidKey = $"{guid}{AdColony.GuidKeyPostfix}",
                    Replay = false,
                    Reward = true,
                    RewardAmount = 2,
                    RewardName = "Credits",
                    SImpCount = 1,
                    STime = 81.65299987792969,
                    Sid = AdColony.Sid,
                    ZoneId = AdColony.Zones.First()
                };
                var response = await this.events3Service.Rewardv4Vc(pl, request);
                if(response != null && !string.IsNullOrEmpty(response.V4VcCallback))
                {
                    this.logger.LogTrace(response.GetLog());
                }
                return response;
            });
        }

        private bool IsAuthenticated()
        {
            return this.scDevice != null;
        }

        private bool IsNewDevice()
        {
            return this.isNewDevice;
        }

        private ConfigureRequestModel GetAdColonyConfigureRequest()
        {
            var request = AdColonyDefault.GetConfigureRequest(
                this.userSettings.AdvertiserId,
                this.scDevice.CustomerId,
                AdColony.MediaPath,
                AdColony.TempStoragePath,
                this.scDevice.CustomerId,
                AdColony.AddId,
                AdColony.BundleId,
                AdColony.Zones,
                AdColony.Sid,
                AdColony.ZoneIds,
                AdColony.GuidKeyPostfix);

            return request;
        }

        #endregion
    }
}