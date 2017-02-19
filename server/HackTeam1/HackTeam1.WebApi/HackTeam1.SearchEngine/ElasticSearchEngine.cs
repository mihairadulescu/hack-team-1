using System;
using System.Collections.Generic;
using System.Linq;
using Elasticsearch.Net;
using HackTeam1.Entities;
using Nest;

namespace HackTeam1.SearchEngine
{
    public class ElasticSearchEngine : IElasticSearchEngine
    {
        private readonly ElasticClient _client;

        public ElasticSearchEngine(string defaultIndex = "document")
        {
            var node = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(node).DefaultIndex(defaultIndex);
            _client = new ElasticClient(settings);

        }

        public void Index(Document document)
        {

            _client.Index(document, z=>z.Refresh(Refresh.True));
        }

        public IEnumerable<Document> Search(string searchPhrase)
        {

            var textField = Infer.Field<Document>(z => z.Text, -0.3);
            var categoryField = Infer.Field<Document>(z => z.Category, 1);
            var origFileName = Infer.Field<Document>(z => z.OriginalFileName, 1.2);
            var titleField = Infer.Field<Document>(z => z.Title, 1.5);

            var searchRequest = new SearchRequest<Document>()
            {
                Query = new MultiMatchQuery()
                {
                    Fields = new[] { textField, categoryField, origFileName, titleField },
                    Fuzziness = Fuzziness.EditDistance(int.MaxValue),
                    Query = searchPhrase
                },
            };
            var response = _client.Search<Document>(searchRequest).Hits;

            return response.OrderByDescending(z => z.Score).Select(p => p.Source);

        }

        public Document GetBy(string fileName)
        {
            return _client.Get<Document>(fileName).Source;
        }
    }
}