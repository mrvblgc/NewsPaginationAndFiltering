using AutoMapper;
using BLL.ServicesModel;
using DAL.JsonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryJsonModel, CategoryDTO>();
            CreateMap<DataListJsonModel, DataListDTO>();
            CreateMap<ItemListJsonModel, ItemListDTO>();
            CreateMap<NewsDataJsonModel, NewsDataDTO>();
            CreateMap<PaginatedNewsViewJsonModel, PaginatedNewsDTO>();
            CreateMap<ItemListDTO, ItemListJsonModel>();
            CreateMap<NewsDetailJsonModel, NewsDetailDTO>();
            CreateMap<DetailCategoryJsonModel, DetailCategoryDTO>();
        }
    }
}
