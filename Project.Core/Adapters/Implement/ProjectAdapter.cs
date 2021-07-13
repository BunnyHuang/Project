using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Core._configs;
using Project.Core.Entities.Project;
using Project.Utility.DataAccess;

namespace Project.Core.Adapters.Implement
{
    public class ProjectAdapter : IProjectAdapter
    {
        public List<ProjectModel> Get()
        {
            return DapperHelper.QueryCollection<ProjectModel>(AppConnectionString.Project,
                StoreProcedures.Project.GetAll).ToList();
        }
    }
}
