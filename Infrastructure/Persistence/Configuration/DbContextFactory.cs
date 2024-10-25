using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace Infrastructure.Persistence.Configuration
{
    public class DbContextFactory : IDesignTimeDbContextFactory<RemindMeDbContext>
    {
        public RemindMeDbContext CreateDbContext(string[] args)
        {
            //Add-Migration Init -Context RemindMeDbContext -OutputDir Persistence\Configuration\Migrations
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Path.GetFullPath(@"../RemindMe/"))
                 .AddJsonFile("appsettings.json")
                 .AddJsonFile("appsettings.Development.json", optional: false)
                 .Build();

            var optionsBuilder = new DbContextOptionsBuilder<RemindMeDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("remindMe"));

            return new RemindMeDbContext(optionsBuilder.Options);
        }
    }
}
