using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace InteliHealth.Utils
{
    public class Upload
    {
        public static string UploadFile(IFormFile file, string[] acceptedExtensions)
        {
            try
            {
                var folder = Path.Combine("StaticFiles", "Images");
                var path = Path.Combine(Directory.GetCurrentDirectory(), folder);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                    if (CheckExtension(acceptedExtensions, fileName))
                    {
                        var extension = GetExtension(fileName);
                        var newName = $"{Guid.NewGuid()}{extension}";
                        var fullPath = Path.Combine(path, newName);

                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        return newName;
                    }

                    return "Extensão não permitida";
                }
                return "";
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }

        public static bool CheckExtension(string[] extensions, string fileName)
        {
            string[] data = fileName.Split('.');
            string extension = data[data.Length - 1];

            foreach (var item in extensions)
            {
                if (extension == item)
                {
                    return true;
                }
            }

            return false;
        }

        public static string GetExtension(string fileName)
        {
            string[] data = fileName.Split('.');
            return data[data.Length - 1];
        }
        
        public static void RemoveFile(string fileName)
        {
            var folder = Path.Combine("StaticFiles", "Images");
            var path = Path.Combine(Directory.GetCurrentDirectory(), folder);
            var fullPath = Path.Combine(path, fileName);

            File.Delete(fullPath);
            
        }
    }
}
