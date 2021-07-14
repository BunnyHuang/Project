using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Adapters
{
    public class StoreProcedures
    {
        public struct Project
        {
            public const string GetAll = "usp_Project_GetAll";
            public const string GetByProjectId = "usp_Project_GetByProjectId";
            public const string GetMemberByProjectId = "usp_Project_GetMemberByProjectId";
            public const string GetByProjectName = "usp_Project_GetByProjectName";
            public const string Insert = "usp_Project_Insert";
            public const string Update = "usp_Project_Update";
            public const string Delete = "usp_Project_Delete";
        }
    }
}
