using Furion;
using System.Reflection;

namespace MyTemplate.Web.Entry;

public class SingleFilePublish : ISingleFilePublish
{
    public Assembly[] IncludeAssemblies()
    {
        return Array.Empty<Assembly>();
    }

    public string[] IncludeAssemblyNames()
    {
        return new[]
        {
            "MyTemplate.Application",
            "MyTemplate.Core",
            "MyTemplate.EntityFramework.Core",
            "MyTemplate.Web.Core"
        };
    }
}