using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class ProductRepositoryAsync : RepositoryAsync<Product>, IProductRepositoryAsync
{
    public ProductRepositoryAsync(AppDbContext dbContext) : base(dbContext)
    {
    }
}

