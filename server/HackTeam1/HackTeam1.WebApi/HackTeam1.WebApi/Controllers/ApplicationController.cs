using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using HackTeam1.Entities;

namespace HackTeam1.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class ApplicationController : ApiController
    {

        [HttpGet]
        [Route("documentSearch/{searchPhrase?}")]
        public List<Document> GetDocumentsBySearchPhrase(string searchPhrase)
        {
            var result = new List<Document>();

            result.Add(new Document()
            {
                Title = "Doc1",
                Category = "Cat1",
                CreatedDate = DateTime.Now,
                Text = "text 1"
            });

            result.Add(new Document()
            {
                Title = "Doc2",
                Category = "Cat2",
                CreatedDate = DateTime.Now,
                Text = "text 2"
            });

            result.Add(new Document()
            {
                Title = "Doc3",
                Category = "Cat3",
                CreatedDate = DateTime.Now,
                Text = "text 3"
            });

            return result;
        }



        [HttpGet]
        [Route("documentDetails/{fileName}")]
        public Document GetDocumentDetails(string fileName)
        {
            var result = new Document()
            {
                Title = "Doc1 details",
                Category = "Cat1 details",
                CreatedDate = DateTime.Now,
                Text = "text 1"
            };

            return result;
        }



        [HttpPost]
        [Route("documentUpload")]
        public async Task<IHttpActionResult> UploadDocument()
        {
            var finalDirectory = @"D:\NerdsHack";
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

                if (File.Exists(Path.Combine(finalDirectory, fileName)))
                {
                    File.Delete(Path.Combine(finalDirectory, fileName));
                }
                    
                File.Copy(file.LocalFileName, Path.Combine(finalDirectory, fileName));

                return Ok();
            }

            return Ok();
        }




        [HttpPost]
        [Route("documentUpdate")]
        public IHttpActionResult UpdateDocument(Document document)
        {
            return Ok();
        }
    }
}
