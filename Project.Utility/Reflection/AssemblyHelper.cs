using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Project.Utility.Reflection
{
    public class AssemblyHelper
    {
        /// <summary>
        /// 取得全部的 Assembly
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <returns></returns>
        public static IEnumerable<Assembly> GetAssemblies(string assemblyName)
        {
            return GetAssemblies(assemblyName, new string[] { });
        }

        /// <summary>
        /// 取得全部的 Assembly 
        /// </summary>
        /// <param name="assemblyName">Assembly 名稱</param>
        /// <param name="excludedName">排除名稱</param>
        /// <returns></returns>
        public static IEnumerable<Assembly> GetAssemblies(string assemblyName, params string[] excludedName)
        {
            var assemblyNames = new List<string>();
            var dependencies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(lib => lib.FullName == assemblyName || lib.FullName.StartsWith(assemblyName));

            foreach (var library in dependencies)
            {
                assemblyNames.Add(library.FullName);
                assemblyNames.AddRange(library.GetReferencedAssemblies()
                    .Where(lib => lib.FullName == assemblyName || lib.FullName.StartsWith(assemblyName))
                    .Select(lib => lib.FullName));
            }

            foreach (var name in assemblyNames.Distinct())
            {
                if (excludedName.Any(e => string.Compare(name, e, true) > 0)) continue;

                yield return Assembly.Load(new AssemblyName(name));
            }

        }
    }
}
