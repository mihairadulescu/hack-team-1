using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackTeam1.Core;
using HackTeam1.Entities;
using HackTeam1.OcrSystem;

namespace HackTeam1.ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IDocumentOcr ocr = new DocumentOcr();

            
        }

        private static void SeedDb()
        {
            var documentDb = new DocumentDb();
            documentDb.SaveDocument(new Document
            {
                OriginalFileName = "first.pdf",
                CreatedDate = DateTime.Now
            });
            documentDb.SaveDocument(new Document
            {
                OriginalFileName = "second.pdf",
                CreatedDate = DateTime.Now
            });
            documentDb.SaveDocument(new Document
            {
                OriginalFileName = "third.pdf",
                CreatedDate = DateTime.Now
            });
            documentDb.SaveDocument(new Document
            {
                OriginalFileName = "fourth.pdf",
                CreatedDate = DateTime.Now
            });
        }
    }
}
