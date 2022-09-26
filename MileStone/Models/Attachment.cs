using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MileStone.Models
{
    public class Attachment
    {
        [Key]
        public Guid AttachmentUID { get; set; }

        public string FileName { get; set; }

        public Guid RelatedItemUID { get; set; }

        public string RelatedItemType { get; set; }

        public string PhysicalPath { get; set; }

        public byte[] Document { get; set; }

    }
}
