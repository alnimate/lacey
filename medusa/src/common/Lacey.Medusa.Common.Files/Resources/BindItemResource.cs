using System.ComponentModel.DataAnnotations;

namespace Lacey.Medusa.Common.Files.Resources
{
    public sealed class BindItemResource
    {
        public BindItemResource()
        {            
        }

        public BindItemResource(string fileName)
        {
            this.FileName = fileName;
        }

        [Required]
        [MaxLength(255)]
        public string FileName { get; set; }
    }
}