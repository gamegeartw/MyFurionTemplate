using Furion;
using Microsoft.Extensions.DependencyInjection;
using MyTemplate.EntityFramework.Core;

namespace MyTemplate.xUnitTest;

public class Startup:AppStartup
{
    public  void ConfigureServices(IServiceCollection services)
    {
        services.AddDatabaseAccessor(options=>
        {
            options.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
            options.AddDb<DefaultDbContext>();
        });
    }
}