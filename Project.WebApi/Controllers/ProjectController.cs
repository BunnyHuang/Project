using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Project.Core.Entities.Project;
using Project.Core.Module;

namespace Project.WebApi.Controllers
{
    [RoutePrefix("Project")]
    public class ProjectController : ApiController
    {
        IProjectModule _projectModule;

        public ProjectController(IProjectModule projectModule)
        {
            _projectModule = projectModule;
        }

        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_projectModule.GetAll());
        }

        [Route("{projectId}")]
        [HttpGet]
        public IHttpActionResult Get(Guid projectId)
        {
            return Ok(_projectModule.Get(projectId));
        }

        [Route("Insert")]
        [HttpPost]
        public IHttpActionResult Insert(string projectName)
        {
            return Ok(_projectModule.Insert(projectName));
        }

        [Route("Update")]
        [HttpPut]
        public IHttpActionResult Update(ProjectModel model)
        {
            return Ok(_projectModule.Update(model));
        }

        [Route("{projectId}")]
        [HttpDelete]
        public IHttpActionResult Delete(Guid projectId)
        {
            return Ok(_projectModule.Delete(projectId));
        }
    }
}