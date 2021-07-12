using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Project.Utility.Reflection;

namespace Project.WebApi
{
    public class AutofacConfig
    {
        public static void Bootstrapper()
        {
            var container = BuildContanier();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        /// <summary>
        /// 註冊相依注入介面
        /// </summary>
        /// <returns></returns>
        private static IContainer BuildContanier()
        {
            const string assemblyName = "Project";

            var builder = new ContainerBuilder();

            var registerAssemblies = AssemblyHelper.GetAssemblies(assemblyName);

            foreach (var assembly in registerAssemblies)
            {
                //一般相依註冊
                builder.RegisterAssemblyTypes(assembly)
                    .AsImplementedInterfaces();
            }

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            return builder.Build();
        }
    }
}