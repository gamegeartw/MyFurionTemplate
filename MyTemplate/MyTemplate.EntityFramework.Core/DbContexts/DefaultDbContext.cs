using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;

namespace MyTemplate.EntityFramework.Core;

[AppDbContext("MyTemplate", DbProvider.Sqlite)]
public class DefaultDbContext : AppDbContext<DefaultDbContext>
{
    public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
    {
    }
}