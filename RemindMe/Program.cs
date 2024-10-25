using Application;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using HealthChecks.UI.Client;
using HealthChecks.UI.Configuration;
using IdGen.DependencyInjection;
using Infrastructure;
using Infrastructure.Persistence.Configuration;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

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

            builder.Services
                .AddHealthChecks()
                .AddSqlServer(connectionString, healthQuery: "select 1", name: "SQL Server", failureStatus: HealthStatus.Unhealthy, tags: new[] { "Feedback", "Database" });

            builder.Services
                .AddHealthChecksUI(opt =>
                {
                    opt.SetEvaluationTimeInSeconds(10);   
                    opt.MaximumHistoryEntriesPerEndpoint(60);    
                    opt.SetApiMaxActiveRequests(1);   
                    opt.AddHealthCheckEndpoint("RemindMe", "/api/health");  
                })
                .AddInMemoryStorage();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();

            app.MapHealthChecks("/api/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.UseHealthChecksUI(delegate (Options options)
            {
                options.UIPath = "/healthcheck-ui";
            });

            app.Run();
        }

        private static void RegisterAutofacModules(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacApplicationModule());
            builder.RegisterModule(new AutofacInfrastructureModule());
        }
    }
}
