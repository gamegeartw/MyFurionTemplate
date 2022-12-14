﻿using Furion;
using Microsoft.Extensions.DependencyInjection;

namespace MyTemplate.EntityFramework.Core;

public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDatabaseAccessor(options => { options.AddDbPool<DefaultDbContext>(); },
            "MyTemplate.Database.Migrations");
    }
}