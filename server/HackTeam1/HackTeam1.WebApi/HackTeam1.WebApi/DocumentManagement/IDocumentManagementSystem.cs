using HackTeam1.Entities;

namespace HackTeam1.WebApi.DocumentManagement
{
    public interface IDocumentManagementSystem
    {
        // Saves to storage & performs OCR on the document
        Document UploadDocument(byte[] content, string fileName);

        // Indexes & updates document in storage
        Document UpdateDocument(Document document);
    }
}