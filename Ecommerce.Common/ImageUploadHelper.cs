using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ecommerce.Common
{
    public static class ImageUploadHelper
    {
        public static char DirSeparator = Path.DirectorySeparatorChar;

        static DateTime now = DateTime.Now;
        static readonly string YearName = now.ToString("yyyy");
        static readonly string MonthName = now.ToString("MMMM");
        static readonly string DayName = now.ToString("dd");
        private const string Basepath = "~/Content/Uploads";

        public static string UploadPath =
           Path.Combine(Basepath, Path.Combine(YearName, Path.Combine(MonthName, DayName)));


        public static string UploadFile(HttpPostedFile file)
        {
            string returnFileName = string.Empty;
            // Check if we have a file
            if (null == file) return returnFileName;
            // Make sure the file has content
            if (!(file.ContentLength > 0)) return returnFileName;
            string fileName = file.FileName;
            string fileExt = Path.GetExtension(file.FileName);
            // Make sure we were able to determine a proper
            // extension
            if (null == fileExt) return returnFileName;


            if (!Directory.Exists(CommonHelpers.MapPath(UploadPath)))
            {
                // If it doesn't exist, create the directory
                Directory.CreateDirectory(CommonHelpers.MapPath(UploadPath));
            }
            string savePath = $"{Basepath}/{YearName}/{MonthName}/{DayName}/";
            savePath = CommonHelpers.GetApplicationLocation() + savePath.Substring(2);

            fileName = fileName.Replace(fileName, Guid.NewGuid().ToString() + fileExt);
            returnFileName = savePath + fileName;
            // Set our full path for saving
            string path = UploadPath + DirSeparator + fileName;
            // Save our file
            file.SaveAs(CommonHelpers.MapPath(path));

            return returnFileName;

        }
    }
}
