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

        public List<ProjectModel> Get()
        {
            return _projectAdapter.Get();
        }
    }
}
