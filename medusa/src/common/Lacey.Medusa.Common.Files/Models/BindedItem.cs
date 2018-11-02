using System.ComponentModel.DataAnnotations;

namespace Lacey.Medusa.Common.Files.Models
{
    public sealed class BindedItem
    {
        public BindedItem(string fileName)
        {
            this.FileName = fileName;
        }

        [Required]
        [MaxLength(255)]
        public string FileName { get; }
    }
}