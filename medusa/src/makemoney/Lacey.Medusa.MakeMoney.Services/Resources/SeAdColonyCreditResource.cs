using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Discovery;
using Lacey.Medusa.Common.Api.Core.Base.Http;
using Lacey.Medusa.Common.Api.Core.Base.Util;
using Lacey.Medusa.Common.Core.Api;

namespace Lacey.Medusa.MakeMoney.Services.Resources
{
    public sealed class SeAdColonyCreditResource : ApiResource
    {
        public SeAdColonyCreditResource(IClientService service) : base(service)
        {
        }

        public SeAdColonyCreditApiRequest SeAdColonyCredit(
            string id,
            string uid,
            string zone,
            string amount,
            string currency,
            string verifier,
            string openUdid,
            string udid,
            string odin1,
            string macSha1,
            string customId)
        {
            return new SeAdColonyCreditApiRequest(this.Service, 
                id,
                uid,
                zone,
                amount,
                currency,
                verifier,
                openUdid,
                udid,
                odin1,
                macSha1,
                customId);
        }

        public sealed class SeAdColonyCreditApiRequest : ApiRequest<string>
        {
            public SeAdColonyCreditApiRequest(
                IClientService service, 
                string id, 
                string uid, 
                string zone, 
                string amount, 
                string currency, 
                string verifier, 
                string openUdid, 
                string udid, 
                string odin1, 
                string macSha1, 
                string customId) : base(service)
            {
                Id = id;
                Uid = uid;
                Zone = zone;
                Amount = amount;
                Currency = currency;
                Verifier = verifier;
                OpenUdid = openUdid;
                Udid = udid;
                Odin1 = odin1;
                MacSha1 = macSha1;
                CustomId = customId;

                this.RequestParameters.Add("id", new Parameter
                {
                    Name = "id",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });

                this.RequestParameters.Add("uid", new Parameter
                {
                    Name = "uid",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });

                this.RequestParameters.Add("zone", new Parameter
                {
                    Name = "zone",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });

                this.RequestParameters.Add("amount", new Parameter
                {
                    Name = "amount",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });

                this.RequestParameters.Add("currency", new Parameter
                {
                    Name = "currency",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });

                this.RequestParameters.Add("verifier", new Parameter
                {
                    Name = "verifier",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });

                this.RequestParameters.Add("open_udid", new Parameter
                {
                    Name = "open_udid",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });

                this.RequestParameters.Add("udid", new Parameter
                {
                    Name = "udid",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });

                this.RequestParameters.Add("odin1", new Parameter
                {
                    Name = "odin1",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });

                this.RequestParameters.Add("mac_sha1", new Parameter
                {
                    Name = "mac_sha1",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });

                this.RequestParameters.Add("custom_id", new Parameter
                {
                    Name = "custom_id",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });
            }

            public override string RestPath => "SE_AdColonyCredit";

            public override string HttpMethod => HttpConsts.Get;

            [RequestParameter("id", RequestParameterType.Query)]
            public string Id { get; private set; }

            [RequestParameter("uid", RequestParameterType.Query)]
            public string Uid { get; private set; }

            [RequestParameter("zone", RequestParameterType.Query)]
            public string Zone { get; private set; }

            [RequestParameter("amount", RequestParameterType.Query)]
            public string Amount { get; private set; }

            [RequestParameter("currency", RequestParameterType.Query)]
            public string Currency { get; private set; }

            [RequestParameter("verifier", RequestParameterType.Query)]
            public string Verifier { get; private set; }

            [RequestParameter("open_udid", RequestParameterType.Query)]
            public string OpenUdid { get; private set; }

            [RequestParameter("udid", RequestParameterType.Query)]
            public string Udid { get; private set; }

            [RequestParameter("odin1", RequestParameterType.Query)]
            public string Odin1 { get; private set; }

            [RequestParameter("mac_sha1", RequestParameterType.Query)]
            public string MacSha1 { get; private set; }

            [RequestParameter("custom_id", RequestParameterType.Query)]
            public string CustomId { get; private set; }
        }
    }
}