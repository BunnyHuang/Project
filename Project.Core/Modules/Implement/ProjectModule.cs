using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Core.Adapters;
using Project.Core.Entities.Project;

namespace Project.Core.Module.Implement
{
    public class ProjectModule : IProjectModule
    {
        IProjectAdapter _projectAdapter;

        public ProjectModule(IProjectAdapter projectAdapter)
        {
            _projectAdapter = projectAdapter;
        }

        public List<ProjectModel> GetAll()
        {
            return _projectAdapter.GetAll();
        }

        public ProjectModel Get(Guid projectId)
        {
            return _projectAdapter.Get(projectId);
        }

        public bool Insert(string projectName)
        {
            var model = new ProjectModel()
            {
                ProjectId = Guid.NewGuid(),
                ProjectName = projectName
            };

            return _projectAdapter.Insert(model);
        }

        public bool Update(ProjectModel model)
        {
            return _projectAdapter.Update(model);
        }

        public bool Delete(Guid projectId)
        {
            return _projectAdapter.Delete(projectId);
        }
    }
}
