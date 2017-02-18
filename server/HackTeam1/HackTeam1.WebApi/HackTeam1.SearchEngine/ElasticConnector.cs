using System;
using System.Collections.Generic;
using HackTeam1.Entities;
using Nest;

namespace HackTeam1.SearchEngine
{
    public class ElasticConnector
    {
        private readonly ElasticClient _client;

        public ElasticConnector()
        {
            var node = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(node);
            _client = new ElasticClient(settings);
         
        }

        public void Index(Document document)
        {
            
            _client.Index(document, idx => idx.Index("document"));
        }

        public void DeleteIndex(string indexName)
        {
            _client.DeleteIndex(indexName);
        }


        public Document GetData()
        {
            var aa =
                _client.Get<Document>(1, idx => idx.Index("document"));

            return aa.Source;
        }

        public IEnumerable<Document> SearchByTitle(string title)
        {
            var request = new SearchRequest
            {
                From = 0,
                Size = 10,
                Query = new TermQuery {Field = "title", Value = title}
            };

            var response = _client.Search<Document>(request);

            return response.Documents;

        }
    }
}