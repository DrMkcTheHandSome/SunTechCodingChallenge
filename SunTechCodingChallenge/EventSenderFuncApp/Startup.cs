using EventSenderFuncApp.Infrastructure;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;


[assembly: FunctionsStartup(typeof(EventSenderFuncApp.Startup))]
namespace EventSenderFuncApp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Startup).Assembly))
                .AddInfrastructure();
        }
    }
}
