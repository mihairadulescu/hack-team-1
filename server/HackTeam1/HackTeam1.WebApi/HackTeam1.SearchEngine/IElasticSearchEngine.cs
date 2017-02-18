using System.Collections.Generic;
using HackTeam1.Entities;

namespace HackTeam1.SearchEngine
{
    public interface IElasticSearchEngine
    {
        void Index(Document document);
        IEnumerable<Document> Search(string searchPhrase);
    }
}