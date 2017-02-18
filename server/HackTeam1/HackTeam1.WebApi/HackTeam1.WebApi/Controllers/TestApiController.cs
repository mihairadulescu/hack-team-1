using System.Web.Http;

namespace HackTeam1.WebApi.Controllers
{
    public class TestApiController : ApiController
    {
        public IHttpActionResult Get()
        {
            return this.Ok("hello world");
        }
    
    }
}