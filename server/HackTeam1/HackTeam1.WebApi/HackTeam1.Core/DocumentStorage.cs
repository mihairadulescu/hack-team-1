using System;
using System.Configuration;
using System.IO;

namespace HackTeam1.Core
{
    public class DocumentStorage
    {
        public static string GetFilePath(string fileName)
        {
            var runningDirectory = ConfigurationSettings.AppSettings["storageFolder"];
            return Path.Combine(runningDirectory, fileName);
        }

        public static void SaveFile(string fileName, string contents)
        {
            var filePath = GetFilePath(fileName);
            File.WriteAllText(filePath, contents);
        }

        public static void SaveFile(string fileName, byte[] content)
        {
            var filePath = GetFilePath(fileName);
            File.WriteAllBytes(filePath, content);
        }

        public static void RemoveFile(string fileName)
        {
            var filePath = GetFilePath(fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static string GetBase64File(string fileName, string extension = "")
        {
            var filePath = GetFilePath(fileName);
            
            var imageAsByteArray = File.ReadAllBytes(filePath + extension);
            return "data:image/png;base64," + Convert.ToBase64String(imageAsByteArray);
        }
    }
}