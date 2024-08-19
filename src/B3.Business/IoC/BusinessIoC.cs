using B3.Business.Contracts.UseCases.CDB;
using B3.Business.UseCases.CDB;
using Microsoft.Extensions.DependencyInjection;

namespace B3.Business.IoC
{
    public static class BusinessIoC
    {        
        public static IServiceCollection AddBusinessIoC(this IServiceCollection services)
        {
            services.AddScoped<ICDBUseCase, CDBUseCase>();         

            return services;
        }        
    }
}
