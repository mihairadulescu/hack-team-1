using System.IO;
using System.Text;

namespace HackTeam1.Core
{
    public class DocumentStorage
    {
        public string GetFilePath(string fileName)
        {
            return Path.Combine("storage", fileName);
        }

        public void SaveFile(string fileName, string contents)
        {
            var filePath = GetFilePath(fileName);
            File.WriteAllText(filePath, contents);
        }

        public void SaveFile(string fileName, byte[] content)
        {
            var fileContents = Encoding.UTF8.GetString(content);
            SaveFile(fileName, fileContents);
        }
    }
}