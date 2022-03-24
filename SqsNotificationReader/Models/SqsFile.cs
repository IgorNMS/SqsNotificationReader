using System.ComponentModel.DataAnnotations;

namespace SqsNotificationReader.Models
{
    internal class SqsFile
    {
        [Key]
        public string? FileName { get; set; }
        public long? FileSize { get; set; }
        public DateTime LastModified { get; set; }
    }
}
