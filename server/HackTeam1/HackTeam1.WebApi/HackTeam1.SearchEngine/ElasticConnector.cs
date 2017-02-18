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


        public Document GetData()
        {
            return _client.Get<Document>(1, idx => idx.Index("document")).Source;
        }
    }
}