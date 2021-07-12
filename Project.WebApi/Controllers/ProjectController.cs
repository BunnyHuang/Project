using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Project.Core.Module;

namespace Project.WebApi.Controllers
{
    [RoutePrefix("Project/Api")]
    public class ProjectController : ApiController
    {
        IProjectModule _projectModule;

        public ProjectController(IProjectModule projectModule)
        {
            _projectModule = projectModule;
        }

        [Route("Get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_projectModule.Get());
        }
    }
}