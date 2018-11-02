using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lacey.Medusa.Common.Files.Resources
{
    public class BindedToEntityResource
    {
        public BindedToEntityResource(
            string entity,
            string entityId,
            IEnumerable<BindedItemResource> items)
        {
            this.Entity = entity;
            this.EntityId = entityId;
            this.Items = items;
        }

        [Required]
        public string Entity { get; set; }

        [Required]
        public string EntityId { get; set; }

        public IEnumerable<BindedItemResource> Items { get; set; }
    }
}