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
    public class CategoryService : ICategoryService
    {   
        private readonly StorageDBContext _activeDirectoryDBContext;
        private readonly IMapper _mapper;

        public CategoryService(StorageDBContext db, IMapper mapper)
        {
            _activeDirectoryDBContext = db;
            _mapper = mapper;
        }

        public async Task<CategoryDto[]> GetCategories()
        {
            var categories = await _activeDirectoryDBContext.Categories
                .Include(x => x.parentCategory)
                .ToArrayAsync();

            return _mapper.Map<CategoryDto[]>(categories);
        }
    }
}
