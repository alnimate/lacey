﻿using System.Collections.Generic;
using System.Threading.Tasks;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.Models;
using Lacey.Medusa.Instagram.Api.Services;
using Lacey.Medusa.Instagram.Api.Services.Concrete;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Boost.Services.Providers.Concrete
{
    public sealed class InstagramBoostProvider : InstagramProvider, IInstagramBoostProvider
    {
        #region Properties/Constructors

        private readonly ILogger logger;

        public InstagramBoostProvider(
            IInstagramAuthProvider instagramAuthProvider,
            ILogger<InstagramBoostProvider> logger)
            : base(instagramAuthProvider, logger)
        {
            this.logger = logger;
        }

        #endregion

        public async Task<IResult<InstaHashtagSearch>> SearchHashtagAsync(
            string query, 
            IEnumerable<long> excludeList = null,
            string rankToken = null)
        {
            return await this.Instagram.HashtagProcessor.SearchHashtagAsync(query, excludeList, rankToken);
        }
    }
}