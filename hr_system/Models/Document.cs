namespace hr_system.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Document
    {
        public int Id { get; set; }

        public string DocumentPath { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        [ForeignKey(nameof(DocumentType))]
        public int DocTypeId { get; set; }

        public DocumentType DocumentType { get; set; }
    }
}
