using System.Collections.Generic;

namespace Lacey.Medusa.Common.Files.Resources
{
    public sealed class UploadFilesResource
    {
        public UploadFilesResource()
        {            
        }

        public UploadFilesResource(
            IEnumerable<UploadItemResource> items)
        {
            this.Items = items;
        }

        public IEnumerable<UploadItemResource> Items { get; set; }
    }
}