namespace hr_system.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PhoneNumber
    {
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }

        public int Employee_id { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
