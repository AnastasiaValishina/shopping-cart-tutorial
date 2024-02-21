﻿using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Repositories.Contracts;

namespace ShopOnline.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopOnlineDbContext _shopOnlineDbContext;
        public ProductRepository(ShopOnlineDbContext shopOnlineDbContext)
        {
            _shopOnlineDbContext = shopOnlineDbContext;
        } 

        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            Console.WriteLine("ProductRepository.GetCategories");
            var categories = await _shopOnlineDbContext.ProductCategories.ToListAsync();
            return categories;
        }

        public Task<ProductCategory> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            Console.WriteLine("ProductRepository.GetItems");
            var products = await _shopOnlineDbContext.Products.ToListAsync();
            return products;
        }
    }
}
