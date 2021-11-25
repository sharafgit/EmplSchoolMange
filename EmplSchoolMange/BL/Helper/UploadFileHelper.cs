using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmplSchoolMange.BL.Helper
{
    public static class UploadFileHelper
    {
        public static String SaveFile (IFormFile FileUrl, string  FolderPath)
        {
            #region Save Photo
            // Get Directory
            string FilePath = Directory.GetCurrentDirectory()+ "/wwwroot/Files/" + FolderPath;

            //Get File Name
            string FileName = Guid.NewGuid() + Path.GetFileName(FileUrl.FileName);

            //Merg The Directory With File Name
            string FinalPath = Path.Combine(FilePath, FileName);

            //Save Your File As Stream "Data Overtime"
            using (var Stream = new FileStream(FinalPath, FileMode.Create))
            {
                FileUrl.CopyTo(Stream);
            }
            #endregion
            return FileName;

        }



        public static void RemoveFile(string FolderName ,string RemovedFileName)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/Files/"+ FolderName + RemovedFileName))
            {
                File.Delete(Directory.GetCurrentDirectory() +"/wwwroot/Files/" + FolderName + RemovedFileName);
            }
        }
    }
}