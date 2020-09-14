using hr_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hr_system.ViewModels
{
    public class AddDocumentViewModel
    {
        public Document Document { get; set; }
        public int DocTypeId { get; set; }
        public int EmployeeId { get; set; }
        public HttpPostedFileBase DocFile { get; set; }
    }
}