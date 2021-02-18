using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface ICategoryService
    {
        public Task<CategoryDto[]> GetCategories();
    }
}
