using System;
using HackTeam1.Entities;

namespace HackTeam1.Core
{
    public class DocumentManagementSystem : IDocumentManagementSystem
    {
        public Document UploadDocument(byte[] content, string fileName)
        {
            SaveToStorage(content, fileName);
            var document = DetermineMimeTypeAndSaveToDb(fileName);

            return document;
        }

        public Document UpdateDocument(Document document)
        {
            return SaveDocument(document);
        }

        private static void SaveToStorage(byte[] content, string fileName)
        {
            DocumentStorage.SaveFile(fileName, content);
        }

        private static Document DetermineMimeTypeAndSaveToDb(string fileName)
        {
            var mimeTypeProvide = new MimeTypeProvider();
            var mimeType = mimeTypeProvide.GetMimeType(fileName);

            var document = new Document
            {
                OriginalFileName = fileName,
                MimeType = mimeType,
                CreatedDate = DateTime.Now
            };

            return SaveDocument(document);
        }

        private static Document SaveDocument(Document document)
        {
            var database = new DocumentDb();
            database.SaveDocument(document);
            return document;
        }
    }
}