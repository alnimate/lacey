using System.Collections.Generic;

namespace Lacey.Medusa.Common.Files.Models
{
    public sealed class UploadedFiles
    {
        public UploadedFiles(
            IEnumerable<UploadedItem> items)
        {
            this.Items = items;
        }

        public IEnumerable<UploadedItem> Items { get; }
    }
}