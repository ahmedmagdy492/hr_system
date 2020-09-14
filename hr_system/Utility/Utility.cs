using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace hr_system.Utility
{
    public static class Utility
    {
        public static string SaveToDisk(HttpContext httpContext, HttpPostedFileBase file, string pathToSaveTo)
        {
            string filePath = Guid.NewGuid().ToString() + file.FileName;
            string fullPath = Path.Combine(httpContext.Server.MapPath(pathToSaveTo), filePath);

            file.SaveAs(fullPath);

            return filePath;
        }
    }
}