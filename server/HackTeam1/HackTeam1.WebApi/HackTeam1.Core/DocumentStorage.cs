using System.IO;
using System.Reflection;
using System.Text;

namespace HackTeam1.Core
{
    public class DocumentStorage
    {
        public static string GetFilePath(string fileName)
        {
            var runningDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Path.Combine(runningDirectory, "storage", fileName);
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
    }
}