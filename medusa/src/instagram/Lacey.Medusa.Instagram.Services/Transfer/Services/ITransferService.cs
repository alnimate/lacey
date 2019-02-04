﻿using System.Threading.Tasks;

namespace Lacey.Medusa.Instagram.Services.Transfer.Services
{
    public interface ITransferService
    {
        Task Transfer(string sourceChannelId, string destChannelId);
    }
}