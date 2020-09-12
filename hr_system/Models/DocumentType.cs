namespace hr_system.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DocumentType
    {
        public int Id { get; set; }

        public string DocTypeName { get; set; }

        public int DocumentId { get; set; }

        public virtual Document Document { get; set; }
    }
}
