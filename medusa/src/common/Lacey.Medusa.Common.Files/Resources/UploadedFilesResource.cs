using System.Collections.Generic;

namespace Lacey.Medusa.Common.Files.Resources
{
    public sealed class UploadedFilesResource
    {
        public UploadedFilesResource()
        {
        }

        public UploadedFilesResource(
            IEnumerable<UploadedItemResource> items)
        {
            this.Items = items;
        }

        public IEnumerable<UploadedItemResource> Items { get; set; }
    }
}