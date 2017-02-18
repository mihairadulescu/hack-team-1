using System;
using Nest;

namespace HackTeam1.SearchEngine
{
    public class ElasticConnector 
    {
        public ElasticConnector()
        {
            var node = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);
        }
    }
}