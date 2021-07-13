using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Project.Core.Entities.Project;
using Project.Core.Module;
using Project.WebApi.Models;

namespace Project.WebApi.Controllers
{
    [RoutePrefix("Project")]
    public class ProjectController : ApiBaseController
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
            var all = Mapper.Map<List<ProjectViewModel>>(_projectModule.GetAll());
            return Ok(all);
        }

        [Route("{projectId}")]
        [HttpGet]
        public IHttpActionResult Get(Guid projectId)
        {
            var model = Mapper.Map<ProjectViewModel>(_projectModule.Get(projectId));
            return Ok(model);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Insert(string projectName)
        {
            return Ok(_projectModule.Insert(projectName));
        }

        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(ProjectViewModel vm)
        {
            var model = Mapper.Map<ProjectModel>(vm);
            return Ok(_projectModule.Update(model));
        }

        [Route("{projectId}")]
        [HttpDelete]
        public IHttpActionResult Delete(Guid projectId)
        {
            return Ok(_projectModule.Delete(projectId));
        }

        [Route("ExceptionTest")]
        [HttpGet]
        public IHttpActionResult ExceptionTest()
        {
            throw new Exception();
        }
    }
}