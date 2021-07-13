using AutoMapper;
using Project.Utility.Reflection;
using Project.WebApi.MapperProfile;

namespace Project.WebApi
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<MappingProfile>();
            });
        }
    }
}