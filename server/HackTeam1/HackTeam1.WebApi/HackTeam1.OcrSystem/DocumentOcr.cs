﻿using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using HackTeam1.Core;
using HackTeam1.Entities;
using Tesseract;
using System.Drawing;
using System.Drawing.Imaging;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace HackTeam1.OcrSystem
{
    public class DocumentOcr : IDocumentOcr
    {
        private string ROMANIAN = "ron";
        private string ENGLISH = "eng";

        private static string DATA_DIR = ConfigurationSettings.AppSettings["tessData"];

        public Document PerformOcr(Document document)
        {
            var stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            Console.WriteLine();
            Console.WriteLine("Performing OCR on {0}", document.OriginalFileName + document.Extension);
            var roTask = ExtractTextFromImage(ROMANIAN, document.OriginalFileName + document.Extension);
            var engTask = ExtractTextFromImage(ENGLISH, document.OriginalFileName + document.Extension);
            Task.WaitAll(roTask, engTask);

            var romanianResult = roTask.Result;
            var englishResult = engTask.Result;
            Console.WriteLine("RO confidence: {0}", romanianResult.Confidence);
            Console.WriteLine("ENG confidence: {0}", englishResult.Confidence);

            SetDocumentText(document, romanianResult, englishResult);
            SuggestTitle(document);
            SuggestCategory(document);

            Console.WriteLine("Time elapsed: {0}", stopWatch.Elapsed.ToString("g"));
            return document;
        }

        private static void SuggestCategory(Document document)
        {
            var suggestions = new CategorySuggestions();
            document.Category = suggestions.SuggestCategory(document) + "_";
        }

        private static void SuggestTitle(Document document)
        {
            document.Title = Path.GetFileNameWithoutExtension(document.OriginalFileName + document.Extension) + "_";
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

        public string ConvertTiffToPng(string fileName)
        {
            var storagePath = ConfigurationSettings.AppSettings["storageFolder"];
            var fullPath = Path.Combine(storagePath, fileName);

            var withoutExtension = Path.GetFileNameWithoutExtension(fileName);
            var pngPath = Path.Combine(storagePath, withoutExtension + ".png");

            Image.FromFile(fullPath).Save(pngPath, ImageFormat.Png);

            return pngPath;
        }
    }
}