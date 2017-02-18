using System;

namespace HackTeam1.Entities
{
    public class Document
    {
        public Document()
        {
            Title = "";
            MimeType = "";
            Category = "";
            OriginalFileName = "";
            OcrFileName = "";
            Text = "";
        }

        public string Title { get; set; }
        public string MimeType { get; set; }
        public string Category { get; set; }
        public string OriginalFileName { get; set; }
        public string OcrFileName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime IndexedDate { get; set; }
        public string Text { get; set; }
    }
}