using Application.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceExtensions
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseInMemoryDatabase("productDb");
        });

        services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
        services.AddTransient<IProductRepositoryAsync, ProductRepositoryAsync>();
    }
}

