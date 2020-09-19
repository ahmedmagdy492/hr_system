namespace SharedLib.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class PhoneNumber
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public int Employee_id { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
