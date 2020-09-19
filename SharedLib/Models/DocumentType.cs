namespace SharedLib.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class DocumentType
    {
        public int Id { get; set; }
        public string DocTypeName { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}
