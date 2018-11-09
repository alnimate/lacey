using System.ComponentModel.DataAnnotations;
using Lacey.Medusa.Common.Validation.Validation;

namespace Lacey.Medusa.Youtube.Services.Store.Models
{
    public sealed class StoreChannelInfo : ValidatableModel
    {
        public StoreChannelInfo(
            string channelId, 
            string title, 
            string description)
        {
            ChannelId = channelId;
            Title = title;
            Description = description;
        }

        [Required]
        [MaxLength(30)]
        public string ChannelId { get; }

        [Required]
        public string Title { get; }

        public string Description { get; }
    }
}