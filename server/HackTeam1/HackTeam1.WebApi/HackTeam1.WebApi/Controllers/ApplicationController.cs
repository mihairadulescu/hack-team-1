using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using HackTeam1.Entities;
using HackTeam1.SearchEngine;
using HackTeam1.WebApi.DocumentManagement;

namespace HackTeam1.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class ApplicationController : ApiController
    {
        
        private readonly IElasticSearchEngine _elasticSearchEngine;
        private readonly IDocumentManagementSystem _documentManagementSystem;

        public ApplicationController()
        {
            _elasticSearchEngine = new ElasticSearchEngine(ConfigurationSettings.AppSettings["defaultIndex"]);
            _documentManagementSystem = new DocumentManagementSystem();

        }

        [HttpGet]
        [Route("documentSearch/{searchPhrase?}")]
        public IHttpActionResult GetDocumentsBySearchPhrase(string searchPhrase = "")
        {
            return this.Ok(_elasticSearchEngine.Search(searchPhrase).ToList());
        }


        [HttpGet]
        [Route("documentDetails/{fileName}")]
        public IHttpActionResult GetDocumentDetails(string fileName)
        {
            return this.Ok(_documentManagementSystem.GetWithDetails(fileName));
        }



        [HttpPost]
        [Route("documentUpload")]
        public async Task<IHttpActionResult> UploadDocument()
        {
            var currentDirectory = Path.GetTempPath();

            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var provider = new MultipartFormDataStreamProvider(currentDirectory);
            await Request.Content.ReadAsMultipartAsync(provider);

            foreach (var file in provider.FileData)
            {
                var fileName = file.Headers.ContentDisposition.FileName.Trim().Replace("\"", "");

                try
                {
                    var document = _documentManagementSystem.UploadDocument(File.ReadAllBytes(file.LocalFileName), fileName);
                    return Ok(document);
                }
                catch (Exception e)
                {
                    throw;
                }
            }

            return Ok();
        }


        [HttpPost]
        [Route("documentUpdate")]
        public IHttpActionResult UpdateDocument(Document document)
        {
            var documentResponse =  this._documentManagementSystem.UpdateDocument(document);
            return Ok(documentResponse);
        }
    }
}
