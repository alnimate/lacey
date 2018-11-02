using System.Collections.Generic;

namespace Lacey.Medusa.Common.Files.Models
{
    public sealed class UploadFiles
    {
        public UploadFiles(
            IEnumerable<UploadItem> items)
        {
            this.Items = items;
        }

        public IEnumerable<UploadItem> Items { get; }
    }
}