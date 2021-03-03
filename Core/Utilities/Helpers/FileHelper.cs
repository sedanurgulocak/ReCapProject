using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string CreateNewFilePath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;
            string path = Environment.CurrentDirectory + @"\CarImages";
            string newPath = Guid.NewGuid().ToString() + fileExtension;
            string result = $@"{path}\{newPath}";
            return result;
        }

        public static string Add(IFormFile file)
        {
            string sourcePath = Path.GetTempFileName();
            string destFileName = CreateNewFilePath(file);

            if (file.Length > 0)
            {
                using (var stream =new FileStream(destFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            //string destFileName = CreateNewFilePath(file);
            
            //File.Move(sourcePath, destFileName);
            return destFileName;
        }

        public static string Update(string sourcePath, IFormFile file)
        {
            string result = CreateNewFilePath(file);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }catch(Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
    }
}
