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
            public const string Insert = "usp_Project_Insert";
            public const string Update = "usp_Project_Update";
            public const string Delete = "usp_Project_Delete";
        }
    }
}
