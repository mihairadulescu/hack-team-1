using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using HackTeam1.Entities;

namespace HackTeam1.Core
{
    public class DocumentDb
    {
        private const string DB_PATH = "storage/database.xml";
        private static readonly object locker = new object();

        public List<Document> GetAllDocuments()
        {
            lock (locker)
            {
                var root = GetRootElement();
                return root.Elements("document").Select(Parse).ToList();
            }
        }

        public Document LoadDocument(string fileName)
        {
            lock (locker)
            {
                var match = GetAllDocuments().FirstOrDefault(x => x.OriginalFileName == fileName);
                if (match != null)
                    return match;

                throw new FileNotFoundException("Could not find document", fileName);
            }
        }

        public void SaveDocument(Document document)
        {
            lock (locker)
            {
                var root = GetRootElement();
                var match =
                    root.Elements("document")
                        .FirstOrDefault(x => 
                            x.Attribute("originalFileName").Value == document.OriginalFileName);

                if (match != null)
                {
                    match.ReplaceWith(ToXml(document));
                }
                else
                {
                    root.Add(ToXml(document));
                }

                root.Save(DB_PATH);
            }
        }

        private static Document Parse(XElement element)
        {
            var document = new Document
            {
                OriginalFileName = element.Attribute("originalFileName").Value,
                OcrFileName = element.Attribute("ocrFileName").Value,
                Title = element.Attribute("title").Value,
                MimeType = element.Attribute("mimeType").Value,
                Category = element.Attribute("category").Value,
                CreatedDate = ParseDate(element.Attribute("createdDate").Value),
                IndexedDate = ParseDate(element.Attribute("indexedDate").Value),
                Text = element.Attribute("text").Value
            };

            return document;
        }

        private static DateTime ParseDate(string date)
        {
            DateTime val;
            DateTime.TryParse(date, out val);

            return val;
        }

        private static XElement ToXml(Document document)
        {
            const string dateFormat = "dd/MM/yyyy HH:mm:ss";
            return new XElement("document",
                new XAttribute("originalFileName", document.OriginalFileName ?? ""),
                new XAttribute("ocrFileName", document.OcrFileName ?? ""),
                new XAttribute("title", document.Title ?? ""),
                new XAttribute("mimeType", document.MimeType ?? ""),
                new XAttribute("category", document.Category ?? ""),
                new XAttribute("createdDate", document.CreatedDate.ToString(dateFormat)),
                new XAttribute("indexedDate", document.IndexedDate.ToString(dateFormat)),
                new XAttribute("text", document.Text ?? "")
            );
        }

        private static XElement GetRootElement()
        {
            var fileContents = File.ReadAllText(DB_PATH);
            var elem = XElement.Parse(fileContents);
            return elem;
        }
    }
}