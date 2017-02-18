using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            SeedDb();

            IDocumentOcr ocr = new DocumentOcr();

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var documentDb = new DocumentDb();
            foreach (var doc in documentDb.GetAllDocuments())
            {
                ocr.PerformOcr(doc);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Total time elapsed: {0}", stopWatch.Elapsed.ToString("g"));

            Console.ReadKey();
        }

        private static void SeedDb()
        {
            var documentDb = new DocumentDb();
            documentDb.SaveDocument(new Document
            {
                OriginalFileName = "58a83a614bdca.tiff",
                CreatedDate = DateTime.Now
            });
            documentDb.SaveDocument(new Document
            {
                OriginalFileName = "AVS51095.tiff",
                CreatedDate = DateTime.Now
            });
            documentDb.SaveDocument(new Document
            {
                OriginalFileName = "InvoiceStay_LA.tiff",
                CreatedDate = DateTime.Now
            });
            documentDb.SaveDocument(new Document
            {
                OriginalFileName = "InvoiceStay_NY.tiff",
                CreatedDate = DateTime.Now
            });
        }
    }
}
