using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface IProductService
    {
        public Task<ProductDto> GetProduct(Guid idProduct);

        public Task<ProductDto[]> GetProducts(Guid idCategory);

        public Task<ProductDto> Update(ProductDto productDto);
    }
}
