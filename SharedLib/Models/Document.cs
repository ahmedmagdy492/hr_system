namespace SharedLib.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Document
    {
        public int Id { get; set; }

        public string DocumentPath { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public int DocTypeId { get; set; }

        public DocumentType DocumentType { get; set; }
    }
}
