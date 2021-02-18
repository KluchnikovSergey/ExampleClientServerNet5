using AutoMapper;
using BusinessLogicLayer.DTO;
using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleHost.MappingProfile
{
    public class DbSetToDTO : Profile
    {
        public DbSetToDTO()
        {
            CreateMap<Category, string>().ConvertUsing(new ContainerToStringConverter());

            CreateMap<Category, CategoryDto>()
                .ForMember(entity => entity.Id, o => o.MapFrom(dto => dto.Id))
                .ForMember(entity => entity.ParentContainerId, o => o.MapFrom(dto => dto.ParentCategoryId))
                .ForMember(entity => entity.ParentContainerName, o => o.MapFrom(dto => dto.parentCategory));

            CreateMap<Product, ProductDto>()
               .ForMember(entity => entity.Id, o => o.MapFrom(dto => dto.Id))
               .ForMember(entity => entity.ParentContainerId, o => o.MapFrom(dto => dto.ParentCategoryId))
               .ForMember(entity => entity.ParentContainerName, o => o.MapFrom(dto => dto.Category))
               .ForMember(entity => entity.Version, o =>o.MapFrom(dto => dto.Version));
        }
    }

    public class ContainerToStringConverter : ITypeConverter<DataAccessLayer.Entity.Category, string>
    {
        public string Convert(Category source, string destination, ResolutionContext context)
        {
            return source != null ? source.Name : "";
        }
    }
}
