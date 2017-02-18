using HackTeam1.Entities;

namespace HackTeam1.OcrSystem
{
    public interface IDocumentOcr
    {
        Document PerformOcr(Document document);
    }
}
