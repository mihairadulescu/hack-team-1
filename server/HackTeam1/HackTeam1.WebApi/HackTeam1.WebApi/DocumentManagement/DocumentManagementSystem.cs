using System;
using HackTeam1.Core;
using HackTeam1.Entities;
using HackTeam1.SearchEngine;

namespace HackTeam1.WebApi.DocumentManagement
{
    public class DocumentManagementSystem : IDocumentManagementSystem
    {
        public IElasticSearchEngine ElasticSearchEngine { get; set; }

        public DocumentManagementSystem()
        {
            ElasticSearchEngine = new ElasticSearchEngine();
        }

        public Document UploadDocument(byte[] content, string fileName)
        {
            SaveToStorage(content, fileName);

            var mimeTypeProvide = new MimeTypeProvider();
            var mimeType = mimeTypeProvide.GetMimeType(fileName);

            var document = new Document
            {
                OriginalFileName = fileName,
                MimeType = mimeType,
                CreatedDate = DateTime.Now
            };

            SaveDocument(document);

            var ocr = new OcrSystem.DocumentOcr();
            return ocr.PerformOcr(document);
        }

        public Document UpdateDocument(Document document)
        {
            this.ElasticSearchEngine.Index(document);
            return SaveDocument(document);
        }

        private static void SaveToStorage(byte[] content, string fileName)
        {
            DocumentStorage.SaveFile(fileName, content);
        }

        private static Document SaveDocument(Document document)
        {
            var database = new DocumentDb();
            database.SaveDocument(document);
            return document;
        }
    }
}