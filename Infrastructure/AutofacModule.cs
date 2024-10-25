using Application.Services.Infrastructure;
using Application.Services.Infrastructure.Reminders;
using Application.Services.Infrastructure.Users;
using Autofac;
using Infrastructure.Persistence.Commands.Reminders;
using Infrastructure.Persistence.Commands.Users;
using System.Reflection;

namespace Infrastructure
{
    public class AutofacInfrastructureModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var thisAssembly = Assembly.GetExecutingAssembly();

            builder
                .RegisterType<UserCommandRepository>()
                .As<IUserCommandRepository>()
                .SingleInstance();

            builder
                .RegisterType<ReminderCommandRepository>()
                .As<IReminderCommandRepository>()
                .SingleInstance();

            builder
                .RegisterAssemblyTypes(thisAssembly)
                .AsClosedTypesOf(typeof(IDomainRetrievalRepository<,>))
                .SingleInstance();
        }
    }
}
