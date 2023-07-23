using EventSenderFuncApp.Commands.CustomerInformationManagement.Queries;
using EventSenderFuncApp.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace EventSenderFuncApp.Infrastructure
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ICustomerQuery, CustomerQuery>();
            return services;
        }
    }
}
