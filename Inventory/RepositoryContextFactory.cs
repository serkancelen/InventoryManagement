using Microsoft.EntityFrameworkCore;
using Repositories.EFCore;

namespace Inventory
{
    public class RepositoryContextFactory
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                prj => prj.MigrationsAssembly("AssociationWebApp"));

            return new RepositoryContext(builder.Options);
        }
    }
}
