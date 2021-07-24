using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ContainerManagement.Service
{
    public static class DependencyInjection
    {
        public static void AddMediatorCQRS(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
