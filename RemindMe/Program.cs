using Application;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using IdGen.DependencyInjection;
using Infrastructure;
using Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace RemindMe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host
                .UseServiceProviderFactory<ContainerBuilder>(new AutofacServiceProviderFactory())
                .ConfigureContainer((Action<ContainerBuilder>)(builder =>
                {
                    RegisterAutofacModules(builder);
                }));

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

#warning move to apsettings
            builder.Services.AddIdGen(11);
            var connectionString = builder.Configuration.GetConnectionString("remindMe");
            builder.Services.AddDbContext<RemindMeDbContext>(options => options.UseSqlServer(connectionString));

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();

            app.Run();
        }

        private static void RegisterAutofacModules(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacApplicationModule());
            builder.RegisterModule(new AutofacInfrastructureModule());
        }
    }
}
