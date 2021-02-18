using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interface;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{  
    public class ProductService : IProductService
    {
        private readonly StorageDBContext _activeDirectoryDBContext;
        private readonly IMapper _mapper;

        public ProductService(StorageDBContext db, IMapper mapper)
        {
            _activeDirectoryDBContext = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> GetProduct(Guid idProduct)
        {
            var products = await _activeDirectoryDBContext.Products
                .FirstOrDefaultAsync(x => x.Id == idProduct);

            return _mapper.Map<ProductDto>(products);
        }

        public async Task<ProductDto[]> GetProducts(Guid idCategory)
        {
            var products = await _activeDirectoryDBContext.Products
                .Where(x => x.ParentCategoryId == idCategory)
                .ToArrayAsync();

            return _mapper.Map<ProductDto[]>(products);
        }

        public async Task<ProductDto> Update(ProductDto productDto)
        {
            var product = await _activeDirectoryDBContext.Products
                .FirstOrDefaultAsync(x =>x.Id == productDto.Id);

            if (product != null && product.Version == productDto.Version)
            {
                product.Name = productDto.Name;
                product.PriceSell = productDto.PriceSell;
                product.Version = Guid.NewGuid();

                await _activeDirectoryDBContext.SaveChangesAsync();

                return _mapper.Map<ProductDto>(product);
            }

            return null;
        }
    }
}
