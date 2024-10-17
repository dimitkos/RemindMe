using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace Infrastructure.Persistence.Configuration
{
    public class DbContextFactory : IDesignTimeDbContextFactory<RemindMeDbContext>
    {
        public RemindMeDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RemindMeDbContext>();

            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Path.GetFullPath(@"../Api/"))
                 .AddJsonFile("appsettings.json")
            //.AddJsonFile("appsettings.Development.json", optional: false)
                 .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("remindMe"));

            return new RemindMeDbContext(optionsBuilder.Options);
        }
    }
}
