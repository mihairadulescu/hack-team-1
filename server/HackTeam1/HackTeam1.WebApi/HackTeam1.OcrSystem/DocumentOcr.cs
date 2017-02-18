using System;
using System.CodeDom;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using HackTeam1.Core;
using HackTeam1.Entities;
using Tesseract;

namespace HackTeam1.OcrSystem
{
    public class DocumentOcr : IDocumentOcr
    {
        private string ROMANIAN = "ron";
        private string ENGLISH = "eng";

        private const string DATA_DIR = "./tessdata";
        private DocumentDb database = new DocumentDb();

        public Document PerformOcr(Document document)
        {
            var fileName = document.OriginalFileName;
            Console.WriteLine("Performing OCR on {0}", fileName);

            var roTask = ExtractTextFromImage(ROMANIAN, fileName);
            var engTask = ExtractTextFromImage(ENGLISH, fileName);
            Task.WaitAll(roTask, engTask);

            var romanianResult = roTask.Result;
            var englishResult = engTask.Result;
            Console.WriteLine("RO confidence: {0}", romanianResult.Confidence);
            Console.WriteLine("ENG confidence: {0}", englishResult.Confidence);

            SetDocumentText(document, romanianResult, englishResult);
            SaveTextToStorage(document);

            return document;
        }

        private static void SaveTextToStorage(Document document)
        {
            var ocrFileName = Path.GetFileNameWithoutExtension(document.OriginalFileName) + ".txt";
            document.OcrFileName = ocrFileName;

            DocumentStorage.SaveFile(ocrFileName, document.Text);
        }

        private static void SetDocumentText(Document document, ExtractionResult romanianResult, ExtractionResult englishResult)
        {
            if (romanianResult.Confidence > englishResult.Confidence)
            {
                Console.WriteLine("Using RO ocr text");
                document.Text = romanianResult.Text;
            }
            else
            {
                Console.WriteLine("Using ENG ocr text");
                document.Text = englishResult.Text;
            }
        }

        private static Task<ExtractionResult> ExtractTextFromImage(string language, string imageFileName)
        {
            return Task.Run(() =>
            {
                var filePath = DocumentStorage.GetFilePath(imageFileName);
                using (var engine = new TesseractEngine(DATA_DIR, language, EngineMode.Default))
                using (var img = Pix.LoadFromFile(filePath))
                using (var page = engine.Process(img))
                {
                    var text = page.GetText();
                    var confidence = page.GetMeanConfidence();

                    return new ExtractionResult
                    {
                        Text = text,
                        Confidence = confidence
                    };
                }
            });
        }

        private struct ExtractionResult
        {
            public string Text { get; set; }
            public double Confidence { get; set; }
        }
    }
}