using System.ComponentModel.DataAnnotations;

namespace Lacey.Medusa.Common.Files.Resources
{
    public sealed class UploadItemResource
    {
        public UploadItemResource()
        {            
        }

        public UploadItemResource(
            string originalFileName,
            string mimeType,
            byte[] file)
        {
            this.OriginalFileName = originalFileName;
            this.MimeType = mimeType;
            this.File = file;
        }

        [Required]
        [MaxLength(255)]
        public string OriginalFileName { get; set; }

        [Required]
        [MaxLength(255)]
        public string MimeType { get; set; }

        public byte[] File { get; set; }
    }
}