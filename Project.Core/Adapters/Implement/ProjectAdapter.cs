using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Project.Core._configs;
using Project.Core.Entities.Project;
using Project.Utility.DataAccess;

namespace Project.Core.Adapters.Implement
{
    public class ProjectAdapter : IProjectAdapter
    {
        public List<ProjectModel> GetAll()
        {
            return DapperHelper.QueryCollection<ProjectModel>(AppConnectionString.Project,
                StoreProcedures.Project.GetAll).ToList();
        }

        public ProjectModel Get(Guid projectId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ProjectId", projectId);

            return DapperHelper.Query<ProjectModel>(AppConnectionString.Project,
                StoreProcedures.Project.GetByProjectId, 
                parameters);
        }

        public bool Insert(ProjectModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ProjectId", model.ProjectId);
            parameters.Add("@ProjectName", model.ProjectName);

            return DapperHelper.Execute(AppConnectionString.Project,
                StoreProcedures.Project.Insert,
                parameters) > 0;
        }

        public bool Update(ProjectModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ProjectId", model.ProjectId);
            parameters.Add("@ProjectName", model.ProjectName);

            return DapperHelper.Execute(AppConnectionString.Project,
                StoreProcedures.Project.Update,
                parameters) > 0;
        }

        public bool Delete(Guid projectId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ProjectId", projectId);

            return DapperHelper.Execute(AppConnectionString.Project,
                StoreProcedures.Project.Delete,
                parameters) > 0;
        }
    }
}
