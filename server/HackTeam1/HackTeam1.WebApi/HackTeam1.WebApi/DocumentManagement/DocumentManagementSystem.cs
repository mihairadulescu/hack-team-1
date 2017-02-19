using System;
using System.IO;
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
                OriginalFileName = Path.GetFileNameWithoutExtension(fileName),
                MimeType = mimeType,
                Extension = Path.GetExtension(fileName),
                CreatedDate = DateTime.Now,
                IndexedDate = DateTime.Now
            };

            var ocr = new OcrSystem.DocumentOcr();
            var ocrizedDocument = ocr.PerformOcr(document);
            
            ElasticSearchEngine.Index(ocrizedDocument);

            return ocrizedDocument;
        }

        public Document UpdateDocument(Document document)
        {
            this.ElasticSearchEngine.Index(document);

            return document;
        }

        public Document GetWithDetails(string fileName)
        {
            var document = this.ElasticSearchEngine.GetBy(fileName);
            document.ImageContent = DocumentStorage.GetBase64File(fileName, document.Extension);

            return document;
        }

        private static void SaveToStorage(byte[] content, string fileName)
        {
            DocumentStorage.SaveFile(fileName, content);
        }

    }
}